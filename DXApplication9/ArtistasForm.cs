using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DXApplication9.Properties;
using DXApplication9.ReportesSistema;
using DXApplication9.UserControls;
using DevExpress.XtraBars;

namespace DXApplication9
{
    public partial class ArtistasForm : DevExpress.XtraEditors.XtraForm
    {
        public bool InsertandoArtista;
        private int AAgrupacionAInicializar = 0;
        //private int _ArtistaProvinciaID;
        private NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private int AImagenId;
        private Agrupacion AGlobalAgrupacion;
        private AgrupacionDeArtista AAgrupacionDeArtistaSeleccionado;
        private class SmallMunicipio
        {
            public int MunicipioId { get; set; }
            public string Descripcion { get; set; }

            public string Provincia { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkAll">Automaticamente selecciona todas las agrupaciones del listbox de las agrupaciones por lo qeu se mostraran todos los integrantes de todas las agrupaciones</param>
        /// <param name="excluyeGrupo">si es true se mostraran todos los integrantes de todos los grupos menos del grupo pasado como parametro, esto para los posibles invitados</param>
        /// <param name="aGrupo">El grupo sobre el cual se basará el constructor</param>
        public ArtistasForm(int? aGrupoId = null, NegocioDataContext aDataContext = null)
        {
            AGlobalDataContext = aDataContext ?? new NegocioDataContext();

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
            //  NuevoIntegrante_simpleButton.Enabled = LoginHelper.RoleDeUsuario == Enumerados.Roles.RecursosHumanos ||
            //                                         LoginHelper.UsuarioRegistrado.EsAdministrador();


            //tipoNomencladorCargoBindingSource.DataSource = AGlobalDataContext.TipoNomencladorCargo;
            //TipoCargo_repositoryItemLookUpEdit.DataSource = Enumerados.ListaDeEnumerados(typeof(Enumerados.TipoCargo));
            ////Enumerados.EnumToList(Enumerados.ProyectoEnumerados.TipoCargo);
            //TipoCargo_repositoryItemLookUpEdit.DisplayMember = "Tipo";
            //TipoCargo_repositoryItemLookUpEdit.ValueMember = "Valor";
            colFechaBaja.Visible = false;
            PopulaGrid();
            Artista_gridView.Columns["FechaBaja"].FilterInfo = new ColumnFilterInfo("[FechaBaja] IS NULL"); //muestro por defecto solo las altas

            PopulaReservas();
            PopulaAgrupacion();
            if (aGrupoId != null)
            {
               // MostrarTodos_barCheckItem.Enabled = false;
                AgrupacionSelect_lookUpEdit.EditValue = (int)aGrupoId;
            }
            if (aGrupoId == null)
            {
                ButtonContainer_layoutControlItem.HideToCustomization();
                Last_emptySpaceItem.HideToCustomization();
            }
            AAgrupacionAInicializar = aGrupoId ?? 0;

            Principal_ribbonPage.Visible = LoginHelper.UsuarioRegistrado.PuedeEditarIntegrantes;
            Economia_ribbonPage.Visible = LoginHelper.UsuarioRegistrado.EsAdministrador() ||
                                  LoginHelper.RoleDeUsuario == Enumerados.Roles.Economico;
        }

        private void PopulaAgrupacion(bool delCatalogo = true)
        {
            if (delCatalogo)
                agrupacionBindingSource.DataSource =
                    AGlobalDataContext.Agrupacion.OrderByDescending(c => c.PerteneceACatalogo).ThenBy(c => !c.DobleVinculo).ThenBy(c => c.Nombre).Where(c => c.PerteneceACatalogo);
            else
            {
                agrupacionBindingSource.DataSource =
                   AGlobalDataContext.Agrupacion.OrderByDescending(c => c.PerteneceACatalogo).ThenBy(c => !c.DobleVinculo).ThenBy(c => c.Nombre);
            }
        }

        private void IntegrantesForm_Load(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch (Exception)
            {

                return;
            }


        }







        private List<SmallMunicipio> GetListaDeMunicipios()
        {
            List<SmallMunicipio> municipios =
                AGlobalDataContext.Municipio.Select(
                    c =>
                        new SmallMunicipio
                        {
                            Descripcion = c.Descripcion,
                            MunicipioId = c.MunicipioID,
                            Provincia = c.Provincia.Descripcion
                        }).ToList();
            return municipios;
        }

        //private void PopulaMunicipiosTreeList(TreeList aTreeList)
        //{

        //    var _Provincias = _GlobalDataContext.Provincia;
        //    // var _TreeList = repositoryItemTreeListLookUpEdit.TreeList;
        //    aTreeList.BeginUpdate();
        //    aTreeList.Columns.Add();
        //    aTreeList.Columns[0].Caption = "MunicipioID";
        //    aTreeList.Columns[0].VisibleIndex = 0;
        //    aTreeList.Columns.Add();
        //    aTreeList.Columns[1].Caption = "Descripcion";
        //    aTreeList.Columns[1].VisibleIndex = 1;
        //    aTreeList.Columns.Add();
        //    aTreeList.EndUpdate();
        //    aTreeList.BeginUnboundLoad();
        //    TreeListNode _NodeParent = null;
        //    foreach (var _Provincia in _Provincias)
        //    {
        //        TreeListNode _RootNode = aTreeList.AppendNode(new object[] { _Provincia.ProvinciaID * -1, _Provincia.Descripcion }, _NodeParent);
        //        var _MunicipiosDeProvincia = _GlobalDataContext.Municipio.Where(c => c.ProvinciaID == _Provincia.ProvinciaID);
        //        foreach (var _Municipio in _MunicipiosDeProvincia)
        //        {
        //            aTreeList.AppendNode(new object[] { _Municipio.MunicipioID, _Municipio.Descripcion }, _RootNode);
        //        }
        //    }
        //    aTreeList.EndUnboundLoad();
        //}

        //private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    _GlobalDataContext.SubmitChanges();
        //}

        //private void checkedListBoxControl1_CheckMemberChanged(object sender, EventArgs e)
        //{
        //    var a = sender;
        //    var b = e;
        //}

        //private void AgrupacioncheckedListBoxControl_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        //{
        //    Cancion_gridControl.EmbeddedNavigator.Enabled = Agrupacion_checkedListBoxControl.CheckedItemsCount > 0;
        //    List<Int32> Lista = new List<int>();
        //    foreach (var _ItemCheck in Agrupacion_checkedListBoxControl.CheckedItems)
        //    {
        //        var _Value = (((Agrupacion)(_ItemCheck))).AgrupacionID;
        //        Lista.Add(Convert.ToInt32(_Value));

        //    }
        //    PopulaIntegrantesGridControl();
        //    Cache.AgrupacionsIds = GetListaAgrupaciones();
        //    var _Canciones = _GlobalDataContext.Cancion.Where(c => Lista.Contains(c.AgrupacionId));
        //    Cancion_gridControl.DataSource = _Canciones;
        //    Cancion_gridControl.Refresh();
        //    Integrantes_gridControl.Refresh();
        //}

        private void IntegrantesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainForm = (MainForm)this.MdiParent;
            if (mainForm != null)
                mainForm.EnableListaIntegrantesButton(true);
        }

        private void IntegrantesForm_Deactivate(object sender, EventArgs e)
        {
            var mainForm = (MainForm)MdiParent;
            if (mainForm != null) mainForm.ProyectosBarButtonItem.Enabled = false;
        }

        private void IntegrantesForm_Activated(object sender, EventArgs e)
        {
            var mainForm = (MainForm)MdiParent;
            if (mainForm != null) mainForm.ProyectosBarButtonItem.Enabled = true;
        }

        //private void FundamentacionLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    List<Artista> _ArtistasList = new List<Artista>();
        //    var Rows = ((Artista_gridView.GetSelectedRows()).Select(c => Artista_gridView.GetRow(c)).ToList());
        //    foreach (var _Row in Rows)
        //    {
        //        Artista _row = (Artista)_Row;
        //        _ArtistasList.Add(_row);
        //    }
        //    var _ArtistasSeleccionados = _ArtistasList;
        //    if (_ArtistasList.Count > 0)
        //    //TODO: Puede darse el caso que seleccionen dos agrupaciones, tendria que enviar al constructorla  agrupacione tiene mas integrantes seleccionados
        //    //Ahora estoy cogiendo solo el grupo del primer integrante seleccionado, pero no necesariamente tiene que ser asi
        //    {
        //        NewProyectForm _NewProyectForm = new NewProyectForm(Enumerados.TipoProyecto.TramiteMigratorio, _ArtistasList[0].AgrupacionId, _ArtistasList);
        //        _NewProyectForm.Name = "Nuevo Proyecto de Fundamentación Para Tramites Migratorios";
        //        _NewProyectForm.Text = "Nuevo Proyecto de Fundamentación Para Tramites Migratorios"; _NewProyectForm.Show();
        //    }
        //    else if (Agrupacion_checkedListBoxControl.CheckedItemsCount > 0)
        //    {
        //        var _GroupId = Convert.ToInt32(Agrupacion_checkedListBoxControl.CheckedItems[0]);
        //        NewProyectForm _NewProyectForm = new NewProyectForm(Enumerados.TipoProyecto.TramiteMigratorio, _GroupId);
        //        _NewProyectForm.Name = "Nuevo Proyecto de Fundamentación";
        //        _NewProyectForm.Show();
        //    }

        //}

        //private void Button_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    // if(gridView1.GetFocusedRowCellValue() )
        //    _GlobalDataContext.SubmitChanges();
        //    Integrantes_gridControl.Refresh();
        //}



        //private void EliminarButton_Click(object sender, EventArgs e)
        //{

        //    //Todo Mostrar un mensaje de advertencia y capturar la desicion
        //    int[] _Rows = Artista_gridView.GetSelectedRows();
        //    foreach (var _Row in _Rows)
        //    {
        //        Artista_gridView.DeleteRow(_Row);
        //    }
        //    _GlobalDataContext.SubmitChanges();
        //}


        private void Artista_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                var a = e.Row as Artista;
                if (a != null && a.ArtistaID != 0)
                    //MessageBox.Show(a.TipoMonedaId.ToString());
                    AGlobalDataContext.SubmitChanges();
                PopulaGrid();
            }
            catch (Exception exception)
            {

                var gridView = Artista_gridView;
                XtraMessageBox.Show("Error en la operacion",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                gridView.DeleteRow(e.RowHandle);
            }

        }

        private void InsertInegrante_buttonEdit_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.IsLeft)
            {
                DialogResult = DialogResult.OK;

            }
            Close();
        }

        private void NuevoTemasimpleButton_Click(object sender, EventArgs e)
        {
            //if (Agrupacion_checkedListBoxControl.CheckedItems.Count > 0)
            //{
            //    foreach (var _ItemCheck in Agrupacion_checkedListBoxControl.CheckedItems)
            //    {
            //        string _NombreAgrupacion = (((DataRowView)(_ItemCheck)).Row).ItemArray[1].ToString();
            //        if (Agrupacion_checkedListBoxControl.CheckedItemsCount > 1)
            //        {
            //            DialogoForm _DialogoForm = new DialogoForm(string.Format("Hay mas de una agrupación seleccionada en el panel lateral, se le asignará el tema a la agrupación {0} por ser la primera seleccionada, está de acuerdo?", _NombreAgrupacion));
            //            if (_DialogoForm.ShowDialog() != DialogResult.OK)
            //            {
            //                break;
            //            }
            //        }
            //  Cancion_gridView.AddNewRow();
            //        break;
            //    }
            //}
        }




        private void Cancion_gridControl_EmbeddedNavigator_Click(object sender, EventArgs e)
        {

        }

        private void Cancion_gridControl_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
        }

        private void Cancion_gridView_RowUpdated_1(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var agrupacionId = AgrupacionSelect_lookUpEdit.EditValue;
            if (agrupacionId == null)
            {
                MessageBox.Show("Debe seleccionar una agrupación", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Cancion cancion = (Cancion)e.Row;
                cancion.AgrupacionId = Convert.ToInt32(agrupacionId);
                AGlobalDataContext.SubmitChanges();
            }

        }

        private void Cancion_gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
        }

        private void ValidaControl(object sender, CancelEventArgs e)
        {
            var control = ((TextEdit)sender);
            var a = control.Text;
            if (String.IsNullOrEmpty(a))
            {
                control.ErrorText = "Dato faltante!";
                DialogResult = DialogResult.Retry;
                e.Cancel = true;
            }
        }

        private void Pasaporte_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
        }

        /// <summary>
        /// Para manejar la forma de seleccionar las agrupaciones en el Agrupacion_checkedListBoxControl
        /// </summary>
        /// <param name="aNombreDelGrupo"></param>
        /// <param name="setSelect">si true entonces selecciona solo el grupo, si false entonces selecciona todos los grupos menos el grupo pasado como parametro </param>
        //public void SetGroupSelectState(string aNombreDelGrupo, bool setSelect = true)
        //{
        //    int _Index = Agrupacion_checkedListBoxControl.FindStringExact(aNombreDelGrupo);
        //    if (_Index == -1) return;
        //    if (setSelect)
        //        Agrupacion_checkedListBoxControl.UnCheckAll();
        //    else
        //        Agrupacion_checkedListBoxControl.CheckAll();
        //    Agrupacion_checkedListBoxControl.SetItemChecked(_Index, setSelect);
        //}


        private void Agrupacion_checkedListBoxControl_DataSourceChanged(object sender, EventArgs e)
        {
            //int Index = Agrupacion_checkedListBoxControl.Items.IndexOf(1);
            //Agrupacion_checkedListBoxControl.UnCheckAll();
            //Agrupacion_checkedListBoxControl.SetItemChecked(Index, true);
        }


        //private void SelectAllAgrupacion_checkEdit_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (SelectAllAgrupacion_checkEdit.Checked)
        //    {
        //        Agrupacion_checkedListBoxControl.CheckAll();
        //    }
        //    else
        //    {
        //        Agrupacion_checkedListBoxControl.UnCheckAll();
        //    }
        //}

        private void Artista_gridView_EditFormShowing(object sender,
            DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs e)
        {
            Artista_gridView.OptionsEditForm.ShowUpdateCancelPanel = DefaultBoolean.False;
            ////trampa para disparar obligatoriamente el evento rowupdate


            // var _Procesando = (Artista) Artista_gridView.GetRow(e.RowHandle);
            //Artista_gridView.SetRowCellValue(e.RowHandle, colOrden, _Procesando.Orden + 1 - 1);
            //var _FirstOrDefault = Artista_gridView.Columns.FirstOrDefault(c => c == colMunicipioId);
            //if (_FirstOrDefault != null) _FirstOrDefault.Visible = true;

            //if (!_GlobalDataContext.FotoDeIntegrante.Any(c => c.ArtistaId == _Procesando.ArtistaID))
            //{
            //   // Artista_gridView.SetRowCellValue(e.RowHandle, colFotoId, null);
            //    //if (Imagen_repositoryItemPictureEdit.InitialImage!=null)
            ////Imagen_repositoryItemPictureEdit.InitialImage.Dispose();
            //}
        }

        private void Artista_gridView_ShowingPopupEditForm(object sender,
            DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs e)
        {

            foreach (Control control in e.EditForm.Controls)
            {
                if (control is EditFormContainer)
                {
                    foreach (Control nestedControl in control.Controls)
                    {
                        if (nestedControl is PanelControl)
                        {
                            foreach (Control button in nestedControl.Controls)
                            {
                                if (button is SimpleButton)
                                {
                                    SimpleButton simpleButton = button as SimpleButton;
                                    if (string.Compare(simpleButton.Text, "Actualizar", true) == 0)
                                    {
                                        simpleButton.Name = "ActualizarBoton";
                                    }
                                    simpleButton.Click += simpleButton_Click;
                                    //simpleButton.Visible = false;
                                }
                            }
                        }
                        //if (nestedControl is PictureEdit) {
                        //    (nestedControl as PictureEdit).Image = null;
                        //}
                    }
                }
            }
        }

        private void simpleButton_Click(object sender, EventArgs eventArgs)
        {
            var simpleButton = sender as SimpleButton;
            if (simpleButton != null)
            {
                if (simpleButton.DialogResult == DialogResult.Cancel)
                {
                    Artista_gridView.CancelUpdateCurrentRow();
                }
            }
            //}
        }

        private void Artista_gridView_RowDeleted(object sender, RowDeletedEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();

        }

        private void Municipio_repositoryItemSearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            ((SearchLookUpEdit)sender).Properties.View.Columns[0].Visible = false;
        }

        private void Artista_gridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //var _Procesando = Artista_gridView.GetRow(e.RowHandle) as Artista;
            //if (_Procesando.ArtistaID == 0 || !_GlobalDataContext.FotoDeIntegrante.Any(c => c.ArtistaId == _Procesando.ArtistaID))
            //{
            //    Imagen_repositoryItemPictureEdit.InitialImage = null;
            //}
            //if (Agrupacion_checkedListBoxControl.CheckedItems != null)
            //{
            //    var _PrimerItem = Agrupacion_checkedListBoxControl.SelectedIndices[0];
            //    var _FirstItemCheckValue = Agrupacion_checkedListBoxControl.GetItemValue(_PrimerItem);
            //    // var _Value = Convert.ToInt32(((DataRowView)(_ItemCheck)).Row.ItemArray[0]);
            //    //  int _PrimerGrupoSeleccionado =_Value;
            //    Artista_gridView.SetRowCellValue(e.RowHandle, Artista_gridView.Columns["AgrupacionId"], _FirstItemCheckValue);
            //}

        }



        private void Imagen_repositoryItemPictureEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Artista_gridView_MouseEnter(object sender, EventArgs e)
        {
            //var gridView = Artista_gridView;
            //Point clickPoint = gridControl1.PointToClient(MousePosition);
            //var hitInfo = gridView.CalcHitInfo(clickPoint);
            //if (hitInfo.InRowCell)
            //{
            //    int rowHandle = hitInfo.RowHandle;
            //    GridColumn column = hitInfo.Column;
            //    //MessageBox.Show(column.Name + " "+rowHandle);
            //    if (column == colOrden)
            //    {
            //        Artista_gridView.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;

            //if (gridView1.GetSelectedRows().Count() > 0)
            //{
            //    var _SelectedRow = gridView1.GetSelectedRows()[0];
            //    Proyectos _ProyectoEditar = _GlobalDataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == ((Proyectos)gridView1.GetRow(_SelectedRow)).ProyectoID);
            //    if (_ProyectoEditar == null) return;
            //    NewProyectForm _NewProyectForm = new NewProyectForm(_ProyectoEditar);
            //    _NewProyectForm.CausaDeProyectoMemoEdit.Enabled = true;
            //    if (_NewProyectForm.ShowDialog() == DialogResult.OK)
            //    {
            //        var _Main = (MainForm)MdiParent;
            //        _Main.MuestraProyectos();
            //        Dispose();
            //        gridView1.RefreshData();
            //    }


            //}

            //}
            //else if (column.Name == Delete_gridColumn.Name)
            //{
            //    if (gridView1.GetSelectedRows().Count() > 0)
            //    {
            //        var _SelectedRow = gridView1.GetSelectedRows()[0];
            //        Proyectos _ProyectoEditar = (Proyectos)gridView1.GetRow(_SelectedRow);
            //        if ((new DialogoForm("Esta Seguro que eliminará el Proyecto")).ShowDialog() == DialogResult.OK)
            //        {
            //            gridView1.DeleteSelectedRows(); _GlobalDataContext.Proyectos.DeleteOnSubmit(_ProyectoEditar);
            //            _GlobalDataContext.SubmitChanges();
            //            gridControl1.Refresh();
            //        }


            //    }
            //}
            //}
        }

        private void Artista_gridView_Click(object sender, EventArgs e)
        {
            var gridView = Artista_gridView;
            Point clickPoint = Integrantes_gridControl.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {
                int rowHandle = hitInfo.RowHandle;
                GridColumn column = hitInfo.Column;
                AgrupacionDeArtista agrupacionDeArtista = (AgrupacionDeArtista)gridView.GetRow(rowHandle);
                // MessageBox.Show(column.Name + " "+rowHandle);
                //if (column == colEdit_gridColumn)
                //{
                //    EditIntegrante_XtraForm _EditIntegrante_XtraForm =
                //        new EditIntegrante_XtraForm((int) AgrupacionSelect_lookUpEdit.EditValue, _agrupacionDeArtista);
                //    if (_EditIntegrante_XtraForm.ShowDialog() == DialogResult.OK)
                //    {
                //        PopulaGrid();
                //    }

                //}

                //if (column == colBaja_gridColumn)
                //{
                //    //if (gridView1.GetSelectedRows().Count() > 0)
                //    //{

                //    // AgrupacionDeArtista agrupacionDeArtista = _GlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == _agrupacionDeArtista.ArtistaId);
                //    DarBajaArtistaSeleccionado();
                //    // }
                //}



            }

        }



        private void Artista_gridView_MouseMove(object sender, MouseEventArgs e)
        {
            var gridView = Artista_gridView;
            Point clickPoint = Integrantes_gridControl.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {
                int rowHandle = hitInfo.RowHandle;
                GridColumn column = hitInfo.Column;
                // MessageBox.Show(column.Name + " "+rowHandle);

                Artista_gridView.OptionsBehavior.EditingMode = GridEditingMode.EditForm;

            }
        }

        //private void DelCatalogo_checkEdit_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!DelCatalogo_checkEdit.Checked)
        //    {
        //        Agrupacion_checkedListBoxControl.DataSource = (new NegocioDataContext()).Agrupacion.OrderByDescending(c => c.PerteneceACatalogo).ThenBy(c => c.Nombre);
        //        Agrupacion_checkedListBoxControl.Refresh();
        //    }
        //    else
        //    {
        //        Agrupacion_checkedListBoxControl.DataSource = (new NegocioDataContext()).Agrupacion.Where(c => c.PerteneceACatalogo).OrderBy(c => c.Nombre);
        //        Agrupacion_checkedListBoxControl.Refresh();
        //    }
        //    Agrupacion_checkedListBoxControl.CheckAll();
        //}

        //private void Cancion_gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        //{
        //    Cancion _Tema = (Cancion)e.Row;
        //    if (_Tema.Autor == null)
        //    {
        //        Cancion_gridView.SetColumnError(colAutor, "Debe especificar el Autor del tema");
        //        e.Valid = false;
        //    }
        //    if (_Tema.Sociedad == null) _Tema.Sociedad = "SGAE";
        //    if (_Tema.Titulo == null)
        //    {
        //        Cancion_gridView.SetColumnError(colTitulo, "Debe especificar el Título del tema");
        //        e.Valid = false;
        //    }
        //}

        private void Cancion_gridView_InvalidRowException(object sender,
            DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        //public List<int> GetListaAgrupaciones()
        //{
        //    List<Int32> _Lista = new List<int>();
        //    foreach (var _ItemCheck in Agrupacion_checkedListBoxControl.CheckedItems)
        //    {
        //        var _Value = (((Agrupacion)(_ItemCheck))).AgrupacionID;
        //        _Lista.Add(Convert.ToInt32(_Value));

        //    }
        //    return _Lista;
        //}

        private void PopulaIntegrantesGridControl()
        {

            var integrantes =
                new NegocioDataContext().AgrupacionDeArtista.Where(
                    c => c.AgrupacionId == Convert.ToInt32(AgrupacionSelect_lookUpEdit.EditValue))
                    .Select(c => c.Artista);
            Integrantes_gridControl.DataSource = integrantes;
        }

        private void NuevoIntegrante_simpleButton_Click(object sender, EventArgs e)
        {
            if (AgrupacionSelect_lookUpEdit.EditValue == null) return;
            EditIntegranteXtraForm editIntegranteXtraForm =
                new EditIntegranteXtraForm((int)AgrupacionSelect_lookUpEdit.EditValue);
            if (editIntegranteXtraForm.ShowDialog() != DialogResult.Cancel)
            {
                PopulaGrid();
            }
        }

        public void PopulaGridConBajas()
        {
            if (AgrupacionSelect_lookUpEdit.EditValue == null) return;

            agrupacionDeArtistaBindingSource.DataSource =
                AGlobalDataContext.AgrupacionDeArtista.Where(
                    c => c.AgrupacionId == (int)AgrupacionSelect_lookUpEdit.EditValue)
                    .OrderBy(c => c.Artista.NomencladorCargo.PesoDeCargo)
                    .ThenBy(c => c.Artista.Nombre);
            MostrarBajas_barCheckItem.Caption = "Ocultar Bajas";
            MostrarBajas_barCheckItem.Glyph = Resources.hide_32x32;
            colFechaBaja.Visible = true;
            //colBaja_gridColumn.Visible = true;
        }

        public void PopulaGridSinBajas()
        {
            if (AgrupacionSelect_lookUpEdit.EditValue == null) return;
            // colBaja_gridColumn.Visible = true;
            AGlobalDataContext = new NegocioDataContext();
            agrupacionDeArtistaBindingSource.DataSource =
                AGlobalDataContext.AgrupacionDeArtista.Where(
                    c => c.AgrupacionId == (int)AgrupacionSelect_lookUpEdit.EditValue && c.FechaBaja == null)
                    .OrderByDescending(c => c.Artista.NomencladorCargo.PesoDeCargo)
                    .ThenBy(c => c.Artista.Nombre);

            //var _Integrantes = new NegocioDataContext().AgrupacionDeArtista.Where(c => _Lista.Contains(c.AgrupacionId) && ).Select(c => c.Artista).DistinctBy(c => c.ArtistaID);
            //Integrantes_gridControl.DataSource = (new NegocioDataContext()).Artista.Where(c => !c.FechaDeBaja.HasValue);
            //MostrarBajas_checkButton.Text = "Mostrar Bajas";
            //MostrarBajas_checkButton.Image = Resources.show_32x32;
            colFechaBaja.Visible = false;
        }


        private void InsertInegrante_buttonEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void AgrupacionSelect_lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            MostrarTodos_barCheckItem.Enabled = false;
            MostrarBajas_barCheckItem.Enabled = false;
            if (AgrupacionSelect_lookUpEdit.EditValue != null)
                try
                {
                    // if(SplashScreenManager.ActivateParentOnSplashFormClosing )SplashScreenManager.CloseForm();
                    try
                    {
                        SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);
                    }
                    catch (Exception)
                    {

                        SplashScreenManager.CloseForm();
                        SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);

                    }
                    MostrarBajas_barCheckItem.Enabled = true;
                    AGlobalAgrupacion =
                        AGlobalDataContext.Agrupacion.FirstOrDefault(
                            c => c.AgrupacionID == Convert.ToInt32(AgrupacionSelect_lookUpEdit.EditValue));
                    MostrarTodos_barCheckItem.Enabled = true;
                }
                catch (Exception)
                {

                    return;
                }

            PopulaGrid();

            Nuevo_barButtonItem.Enabled = LoginHelper.UsuarioRegistrado.PuedeEditarIntegrantes;
        }

        private void Integrantes_gridControl_Click(object sender, EventArgs e)
        {

        }

        private void Artista_gridView_RowStyle(object sender, RowStyleEventArgs e)
        {

            try
            {
                if (e.RowHandle == -1) return;
                AgrupacionDeArtista agrupacionDeArtista = (AgrupacionDeArtista)Artista_gridView.GetRow(e.RowHandle);
                if (agrupacionDeArtista.FechaBaja.HasValue)
                {
                    e.Appearance.BackColor = Color.LightSalmon;
                    e.Appearance.BackColor2 = Color.BurlyWood;

                    // e.Appearance.ForeColor = Color.Chocolate;
                }
                if (agrupacionDeArtista.Artista.Estado == Enumerados.EstadoArtista.Desactivado.ToEntero())
                {
                    e.Appearance.BackColor = Color.White;
                    e.Appearance.ForeColor = Color.IndianRed;
                }
            }
            catch (Exception)
            {

               //do nothing
            }
        }

        private void TodosGrupos_simpleButton_Click(object sender, EventArgs e)
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
            agrupacionDeArtistaBindingSource.DataSource =
                AGlobalDataContext.AgrupacionDeArtista.DistinctBy(c => c.ArtistaId);
        }

        private void agrupacionDeArtistaBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch
            {
            }
        }

        private void Artista_gridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (LoginHelper.UsuarioRegistrado.PuedeEditarIntegrantes)
                {
                    AgrupacionDeArtista agrupacionDeArtista = GetArtistaSeleccionadoPorMouse();
                    EditIntegranteXtraForm editIntegranteXtraForm =
                        new EditIntegranteXtraForm((int)AgrupacionSelect_lookUpEdit.EditValue, agrupacionDeArtista,
                            AGlobalDataContext);
                    if (editIntegranteXtraForm.ShowDialog() == DialogResult.OK)
                    {
                        AGlobalDataContext.Refresh(RefreshMode.KeepChanges, agrupacionDeArtista);
                        PopulaGrid();
                    }
                }
            }
            catch (Exception)
            {

               Utils.MuestraError("no se puede editar el artista desde esta vista");
            }
        }

        private AgrupacionDeArtista GetArtistaSeleccionadoPorMouse()
        {
            var gridView = Artista_gridView;
            Point clickPoint = Integrantes_gridControl.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {
                int rowHandle = hitInfo.RowHandle;
                // GridColumn column = hitInfo.Column;
                AgrupacionDeArtista agrupacionDeArtista = (AgrupacionDeArtista)gridView.GetRow(rowHandle);
                AAgrupacionDeArtistaSeleccionado = agrupacionDeArtista;
                return agrupacionDeArtista;
            }

            return null;
            //    private void IntegrantesForm_Shown(object sender, EventArgs e)
            //    {
            //        var _MainForm = MdiParent as MainForm;
            //        if (_MainForm != null) _MainForm.splashScreenManager1.CloseWaitForm();}
        }

        private void Edit_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            EditaArtistaSeleccionado();
        }

        private void EditaArtistaSeleccionado(AgrupacionDeArtista anAgrupacionDeArtista = null)
        {

            AgrupacionDeArtista agrupacionDeArtista = anAgrupacionDeArtista ?? GetPrimerArtistaSeleccionado();
            if (agrupacionDeArtista == null) MessageBox.Show("Debe seleccionar antes algún integrante");
            EditIntegranteXtraForm editIntegranteXtraForm =
                new EditIntegranteXtraForm((int)AgrupacionSelect_lookUpEdit.EditValue, agrupacionDeArtista);
            if (editIntegranteXtraForm.ShowDialog() == DialogResult.OK)
            {
                PopulaGrid();
            }
        }
        /// <summary>
        /// Devuelve el primer AgrupacionArtista Seleccionado, sino 
        /// hay ninguno seleccionado devuelve Null
        /// </summary>
        /// <returns></returns>
        private AgrupacionDeArtista GetPrimerArtistaSeleccionado()
        {
            try
            {
                AgrupacionDeArtista agrupacionDeArtista = null;
                var seleccionados = Artista_gridView.GetSelectedRows();
                if (!seleccionados.Any())
                {
                    MessageBox.Show("Seleccione al menos un integrante", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                if (seleccionados.Count() > 1)
                {
                    MessageBox.Show("Se accionará sobre el primer integrante selecionado", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                agrupacionDeArtista = (AgrupacionDeArtista)(Artista_gridView.GetRow(seleccionados[0]));


                return
                    AGlobalDataContext.AgrupacionDeArtista.FirstOrDefault(
                        c => c.AgrupacionDeArtistaID == agrupacionDeArtista.AgrupacionDeArtistaID);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Accion_dropDownButton_Click(object sender, EventArgs e)
        {
            ActivaAcciones();
        }

        private void ActivaAcciones()
        {
            int cantCeldasSel = Artista_gridView.GetSelectedRows().Count();
            Baja_barButtonItem.Enabled =
                Edit_barButtonItem.Enabled =
                    Trayecrtoria_barButtonItem.Enabled = (cantCeldasSel > 0);
            // editarToolStripMenuItem.Enabled = darBajaToolStripMenuItem.Enabled=editarTrayectoriaToolStripMenuItem.Enabled 
        }

        private void Baja_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DarBajaArtistaSeleccionado();
            //int artistaId = 0;
            //AgrupacionDeArtista _agrupacionDeArtista = GetPrimerArtistaSeleccionado();
            //if (_agrupacionDeArtista.FechaBaja.HasValue)
            //{
            //    if (
            //        MessageBox.Show(
            //            "Este integrante está actualmente de baja, desea darle de Alta nuevamente?", "Atención",
            //            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            //    {
            //        _agrupacionDeArtista.FechaBaja = null;
            //        _GlobalDataContext.SubmitChanges();

            //    }
            //}
            //else
            //{
            //    //determinar si el integrante no tiene ningun ingreso entonces solicitar que se borre
            //    if (
            //        MessageBox.Show(
            //            "Al darle baja a este integrante no saldrá en más ninguna nómina, esta seguro?",
            //            "ESTA SEGURO?", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            //    {
            //        //sino hay datos historicos no hace falta poner la fecha de baja solo se borra de la base de datos
            //        if (!_agrupacionDeArtista.TieneActividadHistorica)
            //        {
            //            try
            //            {
            //                _GlobalDataContext.AgrupacionDeArtista.DeleteOnSubmit(_agrupacionDeArtista);
            //                _GlobalDataContext.SubmitChanges();

            //            }
            //            catch (Exception)
            //            {

            //                throw;}

            //            if (_agrupacionDeArtista.Artista.AgrupacionDeArtista.Count == 1)//queire decir que solamente el artista ha estado con el grupo en cuestion
            //                {
            //                    //Le doy la opcion de mantener los datos del artista en la base de datos y no borrarlos para un futuro o si prefiere eliminarlo completamente de la base de datos
            //                   if(MessageBox.Show(
            //                        "El Integrante ha sido suprimido de la agrupación. Desea mantener los datos del mismo en la base de datos para un posible uso posterior? (esto permitira que si en un futuro el integrante regresa a trabajar en su institución no tenga que insertar todos sus datos nuevamente al darle de alta,",
            //                        "Opción", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.OK)
            //                   {
            //                       var artista = _GlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == artistaId);
            //                       if (artista != null)
            //                       {
            //                           _GlobalDataContext.Artista.DeleteOnSubmit(artista);
            //                           _GlobalDataContext.SubmitChanges();
            //                       }
            //                    }
            //                                                }
            //             PopulaGrid();
            //        }
            //        PopupBajaXtraForm _BajaXtraForm = new PopupBajaXtraForm(_agrupacionDeArtista.ArtistaId,
            //            (int)AgrupacionSelect_lookUpEdit.EditValue);
            //        if (_BajaXtraForm.ShowDialog() != DialogResult.Cancel)
            //        {
            //            PopulaGrid();
            //        }
            //    }
            //}
        }

        private void Trayecrtoria_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditarTrayectoriaArtistaSeleccionado();
        }

        private void MostrarBajas_checkButton_CheckedChanged(object sender, EventArgs e)
        {
            PopulaGrid();
            // MostrarBajas_checkButton.Text = MostrarBajas_checkButton.Checked ? "Ocultar Bjas" : "Mostrar Bajas";
        }

        private void PopulaGrid()
        {
            PopulaGridConBajas();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var artistaSeleccionado = GetPrimerArtistaSeleccionado();
            if (artistaSeleccionado == null) return;
            EditaArtistaSeleccionado(artistaSeleccionado);
        }

        private void Artista_contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            ActivaAcciones();
        }

        private void DarBajaArtistaSeleccionado(AgrupacionDeArtista anAgrupacionDeArtista = null)
        {

            int artistaId = 0;
            AgrupacionDeArtista agrupacionDeArtista = GetPrimerArtistaSeleccionado();
            if (agrupacionDeArtista.FechaBaja.HasValue)
            {
                if (
                    MessageBox.Show(
                        "Este integrante está actualmente de baja, desea darle de Alta nuevamente?", "Atención",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    agrupacionDeArtista.FechaBaja = null;
                    AGlobalDataContext.SubmitChanges();

                }
            }
            else
            {
                //determinar si el integrante no tiene ningun ingreso entonces solicitar que se borre
                if (
                    MessageBox.Show(
                        "Al darle baja a este integrante no saldrá en más ninguna nómina, esta seguro?",
                        "ESTA SEGURO?", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    //sino hay datos historicos no hace falta poner la fecha de baja solo se borra de la base de datos
                    if (!agrupacionDeArtista.TieneActividadHistorica)
                    {
                        try
                        {
                            AGlobalDataContext.AgrupacionDeArtista.DeleteOnSubmit(agrupacionDeArtista);
                            AGlobalDataContext.SubmitChanges();

                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        if (agrupacionDeArtista.Artista.AgrupacionDeArtista.Count == 1)
                        //queire decir que solamente el artista ha estado con el grupo en cuestion
                        {
                            //Le doy la opcion de mantener los datos del artista en la base de datos y no borrarlos para un futuro o si prefiere eliminarlo completamente de la base de datos
                            if (MessageBox.Show(
                                "El Integrante ha sido suprimido de la agrupación. Desea mantener los datos del mismo en la base de datos para un posible uso posterior? (esto permitira que si en un futuro el integrante regresa a trabajar en su institución no tenga que insertar todos sus datos nuevamente al darle de alta,",
                                "Opción", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.OK)
                            {
                                var artista = AGlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == artistaId);
                                if (artista != null)
                                {
                                    AGlobalDataContext.Artista.DeleteOnSubmit(artista);
                                    AGlobalDataContext.SubmitChanges();
                                }
                            }
                        }
                        PopulaGrid();
                        PopulaReservas();
                    }
                    PopupBajaXtraForm bajaXtraForm = new PopupBajaXtraForm(agrupacionDeArtista.AgrupacionDeArtistaID);
                    if (bajaXtraForm.ShowDialog() != DialogResult.Cancel)
                    {
                        PopulaGrid();
                        PopulaReservas();
                    }
                }
            }

        }

        private void darBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var artistaSeleccionado = GetPrimerArtistaSeleccionado();
            if (artistaSeleccionado == null) return;
            DarBajaArtistaSeleccionado(artistaSeleccionado);
        }

        private void editarTrayectoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var artistaSeleccionado = GetPrimerArtistaSeleccionado();
            if (artistaSeleccionado == null) return;
            EditarTrayectoriaArtistaSeleccionado(artistaSeleccionado);
        }

        private void EditarTrayectoriaArtistaSeleccionado(AgrupacionDeArtista anAgrupacionDeArtista = null)
        {

            AgrupacionDeArtista agrupacionDeArtista = anAgrupacionDeArtista ?? GetPrimerArtistaSeleccionado();
            TrayectoriaArtistaXtraForm trayectoriaXtraForm =
                new TrayectoriaArtistaXtraForm(agrupacionDeArtista.Artista);
            if (trayectoriaXtraForm.ShowDialog() != DialogResult.Cancel)
            {
                PopulaGrid();
            }
        }



        private void dictamenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuestraDictamenDeSeleccionados();
        }

        private void MuestraDictamenDeSeleccionados()
        {
            var artistaSeleccionados = GetArtistasIdSeleccionados();
            var reporte = new XtraReport();
            reporte.CreateDocument();

            for (int i = 0; i < artistaSeleccionados.Count(); i++)
            {

                DictamenXtraReport dictamenXtraReport = new DictamenXtraReport(artistaSeleccionados[i]);
                dictamenXtraReport.CreateDocument();
                reporte.Pages.AddRange(dictamenXtraReport.Pages);
            }
            reporte.ShowPreview();
        }

        private void asignarAgrupaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AsignaAgrupaciones(Reservas_gridView);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Asigna  agrupaciones seleccionadas a integrantes seleccionados del grid que se corresponda
        /// </summary>
        /// <param name="aGridView">Grid que se selecciona</param>
        private void AsignaAgrupaciones(GridView aGridView)
        {
            var grid = aGridView;
            PopupAgrupacionXtraForm agrupacionXtraForm = new PopupAgrupacionXtraForm();
            if (agrupacionXtraForm.ShowDialog() == DialogResult.OK)
            {
                //int agrupacion = agrupacionXtraForm.GrupoSeleccionado;
                if (grid.GetSelectedRows().Count() > 0)
                {
                    Artista artistaSeleccionado;
                    if (grid == Reservas_gridView)
                    {
                        artistaSeleccionado = (Artista)grid.GetRow(Reservas_gridView.GetSelectedRows()[0]);
                    }

                    else
                    {
                        artistaSeleccionado = ((AgrupacionDeArtista)grid.GetRow(Artista_gridView.GetSelectedRows()[0])).Artista;
                    }
                    Agrupacion grupoIdAsignado = AGlobalDataContext.Agrupacion.FirstOrDefault(c => c.AgrupacionID == agrupacionXtraForm.GrupoSeleccionado);
                    if (
                        AGlobalDataContext.AgrupacionDeArtista.Any(
                            c =>
                                artistaSeleccionado.ArtistaID == c.ArtistaId && c.AgrupacionId == grupoIdAsignado.AgrupacionID &&
                                c.FechaBaja == null))
                    {
                        XtraMessageBox.Show(UserLookAndFeel.Default,
                            String.Format("{0} pertenece al grupo {1}", artistaSeleccionado.NombreCompleto,
                                grupoIdAsignado.Nombre), "Atención", MessageBoxButtons.OK);
                        agrupacionXtraForm.Dispose();
                        return;
                    }
                    if (agrupacionXtraForm.TipoVinculo == (short?)(Enumerados.TipoVinculoDeArtista.PrimerVinculo))
                        if (
                        AGlobalDataContext.AgrupacionDeArtista.Any(
                            c =>
                                c.ArtistaId == artistaSeleccionado.ArtistaID && c.FechaBaja == null &&
                                c.TipoVinculo == (short?)(Enumerados.TipoVinculoDeArtista.PrimerVinculo)))
                        {
                            XtraMessageBox.Show(
                                "Ya este integrante tiene primer vínculo por lo que este será su segundo vinculo",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            agrupacionXtraForm.TipoVinculo = (int)Enumerados.TipoVinculoDeArtista.SegundoVinculo;
                        }
                    var agrupacionDeArtista = new AgrupacionDeArtista
                    {
                        ArtistaId = artistaSeleccionado.ArtistaID,
                        AgrupacionId = agrupacionXtraForm.GrupoSeleccionado,
                        FechaAlta = agrupacionXtraForm.FechaAlta,
                        NomencladorCargoId = agrupacionXtraForm.CargoId,
                        AbrevDesempenno = agrupacionXtraForm.AbreviaturaCargo,
                        TipoVinculo = (short?)(agrupacionXtraForm.TipoVinculo)

                    };
                    AGlobalDataContext.AgrupacionDeArtista.InsertOnSubmit(agrupacionDeArtista);
                    AGlobalDataContext.SubmitChanges();
                    PopulaGrid();
                    PopulaReservas();
                }
            }
        }

        private void PopulaReservas()
        {
            artistaBindingSource.DataSource =
                AGlobalDataContext.Artista.Where(c => !c.AgrupacionDeArtista.Any()).OrderBy(c => c.Nombre);
        }

        private void eliminarCompletamenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Reservas_gridView.GetSelectedRows().Count() > 0)
            {
                Artista artistaSeleccionado = (Artista)Reservas_gridView.GetRow(Reservas_gridView.GetSelectedRows()[0]);
                if (artistaSeleccionado.TieneDatosHistoricos)
                {
                    MessageBox.Show(
                        "Este integrante no puede eliminarse porque aunque este de baja tiene datos historicos en la base de datos");
                }
                else
                {
                    Artista artista =
                        AGlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == artistaSeleccionado.ArtistaID);
                    if (artista == null) return;
                    AGlobalDataContext.Artista.DeleteOnSubmit(artista);
                    AGlobalDataContext.SubmitChanges();
                    PopulaReservas();
                }
            }
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(AgrupacionSelect_lookUpEdit.EditValue) != String.Empty)
            {
                TablaCertificoXtraReportV2 tablaCertifico = new TablaCertificoXtraReportV2(AGlobalAgrupacion);
                tablaCertifico.CreateDocument();
                tablaCertifico.ShowRibbonPreviewDialog();
            }
        }

        private void seleccionadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Imprimir tabla d certifico de artistas seleccionados
            MuestraTablaCertificos();
        }

        private void MuestraTablaCertificos()
        {
            int agrupacionId = Convert.ToInt32(AgrupacionSelect_lookUpEdit.EditValue);
            TablaCertificoXtraReportV2 tablaCertifico = new TablaCertificoXtraReportV2(GetArtistasIdSeleccionados(), agrupacionId);
            tablaCertifico.CreateDocument();
            tablaCertifico.ShowRibbonPreviewDialog();
        }


        private int[] GetArtistasIdSeleccionados()
        {
            var grid = Artista_gridView;
            int[] handles = Artista_gridView.GetSelectedRows();
            int[] artistaId = new int[grid.GetSelectedRows().Count()];
            var a = 0;
            foreach (var rowHandle in handles)
            {
                AgrupacionDeArtista artista = (AgrupacionDeArtista)grid.GetRow(rowHandle);
                artistaId[a] = artista.ArtistaId;
                a++;
            }
            return artistaId;
        }

        private List<AgrupacionDeArtista> GetAgrupacionDeArtistasSeleccionados()
        {
            List<AgrupacionDeArtista> lista = new List<AgrupacionDeArtista>();
            var grid = Artista_gridView;
            int[] handles = Artista_gridView.GetSelectedRows();
            //int[] artistaId = new int[grid.GetSelectedRows().Count()];
            //var a = 0;
            foreach (var rowHandle in handles)
            {
                AgrupacionDeArtista agrupacionDeArtista = (AgrupacionDeArtista)grid.GetRow(rowHandle);
                lista.Add(agrupacionDeArtista);
            }
            return lista;
        }

        private IQueryable<Artista> GetArtistasSeleccionados()
        {
            var Artistas = AGlobalDataContext.Artista.Where(c => GetArtistasIdSeleccionados().Contains(c.ArtistaID));
            return Artistas;
            //List<AgrupacionDeArtista> lista = new List<AgrupacionDeArtista>();
            //var grid = Artista_gridView;
            //int[] handles = Artista_gridView.GetSelectedRows();
            ////int[] artistaId = new int[grid.GetSelectedRows().Count()];
            ////var a = 0;
            //foreach (var rowHandle in handles)
            //{
            //    AgrupacionDeArtista agrupacionDeArtista = (AgrupacionDeArtista)grid.GetRow(rowHandle);
            //    lista.Add(agrupacionDeArtista);
            //}
            //return lista;
        }
        private void Todos_checkButton_CheckedChanged(object sender, EventArgs e)
        {
            MostrarTodos();
        }

        private void MostrarTodos()
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
            if (AGlobalDataContext.AgrupacionDeArtista.Any())
            {
                agrupacionDeArtistaBindingSource.DataSource =
                    AGlobalDataContext.AgrupacionDeArtista.OrderBy(c => c.Artista.Nombre);
                MostrarBajas_barCheckItem.Enabled = true;

            }

            else
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

            AgrupacionSelect_lookUpEdit.EditValue = null;
        }


        //private void Artista_gridView_MouseDown(object sender, MouseEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    // obtaining hit info
        //    GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
        //    if (((e.Button & MouseButtons.Right) != 0) && (hitInfo.InRow) &&
        //        (!view.IsGroupRow(hitInfo.RowHandle)))
        //    {
        //        // switching focus
        //        view.FocusedRowHandle = hitInfo.RowHandle;
        //        // showing the custom context menu
        //        var menu = new DXPopupMenu();
        //        foreach (var item in Accion_popupMenu.ItemLinks)
        //        {

        //        }
        //        //DXMenuItem menuItem = new DXMenuItem("DeleteRow",DeleteFocusedRow);
        //        //menuItem.Tag = view;
        //        //menu.Items.Add(menuItem);
        //        Acc.ShowPopup(hitInfo.HitPoint);
        //    }
        //}

        private void DeleteFocusedRow(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void asignarAgrupacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignaAgrupaciones(Artista_gridView);
        }

        private void seleccionadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void seleccionadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var artistasIdsSeleccionados = GetArtistasIdSeleccionados();
            XtraReport reporte = new XtraReport();
            foreach (var artistaIdSeleccionado in artistasIdsSeleccionados)
            {
                var reporteCertificon = new CertIndividualXtraReport(artistaIdSeleccionado);
                reporteCertificon.CreateDocument();
                reporte.Pages.AddRange(reporteCertificon.Pages);
            }
            reporte.ShowRibbonPreviewDialog();

        }

        private void Artista_gridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrincipalribbonPageGroup.Enabled = Artista_gridView.GetSelectedRows().Count() > 0 && LoginHelper.UsuarioRegistrado.PuedeEditarIntegrantes;
            Reportes_ribbonPageGroup.Enabled = Artista_gridView.GetSelectedRows().Count() > 0;

            ActivaIntegrante_barButtonItem.Enabled = GetArtistasSeleccionados().Any(c => c.Estado == Enumerados.EstadoArtista.Desactivado.ToEntero());
            DesactivaIntegrante_barButtonItem.Enabled = GetArtistasSeleccionados().Any(c => c.Estado == Enumerados.EstadoArtista.Activo.ToEntero());

            var selectedRowHandles = Artista_gridView.GetSelectedRows();
            _selectedDataSourceRowIndeces = selectedRowHandles.Select(x => Artista_gridView.GetDataSourceRowIndex(x)).ToList();

        }

        private void Dictamen_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestraDictamenDeSeleccionados();
        }

        private void CertInd_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestraTablaCertificosDeSeleccionados();
        }

        private void MuestraTablaCertificosDeSeleccionados()
        {
            var artistaSeleccionados = GetArtistasIdSeleccionados();
            var reporte = new XtraReport();
            reporte.CreateDocument();

            for (int i = 0; i < artistaSeleccionados.Count(); i++)
            {

                CertIndividualXtraReport XtraReport = new CertIndividualXtraReport(artistaSeleccionados[i]);
                XtraReport.CreateDocument();
                reporte.Pages.AddRange(XtraReport.Pages);
            }
            reporte.ShowRibbonPreviewDialog();
        }

        private void Certifico_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MuestraTablaCertificos();
        }

        private void MostrarBajas_barCheckItem_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MostrarBajas_barCheckItem.Checked)
            {
                MostrarBajas_barCheckItem.Caption = "Ocultar Bajas";
                Artista_gridView.Columns["FechaBaja"].FilterInfo = new ColumnFilterInfo("[FechaBaja] IS NOT NULL");
            }
            else
            {
                MostrarBajas_barCheckItem.Caption = "Mostrar Bajas";
                Artista_gridView.Columns["FechaBaja"].ClearFilter();
            }
           
            //PopulaGrid();
        }

        private void MostrarTodos_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MostrarTodos();
        }

        private void Nuevo_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (AgrupacionSelect_lookUpEdit.EditValue == null) return;
            EditIntegranteXtraForm editIntegranteXtraForm =
                new EditIntegranteXtraForm((int)AgrupacionSelect_lookUpEdit.EditValue);
            if (editIntegranteXtraForm.ShowDialog() != DialogResult.Cancel)
            {
                PopulaGrid();
            }
        }

        private void CertIndividual_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var artistas = GetArtistasSeleccionados();
            if (artistas == null) return;

            var Popup = new PopupFechaMonedaXtraUserControl();
            Popup.Moneda_layoutControlItem.HideToCustomization();
            Popup.dxValidationProvider1.ValidateHiddenControls = false;
            Popup.dxValidationProvider1.RemoveControlError(Popup.Moneda_lookUpEdit);
            if (XtraDialog.Show(Popup, "Seleccione Fecha y Moneda", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                while (!Popup.ValidateForm())
                {
                    Utils.MuestraError("Entrada de datos incorrecta, intente nuevamente");
                    Popup.Dispose();
                    Popup = new PopupFechaMonedaXtraUserControl();
                    Popup.Moneda_layoutControlItem.HideToCustomization();
                    Popup.dxValidationProvider1.ValidateHiddenControls = false;
                    XtraDialog.Show(Popup, "Seleccione Fecha y Moneda", MessageBoxButtons.OKCancel);
                }
                var reporteIncial = new XtraReport();
                foreach (var artista in artistas)
                {
                    var reporte = new CertificoIngresosPersonalesArtistaXtraReport(artista, Popup.FechaInicial, Popup.FechaFinal);
                    reporte.CreateDocument();
                    reporteIncial.Pages.AddRange(reporte.Pages);
                }
                reporteIncial.ShowRibbonPreviewDialog();
            }
        }

        private void MovAlta_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var artistaSeleccionados = GetAgrupacionDeArtistasSeleccionados();
            var reporte = new XtraReport();
            reporte.CreateDocument();
            foreach (var artistaSeleccionado in artistaSeleccionados)
            {
                if (artistaSeleccionado.FechaAlta == null)
                {
                    Utils.MuestraError(String.Format("El Integrante {0} debe tener una fecha de alta o de firma del contrato", artistaSeleccionado.Artista.NombreCompleto));
                }
                MovimientoAltaBajaXtraReport XtraReport = new MovimientoAltaBajaXtraReport(artistaSeleccionado, Enumerados.TipoMovimiento.Alta);
                XtraReport.CreateDocument();
                reporte.Pages.AddRange(XtraReport.Pages);
            }
            reporte.ShowRibbonPreviewDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var artistaSeleccionados = GetAgrupacionDeArtistasSeleccionados();
            var reporte = new XtraReport();
            reporte.CreateDocument();
            foreach (var artistaSeleccionado in artistaSeleccionados)
            {
                if (artistaSeleccionado.FechaBaja == null)
                {
                    Utils.MuestraError(String.Format("El Integrante {0} debe tener una fecha de baja ", artistaSeleccionado.Artista.NombreCompleto));
                }
                MovimientoAltaBajaXtraReport XtraReport = new MovimientoAltaBajaXtraReport(artistaSeleccionado, Enumerados.TipoMovimiento.Baja);
                XtraReport.CreateDocument();
                reporte.Pages.AddRange(XtraReport.Pages);
            }
            reporte.ShowRibbonPreviewDialog();
        }

        private void AgrupacionSelect_lookUpEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.IsLeft)
            {
                PopulaAgrupacion(false);
            }
        }

        private void Actualizar_simpleButton_Click(object sender, EventArgs e)
        {
            AGlobalDataContext = new NegocioDataContext();
            PopulaGrid();
            PopulaReservas();
            PopulaAgrupacion(false);
            AgrupacionSelect_lookUpEdit.ResetBindings();
        }

        private void DesactivaIntegrante_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var agrupacionesArtistasSeleccionados = GetAgrupacionDeArtistasSeleccionados();
            if (agrupacionesArtistasSeleccionados == null) return;
            foreach (var agrupacionArtista in agrupacionesArtistasSeleccionados)
            {
                var artista =
                AGlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == agrupacionArtista.ArtistaId);
                if (artista == null) return;
                artista.Estado = Enumerados.EstadoArtista.Desactivado.ToEntero();
                AGlobalDataContext.SubmitChanges();
            }
            PopulaGrid();
        }

        private void ActivaIntegrante_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var agrupacionesArtistasSeleccionados = GetAgrupacionDeArtistasSeleccionados();
            if (agrupacionesArtistasSeleccionados == null) return;
            foreach (var agrupacionArtista in agrupacionesArtistasSeleccionados)
            {
                var artista =
                AGlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == agrupacionArtista.ArtistaId);
                if (artista == null) return;
                artista.Estado = Enumerados.EstadoArtista.Activo.ToEntero();
                AGlobalDataContext.SubmitChanges();
            }
            PopulaGrid();

        }

        private void EscalaSalarial_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopupAsignarEscalaXtraForm popup = new PopupAsignarEscalaXtraForm();
            if (popup.ShowDialog() != DialogResult.OK) return;
            {
                var dc = new NegocioDataContext();
                var rows = Artista_gridView.GetSelectedRows();
                foreach (var row in rows)
                {
                    var artista1 = ((AgrupacionDeArtista)Artista_gridView.GetRow(row)).Artista;
                    var artista = dc.Artista.FirstOrDefault(c => c.ArtistaID == artista1.ArtistaID);
                    artista.EscalaSalarialId = Convert.ToInt32(popup.EscalaSalarialIdSeleccionado);
                    dc.SubmitChanges();
                }
            }
            PopulaGrid();
        }

        private void establecerComoPersonaQueCobraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var agrupacionArtista = GetPrimerArtistaSeleccionado();
            if (agrupacionArtista == null)
            {
                Utils.MuestraError("Debe seleccionar un integrante");
                return;
            }
            var dc = new NegocioDataContext();
            var agrupacion = dc.Agrupacion.FirstOrDefault(c => c.AgrupacionID == agrupacionArtista.AgrupacionId);
            agrupacion.Nombre_de_Persona_Recibe_Cheque = agrupacionArtista.Artista.NombreCompleto.Trim();
            dc.SubmitChanges();
            Utils.MuestraInformacion(String.Format("Establecido {0} como la persona a cobrar cheque a partir de este momento.", agrupacion.Nombre_de_Persona_Recibe_Cheque));

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Artista_gridView_MouseEnter_1(object sender, EventArgs e)
        {
            Artista_gridView.Focus();
        }

        private List<int> _selectedDataSourceRowIndeces;

      

        private void Artista_gridView_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            if (MostrarSoloSeleccioados_barCheckItem.Checked && _selectedDataSourceRowIndeces != null)
            {
                e.Visible = _selectedDataSourceRowIndeces.Contains(e.ListSourceRow);
                e.Handled = true;
            }
            else
            {
                e.Visible = true;
            }
        }

        private void MostrarSeleccionados_barCheckItem_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            //if(MostrarSeleccionados_barCheckItem.Checked)
            Artista_gridView.RefreshData();
        }

        private void ImpTabla_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Integrantes_gridControl.ShowRibbonPrintPreview();
        }

        private void MostrarMostrarTodosbar_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarTodos();
        }

        private void MostrarSoloCatalogoItemClick(object sender, ItemClickEventArgs e)
        {
            agrupacionDeArtistaBindingSource.DataSource =
                AGlobalDataContext.AgrupacionDeArtista.Where(c => c.Agrupacion.PerteneceACatalogo && !c.Agrupacion.DobleVinculo);
        }

        private void MostrarMostrarDobleVinculos_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            agrupacionDeArtistaBindingSource.DataSource =
                AGlobalDataContext.AgrupacionDeArtista.Where(c => c.Agrupacion.PerteneceACatalogo && c.Agrupacion.DobleVinculo);
        }

        private void MostrarMostrarOciasionales_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            agrupacionDeArtistaBindingSource.DataSource =
                AGlobalDataContext.AgrupacionDeArtista.Where(c => !c.Agrupacion.PerteneceACatalogo && !c.Agrupacion.DobleVinculo);
        }

        private void MostrarAltasYBajas_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            Artista_gridView.Columns["FechaBaja"].ClearFilter();
        }

        private void MostrarSoloAltas_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Artista_gridView.Columns["FechaBaja"].FilterInfo = new ColumnFilterInfo("[FechaBaja] IS NULL");
        }

        private void MostrarSoloBjas_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Artista_gridView.Columns["FechaBaja"].FilterInfo = new ColumnFilterInfo("[FechaBaja] IS NOT NULL");

        }
    }
}