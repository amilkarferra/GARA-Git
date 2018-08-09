using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication9
{
    public partial class PopupAsignarEscalaXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public int EscalaSalarialIdSeleccionado = 0;
        public PopupAsignarEscalaXtraForm()
        {
            InitializeComponent();
            escalaSalarialBindingSource.DataSource = new NegocioDataContext().EscalaSalarial;
        }

        private void Ok_simpleButton_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null) 
            {
                EscalaSalarialIdSeleccionado = Convert.ToInt32(lookUpEdit1.EditValue);
                DialogResult=DialogResult.OK;
            }
        }

        private void Salir_simpleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}