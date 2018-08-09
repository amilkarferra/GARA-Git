namespace DXApplication9
{
    partial class PopupAgrupacionMonedaFechaXtraForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupAgrupacionMonedaFechaXtraForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Ok_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Moneda_lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tipoMonedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Agrupacion_lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.agrupacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FechaFinal_dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.FechaInicial_dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Moneda_lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaFinal_dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaFinal_dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicial_dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicial_dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Ok_simpleButton);
            this.layoutControl1.Controls.Add(this.Cancel_simpleButton);
            this.layoutControl1.Controls.Add(this.Moneda_lookUpEdit);
            this.layoutControl1.Controls.Add(this.Agrupacion_lookUpEdit);
            this.layoutControl1.Controls.Add(this.FechaFinal_dateEdit);
            this.layoutControl1.Controls.Add(this.FechaInicial_dateEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(262, 188);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Ok_simpleButton
            // 
            this.Ok_simpleButton.Image = ((System.Drawing.Image)(resources.GetObject("Ok_simpleButton.Image")));
            this.Ok_simpleButton.Location = new System.Drawing.Point(72, 140);
            this.Ok_simpleButton.Name = "Ok_simpleButton";
            this.Ok_simpleButton.Size = new System.Drawing.Size(80, 36);
            this.Ok_simpleButton.StyleController = this.layoutControl1;
            this.Ok_simpleButton.TabIndex = 9;
            this.Ok_simpleButton.Text = "Aceptar";
            this.Ok_simpleButton.Click += new System.EventHandler(this.Ok_simpleButton_Click);
            // 
            // Cancel_simpleButton
            // 
            this.Cancel_simpleButton.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_simpleButton.Image")));
            this.Cancel_simpleButton.Location = new System.Drawing.Point(156, 140);
            this.Cancel_simpleButton.Name = "Cancel_simpleButton";
            this.Cancel_simpleButton.Size = new System.Drawing.Size(94, 36);
            this.Cancel_simpleButton.StyleController = this.layoutControl1;
            this.Cancel_simpleButton.TabIndex = 8;
            this.Cancel_simpleButton.Text = "Cancelar";
            this.Cancel_simpleButton.Click += new System.EventHandler(this.Cancel_simpleButton_Click);
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
            this.Moneda_lookUpEdit.Size = new System.Drawing.Size(197, 20);
            this.Moneda_lookUpEdit.StyleController = this.layoutControl1;
            this.Moneda_lookUpEdit.TabIndex = 7;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.Moneda_lookUpEdit, conditionValidationRule1);
            // 
            // tipoMonedaBindingSource
            // 
            this.tipoMonedaBindingSource.DataSource = typeof(DXApplication9.TipoMoneda);
            // 
            // Agrupacion_lookUpEdit
            // 
            this.Agrupacion_lookUpEdit.Location = new System.Drawing.Point(53, 36);
            this.Agrupacion_lookUpEdit.Name = "Agrupacion_lookUpEdit";
            this.Agrupacion_lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Agrupacion_lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 47, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.Agrupacion_lookUpEdit.Properties.DataSource = this.agrupacionBindingSource;
            this.Agrupacion_lookUpEdit.Properties.DisplayMember = "Nombre";
            this.Agrupacion_lookUpEdit.Properties.ValueMember = "AgrupacionID";
            this.Agrupacion_lookUpEdit.Size = new System.Drawing.Size(197, 20);
            this.Agrupacion_lookUpEdit.StyleController = this.layoutControl1;
            this.Agrupacion_lookUpEdit.TabIndex = 6;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.Agrupacion_lookUpEdit, conditionValidationRule2);
            // 
            // agrupacionBindingSource
            // 
            this.agrupacionBindingSource.DataSource = typeof(DXApplication9.Agrupacion);
            // 
            // FechaFinal_dateEdit
            // 
            this.FechaFinal_dateEdit.EditValue = null;
            this.FechaFinal_dateEdit.Location = new System.Drawing.Point(174, 12);
            this.FechaFinal_dateEdit.Name = "FechaFinal_dateEdit";
            this.FechaFinal_dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaFinal_dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaFinal_dateEdit.Size = new System.Drawing.Size(76, 20);
            this.FechaFinal_dateEdit.StyleController = this.layoutControl1;
            this.FechaFinal_dateEdit.TabIndex = 5;
            // 
            // FechaInicial_dateEdit
            // 
            this.FechaInicial_dateEdit.EditValue = null;
            this.FechaInicial_dateEdit.Location = new System.Drawing.Point(53, 12);
            this.FechaInicial_dateEdit.Name = "FechaInicial_dateEdit";
            this.FechaInicial_dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaInicial_dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaInicial_dateEdit.Size = new System.Drawing.Size(76, 20);
            this.FechaInicial_dateEdit.StyleController = this.layoutControl1;
            this.FechaInicial_dateEdit.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(262, 188);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.FechaInicial_dateEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(121, 24);
            this.layoutControlItem1.Text = "Desde:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(38, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(242, 56);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.FechaFinal_dateEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(121, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(121, 24);
            this.layoutControlItem2.Text = "Hasta";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(38, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.Agrupacion_lookUpEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(242, 24);
            this.layoutControlItem3.Text = "Grupo:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(38, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Moneda_lookUpEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(242, 24);
            this.layoutControlItem4.Text = "Moneda";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(38, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.Cancel_simpleButton;
            this.layoutControlItem5.Location = new System.Drawing.Point(144, 128);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(98, 40);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.Ok_simpleButton;
            this.layoutControlItem6.Location = new System.Drawing.Point(60, 128);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(84, 40);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 128);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(60, 40);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // PopupAgrupacionMonedaFechaXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 188);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PopupAgrupacionMonedaFechaXtraForm";
            this.Text = "PopupAgrupacionMonedaFechaXtraForm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Moneda_lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMonedaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupacion_lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaFinal_dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaFinal_dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicial_dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicial_dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton Ok_simpleButton;
        private DevExpress.XtraEditors.SimpleButton Cancel_simpleButton;
        private DevExpress.XtraEditors.LookUpEdit Moneda_lookUpEdit;
        private System.Windows.Forms.BindingSource tipoMonedaBindingSource;
        private DevExpress.XtraEditors.LookUpEdit Agrupacion_lookUpEdit;
        private System.Windows.Forms.BindingSource agrupacionBindingSource;
        private DevExpress.XtraEditors.DateEdit FechaFinal_dateEdit;
        private DevExpress.XtraEditors.DateEdit FechaInicial_dateEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}