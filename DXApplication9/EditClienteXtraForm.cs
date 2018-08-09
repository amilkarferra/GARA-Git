using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using DXApplication9.ReportesSistema;

namespace DXApplication9
{
    public partial class EditClienteXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public ControlClientes GlobalControlClientes;
        private NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private bool AClienteSalvado;
        private bool ANacional;

        public EditClienteXtraForm(ControlClientes aControlDeClientes = null)
        {
            try
            {
                GlobalControlClientes = aControlDeClientes != null ? AGlobalDataContext.ControlClientes.FirstOrDefault(c => c.ControlClienteID == aControlDeClientes.ControlClienteID) : new ControlClientes();
                InitializeComponent();
                paisesBindingSource.DataSource = AGlobalDataContext.Paises;
                empresariosBindingSource.DataSource = AGlobalDataContext.Empresarios;
                estadoContratoBindingSource.DataSource = Enumerados.ListaDeEnumerados(typeof (Enumerados.EstadoContrato));
                EmpresarioLayout_layoutControlItem.HideToCustomization();
                Cuentas_simpleButton.Enabled = aControlDeClientes != null;
                HabilitaBotonCrearCarpeta();
                if (aControlDeClientes != null)
                {
                    NumeroContrato_textEdit.EditValue = GlobalControlClientes.NumeroContrato;
                    Pais_lookUpEdit.EditValue = GlobalControlClientes.PaisId;
                    NombreEntidad_textEdit.EditValue = GlobalControlClientes.NombreDeEntidad;
                    Telefono_textEdit.EditValue = GlobalControlClientes.Teléfono;
                    Email_textEdit.EditValue = GlobalControlClientes.Email;
                    Direccion_textEdit.EditValue = GlobalControlClientes.Dirección;
                    representante_textEdit.EditValue = GlobalControlClientes.Representante;
                    CargoRepresentante_textEdit.EditValue = GlobalControlClientes.CargoRepresentante;
                    FechaContrato_dateEdit.DateTime = GlobalControlClientes.FechaContrato;
                    if (GlobalControlClientes.Vigencia != null)
                        Vigente_dateEdit.DateTime = (DateTime)GlobalControlClientes.Vigencia;
                    if (GlobalControlClientes.EmpresarioId != null)
                        Empresario_lookUpEdit.EditValue = GlobalControlClientes.EmpresarioId;
                    EstadoContrato_lookUpEdit.EditValue = aControlDeClientes.EstadoId;
                    Reeup_textEdit.EditValue = GlobalControlClientes.Reup;
                    Nit_textEdit.EditValue = GlobalControlClientes.Nit;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            //else
            //{
            //    FechaContrato_dateEdit.DateTime = DateTime.Today;
            //    Vigente_dateEdit.DateTime = DateTime.Today.Date.AddMonths(6);
            //}
        }

        private void Aceptar_simpleButton_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider2.Validate())
                try
                {
                    ActualizaCliente();
                    if (GlobalControlClientes.ControlClienteID == 0)
                    {
                        GlobalControlClientes.NumeroContrato = ControlClientes.GetProximoNumeroContrato(ANacional);
                        AGlobalDataContext.ControlClientes.InsertOnSubmit(GlobalControlClientes);
                    }
                        
                    AGlobalDataContext.SubmitChanges();
                    AClienteSalvado = true;
                    //DialogResult = DialogResult.OK;
                    Cuentas_simpleButton.Enabled = true;
                    NumeroContrato_textEdit.EditValue = GlobalControlClientes.NumeroContrato;
                    NumeroContrato_textEdit.ForeColor = Color.ForestGreen;
                    HabilitaBotonCrearCarpeta();

                }
                catch (Exception)
                {

                    MessageBox.Show("Error Salvando Datos");
                }
        }

        private void ActualizaCliente()
        {
            GlobalControlClientes.Representante = representante_textEdit.EditValue.ToString().Trim();
            GlobalControlClientes.CargoRepresentante = CargoRepresentante_textEdit.EditValue.ToString().Trim();
            if (Direccion_textEdit.EditValue != null)
                GlobalControlClientes.Dirección = Direccion_textEdit.EditValue.ToString().Trim();
            if (Email_textEdit.EditValue != null)
                GlobalControlClientes.Email = Email_textEdit.EditValue.ToString().Trim();
            GlobalControlClientes.FechaContrato = (DateTime)(GlobalControlClientes.ControlClienteID == 0 ? FechaContrato_dateEdit.EditValue ?? DateTime.Today : GlobalControlClientes.FechaContrato);
            GlobalControlClientes.Vigencia = Vigente_dateEdit.DateTime;
            GlobalControlClientes.PaisId = (int)Pais_lookUpEdit.EditValue;
            GlobalControlClientes.NombreDeEntidad = NombreEntidad_textEdit.EditValue.ToString().Trim();
            if (Telefono_textEdit.EditValue != null)
                GlobalControlClientes.Teléfono = Telefono_textEdit.EditValue.ToString().Trim();
            GlobalControlClientes.NumeroContrato = (int)NumeroContrato_textEdit.EditValue;
            if (Empresario_lookUpEdit.EditValue != null)
                GlobalControlClientes.EmpresarioId = (int)Empresario_lookUpEdit.EditValue;
            GlobalControlClientes.EstadoId = Convert.ToInt32(EstadoContrato_lookUpEdit.EditValue);
            if (Reeup_textEdit.EditValue != null)
                GlobalControlClientes.Reup = Reeup_textEdit.EditValue.ToString().Trim(); 
            if (Nit_textEdit.EditValue != null)
                GlobalControlClientes.Nit = Nit_textEdit.EditValue.ToString().Trim();
        }

        private void Pais_lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ANacional = (int)Pais_lookUpEdit.EditValue == Paises.PaisIdDeCuba;
            if (GlobalControlClientes.ControlClienteID == 0)//caso de insercion
            {

                NumeroContrato_textEdit.EditValue = ControlClientes.GetProximoNumeroContrato(ANacional);
                NumeroContrato_textEdit.ForeColor = Color.Red;
            }


            if (!ANacional)
            {
                EmpresarioLayout_layoutControlItem.RestoreFromCustomization(ItemForPaisId, InsertType.Bottom);
                //EstadoContrato_lookUpEdit.EditValue = estado
                //Fecha_layoutControlItem.HideToCustomization();
                //Vigente_layoutControlItem.HideToCustomization();
            }
            else
            {
                EmpresarioLayout_layoutControlItem.HideToCustomization();
                //Clientes_lookUpEdit.Properties.DataSource =
                //    AGlobalDataContext.ControlClientes.Where(c => c.Paises.Codigo==53);
                //Clientes_lookUpEdit.Text = "";
                //Fecha_layoutControlItem.RestoreFromCustomization(ItemForRepresentante,InsertType.Bottom);
                //Vigente_layoutControlItem.RestoreFromCustomization(Fecha_layoutControlItem,InsertType.Right);
            }
        }

        private void Empresarios_simpleButton_Click(object sender, EventArgs e)
        {
            EmpresariosForm empresariosForm = new EmpresariosForm();

        }

        private void Empresario_lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int empresarioId = (int)Empresario_lookUpEdit.EditValue;
                Empresarios empresario = AGlobalDataContext.Empresarios.FirstOrDefault(c => c.EmpresarioID == empresarioId);
                if (empresario != null)
                {
                    NombreEntidad_textEdit.EditValue = empresario.EmpresaQueRepresenta;
                    if (empresario.Telefono != null) Telefono_textEdit.EditValue = empresario.Telefono.Trim();
                    if (empresario.Email != null) Email_textEdit.EditValue = empresario.Email.Trim();
                    if (empresario.Direccion != null) Direccion_textEdit.EditValue = empresario.Direccion.Trim();
                    representante_textEdit.EditValue = empresario.NombreYApellidos.Trim();
                    if (empresario.EnCondicionDe != null)
                        CargoRepresentante_textEdit.EditValue = empresario.EnCondicionDe.Trim();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("El empresario no tiene todos los datos necesarios insertados");
            }
        }

        private void Cuentas_simpleButton_Click(object sender, EventArgs e)
        {
            PopupCuentasDeBanco cuentasDeClienteXtraForm = new PopupCuentasDeBanco(GlobalControlClientes);
            cuentasDeClienteXtraForm.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (AClienteSalvado) DialogResult = DialogResult.OK;
        }


        private void Carpeta_simpleButton_Click(object sender, EventArgs e)
        {
            var configuracion = DynamicQueryable.FirstOrDefault(AGlobalDataContext.ConfiguracionGeneral);
            //Conformo el nombre d la carpeta, 

            var anno = ConfiguracionGeneral.Anno;
            var numeroContrato = GlobalControlClientes.NumeroContrato;
            var entidad = NombreEntidad_textEdit.EditValue;
            var camino = GlobalControlClientes.EsNacional
                ? configuracion.CaminoContratosNacionales
                : configuracion.CaminoContratoInternacionales;
            if (numeroContrato == 0)
            {
                MessageBox.Show("El contrato debe ser salvado con anterioridad");
                return;
            }
            var nombreCarpeta = string.Format("{0}-{1}-{2}", numeroContrato, anno, entidad);

            //creo la carpeta
            try
            {
                string rutaCompleta = string.Format("{0}\\{1}", camino, nombreCarpeta);
                if (!GlobalControlClientes.EsNacional)
                    rutaCompleta += " "+GlobalControlClientes.ProyectoAsociadoString.ToString().CleanInput();

                if (Directory.Exists(rutaCompleta))
                {
                    if (MessageBox.Show("La Carpeta ya existe, Desea abrirla?", "Exito", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        Process.Start("Explorer.exe", rutaCompleta);
                    }
                    return;
                }
                DirectoryInfo info = Directory.CreateDirectory(rutaCompleta);
                if (!info.Exists)
                {
                    MessageBox.Show(
                        "Problemas al crear la carpeta, verifique que usted tenga permisos para escribir en la ruta configurada o contacte al administrador de sistemas");
                }
                else
                {
                    //MessageBox.Show("Carpeta creada correctamente");
                    if (
                        MessageBox.Show("Carpeta creada correctamente, Desea abrirla?", "Exito", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        Process.Start("Explorer.exe", rutaCompleta);
                    }
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        public void HabilitaBotonCrearCarpeta()
        {
            Carpeta_simpleButton.Enabled = GlobalControlClientes.NumeroContrato != 0;
        }

        private void FechaContrato_dateEdit_EditValueChanged(object sender, EventArgs e)
        {
            var fechaCotnrato = FechaContrato_dateEdit.DateTime;
            if (ANacional)
            {
                var defaultVigencia = ConfiguracionGeneral.ConfiguracionActual.VigenciaContrato;
                Vigente_dateEdit.EditValue = fechaCotnrato.AddYears(1);
            }
               
                Vigente_dateEdit.Properties.MinValue = FechaContrato_dateEdit.DateTime;
            

        }

        private void Empresario_lookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                NuevoEmpresarioForm nuevoForm = new NuevoEmpresarioForm();
                if (nuevoForm.ShowDialog() != DialogResult.Cancel)
                {
                    empresariosBindingSource.DataSource =
                        new NegocioDataContext().Empresarios;
                    Empresario_lookUpEdit.EditValue = nuevoForm.NuevoEmpresario.EmpresarioID;

                }
            }
        }

        private void Pais_lookUpEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                NuevoPaisForm nuevoForm = new NuevoPaisForm();
                if (nuevoForm.ShowDialog() != DialogResult.Cancel)
                {
                    paisesBindingSource.DataSource =
                        new NegocioDataContext().Paises;
                    Pais_lookUpEdit.EditValue = nuevoForm.PaisNuevo.PaisID;

                }
            }
        }


    }
}