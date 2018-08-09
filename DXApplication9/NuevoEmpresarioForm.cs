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

namespace DXApplication9
{
    public partial class NuevoEmpresarioForm : DevExpress.XtraEditors.XtraForm
    {
        public Empresarios NuevoEmpresario = new Empresarios();
        public NuevoEmpresarioForm()
        {
            InitializeComponent();
        }

        private void NuevoEmpresarioForm_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'artistasDataSet.Paises' table. You can move, or remove it, as needed.
            //this.paisesTableAdapter.Fill(this.artistasDataSet.Paises);
            //// TODO: This line of code loads data into the 'artistasDataSet.Empresarios' table. You can move, or remove it, as needed.
            //this.empresariosTableAdapter.Fill(this.artistasDataSet.Empresarios);

        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Salva el Empresario </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit2_Click(object sender, EventArgs e)
        {

            try
            {
                NuevoEmpresario.NombreYApellidos = NombreYApellidostextEdit.EditValue.ToString();
                if (DireccionTextEdit.EditValue != null) NuevoEmpresario.Direccion = DireccionTextEdit.EditValue.ToString();
                if (EmailTextEdit.EditValue != null) NuevoEmpresario.Email = EmailTextEdit.EditValue.ToString();
                if (Empresa_textEdit.EditValue != null) NuevoEmpresario.EmpresaQueRepresenta = Empresa_textEdit.EditValue.ToString(); NuevoEmpresario.EnCondicionDe = EnCondicionDe_textEdit.EditValue.ToString();
                if (TelefonoTextEdit.EditValue != null) NuevoEmpresario.Telefono = TelefonoTextEdit.EditValue.ToString();
                if (EnCondicionDe_textEdit.EditValue != null) NuevoEmpresario.EnCondicionDe = EnCondicionDe_textEdit.EditValue.ToString();
                if (ObjetoSocial_textEdit.EditValue != null)
                    NuevoEmpresario.ObjetoSocial = Convert.ToString(ObjetoSocial_textEdit.EditValue);
                var dc = new NegocioDataContext();
                dc.Empresarios.InsertOnSubmit(NuevoEmpresario);
                dc.SubmitChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                
                Utils.MuestraError("Error en la acción");
            }
        }

        private void Cancel_buttonEdit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Dispose();
        }

        private void NombreYApellidostextEdit_Validating(object sender, CancelEventArgs e)
        {
            ValidaControl(sender,e);
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

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Cancel_buttonEdit_EditValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}