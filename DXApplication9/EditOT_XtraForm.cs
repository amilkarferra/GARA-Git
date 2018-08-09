using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DXApplication9.ReportesSistema;

namespace DXApplication9
{

    public partial class EditOtXtraForm : BaseXtraForm
    {
        private NegocioDataContext AGLobalDataContext = new NegocioDataContext();
        private Guid AOrdenDeTrabajoId;
        public OrdenDeTrabajo GlobalActividad;
        private bool AIsAnUpdate;
        private Enumerados.TipoActividad ATipoDeActividad;
        private bool AGeneraActualizacionDeTablaDeActividades;
        //public OrdenDeTrabajo _ActividadPendienteActualizar;


        public EditOtXtraForm(Enumerados.TipoActividad tipoActividad)
        {

            ATipoDeActividad = tipoActividad;
            AIsAnUpdate = false;
            InitializeComponent();
      
            try
            {
                SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);
            }
            catch (Exception)
            {

                SplashScreenManager.CloseForm();
                SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);

            }
            PopulaControles();
            AcomodaSegunTipoActividad();
            this.DialogResult = DialogResult.OK;
            var ultimaOrden = OrdenDeTrabajo.GetUltimaActividad(ATipoDeActividad);
            FechaConfecciontimeEdit.DateTime = DateTime.Today;
                FechaConfecciontimeEdit.Properties.MinValue = fechaIncialActividadDateEdit.Properties.MinValue = fechaFinalActividadDateEdit.Properties.MinValue =ultimaOrden !=null?ultimaOrden.FechaConfeccion:DateTime.Today;
        }



        private void AcomodaSegunTipoActividad()
        {
            Principal_TabbedControlGroup.SelectedTabPage = Principal_Tab;
            switch (ATipoDeActividad)
            {
                case Enumerados.TipoActividad.OrdenDeTrabajo :
                    this.Text = "Orden De Trabajo";
                    Conceptos_Tab.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    Observaciones_layoutControlItem.HideToCustomization();
                    Proyectos_layoutControlItem.HideToCustomization();
                    EsProyecto_layoutControlItem.HideToCustomization();
                    //emptySpaceItem7.HideToCustomization();
                    Width = 503;
                    Height = 397;
                    NumOT_labelControl.Width = layoutControlItem4.Width;
                    //emptySpaceItem7.HideToCustomization();
                    // emptySpaceItem1.Width = Width - layoutControlGroup2.Width;
                    //      emptySpaceItem5.HideToCustomization();
                    break;
                case Enumerados.TipoActividad.Factura:
                    Conceptos_Tab.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    Text = "Factura de Exportación en Frontera";
                    NroCttoOT_layoutControlItem.HideToCustomization();
                    CoverCheckbox_layoutControlItem.HideToCustomization();
                    ImporteActividad_layoutControlItem.HideToCustomization();
                    CantAct_layoutControlItem.HideToCustomization();
                    PopulaImporteGridControl();
                    Conceptos_Tab.Enabled = AIsAnUpdate;
                    Width = 576;
                    Height = 430;
                    break;
                case Enumerados.TipoActividad.ProduccionInterna:
                    Text = "Producción Interna";
                    Conceptos_Tab.HideToCustomization();
                    Observaciones_layoutControlItem.HideToCustomization();
                    //Proyectos_layoutControlItem.HideToCustomization();
                    EsProyecto_layoutControlItem.HideToCustomization();
                    Proyectos_SearchlookUpEdit.Enabled = true;
                   Cliente_layoutControlItem.HideToCustomization();
                    //clienteQueContrataIdComboBoxEdit.Enabled = false;
                    NroCttoOT_layoutControlItem.HideToCustomization();
                    Proyectos_layoutControlItem.TextSize = new Size(108,26);
                    //emptySpaceItem7.HideToCustomization();
                    Width = 503;
                    Height = 397;
                    // emptySpaceItem1.Width = Width - emptySpaceItem7.Width;
                    //   emptySpaceItem5.HideToCustomization();
                    break;

                //case Enumerados.TipoActividad.Proyecto:
                //    break;
                default:
                    throw new ArgumentOutOfRangeException("tipoActividad", ATipoDeActividad, null);
            }
        }

        /// <summary>
        /// Abre el formulario de edicion de una orden de trabajo específica
        /// </summary>
        /// <param name="anOrdenDeTrabajoId"></param>
        /// <param name="obligaEditarFechas">si es true luego de abrir el formulario limpia los cambios de fecha
        /// util para cuando se duplica una orden de trabajo</param>
        public EditOtXtraForm(Guid anOrdenDeTrabajoId,bool obligaEditarFechas=false)
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
            

            AIsAnUpdate = true;
            InitializeComponent();
            AgrupacionControl.Properties.Buttons[1].Enabled = true;
            FechaConfecciontimeEdit.DateTime = DateTime.Today;
            AOrdenDeTrabajoId = anOrdenDeTrabajoId;

            GlobalActividad =
                AGLobalDataContext.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == AOrdenDeTrabajoId);
            Text += " " + GlobalActividad.ConsecutivoString;
            ATipoDeActividad = (Enumerados.TipoActividad) Enum.Parse(typeof (Enumerados.TipoActividad),
                GlobalActividad.TipoActividad.ToString());
            if (GlobalActividad != null)
            {
                PopulaControles();
                if (ATipoDeActividad == Enumerados.TipoActividad.Factura)
                {
                   EsProyeco_checkEdit.Checked = GlobalActividad.ProyectosId != null;
                    PopulaImporteGridControl();
                }
            }
            AcomodaSegunTipoActividad();
            NumOT_labelControl.Text = GlobalActividad.NumeroDeOrden;
            NumOT_labelControl.ForeColor = Color.DarkBlue;
            FechaConfecciontimeEdit.EditValue = GlobalActividad.FechaConfeccion;
            fechaIncialActividadDateEdit.EditValue = GlobalActividad.FechaIncialActividad;
            fechaFinalActividadDateEdit.EditValue = GlobalActividad.FechaFinalActividad;
            if (!GlobalActividad.Agrupacion.PerteneceACatalogo)
                CargaTodasAgrupaciones();
            AgrupacionControl.EditValue = GlobalActividad.AgrupacionId;
            monedaLookUpEdit.EditValue = GlobalActividad.TipoMonedaId;
            clienteQueContrataIdComboBoxEdit.EditValue = GlobalActividad.ClienteQueContrataId;
            if (GlobalActividad.ProyectosId != null) Proyectos_SearchlookUpEdit.EditValue = GlobalActividad.ProyectosId;
            Observaciones_memoExEdit.EditValue = GlobalActividad.Observaciones;
            Cover_checkEdit.Checked = GlobalActividad.EsPorCover;
            lugarDePresentacionTextEdit.Text = GlobalActividad.LugarDePresentacion;
            importePorActividadTextEdit.EditValue = GlobalActividad.ImportePorActividad;
            NumeroContrato_textEdit.Text = GlobalActividad.NumeroContrato;
            cantidadActividadesSpinEdit.EditValue = GlobalActividad.CantidadActividades;
            Recordatorio_memoEdit.Text = GlobalActividad.Nota;
            if (obligaEditarFechas)
            {
                fechaIncialActividadDateEdit.Text = "";
                fechaFinalActividadDateEdit.Text = "";
            }
        }

        private void ordenDeTrabajoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.ordenDeTrabajoBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.artistasDataSet);

        }

        private void EditOT_XtraForm_Load(object sender, EventArgs e)
        {
            try
            {

                SplashScreenManager.CloseForm();
            }
            catch (Exception)
            {
                // ignored
            }
            // TODO: This line of code loads data into the 'artistasDataSet.OrdenDeTrabajo' table. You can move, or remove it, as needed.


        }

        private void FechaConfecciontimeEdit_EditValueChanged(object sender, EventArgs e)
        {
            fechaIncialActividadDateEdit.Properties.MinValue = fechaIncialActividadDateEdit.DateTime;
        }

        private void fechaIncialActividadDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            fechaFinalActividadDateEdit.Properties.MinValue = fechaIncialActividadDateEdit.DateTime;
            fechaFinalActividadDateEdit.DateTime = fechaIncialActividadDateEdit.DateTime;
            clienteQueContrataIdComboBoxEdit.Properties.DataSource =
                AGLobalDataContext.ControlClientes.Where(
                    c =>c.EstadoId != Enumerados.EstadoContrato.Cancelado.Value() & c.Vigencia != null && c.Vigencia > fechaIncialActividadDateEdit.DateTime)
                    .OrderBy(c => c.FechaContrato.Year)
                    .ThenBy(a => a.NumeroContrato);
            
        }
        private void Salvar_simpleButton_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (!AIsAnUpdate)
                {
                    var ordenSemejante = OrdenDeTrabajo.GetActividadSemejante(fechaIncialActividadDateEdit.DateTime,
                        Convert.ToInt32(clienteQueContrataIdComboBoxEdit.EditValue),
                        Convert.ToInt32(monedaLookUpEdit.EditValue), Convert.ToInt32(AgrupacionControl.EditValue));
                    if (ordenSemejante != null)
                        if (
                            MessageBox.Show(
                                string.Format(
                                    "La orden {0} confeccionada el {1} con lugar de presentacion: {2}, tiene datos muy semejantes. Desea salvar, no obstante, la orden de trabajo actual?",
                                    ordenSemejante.ConsecutivoString, ordenSemejante.FechaConfeccion,
                                    ordenSemejante.LugarDePresentacion), "Atención", MessageBoxButtons.OKCancel) !=
                            DialogResult.OK)
                        {
                            return;
                        }
                }

                if (SalvarActividad())
                {
                    XtraMessageBox.Show(this,"Datos salvados correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AIsAnUpdate = true;

                }
                else
                {
                    MessageBox.Show("Error salvando los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Compruebe entrada de datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }



        }

        private bool SalvarActividad()
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return false;
                var actividad = GetOrdenDeFormulario();
                if (actividad == null)
                {
                    if (ATipoDeActividad == Enumerados.TipoActividad.Factura)
                        Conceptos_Tab.Enabled = false;
                    MessageBox.Show("Error alsalvar datos, Verifique los datos insertados", "Error");
                    return false;
                }


                if (actividad.TieneNominaAsociada && !LoginHelper.EliminaValidacion)
                {
                    MessageBox.Show("La actividad tiene una nomina asociada por lo que no puede editarse");
                    return false;
                }
                GlobalActividad =OrdenDeTrabajo.SalvaActividad(actividad.AgrupacionId, actividad.NumeroContrato,
                    actividad.FechaConfeccion,
                    actividad.FechaIncialActividad, actividad.FechaFinalActividad, actividad.ClienteQueContrataId,
                    actividad.LugarDePresentacion, actividad.ImportePorActividad, actividad.TipoMonedaId,
                    actividad.CantidadActividades,
                    actividad.OrdenDeTrabajoID, ATipoDeActividad, actividad.EsPorCover, AIsAnUpdate ? actividad.Anno : ConfiguracionGeneral.Anno,actividad.Observaciones,actividad.Nota, actividad.ProyectosId,AGLobalDataContext);
                AgrupacionControl.Properties.Buttons[1].Enabled = GlobalActividad != null;

                //_GLobalDataContext = new NegocioDataContext();
                NumOT_labelControl.Text = GlobalActividad.NumeroDeOrden;
                AOrdenDeTrabajoId = GlobalActividad.OrdenDeTrabajoID;
                //PrintPreview_simpleButton.Enabled = true;
                NumOT_labelControl.ForeColor = Color.DarkBlue;
                NumOT_labelControl.ToolTip = "Numero de la Orden de Trabajo";
                //GlobalActividad = _Actividad;
                AGeneraActualizacionDeTablaDeActividades = true;
                if (ATipoDeActividad != Enumerados.TipoActividad.Factura) return true;
                PopulaImporteGridControl();
                Conceptos_Tab.Enabled = true;
                Principal_TabbedControlGroup.SelectedTabPage = Conceptos_Tab;
              
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        private OrdenDeTrabajo GetOrdenDeFormulario()
        {

            OrdenDeTrabajo orden = new OrdenDeTrabajo();

            if (clienteQueContrataIdComboBoxEdit.EditValue == null) return null;
            orden.ClienteQueContrataId = Convert.ToInt32(clienteQueContrataIdComboBoxEdit.EditValue);
            if (AgrupacionControl.EditValue == null) return null;
            orden.AgrupacionId = Convert.ToInt32(AgrupacionControl.EditValue);
            orden.Consecutivo = OrdenDeTrabajo.GetConsecutivoByNroDeOrden(NumOT_labelControl.Text);
            orden.Anno = OrdenDeTrabajo.GetAnnoByNroDeOrden(NumOT_labelControl.Text);
            if (FechaConfecciontimeEdit.EditValue == null) return null;
            orden.FechaConfeccion = (DateTime)FechaConfecciontimeEdit.EditValue;
            if (fechaFinalActividadDateEdit.EditValue == null) return null;
            orden.FechaFinalActividad = Convert.ToDateTime(fechaFinalActividadDateEdit.EditValue);
            if (fechaIncialActividadDateEdit.EditValue == null) return null;
            orden.FechaIncialActividad = Convert.ToDateTime(fechaIncialActividadDateEdit.EditValue);
            orden.ImportePorActividad = Cover_checkEdit.Checked
                ? 0
                : Convert.ToDecimal(importePorActividadTextEdit.EditValue);
            orden.CantidadActividades = Convert.ToInt32(cantidadActividadesSpinEdit.EditValue);
            orden.LugarDePresentacion = lugarDePresentacionTextEdit.Text == null
                ? ""
                : lugarDePresentacionTextEdit.EditValue.ToString();
            if (NumeroContrato_textEdit.EditValue == null && ATipoDeActividad == Enumerados.TipoActividad.OrdenDeTrabajo)
                return null;
            orden.NumeroContrato = Convert.ToString(NumeroContrato_textEdit.EditValue);
            if (monedaLookUpEdit.EditValue == null) return null;
            orden.OrdenDeTrabajoID = AOrdenDeTrabajoId;
            orden.TipoMonedaId = Convert.ToInt32(monedaLookUpEdit.EditValue);
            orden.EsPorCover = Cover_checkEdit.Checked;
            orden.Observaciones = Observaciones_memoExEdit.Text;
            orden.Nota = Recordatorio_memoEdit.Text;
            if (Proyectos_SearchlookUpEdit.EditValue != null) orden.ProyectosId = Guid.Parse(Proyectos_SearchlookUpEdit.EditValue.ToString());
            if (!string.IsNullOrEmpty(Recordatorio_memoEdit.Text)) orden.Nota = Recordatorio_memoEdit.Text;
            return orden;
        }



        private void Cover_checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (Cover_checkEdit.Checked)
            {
                if (importePorActividadTextEdit.Text.Trim() != string.Empty)
                    if (
                        MessageBox.Show(
                            "Esta acción eliminará los valores que se hayan insertado con anterioridad, esta seguro?",
                            "ESTA SEGURO?", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
                    {
                        Cover_checkEdit.Checked = false;
                        return;
                    }
                importePorActividadTextEdit.EditValue = null;
                importePorActividadTextEdit.Enabled = false;

            }
            else
            {
                importePorActividadTextEdit.Reset();
                importePorActividadTextEdit.Enabled = true;
            }
        }

        private void PopulaControles()
        {
            var proximoNumeroOt = OrdenDeTrabajo.GetProximoNumeroDeActividad(ATipoDeActividad);
            if (proximoNumeroOt == string.Empty) return;
            monedaLookUpEdit.Properties.DataSource = AGLobalDataContext.TipoMoneda.Where(c => c.OrdenDeTrabajo);
            AgrupacionControl.Properties.DataSource = AGLobalDataContext.Agrupacion.Where(a => a.PerteneceACatalogo).OrderBy(c => c.Nombre);
            cantidadActividadesSpinEdit.EditValue = 1;
            FechaConfecciontimeEdit.DateTime = DateTime.Today;
            NumOT_labelControl.Text = proximoNumeroOt;
            fechaIncialActividadDateEdit.Properties.MinValue = FechaConfecciontimeEdit.DateTime;
            fechaFinalActividadDateEdit.Properties.MinValue = FechaConfecciontimeEdit.DateTime;
            NumOT_labelControl.ToolTip =
                string.Format("Numero de Orden de Trabajo Propuesto, este número puede variar una vez salvada la misma");
            proyectosBindingSource.DataSource = AGLobalDataContext.Proyectos;

            

        }

        private void LimpiaControles()
        {
            AgrupacionControl.EditValue = null;
            importePorActividadTextEdit.EditValue = null;
            clienteQueContrataIdComboBoxEdit.EditValue = null;
            fechaFinalActividadDateEdit.EditValue =
                fechaIncialActividadDateEdit.EditValue = FechaConfecciontimeEdit.EditValue = null;
            lugarDePresentacionTextEdit.EditValue =
                NumeroContrato_textEdit.EditValue = monedaLookUpEdit.EditValue = null;
            FechaConfecciontimeEdit.EditValue = DateTime.Today;
        }

        private void SugiereNumeroContrato()
        {
            //if (TipoDeActividad != Enumerados.TipoActividad.OrdenDeTrabajo) return;
            //if (AgrupacionControl.EditValue == null || monedaLookUpEdit.EditValue == null ||
            //    clienteQueContrataIdComboBoxEdit.EditValue == null) return;
            //int _AgrupacionId = (int)AgrupacionControl.EditValue;
            //int _MonedaId = (int)monedaLookUpEdit.EditValue;
            //int _Cliente = (int)clienteQueContrataIdComboBoxEdit.EditValue;
            //if (_AgrupacionId == 0 || _MonedaId == 0 || _Cliente == 0) return;
            //string _NumeroContrato = OrdenDeTrabajo.GetNumeroDeContratoEnTurno(_AgrupacionId, _MonedaId, _Cliente);
            if (clienteQueContrataIdComboBoxEdit.EditValue == null) return;
            var contrato =
                AGLobalDataContext.ControlClientes.FirstOrDefault(
                    c => c.ControlClienteID == (int) clienteQueContrataIdComboBoxEdit.EditValue);
            NumeroContrato_textEdit.Text = contrato.NumeroContratoString; 
        }

        private void AgrupacionControl_EditValueChanged(object sender, EventArgs e)
        {
            SugiereNumeroContrato();
        }

        private void monedaLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            SugiereNumeroContrato();
        }

        private void clienteQueContrataIdComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            SugiereNumeroContrato();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SugiereNumeroContrato();
            NumeroContrato_textEdit.Focus();
        }

        private void Ot_Report_simpleButton_Click(object sender, EventArgs e)
        {

            var ordenDeTrabajo = OrdenDeTrabajo.GetOrdenDeTrabajoById(AOrdenDeTrabajoId);
            if (ordenDeTrabajo == null)
            {
                MessageBox.Show("Salve Antes la orden de Trabajo");

            }
            else
                ordenDeTrabajo.MuestraReporte();
        }

        private void DeleteOT_simpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GlobalActividad.EsUltima)
                {
                    XtraMessageBox.Show("Esta no es la ultima actividad  por lo que no puede ser eliminada", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }



                if (
                    XtraMessageBox.Show(
                        "Está usted seguro que desea eliminar la esta actividad, esta acción es irreversible",
                        "Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {
                        AGLobalDataContext.OrdenDeTrabajo.DeleteOnSubmit(GlobalActividad);
                        AGLobalDataContext.SubmitChanges();
                        Close();
                    }
                    catch (Exception)
                    {

                        XtraMessageBox.Show("Error");
                    }
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Error eliminando la orden de trabajo");
            }
        }

        private void SalvarSalir_simpleButton_Click(object sender, EventArgs e)
        {
            if (SalvarActividad())
            {
                XtraMessageBox.Show("Datos salvados correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {
                MessageBox.Show("Error salvando los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Close();
        }



        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            if (!AGeneraActualizacionDeTablaDeActividades)
                DialogResult = DialogResult.Cancel;
            DialogResult = DialogResult.OK;
           Close();

        }

        private void SalvarNuevaSimpleButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                if (SalvarActividad())
                {
                    XtraMessageBox.Show("Datos salvados correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    MessageBox.Show("Error salvando los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                GlobalActividad = null;AOrdenDeTrabajoId = Guid.Empty;
                PopulaControles();
                LimpiaControles();
                var proximoNumeroOt = OrdenDeTrabajo.GetProximoNumeroDeActividad(ATipoDeActividad);
                NumOT_labelControl.Text = proximoNumeroOt;
                NumOT_labelControl.ForeColor = Color.Crimson;
                AOrdenDeTrabajoId = Guid.NewGuid();
                if (ATipoDeActividad == Enumerados.TipoActividad.Factura) PopulaImporteGridControl();

            }
        }

        private void Duplicar_simpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevaOrden = OrdenDeTrabajo.DuplicarActividad(GlobalActividad, AGLobalDataContext);
                if (nuevaOrden == null) return;
                EditOtXtraForm nuevoForm = new EditOtXtraForm(nuevaOrden.OrdenDeTrabajoID,true);
                Hide();
                nuevoForm.ShowDialog();
                DialogResult=DialogResult.OK;

            }
            //try
            //{
            //    if (TipoDeActividad == Enumerados.TipoActividad.Factura)
            //    {
            //        if (
            //            MessageBox.Show("Al duplicar una factura la nueva factura se salva automaticamente, si no esta de acuerdo con el resultado obtenido o si desea cancelar la acción debera eliminar la nueva factura creada", "Atención", MessageBoxButtons.OKCancel) ==
            //            DialogResult.Cancel) return;
            //    }
            //    IsAnUpdate = true;
            //    //SalvarActividad();
            //    var activdadIdOriginal = GlobalActividad.OrdenDeTrabajoID;
            //    OrdenDeTrabajoId = Guid.Empty; var _ProximoNumeroOT = OrdenDeTrabajo.GetProximoNumeroDeActividad(TipoDeActividad);
            //    NumOT_labelControl.Text = _ProximoNumeroOT;
            //    NumOT_labelControl.ForeColor = Color.Crimson;
            //    SugiereNumeroContrato();
            //    OrdenDeTrabajoId = Guid.NewGuid();
            //    FechaConfecciontimeEdit.DateTime = DateTime.Today;
            //    if (TipoDeActividad != Enumerados.TipoActividad.Factura)
            //        fechaFinalActividadDateEdit.Text = fechaIncialActividadDateEdit.Text = String.Empty;
            //    if (TipoDeActividad == Enumerados.TipoActividad.Factura)
            //    {
            //        fechaFinalActividadDateEdit.DateTime = GlobalActividad.FechaFinalActividad;
            //        fechaIncialActividadDateEdit.DateTime = GlobalActividad.FechaIncialActividad;
            //        if (SalvarActividad())
            //        {

            //            XtraMessageBox.Show("Datos salvados correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //        }
            //        else
            //        {
            //            MessageBox.Show("Error salvando los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //        if (TipoDeActividad == Enumerados.TipoActividad.Factura)
            //        {
            //            var importesEnFacturaOriginal =
            //                _GLobalDataContext.ImportesDeFacturaEnFrontera.Where(c => c.ActividadId == activdadIdOriginal);
            //            foreach (var c in importesEnFacturaOriginal)
            //            {
            //                var importe = new ImportesDeFacturaEnFrontera
            //                {
            //                    ActividadId = GlobalActividad.OrdenDeTrabajoID,
            //                    Cantidad = c.Cantidad,
            //                    Descripción = c.Descripción,
            //                    ImporteUnitario = c.ImporteUnitario,
            //                    TipoImporte = c.TipoImporte
            //                };
            //                GlobalActividad.ImportesDeFacturaEnFrontera.Add(importe);
            //            }
            //            _GLobalDataContext.SubmitChanges();
            //            PopulaImporteGridControl();
            //        }

            //        fechaFinalActividadDateEdit.Text = fechaIncialActividadDateEdit.Text = String.Empty;
            //    }
            //}
            catch ( Exception)
            {

                XtraMessageBox.Show("Ha existido algun error en el proceso");
            }

        }

        private void PopulaImporteGridControl()
        {
            if (GlobalActividad != null)
            {
                importesDeFacturaEnFronteraBindingSource.DataSource =
                     AGLobalDataContext.ImportesDeFacturaEnFrontera.Where(
                         c => c.ActividadId == GlobalActividad.OrdenDeTrabajoID);
            }
            else
            {
                Importes_gridControl.Enabled = false;
            }

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            Importes_gridView.SetRowCellValue(e.RowHandle, colActividadId, GlobalActividad.OrdenDeTrabajoID);

        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            AGLobalDataContext.SubmitChanges();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                var importeDeFactura = (ImportesDeFacturaEnFrontera)e.Row;
                importeDeFactura.ActividadId = GlobalActividad.OrdenDeTrabajoID;// importeDeFactura.ActividadId = _GlobalActividad.OrdenDeTrabajoID;
                AGLobalDataContext.SubmitChanges();
                //_GlobalActividad.ImportePorActividad = _GlobalActividad.GetImporteDeFactura();
                var importesDeFacturaEnFronteras = GlobalActividad.ImportesDeFacturaEnFrontera;
                if (importesDeFacturaEnFronteras.Any())
                {
                    int sum = 0;
                    foreach (var importesDeFacturaEnFrontera in importesDeFacturaEnFronteras)
                    {
                        if (importesDeFacturaEnFrontera.Cantidad != null)
                            sum += Convert.ToInt32(importesDeFacturaEnFrontera.Cantidad);
                    }
                    GlobalActividad.CantidadActividades = sum;

                }
                AGLobalDataContext.SubmitChanges();

            }
            catch (Exception)
            {
                Importes_gridView.DeleteRow(e.RowHandle);
            }

        }

        private void ActualizaIntegrante_simpleButton_Click(object sender, EventArgs e)
        {
            ActualizaIngrantesDeActividad();
        }

        private void ActualizaIngrantesDeActividad()
        {
            if (GlobalActividad.OrdenDeTrabajoID == Guid.Empty) return;
            OrdenDeTrabajo.EliminarParticipantesDeActividad(AOrdenDeTrabajoId, AGLobalDataContext);
            OrdenDeTrabajo.InsertaParticipantesDeActividad(AOrdenDeTrabajoId, AGLobalDataContext);
        }


        private void ImprimirOt_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            XtraReport reporte = GetReporteCompletoOt();
            XtraReport reporte2 = GetReporteCompletoOt();
            reporte.Pages.AddRange(reporte2.Pages);
            ReportPrintTool pt = new ReportPrintTool(reporte);
            pt.Print();
        }



        private void VistaPreliminarOt_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var reporte = GetReporteCompletoOt();
            reporte.ShowRibbonPreview();
        }
        private XtraReport GetReporteCompletoOt()
        {
            if (GlobalActividad == null)
            {
                if (!SalvarActividad())
                {
                    XtraMessageBox.Show("Verifique datos de la orden de trabajo", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
            }
            // SalvarActividad();
            AGLobalDataContext = new NegocioDataContext();
            var actividadContext =
                               AGLobalDataContext.OrdenDeTrabajo.FirstOrDefault(
                                   c => c.OrdenDeTrabajoID == GlobalActividad.OrdenDeTrabajoID);
            switch (ATipoDeActividad)
            {
                case Enumerados.TipoActividad.Factura:
                    FactExportXtraReport factura = new FactExportXtraReport(actividadContext);
                    factura.CreateDocument();
                    return factura;
                case Enumerados.TipoActividad.OrdenDeTrabajo:
                {
                    OrdenDeTrabajoXtraReport reporte = new OrdenDeTrabajoXtraReport(actividadContext);
                    reporte.CreateDocument();
                    M2XtraReport m2XtraReport = new M2XtraReport(actividadContext);
                    m2XtraReport.CreateDocument();
                    reporte.Pages.AddRange(m2XtraReport.Pages);
                    return reporte;
                }
                case Enumerados.TipoActividad.ProduccionInterna:
                {
                    ProduccionInternaXtraReport reporte = new ProduccionInternaXtraReport(actividadContext);
                    reporte.CreateDocument();
                    M2XtraReport m2XtraReport = new M2XtraReport(actividadContext);
                    m2XtraReport.CreateDocument();
                    reporte.Pages.AddRange(m2XtraReport.Pages);
                    return reporte;
                }
            }
            return null;
        }

        
        private void Print_dropDownButton_Click(object sender, EventArgs e)
        {
            var ordenDeTrabajo = OrdenDeTrabajo.GetOrdenDeTrabajoById(AOrdenDeTrabajoId);
            if (ordenDeTrabajo == null)
            {
                MessageBox.Show("Salve Antes la orden de Trabajo");
                Print_dropDownButton.DropDownControl = null;
            }
            else
            {
                Print_dropDownButton.DropDownControl = Print_popupMenu;
            }
        }

        private void AgrupacionControl_EditValueChanged_1(object sender, EventArgs e)
        {
          var  agrupacionId =Convert.ToInt32(AgrupacionControl.EditValue);
            if (agrupacionId == 0) return;
            var agrupacion = AGLobalDataContext.Agrupacion.FirstOrDefault(c => c.AgrupacionID == agrupacionId);
            if (agrupacion.EsProyecto)
            {
                proyectosBindingSource.DataSource = AGLobalDataContext.Proyectos;
                Proyectos_SearchlookUpEdit.ResetBindings();
                Proyectos_SearchlookUpEdit.Enabled = true;

                ConditionValidationRule rule = new ConditionValidationRule
                {
                    ConditionOperator = ConditionOperator.IsNotBlank,
                    ErrorText = "Obligatorio"
                };
                dxValidationProvider1.SetValidationRule(Proyectos_SearchlookUpEdit, rule);
            }
            else
            {
                dxValidationProvider1.SetValidationRule(Proyectos_SearchlookUpEdit,null);
            }
        }

        private void AgrupacionControl_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph & !e.Button.IsLeft )
            {
                ActualizaIngrantesDeActividad();
                XtraMessageBox.Show("Integrantes de la actividad actualizados correctamente", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (e.Button.IsLeft)
            {
                CargaTodasAgrupaciones();
             //   AgrupacionControl.ResetBindings();
            }


        }

        private void CargaTodasAgrupaciones()
        {
            AgrupacionControl.Properties.DataSource = AGLobalDataContext.Agrupacion.OrderBy(c => c.Nombre);
            AgrupacionControl.ResetBindings();
        }

        private void Proyectos_SearchlookUpEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                PopupProyectoNacionalXtraForm popup = new PopupProyectoNacionalXtraForm(null,AGLobalDataContext);
                if (popup.ShowDialog(this) == DialogResult.OK)
                {
                    AGLobalDataContext = new NegocioDataContext();
                    proyectosBindingSource.ResetBindings(false);
                    Proyectos_SearchlookUpEdit.Properties.DataSource = new NegocioDataContext().Proyectos;
                    Proyectos_SearchlookUpEdit.EditValue = popup.GlobalProyecto.ProyectoID;
                  
                }
               
            }
        }

        private void Importes_gridControl_Click(object sender, EventArgs e)
        {

        }

        private void Importes_gridView_Click(object sender, EventArgs e)
        {
            var row = 0;
            var column = GetClickedInformation(Importes_gridControl, Importes_gridView, out row);
            if (column != null)
            {
                if (column == EliminarConcepto_gridColumn)
                {
                    var importe = (ImportesDeFacturaEnFrontera)Importes_gridView.GetRow(row);
                    if (GlobalActividad.EliminaImportesDeFactura(importe))
                    {
                        Importes_gridView.DeleteRow(row);
                    }

                }


            }
            
        }

        private void Print_dropDownButton_Click_1(object sender, EventArgs e)
        {
            if (GlobalActividad.TipoActividad == (int) Enumerados.TipoActividad.Factura)
            {
                if (!(Importes_gridView.RowCount > 0))
                {
                    Print_dropDownButton.DropDownControl = null;
                    //Print_popupMenu.HidePopup();
                    Utils.MuestraInformacion("La Factura está vacía, no se puede mostrar el reporte");

                }
                else
                {
                    Print_dropDownButton.DropDownControl = Print_popupMenu;
                    
                }
            }
        }

        private void EsProyeco_checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            Proyectos_SearchlookUpEdit.Enabled = EsProyeco_checkEdit.Checked;

        }

        private void Proyectos_SearchlookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Proyectos_SearchlookUpEdit.EditValue != null)
            {
                var proyectoId = (Guid)Proyectos_SearchlookUpEdit.EditValue;
                var proyecto = AGLobalDataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == proyectoId);
                if (proyecto != null) clienteQueContrataIdComboBoxEdit.EditValue = proyecto.ControlClienteId;
            }
        }

        private void AgrupacionControl_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {

        }

        private void NuevoConcepto_simpleButton_Click(object sender, EventArgs e)
        {
           // Importes_gridView.;
        }
    }
}

