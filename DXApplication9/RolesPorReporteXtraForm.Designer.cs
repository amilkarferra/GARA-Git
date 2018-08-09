namespace DXApplication9
{
    partial class RolesPorReporteUserControl
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
            this.treeListBand1 = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.smallConfiguracionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescripcion = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colExiste = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.smallConfiguracionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListBand1
            // 
            this.treeListBand1.Caption = "treeListBand1";
            this.treeListBand1.Name = "treeListBand1";
            this.treeListBand1.Visible = false;
            // 
            // smallConfiguracionBindingSource
            // 
            this.smallConfiguracionBindingSource.DataSource = typeof(DXApplication9.RolesPorReporteUserControl.SmallConfiguracion);
            // 
            // treeList1
            // 
            this.treeList1.CheckBoxFieldName = "Existe";
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colDescripcion,
            this.colParentId,
            this.colExiste});
            this.treeList1.DataSource = this.smallConfiguracionBindingSource;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsSelection.MultiSelect = true;
            this.treeList1.OptionsView.ShowCheckBoxes = true;
            this.treeList1.Size = new System.Drawing.Size(381, 391);
            this.treeList1.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 34;
            this.colId.Name = "colId";
            this.colId.Width = 90;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.MinWidth = 34;
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 0;
            this.colDescripcion.Width = 90;
            // 
            // colParentId
            // 
            this.colParentId.FieldName = "ParentId";
            this.colParentId.Name = "colParentId";
            this.colParentId.Width = 90;
            // 
            // colExiste
            // 
            this.colExiste.FieldName = "Existe";
            this.colExiste.Name = "colExiste";
            this.colExiste.Width = 90;
            // 
            // RolesPorReporteUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Name = "RolesPorReporteUserControl";
            this.Size = new System.Drawing.Size(381, 391);
            ((System.ComponentModel.ISupportInitialize)(this.smallConfiguracionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListBand treeListBand1;
        private System.Windows.Forms.BindingSource smallConfiguracionBindingSource;
        public DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescripcion;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colExiste;

    }
}