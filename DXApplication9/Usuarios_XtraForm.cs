using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet.Internal;
using DXApplication9.UserControls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace DXApplication9
{
    public partial class UsuariosXtraForm : XtraForm
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        public UsuariosXtraForm()
        {
            InitializeComponent();
            usuarioBindingSource.DataSource = AGlobalDataContext.Usuario;
            Roles_repositoryItemLookUpEdit.DataSource =
            Enumerados.ListaDeEnumerados(typeof(Enumerados.Roles));
            //gridView1.OptionsEditForm.CustomEditFormLayout = new EditUserXtraUserControl();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Usuario user = (Usuario)e.Row;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt());
            AGlobalDataContext.SubmitChanges();
            gridControl1.DataSource = AGlobalDataContext.Usuario;

        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            //  gridView1.ed
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            int rowHandle;
            var column = GetClickedInformation(gridControl1, gridView1, out rowHandle);
            if (column == Edit_gridColumn)
            {
                Usuario usuario = (Usuario)gridView1.GetRow(rowHandle);
                var respuesta = XtraMessageBox.Show("Desea Editar la contraseña del usuario?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                EditUserXtraUserControl form = new EditUserXtraUserControl(usuario, respuesta==DialogResult.Yes);
                if (form.ShowDialog() == DialogResult.Cancel) return;
                ActualizaUsuarios();
            }
            else if (column == Del_gridColumn)
            {
                Usuario usuario = (Usuario)gridView1.GetRow(rowHandle);
                usuario = AGlobalDataContext.Usuario.FirstOrDefault(c => c.UsuarioID == usuario.UsuarioID);
                try
                {
                    AGlobalDataContext.Usuario.DeleteOnSubmit(usuario);
                    AGlobalDataContext.SubmitChanges();
                    ActualizaUsuarios();
                }
                catch (Exception)
                {
                    Utils.MuestraError("Este usuario no puede ser borrado");
                }
            }


        }

        private void ActualizaUsuarios()
        {
            usuarioBindingSource.DataSource = new NegocioDataContext().Usuario;
        }

        public GridColumn GetClickedInformation(GridControl aGridControl, GridView agridView, out int rowHandle)
        {
            var gridView = agridView;
            Point clickPoint = aGridControl.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {
                rowHandle = hitInfo.RowHandle;
                GridColumn column = hitInfo.Column;
                return column;
            }
            rowHandle = 0;
            return null;
        }

        private void NuevoUsuario_simpleButton_Click(object sender, EventArgs e)
        {
            EditUserXtraUserControl form = new EditUserXtraUserControl();
            if (form.ShowDialog() == DialogResult.Cancel) return;
            ActualizaUsuarios();
        }
    }
}