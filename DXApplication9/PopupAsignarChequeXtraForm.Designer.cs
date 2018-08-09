namespace DXApplication9
{
    partial class PopupAsignarChequeXtraForm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.EstadoCuenta_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.PagoPorTransferencia_checkEdit = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.FechaEntrega_dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.Cheque_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.EstadoCuenta_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoCuenta_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagoPorTransferencia_checkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEntrega_dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEntrega_dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cheque_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoCuenta_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.EstadoCuenta_textEdit);
            this.layoutControl1.Controls.Add(this.PagoPorTransferencia_checkEdit);
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.FechaEntrega_dateEdit);
            this.layoutControl1.Controls.Add(this.Cheque_textEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(296, 132);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // EstadoCuenta_textEdit
            // 
            this.EstadoCuenta_textEdit.Location = new System.Drawing.Point(199, 36);
            this.EstadoCuenta_textEdit.Name = "EstadoCuenta_textEdit";
            this.EstadoCuenta_textEdit.Properties.DisplayFormat.FormatString = "d0";
            this.EstadoCuenta_textEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EstadoCuenta_textEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EstadoCuenta_textEdit.Properties.Mask.EditMask = "0000";
            this.EstadoCuenta_textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.EstadoCuenta_textEdit.Size = new System.Drawing.Size(85, 20);
            this.EstadoCuenta_textEdit.StyleController = this.layoutControl1;
            this.EstadoCuenta_textEdit.TabIndex = 9;
            // 
            // PagoPorTransferencia_checkEdit
            // 
            this.PagoPorTransferencia_checkEdit.Location = new System.Drawing.Point(12, 36);
            this.PagoPorTransferencia_checkEdit.Name = "PagoPorTransferencia_checkEdit";
            this.PagoPorTransferencia_checkEdit.Properties.Caption = "Transferencia";
            this.PagoPorTransferencia_checkEdit.Size = new System.Drawing.Size(94, 19);
            this.PagoPorTransferencia_checkEdit.StyleController = this.layoutControl1;
            this.PagoPorTransferencia_checkEdit.TabIndex = 8;
            this.PagoPorTransferencia_checkEdit.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageUri.Uri = "Cancel";
            this.simpleButton2.Location = new System.Drawing.Point(183, 84);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(101, 36);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "Cancelar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageUri.Uri = "Apply";
            this.simpleButton1.Location = new System.Drawing.Point(106, 84);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(73, 36);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "OK";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FechaEntrega_dateEdit
            // 
            this.FechaEntrega_dateEdit.EditValue = null;
            this.FechaEntrega_dateEdit.Location = new System.Drawing.Point(103, 60);
            this.FechaEntrega_dateEdit.Name = "FechaEntrega_dateEdit";
            this.FechaEntrega_dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaEntrega_dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaEntrega_dateEdit.Size = new System.Drawing.Size(181, 20);
            this.FechaEntrega_dateEdit.StyleController = this.layoutControl1;
            this.FechaEntrega_dateEdit.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.FechaEntrega_dateEdit, conditionValidationRule1);
            // 
            // Cheque_textEdit
            // 
            this.Cheque_textEdit.Location = new System.Drawing.Point(103, 12);
            this.Cheque_textEdit.Name = "Cheque_textEdit";
            this.Cheque_textEdit.Size = new System.Drawing.Size(181, 20);
            this.Cheque_textEdit.StyleController = this.layoutControl1;
            this.Cheque_textEdit.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.Cheque_textEdit, conditionValidationRule2);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.EstadoCuenta_layoutControlItem});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(296, 132);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Cheque_textEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem1.Text = "Cheque";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(86, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.FechaEntrega_dateEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(143, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Fecha";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(86, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton1;
            this.layoutControlItem3.Location = new System.Drawing.Point(94, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(77, 40);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButton2;
            this.layoutControlItem4.Location = new System.Drawing.Point(171, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(105, 40);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(94, 40);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.PagoPorTransferencia_checkEdit;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(98, 24);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // EstadoCuenta_layoutControlItem
            // 
            this.EstadoCuenta_layoutControlItem.Control = this.EstadoCuenta_textEdit;
            this.EstadoCuenta_layoutControlItem.Location = new System.Drawing.Point(98, 24);
            this.EstadoCuenta_layoutControlItem.Name = "EstadoCuenta_layoutControlItem";
            this.EstadoCuenta_layoutControlItem.Size = new System.Drawing.Size(178, 24);
            this.EstadoCuenta_layoutControlItem.Text = "Estado de Cuenta";
            this.EstadoCuenta_layoutControlItem.TextSize = new System.Drawing.Size(86, 13);
            // 
            // PopupAsignarChequeXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 132);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PopupAsignarChequeXtraForm";
            this.Text = "Asignando Cheque";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EstadoCuenta_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagoPorTransferencia_checkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEntrega_dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEntrega_dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cheque_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoCuenta_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.DateEdit FechaEntrega_dateEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        public DevExpress.XtraEditors.TextEdit Cheque_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        public DevExpress.XtraEditors.TextEdit EstadoCuenta_textEdit;
        public DevExpress.XtraEditors.CheckEdit PagoPorTransferencia_checkEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem EstadoCuenta_layoutControlItem;

    }
}