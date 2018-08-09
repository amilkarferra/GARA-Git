using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace DXApplication9
{
    public partial class WaitForm1 : WaitForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption">ej: Un momento Por favor</param>
        /// <param name="description">ej: Cargando Formulario</param>
        public WaitForm1(string caption, string description)
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
            SetCaption(caption);
            SetDescription(description);
            
        }

        public WaitForm1()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;

        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        private void progressPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}