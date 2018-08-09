namespace DXApplication9
{
    partial class NuevoPaisForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoPaisForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.dataLayoutControl2 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.NombrePaisTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForNombrePais = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonEdit2 = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.Codigo_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.paisesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.artistasDataSet = new DXApplication9.ArtistasDataSet();
            this.continentesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.negocioDataContextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).BeginInit();
            this.dataLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NombrePaisTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNombrePais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Codigo_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paisesBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.artistasDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.continentesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocioDataContextBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.dataLayoutControl2);
            this.dataLayoutControl1.DataSource = this.negocioDataContextBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(301, 139);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Controls.Add(this.buttonEdit1);
            this.dataLayoutControl2.Controls.Add(this.buttonEdit2);
            this.dataLayoutControl2.Controls.Add(this.Codigo_textEdit);
            this.dataLayoutControl2.Controls.Add(this.NombrePaisTextEdit);
            this.dataLayoutControl2.DataSource = this.paisesBindingSource;
            this.dataLayoutControl2.Location = new System.Drawing.Point(12, 12);
            this.dataLayoutControl2.Name = "dataLayoutControl2";
            this.dataLayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(92, 189, 250, 350);
            this.dataLayoutControl2.Root = this.Root;
            this.dataLayoutControl2.Size = new System.Drawing.Size(277, 115);
            this.dataLayoutControl2.TabIndex = 4;
            this.dataLayoutControl2.Text = "dataLayoutControl2";
            // 
            // NombrePaisTextEdit
            // 
            this.NombrePaisTextEdit.Location = new System.Drawing.Point(74, 12);
            this.NombrePaisTextEdit.Name = "NombrePaisTextEdit";
            this.NombrePaisTextEdit.Size = new System.Drawing.Size(191, 20);
            this.NombrePaisTextEdit.StyleController = this.dataLayoutControl2;
            this.NombrePaisTextEdit.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(277, 115);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForNombrePais,
            this.layoutControlItem,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(257, 95);
            // 
            // ItemForNombrePais
            // 
            this.ItemForNombrePais.Control = this.NombrePaisTextEdit;
            this.ItemForNombrePais.CustomizationFormText = "Nombre";
            this.ItemForNombrePais.Location = new System.Drawing.Point(0, 0);
            this.ItemForNombrePais.Name = "ItemForNombrePais";
            this.ItemForNombrePais.Size = new System.Drawing.Size(257, 24);
            this.ItemForNombrePais.Text = "Nombre Pais";
            this.ItemForNombrePais.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(301, 139);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataLayoutControl2;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(281, 119);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // buttonEdit2
            // 
            this.buttonEdit2.Location = new System.Drawing.Point(161, 60);
            this.buttonEdit2.Name = "buttonEdit2";
            this.buttonEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Aceptar", null, null, true)});
            this.buttonEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.buttonEdit2.Size = new System.Drawing.Size(50, 38);
            this.buttonEdit2.StyleController = this.dataLayoutControl2;
            this.buttonEdit2.TabIndex = 4;
            this.buttonEdit2.Click += new System.EventHandler(this.buttonEdit2_Click);
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(215, 60);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Aceptar", null, null, true)});
            this.buttonEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.buttonEdit1.Size = new System.Drawing.Size(50, 38);
            this.buttonEdit1.StyleController = this.dataLayoutControl2;
            this.buttonEdit1.TabIndex = 3;
            this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            this.buttonEdit1.EditValueChanged += new System.EventHandler(this.buttonEdit1_EditValueChanged);
            // 
            // Codigo_textEdit
            // 
            this.Codigo_textEdit.Location = new System.Drawing.Point(74, 36);
            this.Codigo_textEdit.Name = "Codigo_textEdit";
            this.Codigo_textEdit.Properties.Mask.EditMask = "n0";
            this.Codigo_textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Codigo_textEdit.Size = new System.Drawing.Size(191, 20);
            this.Codigo_textEdit.StyleController = this.dataLayoutControl2;
            this.Codigo_textEdit.TabIndex = 6;
            // 
            // layoutControlItem
            // 
            this.layoutControlItem.Control = this.Codigo_textEdit;
            this.layoutControlItem.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem.Name = "layoutControlItem";
            this.layoutControlItem.Size = new System.Drawing.Size(257, 24);
            this.layoutControlItem.Text = "Código:";
            this.layoutControlItem.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.buttonEdit2;
            this.layoutControlItem2.Location = new System.Drawing.Point(149, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(54, 47);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.buttonEdit1;
            this.layoutControlItem3.Location = new System.Drawing.Point(203, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(54, 47);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(149, 47);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // paisesBindingSource
            // 
            this.paisesBindingSource.DataMember = "Paises";
            //this.paisesBindingSource.DataSource = this.artistasDataSet;
            // 
            // artistasDataSet
            // 
            //this.artistasDataSet.DataSetName = "ArtistasDataSet";
            //this.artistasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // continentesBindingSource
            // 
            this.continentesBindingSource.DataMember = "Continentes";
            //this.continentesBindingSource.DataSource = this.artistasDataSet;
            // 
            // negocioDataContextBindingSource
            // 
            this.negocioDataContextBindingSource.DataSource = typeof(DXApplication9.NegocioDataContext);
            // 
            // NuevoPaisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 139);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "NuevoPaisForm";
            this.Text = "NuevoPais";
            this.Load += new System.EventHandler(this.NuevoPais_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).EndInit();
            this.dataLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NombrePaisTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNombrePais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Codigo_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paisesBindingSource)).EndInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.artistasDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.continentesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.negocioDataContextBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource negocioDataContextBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
      //  private ArtistasDataSet artistasDataSet;
        private System.Windows.Forms.BindingSource paisesBindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl2;
        private DevExpress.XtraEditors.TextEdit NombrePaisTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNombrePais;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private System.Windows.Forms.BindingSource continentesBindingSource;
        private DevExpress.XtraEditors.TextEdit Codigo_textEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}