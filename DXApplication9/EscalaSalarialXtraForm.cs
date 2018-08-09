using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DXApplication9.UserControls;

namespace DXApplication9
{
    public partial class EscalaSalarialXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private NegocioDataContext GlobalDataContext = new NegocioDataContext();

        public  EscalaSalarialXtraForm()
        {
            InitializeComponent();

            escalaSalarialBindingSource.DataSource = GlobalDataContext.EscalaSalarial;

        }
        private void Add_simpleButton_Click(object sender, EventArgs e)
        {
            EscalaSalairalPopupXtraForm popupXtraForm = new EscalaSalairalPopupXtraForm();
            if (popupXtraForm.ShowDialog() == DialogResult.OK)
            {
                RefrescaGrid();
            }
        }

        private void RefrescaGrid()
        {
            escalaSalarialBindingSource.DataSource = new NegocioDataContext().EscalaSalarial;
        }

        private void EscalaSalarialGridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
            Edit_simpleButton.Enabled = EscalaSalarialGridView.GetSelectedRows().Any();
            Del_simpleButton.Enabled = EscalaSalarialGridView.GetSelectedRows().Any();
        }

        private void Edit_simpleButton_Click(object sender, EventArgs e)
        {
            if (!EscalaSalarialGridView.GetSelectedRows().Any()) return;
            EscalaSalarial primerEscala = (EscalaSalarial) EscalaSalarialGridView.GetRow(EscalaSalarialGridView.GetSelectedRows()[0]);
            var popup = new EscalaSalairalPopupXtraForm(primerEscala);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                RefrescaGrid();
            }
        }

        private void Del_simpleButton_Click(object sender, EventArgs e)
        {
            if (!EscalaSalarialGridView.GetSelectedRows().Any()) return;
            EscalaSalarial primerEscala = (EscalaSalarial)EscalaSalarialGridView.GetRow(EscalaSalarialGridView.GetSelectedRows()[0]);
            if(primerEscala!=null)
            if (
                XtraMessageBox.Show("Está seguro?", "Acción irreversible", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.OK)
            {
                
                var dc = new NegocioDataContext();
                var escala = dc.EscalaSalarial.FirstOrDefault(c => c.EscalaSalarialID == primerEscala.EscalaSalarialID);
                if (escala == null) return;
                dc.EscalaSalarial.DeleteOnSubmit(escala);
                dc.SubmitChanges();
                RefrescaGrid();
                }
        }
    }
}