using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;

namespace DXApplication9.UserControls
{
    public partial class EditUserXtraUserControl : XtraForm
    {
        bool IsAnUpdate = false;
        Usuario GlobalUsuario ;
        NegocioDataContext GlobalDataContext = new NegocioDataContext();
        bool IsPasswordEdit = false;
        public EditUserXtraUserControl()
        {
            InitializeComponent();
            Role_lookUpEdit.Properties.DataSource = Enumerados.ListaDeEnumerados(typeof(Enumerados.Roles));
            

        }

        public EditUserXtraUserControl(Usuario anUsuario, bool updatePassword = false)
        {
            InitializeComponent();
            IsPasswordEdit = updatePassword;
            IsAnUpdate = true;
            Role_lookUpEdit.Properties.DataSource = Enumerados.ListaDeEnumerados(typeof(Enumerados.Roles));
            GlobalUsuario = GlobalDataContext.Usuario.FirstOrDefault(c => c.UsuarioID == anUsuario.UsuarioID);
            var u = GlobalUsuario;
            NombreCompleto_textEdit.EditValue = u.NombreCompleto;
            NombreUsuario_textEdit.EditValue = u.NombreUsuario;
            Cargo_textEdit.EditValue = u.Cargo;
            Role_lookUpEdit.EditValue = u.RoleId;
            if (!updatePassword)
            {
                VerContra_layoutControlItem.HideToCustomization();
                Contrasenna_layoutControlItem.HideToCustomization();
            }
           
        }

        private void Password_textEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Ok_simpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalDataContext = new NegocioDataContext();
                if (IsPasswordEdit?dxValidationProvider1.Validate():NoPassword_dxValidationProvider.Validate())
                {
                    if (!IsAnUpdate)
                        GlobalUsuario = new Usuario();
                    else
                        GlobalUsuario = GlobalDataContext.Usuario.FirstOrDefault(c => c.UsuarioID == GlobalUsuario.UsuarioID);
                    GlobalUsuario.Cargo = Convert.ToString(Cargo_textEdit.EditValue).Trim();
                    GlobalUsuario.NombreCompleto = Convert.ToString(NombreCompleto_textEdit.EditValue).Trim();
                    GlobalUsuario.NombreUsuario = Convert.ToString(NombreUsuario_textEdit.EditValue).ToLower().Trim();
                    GlobalUsuario.RoleId = Convert.ToInt32(Role_lookUpEdit.EditValue);
                    GlobalUsuario.Password = BCrypt.Net.BCrypt.HashPassword(Convert.ToString(Password_textEdit.EditValue), BCrypt.Net.BCrypt.GenerateSalt());

                    if (!IsAnUpdate) {
                        GlobalDataContext.Usuario.InsertOnSubmit(GlobalUsuario);
                        var existe = GlobalDataContext.Usuario.Any(c => c.NombreUsuario.ToLower().Trim() == GlobalUsuario.NombreUsuario);
                        if (existe)
                        {
                            Utils.MuestraError("Nombre de usuario existente");
                            return;
                        }   
                    }
                    GlobalDataContext.SubmitChanges();
                    Utils.MuestraMensajeOk();
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception)
            {
                DialogResult = DialogResult.Abort;
                Utils.MuestraError();
            }
        }


    }
}
