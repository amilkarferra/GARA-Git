namespace DXApplication9
{
    partial class EscalaSalarialXtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EscalaSalarialXtraForm));
            this.EscalaSalarialGridControl = new DevExpress.XtraGrid.GridControl();
            this.escalaSalarialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EscalaSalarialGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEscalaSalarialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEscalaSalarial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Del_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Edit_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Add_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.EscalaSalarialGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escalaSalarialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EscalaSalarialGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // EscalaSalarialGridControl
            // 
            this.EscalaSalarialGridControl.DataSource = this.escalaSalarialBindingSource;
            this.EscalaSalarialGridControl.Location = new System.Drawing.Point(12, 38);
            this.EscalaSalarialGridControl.MainView = this.EscalaSalarialGridView;
            this.EscalaSalarialGridControl.Name = "EscalaSalarialGridControl";
            this.EscalaSalarialGridControl.Size = new System.Drawing.Size(614, 346);
            this.EscalaSalarialGridControl.TabIndex = 0;
            this.EscalaSalarialGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.EscalaSalarialGridView});
            // 
            // escalaSalarialBindingSource
            // 
            this.escalaSalarialBindingSource.DataSource = typeof(DXApplication9.EscalaSalarial);
            // 
            // EscalaSalarialGridView
            // 
            this.EscalaSalarialGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEscalaSalarialID,
            this.colEscalaSalarial});
            this.EscalaSalarialGridView.GridControl = this.EscalaSalarialGridControl;
            this.EscalaSalarialGridView.Name = "EscalaSalarialGridView";
            this.EscalaSalarialGridView.OptionsBehavior.Editable = false;
            this.EscalaSalarialGridView.OptionsDetail.EnableMasterViewMode = false;
            this.EscalaSalarialGridView.OptionsSelection.InvertSelection = true;
            this.EscalaSalarialGridView.OptionsSelection.MultiSelect = true;
            this.EscalaSalarialGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.EscalaSalarialGridView.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.EscalaSalarialGridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.EscalaSalarialGridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.EscalaSalarialGridView_SelectionChanged);
            // 
            // colEscalaSalarialID
            // 
            this.colEscalaSalarialID.FieldName = "EscalaSalarialID";
            this.colEscalaSalarialID.Name = "colEscalaSalarialID";
            // 
            // colEscalaSalarial
            // 
            this.colEscalaSalarial.Caption = "Escala Salarial";
            this.colEscalaSalarial.FieldName = "Escala";
            this.colEscalaSalarial.Name = "colEscalaSalarial";
            this.colEscalaSalarial.Visible = true;
            this.colEscalaSalarial.VisibleIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Del_simpleButton);
            this.layoutControl1.Controls.Add(this.Edit_simpleButton);
            this.layoutControl1.Controls.Add(this.Add_simpleButton);
            this.layoutControl1.Controls.Add(this.EscalaSalarialGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(81, 178, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(638, 396);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Del_simpleButton
            // 
            this.Del_simpleButton.Enabled = false;
            this.Del_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Del_simpleButton.ImageOptions.Image")));
            this.Del_simpleButton.Location = new System.Drawing.Point(564, 12);
            this.Del_simpleButton.Name = "Del_simpleButton";
            this.Del_simpleButton.Size = new System.Drawing.Size(62, 22);
            this.Del_simpleButton.StyleController = this.layoutControl1;
            this.Del_simpleButton.TabIndex = 6;
            this.Del_simpleButton.Text = "Eliminar";
            this.Del_simpleButton.Click += new System.EventHandler(this.Del_simpleButton_Click);
            // 
            // Edit_simpleButton
            // 
            this.Edit_simpleButton.Enabled = false;
            this.Edit_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Edit_simpleButton.ImageOptions.Image")));
            this.Edit_simpleButton.Location = new System.Drawing.Point(506, 12);
            this.Edit_simpleButton.Name = "Edit_simpleButton";
            this.Edit_simpleButton.Size = new System.Drawing.Size(54, 22);
            this.Edit_simpleButton.StyleController = this.layoutControl1;
            this.Edit_simpleButton.TabIndex = 5;
            this.Edit_simpleButton.Text = "Editar";
            this.Edit_simpleButton.Click += new System.EventHandler(this.Edit_simpleButton_Click);
            // 
            // Add_simpleButton
            // 
            this.Add_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Add_simpleButton.ImageOptions.Image")));
            this.Add_simpleButton.Location = new System.Drawing.Point(445, 12);
            this.Add_simpleButton.Name = "Add_simpleButton";
            this.Add_simpleButton.Size = new System.Drawing.Size(57, 22);
            this.Add_simpleButton.StyleController = this.layoutControl1;
            this.Add_simpleButton.TabIndex = 4;
            this.Add_simpleButton.Text = "Nueva";
            this.Add_simpleButton.Click += new System.EventHandler(this.Add_simpleButton_Click);
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
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(638, 396);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.EscalaSalarialGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(618, 350);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.Add_simpleButton;
            this.layoutControlItem2.Location = new System.Drawing.Point(433, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(61, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.Edit_simpleButton;
            this.layoutControlItem3.Location = new System.Drawing.Point(494, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(58, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Del_simpleButton;
            this.layoutControlItem4.Location = new System.Drawing.Point(552, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(66, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(433, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // EscalaSalarialXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 396);
            this.Controls.Add(this.layoutControl1);
            this.Name = "EscalaSalarialXtraForm";
            this.Text = "EscalaSalarial";
            ((System.ComponentModel.ISupportInitialize)(this.EscalaSalarialGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escalaSalarialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EscalaSalarialGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl EscalaSalarialGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView EscalaSalarialGridView;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource escalaSalarialBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEscalaSalarialID;
        private DevExpress.XtraGrid.Columns.GridColumn colEscalaSalarial;
        private DevExpress.XtraEditors.SimpleButton Edit_simpleButton;
        private DevExpress.XtraEditors.SimpleButton Add_simpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton Del_simpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}