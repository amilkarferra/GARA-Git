namespace DXApplication9.UserControls
{
    partial class EditUserXtraUserControl
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.Password_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Cancel_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Cargo_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.Password2_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.NombreUsuario_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.NombreCompleto_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.Role_lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.Ok_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Contrasenna_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.VerContra_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.NoPassword_dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Password_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cargo_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password2_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NombreUsuario_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NombreCompleto_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_lookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrasenna_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerContra_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoPassword_dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // Password_textEdit
            // 
            this.Password_textEdit.Location = new System.Drawing.Point(114, 84);
            this.Password_textEdit.Name = "Password_textEdit";
            this.Password_textEdit.Properties.PasswordChar = '*';
            this.Password_textEdit.Properties.UseSystemPasswordChar = true;
            this.Password_textEdit.Size = new System.Drawing.Size(284, 20);
            this.Password_textEdit.StyleController = this.layoutControl1;
            this.Password_textEdit.TabIndex = 6;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.Password_textEdit, conditionValidationRule4);
            this.Password_textEdit.EditValueChanged += new System.EventHandler(this.Password_textEdit_EditValueChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Cancel_simpleButton);
            this.layoutControl1.Controls.Add(this.Cargo_textEdit);
            this.layoutControl1.Controls.Add(this.Password2_textEdit);
            this.layoutControl1.Controls.Add(this.Password_textEdit);
            this.layoutControl1.Controls.Add(this.NombreUsuario_textEdit);
            this.layoutControl1.Controls.Add(this.NombreCompleto_textEdit);
            this.layoutControl1.Controls.Add(this.Role_lookUpEdit);
            this.layoutControl1.Controls.Add(this.Ok_simpleButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(410, 204);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Cancel_simpleButton
            // 
            this.Cancel_simpleButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Cancel_simpleButton.ImageOptions.Image = global::DXApplication9.Properties.Resources.cancel_32x321;
            this.Cancel_simpleButton.Location = new System.Drawing.Point(308, 156);
            this.Cancel_simpleButton.Name = "Cancel_simpleButton";
            this.Cancel_simpleButton.Size = new System.Drawing.Size(90, 36);
            this.Cancel_simpleButton.StyleController = this.layoutControl1;
            this.Cancel_simpleButton.TabIndex = 11;
            this.Cancel_simpleButton.Text = "Cancelar";
            // 
            // Cargo_textEdit
            // 
            this.Cargo_textEdit.Location = new System.Drawing.Point(114, 60);
            this.Cargo_textEdit.Name = "Cargo_textEdit";
            this.Cargo_textEdit.Size = new System.Drawing.Size(284, 20);
            this.Cargo_textEdit.StyleController = this.layoutControl1;
            this.Cargo_textEdit.TabIndex = 9;
            // 
            // Password2_textEdit
            // 
            this.Password2_textEdit.Location = new System.Drawing.Point(114, 108);
            this.Password2_textEdit.Name = "Password2_textEdit";
            this.Password2_textEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Password2_textEdit.Properties.PasswordChar = '*';
            this.Password2_textEdit.Properties.UseSystemPasswordChar = true;
            this.Password2_textEdit.Size = new System.Drawing.Size(284, 20);
            this.Password2_textEdit.StyleController = this.layoutControl1;
            this.Password2_textEdit.TabIndex = 7;
            compareAgainstControlValidationRule1.CaseSensitive = true;
            compareAgainstControlValidationRule1.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Equals;
            compareAgainstControlValidationRule1.Control = this.Password_textEdit;
            compareAgainstControlValidationRule1.ErrorText = "Las contraseñas no coinciden";
            this.dxValidationProvider1.SetValidationRule(this.Password2_textEdit, compareAgainstControlValidationRule1);
            // 
            // NombreUsuario_textEdit
            // 
            this.NombreUsuario_textEdit.Location = new System.Drawing.Point(114, 36);
            this.NombreUsuario_textEdit.Name = "NombreUsuario_textEdit";
            this.NombreUsuario_textEdit.Properties.Mask.EditMask = "\\p{Ll}+";
            this.NombreUsuario_textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.NombreUsuario_textEdit.Size = new System.Drawing.Size(284, 20);
            this.NombreUsuario_textEdit.StyleController = this.layoutControl1;
            this.NombreUsuario_textEdit.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.NombreUsuario_textEdit, conditionValidationRule1);
            this.NoPassword_dxValidationProvider.SetValidationRule(this.NombreUsuario_textEdit, conditionValidationRule1);
            // 
            // NombreCompleto_textEdit
            // 
            this.NombreCompleto_textEdit.Location = new System.Drawing.Point(114, 12);
            this.NombreCompleto_textEdit.Name = "NombreCompleto_textEdit";
            this.NombreCompleto_textEdit.Size = new System.Drawing.Size(284, 20);
            this.NombreCompleto_textEdit.StyleController = this.layoutControl1;
            this.NombreCompleto_textEdit.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.NombreCompleto_textEdit, conditionValidationRule2);
            this.NoPassword_dxValidationProvider.SetValidationRule(this.NombreCompleto_textEdit, conditionValidationRule2);
            // 
            // Role_lookUpEdit
            // 
            this.Role_lookUpEdit.Location = new System.Drawing.Point(114, 132);
            this.Role_lookUpEdit.Name = "Role_lookUpEdit";
            this.Role_lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Role_lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Tipo", "Rol")});
            this.Role_lookUpEdit.Properties.DisplayMember = "Tipo";
            this.Role_lookUpEdit.Properties.NullText = "";
            this.Role_lookUpEdit.Properties.ValueMember = "Valor";
            this.Role_lookUpEdit.Size = new System.Drawing.Size(284, 20);
            this.Role_lookUpEdit.StyleController = this.layoutControl1;
            this.Role_lookUpEdit.TabIndex = 8;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Obligatorio";
            this.NoPassword_dxValidationProvider.SetValidationRule(this.Role_lookUpEdit, conditionValidationRule3);
            this.dxValidationProvider1.SetValidationRule(this.Role_lookUpEdit, conditionValidationRule3);
            // 
            // Ok_simpleButton
            // 
            this.Ok_simpleButton.ImageOptions.Image = global::DXApplication9.Properties.Resources.apply_32x321;
            this.Ok_simpleButton.Location = new System.Drawing.Point(218, 156);
            this.Ok_simpleButton.Name = "Ok_simpleButton";
            this.Ok_simpleButton.Size = new System.Drawing.Size(86, 36);
            this.Ok_simpleButton.StyleController = this.layoutControl1;
            this.Ok_simpleButton.TabIndex = 10;
            this.Ok_simpleButton.Text = "Aceptar";
            this.Ok_simpleButton.Click += new System.EventHandler(this.Ok_simpleButton_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.Contrasenna_layoutControlItem,
            this.VerContra_layoutControlItem,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(410, 204);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.NombreCompleto_textEdit;
            this.layoutControlItem1.CustomizationFormText = "Nombre Completo";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem1.Text = "Nombre Completo";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.NombreUsuario_textEdit;
            this.layoutControlItem2.CustomizationFormText = "Nombre de Usuario";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem2.Text = "Nombre de Usuario";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(99, 13);
            // 
            // Contrasenna_layoutControlItem
            // 
            this.Contrasenna_layoutControlItem.Control = this.Password_textEdit;
            this.Contrasenna_layoutControlItem.CustomizationFormText = "Contraseña";
            this.Contrasenna_layoutControlItem.Location = new System.Drawing.Point(0, 72);
            this.Contrasenna_layoutControlItem.Name = "Contrasenna_layoutControlItem";
            this.Contrasenna_layoutControlItem.Size = new System.Drawing.Size(390, 24);
            this.Contrasenna_layoutControlItem.Text = "Contraseña";
            this.Contrasenna_layoutControlItem.TextSize = new System.Drawing.Size(99, 13);
            // 
            // VerContra_layoutControlItem
            // 
            this.VerContra_layoutControlItem.Control = this.Password2_textEdit;
            this.VerContra_layoutControlItem.CustomizationFormText = "Verifique contraseña";
            this.VerContra_layoutControlItem.Location = new System.Drawing.Point(0, 96);
            this.VerContra_layoutControlItem.Name = "VerContra_layoutControlItem";
            this.VerContra_layoutControlItem.Size = new System.Drawing.Size(390, 24);
            this.VerContra_layoutControlItem.Text = "Verifique contraseña";
            this.VerContra_layoutControlItem.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.Role_lookUpEdit;
            this.layoutControlItem5.CustomizationFormText = "Rol";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem5.Text = "Rol";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.Cargo_textEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem6.Text = "Cargo:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.Ok_simpleButton;
            this.layoutControlItem7.Location = new System.Drawing.Point(206, 144);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(90, 40);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.Cancel_simpleButton;
            this.layoutControlItem8.Location = new System.Drawing.Point(296, 144);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(94, 40);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 144);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(206, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // NoPassword_dxValidationProvider
            // 
            this.NoPassword_dxValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // EditUserXtraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 204);
            this.Controls.Add(this.layoutControl1);
            this.Name = "EditUserXtraUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.Password_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cargo_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password2_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NombreUsuario_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NombreCompleto_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_lookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrasenna_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerContra_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoPassword_dxValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit Password2_textEdit;
        private DevExpress.XtraEditors.TextEdit Password_textEdit;
        private DevExpress.XtraEditors.TextEdit NombreUsuario_textEdit;
        private DevExpress.XtraEditors.TextEdit NombreCompleto_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem Contrasenna_layoutControlItem;
        private DevExpress.XtraLayout.LayoutControlItem VerContra_layoutControlItem;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.LookUpEdit Role_lookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit Cargo_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton Ok_simpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton Cancel_simpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider NoPassword_dxValidationProvider;
    }
}
