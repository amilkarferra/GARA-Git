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

namespace DXApplication9.UserControls
{
    public partial class AgrupacionesFormXtraUserControl : EditFormUserControl
    {
        public AgrupacionesFormXtraUserControl()
        {
            InitializeComponent();
        }

        private void checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkEdit.Checked)
            {
                Codigo_textEdit.Properties.NullText = "No Aplicable"; 
                Codigo_textEdit.Enabled = false;
                
            }
            else
            {
                Codigo_textEdit.Properties.NullText = "Indique Codigo";
                Codigo_textEdit.Enabled = true;
            }

        }
    }
}
