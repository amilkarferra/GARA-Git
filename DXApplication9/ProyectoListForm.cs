using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DXApplication9.ReportesSistema;

//using XtraMessageBox = DevExpress.DXCore.Controls.XtraEditors.XtraMessageBox;


namespace DXApplication9
{
    public partial class ProyectoListForm : BaseXtraForm
    {
        NegocioDataContext AGlobalDataContext = (new NegocioDataContext());
        public ProyectoListForm()
        {
            try
            {
                try
                {
                    SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);
                }
                catch (Exception)
                {

                    SplashScreenManager.CloseForm();
                    SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);

                }

                InitializeComponent();
                PopulaAnnoCheckBox();
                Pais_repositoryItemLookUpEdit.DataSource = AGlobalDataContext.Paises;
                agrupacionBindingSource.DataSource = AGlobalDataContext.Agrupacion;
                empresariosBindingSource.DataSource = AGlobalDataContext.Empresarios;
                TipoProyecto_repositoryItemLookUpEdit.DataSource =
                    Enumerados.ListaDeEnumerados(typeof (Enumerados.TipoProyecto));
                Estado_repositoryItemLookUpEdit.DataSource = Enumerados.ListaDeEnumerados(typeof(Enumerados.EstadoProyecto));
                Estado_repositoryItemLookUpEdit.DisplayMember = "Tipo";
                Estado_repositoryItemLookUpEdit.ValueMember = "Valor";
                PopulaProyectos();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza la tabla de proyectos
        /// </summary>
        private void PopulaProyectos()
        {
            AGlobalDataContext = new NegocioDataContext();
            Proyectos_bindingSource.DataSource = AGlobalDataContext.Proyectos.OrderBy(c => c.Consecutivo);

        }

        private void ProyectoForm_Load(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch 
            {
                
               //donothing
            }
        }

        //private void gridControl1_DoubleClick(object sender, EventArgs e)
        //{
        //    if (gridView1.GetSelectedRows().Count() > 0)
        //    {
        //        var _SelectedRow = gridView1.GetSelectedRows()[0];
        //        Proyectos _ProyectoEditar = (Proyectos) gridView1.GetRow(_SelectedRow);
        //        NewProyectForm _NewProyectForm = new NewProyectForm(_ProyectoEditar);
        //        _NewProyectForm.CausaDeProyectoMemoEdit.Enabled = true;
        //       if (_NewProyectForm.ShowDialog() == DialogResult.OK)
        //        {
        //            gridControl1.Refresh();
        //        }


        //    }
        //}


        private void Report_repositoryItemButtonEdit_Click(object sender, EventArgs e)
        {


        }

        private void Edit_repositoryItemButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (Proyectos_gridView.GetSelectedRows().Count() > 0)
            {
                var selectedRow = Proyectos_gridView.GetSelectedRows()[0];
                Proyectos proyectoEditar = AGlobalDataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == ((Proyectos)Proyectos_gridView.GetRow(selectedRow)).ProyectoID);
                if (proyectoEditar == null) return;
                NewProyectForm newProyectForm = new NewProyectForm(proyectoEditar,AGlobalDataContext)
                {
                    CausaDeProyectoMemoEdit = { Enabled = true }
                };
                if (newProyectForm.ShowDialog() == DialogResult.OK)
                {
                    var main = (MainForm)MdiParent;
                    main.MuestraProyectos();
                    PopulaProyectos();
                }


            }
        }

        private void AddNuevoProyecto()
        {
            NewProyectForm newProyectForm = new NewProyectForm();
            if (newProyectForm.ShowDialog() != DialogResult.Abort)
            {
                PopulaProyectos();
                Proyectos_gridView.MoveLastVisible();
            }

        }

        private void Delete_repositoryItemButtonEdit_Click(object sender, EventArgs e)
        {
            if (Proyectos_gridView.GetSelectedRows().Count() > 0)
            {
                var selectedRow = Proyectos_gridView.GetSelectedRows()[0];
                Proyectos proyectoEditar = (Proyectos)Proyectos_gridView.GetRow(selectedRow);
                //if ((new DialogoForm("Esta Seguro que eliminará el Proyecto")).ShowDialog() == DialogResult.OK)
                //{
                //    Proyectos_gridView.DeleteSelectedRows(); _GlobalDataContext.Proyectos.DeleteOnSubmit(proyectoEditar);
                //    _GlobalDataContext.SubmitChanges();
                //    Proyectos_gridControl.Refresh();
                //}


            }
        }

        private void Report_repositoryItemButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Proyectos proyectos = (Proyectos)(Proyectos_gridView.GetRow(Proyectos_gridView.GetSelectedRows()[0]));
            if (e.Button.IsLeft)
            {
                if (proyectos.ParticipantesDeProyectos.Count > 0)
                {
                    proyectos.MostrarReporteFundamentacion();
                }
                else
                {
                    MessageBox.Show("Debe insertar al menos un integrante al proyecto");
                }
            }
            else
            {
                if (proyectos.TipoProyecto == Enumerados.TipoProyecto.TramiteMigratorio.ToString())
                {
                    MessageBox.Show("El Tramite Migratorio no necesita datos Económicos", "No Existe",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                proyectos.MostrarReporteProyectoEconomico();
            }
        }


        public void MuestraReporteDeProyecto()
        {
            var proyecto = GetSelectedProyecto();
            proyecto.MuestraReporteTablaParticipantes();
        }

        public Proyectos GetSelectedProyecto()
        {
            Proyectos proyectos = (Proyectos)(Proyectos_gridView.GetRow(Proyectos_gridView.GetSelectedRows()[0]));
            return proyectos;
        }

        private void ProyectoListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm main = (MainForm)MdiParent;
            main.CerrandoListaDeProyectos();
        }

        private void Empresario_repositoryItemLookUpEdit_BeforeShowMenu(object sender, DevExpress.XtraEditors.Controls.BeforeShowMenuEventArgs e)
        {
            Empresario_repositoryItemLookUpEdit.DataSource = AGlobalDataContext.Empresarios;
            Empresario_repositoryItemLookUpEdit.ForceInitialize();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            //var gridView = Proyectos_gridView;
            //Point clickPoint = Proyectos_gridControl.PointToClient(MousePosition);
            //var hitInfo = gridView.CalcHitInfo(clickPoint);
            //if (hitInfo.InRowCell)
            //{
            //    GridColumn column = hitInfo.Column;
            //    //MessageBox.Show(column.Name + " "+rowHandle);
            //    if (column.Name == "EditgridColumn")
            //    {


            //        if (Proyectos_gridView.GetSelectedRows().Count() > 0)
            //        {
            //            var _SelectedRow = Proyectos_gridView.GetSelectedRows()[0];
            //            var _proyecto = (Proyectos)e.
            //            Proyectos _ProyectoEditar = _GlobalDataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == ((Proyectos) Proyectos_gridView.GetRow(_SelectedRow)).ProyectoID);
            //            if (_ProyectoEditar == null) return;
            //            NewProyectForm _NewProyectForm = new NewProyectForm(_ProyectoEditar);
            //            _NewProyectForm.CausaDeProyectoMemoEdit.Enabled = true;
            //            if (_NewProyectForm.ShowDialog() == DialogResult.OK)
            //            {
            //                Proyectos_bindingSource.DataSource = new NegocioDataContext().Proyectos;
            //            }


            //        }

            //    }
            //    else if (column.Name == Delete_gridColumn.Name)
            //    {
            //        if (Proyectos_gridView.GetSelectedRows().Count() > 0)
            //        {
            //            var _SelectedRow = Proyectos_gridView.GetSelectedRows()[0];
            //            Proyectos _ProyectoEditar = (Proyectos)Proyectos_gridView.GetRow(_SelectedRow);
            //            if ((new DialogoForm("Esta Seguro que eliminará el Proyecto")).ShowDialog() == DialogResult.OK)
            //            {
            //                Proyectos_gridView.DeleteSelectedRows(); _GlobalDataContext.Proyectos.DeleteOnSubmit(_ProyectoEditar);
            //                _GlobalDataContext.SubmitChanges();
            //                Proyectos_gridControl.Refresh();
            //            }


            //        }
            //    }
            //}
        }


        public void ManejaBotonesDeReportesDeProyecto()
        {
            var proyectoSeleccionado = (Proyectos)Proyectos_gridView.GetRow(Proyectos_gridView.GetSelectedRows()[0]);
            if (proyectoSeleccionado != null)
            {
                ICMReport_barButtonItem.Enabled =ICM_barSubItem.Enabled = Repert_barButtonItem.Enabled =ProyEco_barButtonItem.Enabled = !proyectoSeleccionado.EsTramiteMigratorio;

                bool hayTramitesMigratorios =  proyectoSeleccionado.ParticipantesDeProyectos.Any(
                                                                      c => c.TipoTramiteMigratorio != null);

                FundHabilitacionPasaporte_barButtonItem.Enabled = (proyectoSeleccionado.EsComercial ||
                                                                   proyectoSeleccionado.EsPromocional) &&
                                                                  hayTramitesMigratorios;


            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ManejaBotonesDeReportesDeProyecto();
            EditProyect_barButtonItem.Enabled = Proyectos_gridView.GetSelectedRows().Any();
        }

        private void Proyectos_gridView_Click(object sender, EventArgs e)
        {
            int rowHandle;
            var column = GetClickedInformation(Proyectos_gridControl, Proyectos_gridView, out rowHandle);
            if (column == null) return;
            //if (column == EditgridColumn)
            //{


            //    if (Proyectos_gridView.GetRow(rowHandle) != null)
            //    {
            //        var proyecto = (Proyectos)Proyectos_gridView.GetRow(rowHandle);
            //        if (proyecto == null) return;
            //        NewProyectForm newProyectForm = new NewProyectForm(proyecto, _GlobalDataContext)
            //        {
            //            CausaDeProyectoMemoEdit = { Enabled = true }
            //        };
            //        if (newProyectForm.ShowDialog() == DialogResult.OK)
            //        {
            //            PopulaProyectos();
            //        }


            //    }

            //}
            //else if (column.Name == Delete_gridColumn.Name)
            //{
            //    if (Proyectos_gridView.GetSelectedRows().Count() > 0)
            //    {
            //        var selectedRow = Proyectos_gridView.GetSelectedRows()[0];
            //        Proyectos proyectoEditar = (Proyectos)Proyectos_gridView.GetRow(selectedRow);
            //        if ((new DialogoForm("Esta Seguro que eliminará el Proyecto")).ShowDialog() == DialogResult.OK)
            //        {
            //            Proyectos_gridView.DeleteSelectedRows(); _GlobalDataContext.Proyectos.DeleteOnSubmit(proyectoEditar);
            //            _GlobalDataContext.SubmitChanges();
            //            Proyectos_gridControl.Refresh();
            //        }


            //    }
            //}
        }

        private void ProyectoHabilitacionPasaporte_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetSelectedProyecto().MostrarReporteFundamentacion(true);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SplashScreenManager.ShowForm(MdiParent, typeof(Reportes_WaitForm), true, true);
            // var _FormularioDeProyectos = (ProyectoListForm)ActiveMdiChild;
            Proyectos proyecto = GetSelectedProyecto();

            if (proyecto.EsTramiteMigratorio)
            {
                MessageBox.Show("No Aplicable", "No Aplicable", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            proyecto.MostrarReporteProyectoInstituto();

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           GetSelectedProyecto().MostrarReporteFundamentacion();
        }

        private void NuevoProyecto_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddNuevoProyecto();
        }

        private void Proyectos_gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            EditProyect_barButtonItem.Enabled = Proyectos_gridView.GetSelectedRows().Any();
        }

        private void EditProyect_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var proyecto = GetSelectedProyecto();
            if (proyecto == null) return;
            NewProyectForm newProyectForm = new NewProyectForm(proyecto, AGlobalDataContext);
            if (newProyectForm.ShowDialog() == DialogResult.OK)
            {
                PopulaProyectos();
            }
        }

        private void ProyEco_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!GetSelectedProyecto().Presentacion.Any())
            {
                XtraMessageBox.Show("El proyecto no tiene presentación por lo que no se puede mostrar este reporte",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            GetSelectedProyecto().MostrarReporteProyectoEconomico();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GetSelectedProyecto().MuestraReporteTablaDeCertifico();
            }
            catch (Exception)
            {
                
                XtraMessageBox.Show("El proyecto no tiene integrantes ",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Repert_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetSelectedProyecto().GetReporteRepertorio().ShowPreviewDialog();
        }

        private void ReportParticipantes_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetSelectedProyecto().MuestraReporteTablaParticipantes();
        }

        private void Proyectos_gridView_DoubleClick(object sender, EventArgs e)
        {
            int rowHandle;
            var column = GetClickedInformation(Proyectos_gridControl, Proyectos_gridView, out rowHandle);
            var proyecto = (Proyectos)Proyectos_gridView.GetRow(rowHandle);
            if (proyecto == null) return;
            if (proyecto.TipoProyectoId!=Convert.ToInt32(Enumerados.TipoProyecto.ProyectoNacional))
            {
                NewProyectForm newProyectForm = new NewProyectForm(proyecto, AGlobalDataContext);
                if (newProyectForm.ShowDialog() == DialogResult.OK)
                {
                    AGlobalDataContext = new NegocioDataContext();
                    PopulaProyectos();
                }
            }
            else 
            {
                PopupProyectoNacionalXtraForm newPopup = new PopupProyectoNacionalXtraForm(proyecto,AGlobalDataContext);
                if (newPopup.ShowDialog() == DialogResult.OK)
                {
                    AGlobalDataContext = new NegocioDataContext();
                    PopulaProyectos();
                }
            }
            
            
        }

        private void ActualizarDatos_simpleButton_Click(object sender, EventArgs e)
        {
           // AGlobalDataContext = new NegocioDataContext();
            PopulaProyectos();
            Utils.MuestraInformacion("DATOS ACTUALIZADOS. <br><i>Los datos de los participantes se excluyen de esta actualización");
        }

        private void NuevoProyFront_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopupProyectoNacionalXtraForm xtraform = new PopupProyectoNacionalXtraForm();
            if (xtraform.ShowDialog() == DialogResult.OK)
            {
                PopulaProyectos();
            }
        }

        private void Cerrar_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var proyecto = GetSelectedProyecto();
            if(proyecto==null)return;
            var popup = new PopupCierreProyectoXtraForm(proyecto);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                PopulaProyectos();}
        }

        private void SetEstadoProyecto(Enumerados.EstadoProyecto estadoProyecto)
        {
            var proyecto = GetSelectedProyecto();
            if (proyecto == null) return;
            PopupSetEstados_XtraUserControlcs popup = new PopupSetEstados_XtraUserControlcs();
            popup.Estado_lookUpEdit.Properties.DataSource =
                Enumerados.ListaDeEnumerados(typeof(Enumerados.EstadoProyecto));

            if (XtraDialog.Show(popup) == DialogResult.OK)
            {
                AGlobalDataContext = new NegocioDataContext();
                proyecto = AGlobalDataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == proyecto.ProyectoID);
                proyecto.EstadoProyecto = (int) estadoProyecto;
                AGlobalDataContext.SubmitChanges();
                PopulaProyectos();
            }
        }

        private void Cancelar_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetEstadoProyecto(Enumerados.EstadoProyecto.Cancelado);
        }

        private void Descancelar_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var proyecto = GetSelectedProyecto();
            proyecto.SetEstado();
            PopulaProyectos();}

        private void ConsPolitica_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var proyecto = GetSelectedProyecto();
            var reporte = new ConsultaPoliticaXtraReport(proyecto);
            reporte.CreateDocument();
            var anexo1 = new ConsultaPoliticaAnexoIntegrantes(proyecto);
            anexo1.CreateDocument();
            var anexo2 = new ConsultaPoliticaAnexo2XtraReport(proyecto);
            anexo2.CreateDocument();
            reporte.Pages.AddRange(anexo1.Pages);
            reporte.Pages.AddRange(anexo2.Pages);
            reporte.ShowRibbonPreviewDialog();
        }
        private void FiltraAnno()
        {
            string cadenaDeFiltrado = GetCadenaDeFiltradoPorAnno();
            if (cadenaDeFiltrado == String.Empty) return;
            Proyectos_gridView.Columns["Anno"].FilterInfo = new ColumnFilterInfo(ColumnFilterType.Value,
                ConfiguracionGeneral.Anno, cadenaDeFiltrado);
        }

        private string GetCadenaDeFiltradoPorAnno()
        {
            string cadenaFiltro = "";
            var items = Annos_checkedComboBoxEdit.Properties.Items.Where(c => c.CheckState == CheckState.Checked);
            if (!items.Any()) return String.Empty; foreach (var item in items)
            {
                cadenaFiltro += string.Format("[Anno]='{0}' OR", item.Value);
            }
            //Elimino el ultimo OR

            return cadenaFiltro.Right(2);
        }

        private void Annos_checkedComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            FiltraAnno();
        }

        private void PopulaAnnoCheckBox()
        {
            var annos = AGlobalDataContext.OrdenDeTrabajo.DistinctBy(c => c.Anno).Select(c => c.Anno);
            foreach (var anno in annos)
            {
                Annos_checkedComboBoxEdit.Properties.Items.Add(anno,
                    anno == ConfiguracionGeneral.Anno ? CheckState.Checked : CheckState.Unchecked);
            }
            // Annos_checkedComboBoxEdit.Properties.DataSource = annos;
            //Annos_checkedComboBoxEdit.

        }

        


    }
}