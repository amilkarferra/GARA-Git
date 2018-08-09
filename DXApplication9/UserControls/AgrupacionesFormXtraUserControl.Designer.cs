namespace DXApplication9.UserControls
{
    partial class AgrupacionesFormXtraUserControl
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Codigo_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.Nombre_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.Codigo_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.Nombre_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.agrupacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Cobra_lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Porciento_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Codigo_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nombre_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Codigo_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nombre_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cobra_lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porciento_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.SetBoundPropertyName(this.layoutControl1, "");
            this.layoutControl1.Controls.Add(this.Porciento_textEdit);
            this.layoutControl1.Controls.Add(this.Cobra_lookUpEdit);
            this.layoutControl1.Controls.Add(this.Codigo_textEdit);
            this.layoutControl1.Controls.Add(this.pictureEdit1);
            this.layoutControl1.Controls.Add(this.Nombre_textEdit);
            this.layoutControl1.Controls.Add(this.checkEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1297, 172, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(409, 139);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Codigo_textEdit
            // 
            this.SetBoundFieldName(this.Codigo_textEdit, "Codigo");
            this.SetBoundPropertyName(this.Codigo_textEdit, "EditValue");
            this.Codigo_textEdit.Location = new System.Drawing.Point(230, 59);
            this.Codigo_textEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Codigo_textEdit.Name = "Codigo_textEdit";
            this.Codigo_textEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Codigo_textEdit.Size = new System.Drawing.Size(167, 20);
            this.Codigo_textEdit.StyleController = this.layoutControl1;
            this.Codigo_textEdit.TabIndex = 7;
            // 
            // pictureEdit1
            // 
            this.SetBoundFieldName(this.pictureEdit1, "BitmapImagen");
            this.SetBoundPropertyName(this.pictureEdit1, "EditValue");
            this.pictureEdit1.Location = new System.Drawing.Point(12, 28);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Size = new System.Drawing.Size(103, 99);
            this.pictureEdit1.StyleController = this.layoutControl1;
            this.pictureEdit1.TabIndex = 6;
            // 
            // Nombre_textEdit
            // 
            this.SetBoundFieldName(this.Nombre_textEdit, "Nombre");
            this.SetBoundPropertyName(this.Nombre_textEdit, "EditValue");
            this.Nombre_textEdit.Location = new System.Drawing.Point(230, 35);
            this.Nombre_textEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Nombre_textEdit.Name = "Nombre_textEdit";
            this.Nombre_textEdit.Size = new System.Drawing.Size(167, 20);
            this.Nombre_textEdit.StyleController = this.layoutControl1;
            this.Nombre_textEdit.TabIndex = 5;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.Nombre_textEdit, conditionValidationRule2);
            // 
            // checkEdit
            // 
            this.SetBoundFieldName(this.checkEdit, "PerteneceACatalogo");
            this.SetBoundPropertyName(this.checkEdit, "EditValue");
            this.checkEdit.Location = new System.Drawing.Point(124, 12);
            this.checkEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkEdit.Name = "checkEdit";
            this.checkEdit.Properties.Caption = "Del Catálogo";
            this.checkEdit.Size = new System.Drawing.Size(273, 19);
            this.checkEdit.StyleController = this.layoutControl1;
            this.checkEdit.TabIndex = 4;
            this.checkEdit.CheckedChanged += new System.EventHandler(this.checkEdit_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.splitterItem1,
            this.Codigo_layoutControlItem,
            this.Nombre_layoutControlItem,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(409, 139);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.checkEdit;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(112, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(277, 23);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pictureEdit1;
            this.layoutControlItem2.CustomizationFormText = "Logo";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(107, 119);
            this.layoutControlItem2.Text = "Logo";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(103, 13);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(107, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 119);
            // 
            // Codigo_layoutControlItem
            // 
            this.Codigo_layoutControlItem.Control = this.Codigo_textEdit;
            this.Codigo_layoutControlItem.CustomizationFormText = "Codigo";
            this.Codigo_layoutControlItem.Location = new System.Drawing.Point(112, 47);
            this.Codigo_layoutControlItem.Name = "Codigo_layoutControlItem";
            this.Codigo_layoutControlItem.Size = new System.Drawing.Size(277, 24);
            this.Codigo_layoutControlItem.Text = "Codigo";
            this.Codigo_layoutControlItem.TextSize = new System.Drawing.Size(103, 13);
            // 
            // Nombre_layoutControlItem
            // 
            this.Nombre_layoutControlItem.Control = this.Nombre_textEdit;
            this.Nombre_layoutControlItem.CustomizationFormText = "Nombre";
            this.Nombre_layoutControlItem.Location = new System.Drawing.Point(112, 23);
            this.Nombre_layoutControlItem.Name = "Nombre_layoutControlItem";
            this.Nombre_layoutControlItem.Size = new System.Drawing.Size(277, 24);
            this.Nombre_layoutControlItem.Text = "Nombre:";
            this.Nombre_layoutControlItem.TextSize = new System.Drawing.Size(103, 13);
            // 
            // agrupacionBindingSource
            // 
            this.agrupacionBindingSource.DataSource = typeof(DXApplication9.Agrupacion);
            // 
            // Cobra_lookUpEdit
            // 
            this.SetBoundFieldName(this.Cobra_lookUpEdit, "[Nombre de Persona Recibe Cheque]");
            this.Cobra_lookUpEdit.Location = new System.Drawing.Point(230, 83);
            this.Cobra_lookUpEdit.Name = "Cobra_lookUpEdit";
            this.Cobra_lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Cobra_lookUpEdit.Properties.DisplayMember = "NombreCompleto";
            this.Cobra_lookUpEdit.Size = new System.Drawing.Size(167, 20);
            this.Cobra_lookUpEdit.StyleController = this.layoutControl1;
            this.Cobra_lookUpEdit.TabIndex = 8;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.Cobra_lookUpEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(112, 71);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(277, 24);
            this.layoutControlItem3.Text = "Cobra:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(103, 13);
            // 
            // Porciento_textEdit
            // 
            this.SetBoundPropertyName(this.Porciento_textEdit, "");
            this.Porciento_textEdit.Location = new System.Drawing.Point(230, 107);
            this.Porciento_textEdit.Name = "Porciento_textEdit";
            this.Porciento_textEdit.Properties.Mask.EditMask = "n0";
            this.Porciento_textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Porciento_textEdit.Size = new System.Drawing.Size(167, 20);
            this.Porciento_textEdit.StyleController = this.layoutControl1;
            this.Porciento_textEdit.TabIndex = 9;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Porciento_textEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(112, 95);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(277, 24);
            this.layoutControlItem4.Text = "Porciento Contratado";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(103, 13);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // AgrupacionesFormXtraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AgrupacionesFormXtraUserControl";
            this.Size = new System.Drawing.Size(409, 139);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Codigo_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nombre_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Codigo_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nombre_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cobra_lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Porciento_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource agrupacionBindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit Nombre_textEdit;
        private DevExpress.XtraEditors.CheckEdit checkEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem Nombre_layoutControlItem;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraEditors.TextEdit Codigo_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem Codigo_layoutControlItem;
        private DevExpress.XtraEditors.LookUpEdit Cobra_lookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit Porciento_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}
