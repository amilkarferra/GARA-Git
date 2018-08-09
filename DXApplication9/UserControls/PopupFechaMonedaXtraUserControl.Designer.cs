namespace DXApplication9.UserControls
{
    partial class PopupFechaMonedaXtraUserControl
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Fecha_dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.Moneda_lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tipoMonedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Moneda_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.dxValidationProvider2 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fecha_dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fecha_dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moneda_lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moneda_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(53, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(200, 20);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 8;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.dateEdit1, conditionValidationRule3);
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Fecha_dateEdit);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Controls.Add(this.Moneda_lookUpEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(265, 167);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Fecha_dateEdit
            // 
            this.Fecha_dateEdit.EditValue = null;
            this.Fecha_dateEdit.Location = new System.Drawing.Point(53, 36);
            this.Fecha_dateEdit.Name = "Fecha_dateEdit";
            this.Fecha_dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Fecha_dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Fecha_dateEdit.Size = new System.Drawing.Size(200, 20);
            this.Fecha_dateEdit.StyleController = this.layoutControl1;
            this.Fecha_dateEdit.TabIndex = 9;
            compareAgainstControlValidationRule1.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.GreaterOrEqual;
            compareAgainstControlValidationRule1.Control = this.dateEdit1;
            compareAgainstControlValidationRule1.ErrorText = "Esta fecha debe ser posterior o igual a la fecha inicial.";
            this.dxValidationProvider2.SetValidationRule(this.Fecha_dateEdit, compareAgainstControlValidationRule1);
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.Fecha_dateEdit, conditionValidationRule1);
            this.Fecha_dateEdit.EditValueChanged += new System.EventHandler(this.dateEdit2_EditValueChanged);
            // 
            // Moneda_lookUpEdit
            // 
            this.Moneda_lookUpEdit.Location = new System.Drawing.Point(53, 60);
            this.Moneda_lookUpEdit.Name = "Moneda_lookUpEdit";
            this.Moneda_lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Moneda_lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abreviatura", "Abreviatura", 67, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.Moneda_lookUpEdit.Properties.DataSource = this.tipoMonedaBindingSource;
            this.Moneda_lookUpEdit.Properties.DisplayMember = "Abreviatura";
            this.Moneda_lookUpEdit.Properties.ValueMember = "TipoMonedaID";
            this.Moneda_lookUpEdit.Size = new System.Drawing.Size(200, 20);
            this.Moneda_lookUpEdit.StyleController = this.layoutControl1;
            this.Moneda_lookUpEdit.TabIndex = 6;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.Moneda_lookUpEdit, conditionValidationRule2);
            this.Moneda_lookUpEdit.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // tipoMonedaBindingSource
            // 
            this.tipoMonedaBindingSource.DataSource = typeof(DXApplication9.TipoMoneda);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.Moneda_layoutControlItem,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(265, 167);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(245, 75);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Moneda_layoutControlItem
            // 
            this.Moneda_layoutControlItem.Control = this.Moneda_lookUpEdit;
            this.Moneda_layoutControlItem.Location = new System.Drawing.Point(0, 48);
            this.Moneda_layoutControlItem.Name = "Moneda_layoutControlItem";
            this.Moneda_layoutControlItem.Size = new System.Drawing.Size(245, 24);
            this.Moneda_layoutControlItem.Text = "Moneda";
            this.Moneda_layoutControlItem.TextSize = new System.Drawing.Size(38, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dateEdit1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(245, 24);
            this.layoutControlItem5.Text = "Desde";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(38, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.Fecha_dateEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(245, 24);
            this.layoutControlItem6.Text = "Hasta";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(38, 13);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // dxValidationProvider2
            // 
            this.dxValidationProvider2.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // PopupFechaMonedaXtraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "PopupFechaMonedaXtraUserControl";
            this.Size = new System.Drawing.Size(265, 167);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Fecha_dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fecha_dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moneda_lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Moneda_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        public DevExpress.XtraEditors.DateEdit Fecha_dateEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        public DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        public DevExpress.XtraEditors.LookUpEdit Moneda_lookUpEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        public DevExpress.XtraLayout.LayoutControlItem Moneda_layoutControlItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.Windows.Forms.BindingSource tipoMonedaBindingSource;
    }
}
