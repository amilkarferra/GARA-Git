using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BCrypt.Net;

namespace DXApplication9
{
    public partial class LoginXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private static int _intentos = 0;
        public LoginXtraForm()
        {
            InitializeComponent();
            ErrorLabel_layoutControlItem.HideToCustomization();

        }



        private void Aceptar_simpleButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            NegocioDataContext dc = new NegocioDataContext();
            string usuario = Usuario_textEdit.EditValue.ToString();
            string pass = Password_textEdit.EditValue.ToString();
            Usuario user = dc.Usuario.FirstOrDefault(c => c.NombreUsuario == usuario);
            if (user != null && BCrypt.Net.BCrypt.Verify(pass, user.Password))
            {

                LoginHelper.UsuarioRegistrado = user;
                this.DialogResult = DialogResult.OK;
                Dispose();
            }
            else
            {
                _intentos++;
                ErrorLabel_layoutControlItem.RestoreFromCustomization(emptySpaceItem2, DevExpress.XtraLayout.Utils.InsertType.Right);

                if (_intentos >= 3)
                {

                    MessageBox.Show("Usted ha superado el número máximo de intentos, el sistema abortará",
                        "Cerrando", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // DialogResult = DialogResult.Abort;
                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        // WinForms app
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        // Console app
                        System.Environment.Exit(1);
                    }
                }
                else
                {
                    Usuario_textEdit.ResetText();
                    Password_textEdit.ResetText(); Usuario_textEdit.Focus();
                }
            }
        }



        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;

        }

        private void Password_textEdit_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrEmpty(Password_textEdit.EditValue.ToString());
        }

        public string GetCpuid()
        {
            string cpuId = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuId == "")
                {
                    //Remark gets only the first CPU ID
                    cpuId = mo.Properties["processorID"].Value.ToString();

                }
            }
            //XtraMessageBox.Show(cpuID,"Informacion",MessageBoxButtons.OK);
            return cpuId;
        }


    }
}