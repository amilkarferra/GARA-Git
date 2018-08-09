using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DevExpress.Data.PLinq.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DXApplication9.UserControls;

namespace DXApplication9
{
    public partial class EditIntegranteXtraForm : XtraForm
    {
        public bool Propiedad = true;
        NegocioDataContext AGlobalDataContext;
        private int AArtistaId;
        private int AAgrupacionId;
        private int artistaId = 0;
        private AgrupacionDeArtista AAgrupacionDeArtista;
        private Agrupacion AGlobalAgrupacion;
        private class SmallMunicipioProvincia
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public int ParentId { get; set; }

        }
        public EditIntegranteXtraForm(int agrupacionId, AgrupacionDeArtista anAgrupacionDeArtista = null, NegocioDataContext globalDataContext = null)
        {
            AGlobalDataContext = globalDataContext ?? new NegocioDataContext();
            Artista artista = null; AGlobalAgrupacion = AGlobalDataContext.Agrupacion.FirstOrDefault(c => c.AgrupacionID == agrupacionId);
            InitializeComponent();
            TipoVinculo_lookUpEdit.Properties.DataSource = Enumerados.ListaDeEnumerados(typeof(Enumerados.TipoVinculoDeArtista));
            TipoVinculo_lookUpEdit.Properties.ValueMember = "Valor";
            TipoVinculo_lookUpEdit.Properties.DisplayMember = "Tipo";
            Municipio_treeListLookUpEdit1TreeList.DataSource = GetListaDeMunicipios();
            escalaSalarialBindingSource.DataSource = AGlobalDataContext.EscalaSalarial;
            //PopulaMunicipiosTreeList();
            // municipioBindingSource.DataSource = GetListaDeMunicipios();
            AAgrupacionId = agrupacionId;


            AAgrupacionDeArtista = anAgrupacionDeArtista;
            if (anAgrupacionDeArtista != null)
            {
                AArtistaId = anAgrupacionDeArtista.ArtistaId;
                artista = anAgrupacionDeArtista.Artista;

                #region Datos personales
                #region Foto
                if (artista.Foto != null)
                {
                    MemoryStream ms = new MemoryStream(artista.Foto);
                    Bitmap imagenBitmap = new Bitmap(ms);
                    pictureEdit1.Image = imagenBitmap;
                }
                #endregion
                Nombre_textEdit.EditValue = anAgrupacionDeArtista.Artista.Nombre;
                PrimerApellicod_textEdit.EditValue = anAgrupacionDeArtista.Artista.PrimerApellido;
                SegundoApellido_textEdit.EditValue = anAgrupacionDeArtista.Artista.SegundoApellido;
                NumeroCarnet_textEdit.EditValue = anAgrupacionDeArtista.Artista.CarnetIdentidad;
                EstadoCivil_comboBoxEdit.EditValue = anAgrupacionDeArtista.Artista.EstadoCivil;
                Direccion_textEdit.EditValue = artista.Direccion;
                Municipio_treeListLookUpEdit.EditValue = anAgrupacionDeArtista.Artista.MunicipioId;
                Escolaridad_textEdit.EditValue = artista.EscolaridadEnsennanzaGeneral;
                AnnoGraduadoEnseGral_textEdit.EditValue = artista.AnnoGraduado;
                #endregion
                #region Datos Laborales

                Agencia_textEdit.Text = artista.Organismo;
                if (anAgrupacionDeArtista.FechaAlta != null)
                    FechaAlta_dateEdit.EditValue = anAgrupacionDeArtista.FechaAlta;
                statusLaboralTextEdit.EditValue = anAgrupacionDeArtista.Artista.StatusLaboral;
                FuenteProcedencia_textEdit.EditValue = artista.FuenteProcedencia;
                if (anAgrupacionDeArtista.Artista.FechaIngresoSector != null) fechaIngresoSectorDateEdit.DateTime = (DateTime)anAgrupacionDeArtista.Artista.FechaIngresoSector;
                ServicioSocial_textEdit.EditValue = artista.CumplimientoServicioSocial;
                Desempenno_lookUpEdit.EditValue = anAgrupacionDeArtista.NomencladorCargoId;
                DesempeñoAbrev_textEdit.EditValue = anAgrupacionDeArtista.AbrevDesempenno;
                TipoContrato_textEdit.EditValue = artista.TipoContratoArtista;
                TipoVinculo_lookUpEdit.EditValue = anAgrupacionDeArtista.TipoVinculo;
            //    EscalaSalarial_lookUpEdit.EditValue = anAgrupacionDeArtista.Artista.EscalaSalarialId;

                #region Evaluacion Artistica
                EvaluacionArtistica_textEdit.EditValue = artista.EvaluacionArtistica;
                NivelEvaluacion_textEdit.EditValue = artista.NivelEvaluacionArt;
                CodigoEvaluacionArt_textEdit.EditValue = artista.CodigoEvalArtistica;
                FechaEvaluacion_dateEdit.EditValue = artista.FechaEvalArtistica;
                #endregion

                #region Aval
                AvalLookUpEdit.EditValue = artista.TipoAval;
                CodigoAval_textEdit.EditValue = artista.CodigoAvalProfesionalidad;
                FechaAval_dateEdit.EditValue = artista.FechaAval;
                #endregion

                #region Otra Profesion
                OtraProfesion_textEdit.EditValue = artista.OtraProfesion;
                AnnoOtraProfesion_textEdit.EditValue = artista.AnnoGraduadoOtraProfesion;
                #endregion

                #region Enseñanza Especializada

                EnsennanzaEsp_textEdit.EditValue = artista.EnsennanzaEspecializada;
                annoGraduadoEnsEsp_TextEdit.EditValue = artista.AnnoGraduadoEnsEspecializada;
                #endregion

                #endregion

                artistaId = anAgrupacionDeArtista.Artista.ArtistaID;
                Text = String.Format("Editando datos de {0}", AAgrupacionDeArtista.Artista.NombreCompleto);

            }
            nomencladorCargoBindingSource.DataSource = AGlobalDataContext.NomencladorCargo;
            trayectoriaArtistaBindingSource.DataSource = AGlobalDataContext.TrayectoriaArtista.Where(c => c.ArtistaId == artistaId);

            // This line of code is generated by Data Source Configuration Wizard
           // Municipio_treeListLookUpEdit.Properties.DataSource = new DXApplication9.NegocioDataContext().Provincia;
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
            //sqlDataSource1.Fill();
        }


        private void EditIntegrante_XtraUserControl_Load(object sender, EventArgs e)
        {
            
            Agrupacion_repositoryItemLookUpEdit.DataSource = AGlobalDataContext.Agrupacion;
            TipoVinculo_repositoryItemLookUpEdit.DataSource = Enumerados.ListaDeEnumerados(typeof(Enumerados.TipoVinculoDeArtista));
            tabbedControlGroup1.SelectedTabPage = Personales_layoutControlGroup;
            bindingSource1.DataSource = AGlobalDataContext.AgrupacionDeArtista.Where(c => c.ArtistaId == artistaId);
        }

        public void CreaTablaMunicipioProvincia()
        {
            
        }

        private void PopulaMunicipiosTreeList()
        {
            TreeList aTreeList = Municipio_treeListLookUpEdit1TreeList;
            var provincias = AGlobalDataContext.Provincia;
            // var _TreeList = repositoryItemTreeListLookUpEdit.TreeList;
            aTreeList.BeginUpdate();
            aTreeList.Columns.Add();
            aTreeList.Columns[0].Caption = "MunicipioID";
            aTreeList.Columns[0].VisibleIndex = 0;
            aTreeList.Columns[0].Visible = false;
            aTreeList.Columns.Add();
            aTreeList.Columns[1].Caption = "Descripcion";
            aTreeList.Columns[1].VisibleIndex = 1;
            aTreeList.Columns.Add();
            aTreeList.EndUpdate();
            aTreeList.BeginUnboundLoad();
            TreeListNode nodeParent = null;
            foreach (var provincia in provincias)
            {
                TreeListNode rootNode = aTreeList.AppendNode(new object[] { provincia.ProvinciaID * -1, provincia.Descripcion }, nodeParent);
                var municipiosDeProvincia = AGlobalDataContext.Municipio.Where(c => c.ProvinciaID == provincia.ProvinciaID);
                foreach (var municipio in municipiosDeProvincia)
                {
                    aTreeList.AppendNode(new object[] { municipio.MunicipioID, municipio.Descripcion }, rootNode);
                }
            }
            Municipio_treeListLookUpEdit.Properties.NullText = "-Seleccione-";
            aTreeList.EndUnboundLoad();
        }
        private List<SmallMunicipioProvincia> GetListaDeMunicipios()
        {

            List<SmallMunicipioProvincia> smallMunicipiosProvincia = new List<SmallMunicipioProvincia>();
            var provincias = AGlobalDataContext.Provincia;
            foreach (var provincia in provincias)
            {
                var parentId = provincia.ProvinciaID + 100000;
                smallMunicipiosProvincia.Add(new SmallMunicipioProvincia { Id = parentId, Descripcion = provincia.Descripcion, ParentId = 0 });
                var municipiosDeProvincia = AGlobalDataContext.Municipio.Where(c => c.ProvinciaID == provincia.ProvinciaID);
                foreach (var municipio in municipiosDeProvincia)
                {
                    smallMunicipiosProvincia.Add(new SmallMunicipioProvincia { Descripcion = municipio.Descripcion, Id = municipio.MunicipioID, ParentId = provincia.ProvinciaID + 100000 });
                }
            }
            return smallMunicipiosProvincia;
        }

        private void layoutControlGroup1_Hidden(object sender, EventArgs e)
        {
            var a = 1;
            var b = a;
        }


        private void pictureEdit1_ImageChanged(object sender, EventArgs e)
        {

        }

        private void Municipio_treeListLookUpEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToInt32(e.NewValue) > 10000)
            {
                MessageBox.Show(string.Format("Debe seleccionar un Municipio, no una provincia"));
                e.Cancel = true;
            }
        }

        private void Commands_buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.IsLeft) //Ok button
            {

                //TODO hacer la salva de los artistas
            }
            Dispose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var a = this.Controls;
            MessageBox.Show(a.Count.ToString());
        }

        private void tabbedControlGroup1_SelectedPageChanging(object sender, DevExpress.XtraLayout.LayoutTabPageChangingEventArgs e)
        {
            if (e.Page == Agrupaciones_layoutControlGroup)
            {
                if (artistaId == 0) //estoy insertando un nuevo artista
                {
                    if (MessageBox.Show("Para asignarle una agrupación a un artista debe salvarlo antes, esta de acuerdo?", "Un momento...", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
                    {
                        artistaId = SalvarIntegrante();
                        bindingSource1.DataSource =
                            AGlobalDataContext.AgrupacionDeArtista.Where(c => c.ArtistaId == artistaId);

                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else if (e.Page == Trayectoria_layoutControlGroup)
            {
                if (artistaId == 0) //estoy insertando un nuevo artista
                {
                    if (MessageBox.Show("Para insertar la trayectoria de un artista debe salvarlo antes, esta de acuerdo?", "Un momento...", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
                    {
                        artistaId = SalvarIntegrante();
                        trayectoriaArtistaBindingSource.DataSource =
                            AGlobalDataContext.TrayectoriaArtista.Where(c => c.ArtistaId == artistaId);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }



        private void EditIntegrante_XtraUserControl_Enter(object sender, EventArgs e)
        {


        }

        private void AgrupacionDeArtista_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {

            AgrupacionDeArtista agrupacionDeArtista = (AgrupacionDeArtista)e.Row;
            //if (string.IsNullOrEmpty(Artista_textEdit.Text)){
            //    GridViewInfo viewInfo = AgrupacionDeArtista_gridView.GetViewInfo() as GridViewInfo;
            //    AgrupacionDeArtista_gridView.DeleteRow(viewInfo.RowsInfo[viewInfo.RowsInfo.Count - 1].RowHandle);
            //}
            agrupacionDeArtista.ArtistaId = artistaId; AGlobalDataContext.SubmitChanges();

        }

        private void AgrupacionDeArtista_gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            var agrupacionForm = new AgrupacionesForm();
            agrupacionForm.Show();
            agrupacionForm.gridView1.AddNewRow();
            agrupacionForm.gridView1.ShowEditForm();
            if (agrupacionForm.DialogResult == DialogResult.OK)
            {
                Agrupacion_repositoryItemLookUpEdit.DataSource = (new NegocioDataContext()).Agrupacion;
            }
        }

        private int SalvarIntegrante()
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return 0;
                Artista artista = artistaId == 0 ? (new Artista()) : 
                    AGlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == artistaId);
                if (artistaId == 0)
                {
                    if (AGlobalDataContext.Artista.Any(c => c.CarnetIdentidad == Convert.ToString(NumeroCarnet_textEdit.EditValue)))
                    {
                        MessageBox.Show("Ya esta persona se encuentra en nuestra base de datos");
                        return 0;
                    }
                }
                #region Datos Personales

                Binary binary;
                #region Foto

                if (pictureEdit1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {


                        pictureEdit1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        binary = new Binary(ms.GetBuffer());
                        byte[] imagen = binary.ToArray();artista.Foto = imagen;

                    }
                }
                else
                {
                    artista.Foto = null;
                }

                #endregion
                artista.Nombre = Convert.ToString(Nombre_textEdit.EditValue).Trim();
                artista.PrimerApellido = Convert.ToString(PrimerApellicod_textEdit.EditValue).Trim();
                artista.SegundoApellido = Convert.ToString(SegundoApellido_textEdit.EditValue).Trim();
                artista.CarnetIdentidad = Convert.ToString(NumeroCarnet_textEdit.EditValue).Trim();
                artista.EstadoCivil = Convert.ToString(EstadoCivil_comboBoxEdit.EditValue).Trim();
                artista.Direccion = Convert.ToString(Direccion_textEdit.EditValue).Trim();
                if (Municipio_treeListLookUpEdit.EditValue != null) artista.MunicipioId = String.IsNullOrEmpty(Municipio_treeListLookUpEdit.EditValue.ToString()) ? (int?)null : Convert.ToInt32(Municipio_treeListLookUpEdit.EditValue);
               artista.EscolaridadEnsennanzaGeneral = Convert.ToString(Escolaridad_textEdit.EditValue).Trim();
                artista.AnnoGraduado = Convert.ToInt32(AnnoGraduadoEnseGral_textEdit.EditValue);

                #endregion

                #region Datos Laborales
                
                artista.Organismo = Convert.ToString(Agencia_textEdit.EditValue).Trim();
                artista.StatusLaboral = Convert.ToString(statusLaboralTextEdit.EditValue);
                artista.FuenteProcedencia = Convert.ToString(FuenteProcedencia_textEdit.EditValue);
                if(fechaIngresoSectorDateEdit.EditValue!=null)artista.FechaIngresoSector = Convert.ToDateTime(fechaIngresoSectorDateEdit.EditValue);
                artista.CumplimientoServicioSocial = Convert.ToString(ServicioSocial_textEdit.EditValue).Trim();
                //if (EscalaSalarial_lookUpEdit.EditValue!=null)
                //artista.EscalaSalarialId = Convert.ToInt32(EscalaSalarial_lookUpEdit.EditValue);
              

                artista.TipoContratoArtista = Convert.ToString(TipoContrato_textEdit.EditValue).Trim();

                #region Evaluacion Artistica
                artista.EvaluacionArtistica = Convert.ToString(EvaluacionArtistica_textEdit.EditValue).Trim();
                artista.NivelEvaluacionArt = Convert.ToString(NivelEvaluacion_textEdit.EditValue).Trim();
                artista.CodigoEvalArtistica = Convert.ToString(CodigoEvaluacionArt_textEdit.EditValue).Trim();
                if (FechaEvaluacion_dateEdit.EditValue != null) artista.FechaEvalArtistica = Convert.ToDateTime(FechaEvaluacion_dateEdit.EditValue);
                #endregion

                #region Aval de profesionalidad
               // if (AvalLookUpEdit.Text != String.Empty) artista.TipoAval = Convert.ToInt32(AvalLookUpEdit.EditValue);
                artista.TipoAval = (int?) (AvalLookUpEdit.EditValue==null?AvalLookUpEdit.EditValue:Convert.ToInt32(AvalLookUpEdit.EditValue));
                artista.CodigoAvalProfesionalidad = Convert.ToString(CodigoAval_textEdit.EditValue).Trim();
                if (FechaAval_dateEdit.EditValue != null) artista.FechaAval = Convert.ToDateTime(FechaAval_dateEdit.EditValue);
                #endregion

                #region Otra Profesion
                artista.OtraProfesion = Convert.ToString(OtraProfesion_textEdit.EditValue).Trim();
                artista.AnnoGraduadoOtraProfesion = Convert.ToInt32(AnnoOtraProfesion_textEdit.EditValue);
                #endregion

                #region Enseñanza Especializada
                artista.EnsennanzaEspecializada = Convert.ToString(EnsennanzaEsp_textEdit.EditValue).Trim();
                artista.AnnoGraduadoEnsEspecializada = Convert.ToInt32(annoGraduadoEnsEsp_TextEdit.EditValue);
                #endregion

                #endregion

                artista.Estado = Enumerados.EstadoArtista.Activo.ToEntero();

             if (artistaId == 0)
                {
                    AGlobalDataContext.Artista.InsertOnSubmit(artista);
                }

              AGlobalDataContext.SubmitChanges();

                if (AAgrupacionDeArtista == null || AAgrupacionDeArtista.AgrupacionDeArtistaID == 0)
                {
                    AGlobalDataContext.AgrupacionDeArtista.InsertOnSubmit(new AgrupacionDeArtista
                    {
                        AgrupacionId = AAgrupacionId,
                        ArtistaId = artista.ArtistaID,
                        NomencladorCargoId = Convert.ToInt32(Desempenno_lookUpEdit.EditValue),
                        AbrevDesempenno = Convert.ToString(DesempeñoAbrev_textEdit.EditValue),
                        FechaAlta = FechaAlta_dateEdit.DateTime
                    });
                    AGlobalDataContext.SubmitChanges();

                }
                else
                {
                 
                    ActualizaAgrupacionDeArtista();
                }
               // _GlobalDataContext.SubmitChanges();
                return artista.ArtistaID;

            }
            catch (Exception exception)
            {
                DialogResult = DialogResult.Cancel;
               Utils.MuestraError();
                return 0;
            }
        }

        private void ActualizaAgrupacionDeArtista()
        {
            try
            {
                var dataContext = new NegocioDataContext();
                var agrupacionDeArtista = dataContext.AgrupacionDeArtista.FirstOrDefault(
                        c => c.ArtistaId == artistaId && c.AgrupacionId == AAgrupacionId);
                if (Desempenno_lookUpEdit.Text != string.Empty) agrupacionDeArtista.NomencladorCargoId = Convert.ToInt32(Desempenno_lookUpEdit.EditValue);
                agrupacionDeArtista.AbrevDesempenno = Convert.ToString(DesempeñoAbrev_textEdit.EditValue).Trim();
                agrupacionDeArtista.TipoVinculo = Convert.ToInt32(TipoVinculo_lookUpEdit.EditValue);
                agrupacionDeArtista.FechaAlta = FechaAlta_dateEdit.DateTime;
                dataContext.SubmitChanges();
               // _GlobalDataContext = dataContext;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void AgrupacionDeArtista_gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (Cache.AgrupacionsIds != null && Cache.AgrupacionsIds.Count > 0) AgrupacionDeArtista_gridView.SetRowCellValue(e.RowHandle, colAgrupacionId, Cache.AgrupacionsIds[0]);
        }

        private void Salvar_simpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                int integranteId = SalvarIntegrante();
                if (integranteId == 0)
                {
                    MessageBox.Show("Verifique datos");
                    return;
                }
                if (!AGlobalDataContext.AgrupacionDeArtista.Any(c => c.ArtistaId == integranteId))
                {
                    if (Cache.AgrupacionsIds != null)
                    {
                        int agrupacionDefatult = Cache.AgrupacionsIds[0];
                        AGlobalDataContext.AgrupacionDeArtista.InsertOnSubmit(new AgrupacionDeArtista
                        {
                            AgrupacionId = agrupacionDefatult,
                            ArtistaId = integranteId,
                            FechaAlta = DateTime.Today
                        });
                        AGlobalDataContext.SubmitChanges();
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {

                DialogResult = DialogResult.Cancel;

            }

        }

        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextEdit_Validating(object sender, CancelEventArgs e)
        {
            var textEdit = ((TextEdit)sender);
            if (string.IsNullOrEmpty(textEdit.Text))
            {
                e.Cancel = true;
                textEdit.ErrorText = "Obligatorio";
            }
        }

        private void SplitName_simpleButton_Click(object sender, EventArgs e)
        {
            var nombreCompleto = Nombre_textEdit.Text.SplitNombreCompleto();
            Nombre_textEdit.Text = nombreCompleto[0].Trim();
            if (nombreCompleto[1] != null) PrimerApellicod_textEdit.Text = nombreCompleto[1].Trim();
            if (nombreCompleto[2] != null) SegundoApellido_textEdit.Text = nombreCompleto[2].Trim();
        }

        private void fKArtistaNOPCodMunicipioBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Desempenno_lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Desempenno_lookUpEdit.Text.Trim().Count() < 30 & DesempeñoAbrev_textEdit.Text == String.Empty)
            {
                DesempeñoAbrev_textEdit.EditValue = Desempenno_lookUpEdit.Text.Trim();
            }
        }

        private void Trayectoria_gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            try
            {
                AGlobalDataContext.SubmitChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar Datos", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                trayectoriaArtistaBindingSource.DataSource =
                            AGlobalDataContext.TrayectoriaArtista.Where(c => c.ArtistaId == artistaId);
            }

        }

        private void Trayectoria_gridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            try
            {
                TrayectoriaArtista trayectoria = (TrayectoriaArtista)e.Row;
                if (trayectoria.TrayectoriaArtistaID == 0)
                {
                    trayectoria.ArtistaId = AArtistaId;
                    AGlobalDataContext.TrayectoriaArtista.InsertOnSubmit(trayectoria);
                }
                AGlobalDataContext.SubmitChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al salvar Datos", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                trayectoriaArtistaBindingSource.DataSource =
                            AGlobalDataContext.TrayectoriaArtista.Where(c => c.ArtistaId == artistaId);
            }
        }



        private void Trayectoria_gridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            var trayectoria = (TrayectoriaArtista)e.Row;
            if (trayectoria.Centro == null)
            {
                Trayectoria_gridView.SetColumnError(Trayectoria_gridView.Columns["Centro"], "Indique Centro ej: Agencia Clave Cubana, Musicuba, etc...");
                e.Valid = false;

            }
            if (trayectoria.Agrupacion == null)
            {
                Trayectoria_gridView.SetColumnError(Trayectoria_gridView.Columns["Agrupacion"], "Indique la unidad artística ...");
                e.Valid = false;

            }
            if (trayectoria.Desempenno == null)
            {
                Trayectoria_gridView.SetColumnError(Trayectoria_gridView.Columns["Desempenno"], "Indique Desempeño ...");
                e.Valid = false;

            }
            if (trayectoria.Desde < Convert.ToDateTime("1/1/1930"))
            {
                Trayectoria_gridView.SetColumnError(Trayectoria_gridView.Columns["Desde"], "Indique Fecha de alta en dicha unidad Artística ...");
                e.Valid = false;

            }
        }

        private void Trayectoria_gridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void LimpiarAval_simpleButton_Click(object sender, EventArgs e)
        {
            AvalLookUpEdit.EditValue = null;
        }

       




    }
}
