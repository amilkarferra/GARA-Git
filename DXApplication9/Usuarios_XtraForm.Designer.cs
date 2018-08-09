namespace DXApplication9
{
    partial class UsuariosXtraForm
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.NuevoUsuario_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUsuarioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreCompleto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Roles_repositoryItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Edit_gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Edit_repositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.Del_gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Del_repositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Roles_repositoryItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_repositoryItemButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Del_repositoryItemButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.NuevoUsuario_simpleButton);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(829, 261);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // NuevoUsuario_simpleButton
            // 
            this.NuevoUsuario_simpleButton.ImageOptions.Image = global::DXApplication9.Properties.Resources.add_16x16;
            this.NuevoUsuario_simpleButton.Location = new System.Drawing.Point(679, 12);
            this.NuevoUsuario_simpleButton.Name = "NuevoUsuario_simpleButton";
            this.NuevoUsuario_simpleButton.Size = new System.Drawing.Size(138, 22);
            this.NuevoUsuario_simpleButton.StyleController = this.layoutControl1;
            this.NuevoUsuario_simpleButton.TabIndex = 5;
            this.NuevoUsuario_simpleButton.Text = "Insertar Nuevo Usuario";
            this.NuevoUsuario_simpleButton.Click += new System.EventHandler(this.NuevoUsuario_simpleButton_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.usuarioBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Roles_repositoryItemLookUpEdit,
            this.Edit_repositoryItemButtonEdit,
            this.Del_repositoryItemButtonEdit});
            this.gridControl1.Size = new System.Drawing.Size(805, 211);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // usuarioBindingSource
            // 
            this.usuarioBindingSource.DataSource = typeof(DXApplication9.Usuario);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.TopNewRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView1.Appearance.TopNewRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUsuarioID,
            this.colNombreUsuario,
            this.colNombreCompleto,
            this.colCargo,
            this.colRoleId,
            this.colPassword,
            this.Edit_gridColumn,
            this.Del_gridColumn});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Clic aquí Para insertar nuevo registro";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.gridView1.OptionsEditForm.EditFormColumnCount = 1;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.HiddenEditor += new System.EventHandler(this.gridView1_HiddenEditor);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // colUsuarioID
            // 
            this.colUsuarioID.FieldName = "UsuarioID";
            this.colUsuarioID.Name = "colUsuarioID";
            this.colUsuarioID.OptionsEditForm.Caption = "caption";
            this.colUsuarioID.OptionsEditForm.CaptionLocation = DevExpress.XtraGrid.EditForm.EditFormColumnCaptionLocation.Top;
            // 
            // colNombreUsuario
            // 
            this.colNombreUsuario.FieldName = "NombreUsuario";
            this.colNombreUsuario.Name = "colNombreUsuario";
            this.colNombreUsuario.OptionsEditForm.Caption = "Nombre de Usuario:";
            this.colNombreUsuario.Visible = true;
            this.colNombreUsuario.VisibleIndex = 1;
            // 
            // colNombreCompleto
            // 
            this.colNombreCompleto.FieldName = "NombreCompleto";
            this.colNombreCompleto.Name = "colNombreCompleto";
            this.colNombreCompleto.OptionsEditForm.Caption = "Nombre Completo:";
            this.colNombreCompleto.Visible = true;
            this.colNombreCompleto.VisibleIndex = 2;
            // 
            // colCargo
            // 
            this.colCargo.FieldName = "Cargo";
            this.colCargo.Name = "colCargo";
            this.colCargo.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colCargo.Visible = true;
            this.colCargo.VisibleIndex = 3;
            // 
            // colRoleId
            // 
            this.colRoleId.Caption = "Rol";
            this.colRoleId.ColumnEdit = this.Roles_repositoryItemLookUpEdit;
            this.colRoleId.FieldName = "RoleId";
            this.colRoleId.Name = "colRoleId";
            this.colRoleId.OptionsEditForm.Caption = "Role:";
            this.colRoleId.Visible = true;
            this.colRoleId.VisibleIndex = 4;
            this.colRoleId.Width = 90;
            // 
            // Roles_repositoryItemLookUpEdit
            // 
            this.Roles_repositoryItemLookUpEdit.AutoHeight = false;
            this.Roles_repositoryItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Roles_repositoryItemLookUpEdit.DisplayMember = "Tipo";
            this.Roles_repositoryItemLookUpEdit.Name = "Roles_repositoryItemLookUpEdit";
            this.Roles_repositoryItemLookUpEdit.ValueMember = "Valor";
            // 
            // colPassword
            // 
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            this.colPassword.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            // 
            // Edit_gridColumn
            // 
            this.Edit_gridColumn.ColumnEdit = this.Edit_repositoryItemButtonEdit;
            this.Edit_gridColumn.Name = "Edit_gridColumn";
            this.Edit_gridColumn.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.Edit_gridColumn.Visible = true;
            this.Edit_gridColumn.VisibleIndex = 5;
            this.Edit_gridColumn.Width = 28;
            // 
            // Edit_repositoryItemButtonEdit
            // 
            this.Edit_repositoryItemButtonEdit.AutoHeight = false;
            editorButtonImageOptions1.Image = global::DXApplication9.Properties.Resources.design_16x16;
            this.Edit_repositoryItemButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.Edit_repositoryItemButtonEdit.Name = "Edit_repositoryItemButtonEdit";
            this.Edit_repositoryItemButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // Del_gridColumn
            // 
            this.Del_gridColumn.ColumnEdit = this.Del_repositoryItemButtonEdit;
            this.Del_gridColumn.Name = "Del_gridColumn";
            this.Del_gridColumn.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.Del_gridColumn.Visible = true;
            this.Del_gridColumn.VisibleIndex = 6;
            this.Del_gridColumn.Width = 31;
            // 
            // Del_repositoryItemButtonEdit
            // 
            this.Del_repositoryItemButtonEdit.AutoHeight = false;
            editorButtonImageOptions2.Image = global::DXApplication9.Properties.Resources.removepivotfield_16x16;
            this.Del_repositoryItemButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions2, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.Del_repositoryItemButtonEdit.Name = "Del_repositoryItemButtonEdit";
            this.Del_repositoryItemButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(829, 261);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(809, 215);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.NuevoUsuario_simpleButton;
            this.layoutControlItem2.Location = new System.Drawing.Point(667, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(142, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(667, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UsuariosXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 261);
            this.Controls.Add(this.layoutControl1);
            this.Name = "UsuariosXtraForm";
            this.Text = "Usuarios de GARA";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Roles_repositoryItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Edit_repositoryItemButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Del_repositoryItemButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuarioID;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreCompleto;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleId;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource usuarioBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Roles_repositoryItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colCargo;
        private DevExpress.XtraGrid.Columns.GridColumn Edit_gridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Edit_repositoryItemButtonEdit;
        private DevExpress.XtraGrid.Columns.GridColumn Del_gridColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Del_repositoryItemButtonEdit;
        private DevExpress.XtraEditors.SimpleButton NuevoUsuario_simpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}