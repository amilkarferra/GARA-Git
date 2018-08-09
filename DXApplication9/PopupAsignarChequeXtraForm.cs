using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;

namespace DXApplication9
{
	public partial class PopupAsignarChequeXtraForm: DevExpress.XtraEditors.XtraForm
	{
	    /// <summary>
	    /// 
	    /// </summary>
	    public PopupAsignarChequeXtraForm()
		{
            InitializeComponent();
            EstadoCuenta_layoutControlItem.HideToCustomization();
		}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
            Dispose();
        }

        private void Borrar_simpleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (PagoPorTransferencia_checkEdit.Checked)
            {
                EstadoCuenta_layoutControlItem.RestoreFromCustomization(layoutControlItem5,InsertType.Right);
            }
        }
	}
}