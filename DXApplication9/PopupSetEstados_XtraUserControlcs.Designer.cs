namespace DXApplication9
{
    partial class PopupSetEstados_XtraUserControlcs
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Estado_lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Estado_lookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Estado_lookUpEdit
            // 
            this.Estado_lookUpEdit.Location = new System.Drawing.Point(27, 18);
            this.Estado_lookUpEdit.Name = "Estado_lookUpEdit";
            this.Estado_lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Estado_lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Tipo", "Estado")});
            this.Estado_lookUpEdit.Properties.DisplayMember = "Tipo";
            this.Estado_lookUpEdit.Properties.NullText = "-Seleccione Estado-";
            this.Estado_lookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.Estado_lookUpEdit.Properties.ValueMember = "Valor";
            this.Estado_lookUpEdit.Size = new System.Drawing.Size(127, 20);
            this.Estado_lookUpEdit.TabIndex = 0;
            // 
            // PopupSetEstados_XtraUserControlcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Estado_lookUpEdit);
            this.Name = "PopupSetEstados_XtraUserControlcs";
            this.Size = new System.Drawing.Size(179, 60);
            ((System.ComponentModel.ISupportInitialize)(this.Estado_lookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit Estado_lookUpEdit;
    }
}
