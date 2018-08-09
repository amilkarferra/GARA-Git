namespace DXApplication9
{
    partial class LoginXtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginXtraForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Password_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.Error_labelControl = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Cancel_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Aceptar_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Usuario_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ErrorLabel_layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Password_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Usuario_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorLabel_layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Password_textEdit);
            this.layoutControl1.Controls.Add(this.Error_labelControl);
            this.layoutControl1.Controls.Add(this.pictureBox1);
            this.layoutControl1.Controls.Add(this.Cancel_simpleButton);
            this.layoutControl1.Controls.Add(this.Aceptar_simpleButton);
            this.layoutControl1.Controls.Add(this.Usuario_textEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(543, 124, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(487, 181);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Password_textEdit
            // 
            this.Password_textEdit.Location = new System.Drawing.Point(254, 36);
            this.Password_textEdit.Name = "Password_textEdit";
            this.Password_textEdit.Properties.PasswordChar = '*';
            this.Password_textEdit.Properties.UseSystemPasswordChar = true;
            this.Password_textEdit.Size = new System.Drawing.Size(221, 20);
            this.Password_textEdit.StyleController = this.layoutControl1;
            this.Password_textEdit.TabIndex = 10;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.Password_textEdit, conditionValidationRule1);
            // 
            // Error_labelControl
            // 
            this.Error_labelControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Error_labelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_labelControl.Appearance.ForeColor = System.Drawing.Color.Red;
            this.Error_labelControl.Appearance.Image = global::DXApplication9.Properties.Resources.cancel_16x16;
            this.Error_labelControl.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Error_labelControl.Appearance.Options.UseBackColor = true;
            this.Error_labelControl.Appearance.Options.UseFont = true;
            this.Error_labelControl.Appearance.Options.UseForeColor = true;
            this.Error_labelControl.Appearance.Options.UseImage = true;
            this.Error_labelControl.Appearance.Options.UseImageAlign = true;
            this.Error_labelControl.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.Error_labelControl.Location = new System.Drawing.Point(171, 100);
            this.Error_labelControl.Margin = new System.Windows.Forms.Padding(0);
            this.Error_labelControl.Name = "Error_labelControl";
            this.Error_labelControl.Padding = new System.Windows.Forms.Padding(1);
            this.Error_labelControl.ShowToolTips = false;
            this.Error_labelControl.Size = new System.Drawing.Size(304, 69);
            this.Error_labelControl.StyleController = this.layoutControl1;
            this.Error_labelControl.TabIndex = 9;
            this.Error_labelControl.Text = "Verifique Nombre de Usuario y Contraseña";
            this.Error_labelControl.ToolTip = "Verifique Nombre de Usuario y Contraseña";
            this.Error_labelControl.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Error;
            this.Error_labelControl.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Cancel_simpleButton
            // 
            this.Cancel_simpleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_simpleButton.ImageOptions.Image")));
            this.Cancel_simpleButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Cancel_simpleButton.Location = new System.Drawing.Point(436, 60);
            this.Cancel_simpleButton.Name = "Cancel_simpleButton";
            this.Cancel_simpleButton.Size = new System.Drawing.Size(39, 36);
            this.Cancel_simpleButton.StyleController = this.layoutControl1;
            this.Cancel_simpleButton.TabIndex = 7;
            this.Cancel_simpleButton.Click += new System.EventHandler(this.Cancel_simpleButton_Click);
            // 
            // Aceptar_simpleButton
            // 
            this.Aceptar_simpleButton.ImageOptions.Image = global::DXApplication9.Properties.Resources.apply_32x32;
            this.Aceptar_simpleButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Aceptar_simpleButton.Location = new System.Drawing.Point(394, 60);
            this.Aceptar_simpleButton.Name = "Aceptar_simpleButton";
            this.Aceptar_simpleButton.Size = new System.Drawing.Size(38, 36);
            this.Aceptar_simpleButton.StyleController = this.layoutControl1;
            this.Aceptar_simpleButton.TabIndex = 6;
            this.Aceptar_simpleButton.Click += new System.EventHandler(this.Aceptar_simpleButton_Click);
            // 
            // Usuario_textEdit
            // 
            this.Usuario_textEdit.Location = new System.Drawing.Point(254, 12);
            this.Usuario_textEdit.Name = "Usuario_textEdit";
            this.Usuario_textEdit.Properties.Mask.EditMask = "\\p{Ll}+";
            this.Usuario_textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.Usuario_textEdit.Size = new System.Drawing.Size(221, 20);
            this.Usuario_textEdit.StyleController = this.layoutControl1;
            this.Usuario_textEdit.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Obligatorio";
            this.dxValidationProvider1.SetValidationRule(this.Usuario_textEdit, conditionValidationRule2);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.BackgroundImageVisible = true;
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.ErrorLabel_layoutControlItem,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(487, 181);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Usuario_textEdit;
            this.layoutControlItem1.CustomizationFormText = "Nombre de Usuario";
            this.layoutControlItem1.Location = new System.Drawing.Point(148, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(148, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(319, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Nombre de Usuario";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.Aceptar_simpleButton;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(382, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(42, 40);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Cancel_simpleButton;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(424, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(43, 40);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // ErrorLabel_layoutControlItem
            // 
            this.ErrorLabel_layoutControlItem.Control = this.Error_labelControl;
            this.ErrorLabel_layoutControlItem.CustomizationFormText = "Verifique Nombre de Usuario y Contraseña";
            this.ErrorLabel_layoutControlItem.Location = new System.Drawing.Point(159, 88);
            this.ErrorLabel_layoutControlItem.MinSize = new System.Drawing.Size(305, 40);
            this.ErrorLabel_layoutControlItem.Name = "ErrorLabel_layoutControlItem";
            this.ErrorLabel_layoutControlItem.Size = new System.Drawing.Size(308, 73);
            this.ErrorLabel_layoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ErrorLabel_layoutControlItem.Text = "Verifique Nombre de Usuario y Contraseña";
            this.ErrorLabel_layoutControlItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ErrorLabel_layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.ErrorLabel_layoutControlItem.TextToControlDistance = 0;
            this.ErrorLabel_layoutControlItem.TrimClientAreaToControl = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.Password_textEdit;
            this.layoutControlItem2.CustomizationFormText = "Contraseña";
            this.layoutControlItem2.Location = new System.Drawing.Point(148, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(148, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(319, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Contraseña";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(91, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(148, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(234, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.pictureBox1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(148, 161);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(148, 88);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(11, 73);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            // 
            // LoginXtraForm
            // 
            this.AcceptButton = this.Aceptar_simpleButton;
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.Appearance.Image = global::DXApplication9.Properties.Resources.usergroup_32x32;
            this.Appearance.Options.UseImage = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.CancelButton = this.Cancel_simpleButton;
            this.ClientSize = new System.Drawing.Size(487, 181);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginXtraForm";
            this.Text = "Ventana de Acceso a Sistema GARA";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Password_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Usuario_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorLabel_layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton Cancel_simpleButton;
        private DevExpress.XtraEditors.SimpleButton Aceptar_simpleButton;
        private DevExpress.XtraEditors.TextEdit Usuario_textEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LabelControl Error_labelControl;
        private DevExpress.XtraLayout.LayoutControlItem ErrorLabel_layoutControlItem;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit Password_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}