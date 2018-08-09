using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraExport;
using DXApplication9.Properties;

namespace DXApplication9
{
    public partial class PopupConfiguracionGeneralXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private bool ACambiosRealizados;
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private int AConfiguracionId = 0;
        public PopupConfiguracionGeneralXtraForm()
        {
            InitializeComponent();
            cuentasEmpresaBindingSource.DataSource = AGlobalDataContext.CuentasEmpresa;
            tipoMonedaBindingSource.DataSource = AGlobalDataContext.TipoMoneda;
            PopulaControles();
        }

        private void PopulaControles()
        {
            if (!AGlobalDataContext.ConfiguracionGeneral.Any()) return;
            var configuracion = AGlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            AConfiguracionId = configuracion.ConfiguracionID;
            NombreCentro_textEdit.EditValue = configuracion.Agencia;
            Direccion_textEdit.EditValue = configuracion.DireccionEmpresa;
            Tel_textEdit.EditValue = configuracion.TelefonosAgencia;
            SitioWeb_textEdit.EditValue = configuracion.SitioWeb;
            Email_textEdit.EditValue = configuracion.CorreoElectronico;
            EnCierre_checkEdit.Checked = configuracion.CerrandoAnno;

            if (configuracion.LogoAgencia != null)
            {
                MemoryStream ms = new MemoryStream(configuracion.LogoAgencia);
                Bitmap imagenBitmap = new Bitmap(ms);
                pictureEdit1.Image = imagenBitmap;
            }
            #region Generales

            Anno_textEdit.EditValue = configuracion.AnnoDeTrabajo;

            PrimerCttoNacional_textEdit5.EditValue = configuracion.PrimerNumeroContratoNacionalAnual;
            CaminoCttoNacional_buttonEdit.EditValue = configuracion.CaminoContratosNacionales;

            PrimerCttoIntern_textEdit.EditValue = configuracion.PrimerNumeroContratoInternacionalAnual;
            CaminoCttoInternacional_buttonEdit.EditValue = configuracion.CaminoContratoInternacionales;

            NIT_textEdit.EditValue = configuracion.NitAgencia;
            Reup_textEdit.EditValue = configuracion.Reup;

            #endregion

            #region Cargos Principales

            NombreDirigeAgencia_textEdit.EditValue = configuracion.NombreDeJefeAgencia;
            CargoDirigeAgencia_textEdit.EditValue = configuracion.CargoDeJefeDeAgencia;

            NombreDirigTram_textEdit.EditValue = configuracion.NombreJefeDeDptoTramite;
            CargoDirTram_textEdit.EditValue = configuracion.CargoJefeDptoTramite;

            NombreDirEmpRect_textEdit.EditValue = configuracion.Destinatario_O_DirigidoA;
            CargoDirEmpRect_textEdit.EditValue = configuracion.CargoDestinatario;
            NombEmpRect_textEdit.EditValue = configuracion.EmpresaDestinatario;

            #endregion

            #region Otras
            VigenciaContrato_textEdit.EditValue = configuracion.VigenciaContrato == null ? 0 : Convert.ToInt32(configuracion.VigenciaContrato);
            #endregion


        }

        private void CuentasEmpresa_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
        }

        private void CuentasEmpresa_gridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Eliminar_simpleButton.Enabled = CuentasEmpresa_gridView.GetSelectedRows().Any();
        }

        private void Eliminar_simpleButton_Click(object sender, EventArgs e)
        {
            CuentasEmpresa_gridView.DeleteSelectedRows();
            AGlobalDataContext.SubmitChanges();
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                CaminoCttoNacional_buttonEdit.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void CaminoCttoInternacional_buttonEdit_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                CaminoCttoInternacional_buttonEdit.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Aceptar_simpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidaFormulario()) return;
                ConfiguracionGeneral configuracion = AConfiguracionId == 0 ? (new ConfiguracionGeneral()) : AGlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
                if (configuracion != null)
                {
                    configuracion.Agencia = Convert.ToString(NombreCentro_textEdit.EditValue);
                    configuracion.DireccionEmpresa = Convert.ToString(Direccion_textEdit.EditValue);
                    configuracion.TelefonosAgencia = Convert.ToString(Tel_textEdit.EditValue);
                    configuracion.CorreoElectronico = Convert.ToString(Email_textEdit.EditValue);
                    configuracion.SitioWeb = Convert.ToString(SitioWeb_textEdit.EditValue);



                    if (pictureEdit1.Image != null)
                    {
                        {
                            Image img = pictureEdit1.Image;
                            byte[] data = ByteImageConverter.ToByteArray(img, img.RawFormat);
                            configuracion.LogoAgencia = data;
                        }
                    }
                    // pictureEdit1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //pictureEdit1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //binary = new Binary(ms.GetBuffer());
                    //byte[] _Imagen = binary.ToArray();
                    //configuracion.LogoAgencia = _Imagen;




                    #region Generales

                    configuracion.AnnoDeTrabajo = Convert.ToInt32(Anno_textEdit.EditValue);

                    configuracion.PrimerNumeroContratoNacionalAnual = Convert.ToInt32(PrimerCttoNacional_textEdit5.EditValue);
                    configuracion.CaminoContratosNacionales = Convert.ToString(CaminoCttoNacional_buttonEdit.EditValue);

                    configuracion.PrimerNumeroContratoInternacionalAnual =
                        Convert.ToInt32(PrimerCttoIntern_textEdit.EditValue);
                    configuracion.CaminoContratoInternacionales =
                        Convert.ToString(CaminoCttoInternacional_buttonEdit.EditValue);

                    configuracion.Reup = Convert.ToString(Reup_textEdit.EditValue).Trim();
                    configuracion.NitAgencia = Convert.ToString(NIT_textEdit.EditValue).Trim();
                    configuracion.CerrandoAnno = EnCierre_checkEdit.Checked;

                    #endregion

                    #region cargos

                    configuracion.NombreDeJefeAgencia = Convert.ToString(NombreDirigeAgencia_textEdit.EditValue);
                    configuracion.CargoDeJefeDeAgencia = Convert.ToString(CargoDirigeAgencia_textEdit.EditValue);

                    configuracion.NombreJefeDeDptoTramite = Convert.ToString(NombreDirigTram_textEdit.EditValue);
                    configuracion.CargoJefeDptoTramite = Convert.ToString(CargoDirTram_textEdit.EditValue);

                    configuracion.Destinatario_O_DirigidoA = Convert.ToString(NombreDirEmpRect_textEdit.EditValue);
                    configuracion.CargoDestinatario = Convert.ToString(CargoDirEmpRect_textEdit.EditValue);
                    configuracion.EmpresaDestinatario = Convert.ToString(NombEmpRect_textEdit.EditValue);

                    #endregion

                    #region Otras
                    configuracion.VigenciaContrato = VigenciaContrato_textEdit.EditValue == null ? 0 : Convert.ToInt32(VigenciaContrato_textEdit.EditValue);
                    #endregion

                    if (AConfiguracionId == 0)
                    {
                        AGlobalDataContext.ConfiguracionGeneral.InsertOnSubmit(configuracion);
                    }
                }

                AGlobalDataContext.SubmitChanges();
                ACambiosRealizados = true;
            }
            catch (Exception exception)
            {

                XtraMessageBox.Show(exception.Message);
            }

        }

        private bool ValidaFormulario()
        {
            bool ok = ValidaCargos();
            if (!ValidaGenerales())
                ok = false;
            return ok;

        }

        private bool ValidaCargos()
        {
            if (Cargos_dxValidationProvider.Validate())
            {
                Cargos_layoutControlGroup.CaptionImage = null;
                return true;
            }
            Cargos_layoutControlGroup.CaptionImage = Resources.error_16x16;
            return false;
        }

        private bool ValidaGenerales()
        {
            if (General_dxValidationProvider.Validate())
            {
                Generales_layoutControlGroup.CaptionImage = null;
                return true;
            }
            Generales_layoutControlGroup.CaptionImage = Resources.error_16x16;
            return false;
        }



        private void Salir_simpleButton_Click(object sender, EventArgs e)
        {
            if (ACambiosRealizados)
                DialogResult = DialogResult.OK;
            Close();
        }

        private void cuentasEmpresaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void imageEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}