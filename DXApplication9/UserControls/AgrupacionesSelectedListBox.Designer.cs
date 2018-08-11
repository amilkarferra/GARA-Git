namespace DXApplication9.UserControls
{
    partial class AgrupacionesSelectedListBox
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.agrupacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FiltrarAgrupacion_dropDownButton = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.SoloCatalogo_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.MostrarNoCatalogo_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.MostrarTodos_barButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.Agrupaciones_checkedComboBoxEdit = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupaciones_checkedComboBoxEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // agrupacionBindingSource
            // 
            this.agrupacionBindingSource.DataSource = typeof(DXApplication9.Agrupacion);
            this.agrupacionBindingSource.Sort = "Nombre";
            // 
            // FiltrarAgrupacion_dropDownButton
            // 
            this.FiltrarAgrupacion_dropDownButton.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show;
            this.FiltrarAgrupacion_dropDownButton.DropDownControl = this.popupMenu1;
            this.FiltrarAgrupacion_dropDownButton.ImageOptions.Image = global::DXApplication9.Properties.Resources.show_16x161;
            this.FiltrarAgrupacion_dropDownButton.Location = new System.Drawing.Point(145, 0);
            this.FiltrarAgrupacion_dropDownButton.Name = "FiltrarAgrupacion_dropDownButton";
            this.FiltrarAgrupacion_dropDownButton.Size = new System.Drawing.Size(36, 21);
            toolTipTitleItem1.Text = "Filtrar Agrupaciones";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Filtro rápido: Solo catálogo, no del catálogo y mostrar todas las  Unidades Artís" +
    "ticas.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.FiltrarAgrupacion_dropDownButton.SuperTip = superToolTip1;
            this.FiltrarAgrupacion_dropDownButton.TabIndex = 4;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.SoloCatalogo_barButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.MostrarNoCatalogo_barButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.MostrarTodos_barButtonItem)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // SoloCatalogo_barButtonItem
            // 
            this.SoloCatalogo_barButtonItem.Caption = "Mostrar solo catálogo";
            this.SoloCatalogo_barButtonItem.Id = 0;
            this.SoloCatalogo_barButtonItem.ImageOptions.Image = global::DXApplication9.Properties.Resources.multiplemasterfilter_16x16;
            this.SoloCatalogo_barButtonItem.ImageOptions.LargeImage = global::DXApplication9.Properties.Resources.multiplemasterfilter_32x32;
            this.SoloCatalogo_barButtonItem.Name = "SoloCatalogo_barButtonItem";
            this.SoloCatalogo_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SoloCatalogo_barButtonItem_ItemClick);
            // 
            // MostrarNoCatalogo_barButtonItem
            // 
            this.MostrarNoCatalogo_barButtonItem.Caption = "Mostrar solo los que no pertenecen al catálogo";
            this.MostrarNoCatalogo_barButtonItem.Id = 1;
            this.MostrarNoCatalogo_barButtonItem.ImageOptions.Image = global::DXApplication9.Properties.Resources.filterbyargument_pie_16x16;
            this.MostrarNoCatalogo_barButtonItem.ImageOptions.LargeImage = global::DXApplication9.Properties.Resources.filterbyargument_pie_32x32;
            this.MostrarNoCatalogo_barButtonItem.Name = "MostrarNoCatalogo_barButtonItem";
            this.MostrarNoCatalogo_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MostrarNoCatalogo_barButtonItem_ItemClick);
            // 
            // MostrarTodos_barButtonItem
            // 
            this.MostrarTodos_barButtonItem.Caption = "Mostar Todo";
            this.MostrarTodos_barButtonItem.Id = 2;
            this.MostrarTodos_barButtonItem.ImageOptions.Image = global::DXApplication9.Properties.Resources.filterbyseries_pie_16x16;
            this.MostrarTodos_barButtonItem.ImageOptions.LargeImage = global::DXApplication9.Properties.Resources.filterbyseries_pie_32x32;
            this.MostrarTodos_barButtonItem.Name = "MostrarTodos_barButtonItem";
            this.MostrarTodos_barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MostrarTodos_barButtonItem_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.SoloCatalogo_barButtonItem,
            this.MostrarNoCatalogo_barButtonItem,
            this.MostrarTodos_barButtonItem});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(181, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 21);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(181, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 21);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(181, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 21);
            // 
            // Agrupaciones_checkedComboBoxEdit
            // 
            this.Agrupaciones_checkedComboBoxEdit.EditValue = "";
            this.Agrupaciones_checkedComboBoxEdit.Location = new System.Drawing.Point(0, 0);
            this.Agrupaciones_checkedComboBoxEdit.Name = "Agrupaciones_checkedComboBoxEdit";
            this.Agrupaciones_checkedComboBoxEdit.Properties.AllowMultiSelect = true;
            this.Agrupaciones_checkedComboBoxEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.Agrupaciones_checkedComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Agrupaciones_checkedComboBoxEdit.Properties.DataSource = this.agrupacionBindingSource;
            this.Agrupaciones_checkedComboBoxEdit.Properties.DisplayMember = "Nombre";
            this.Agrupaciones_checkedComboBoxEdit.Properties.IncrementalSearch = true;
            this.Agrupaciones_checkedComboBoxEdit.Properties.ValueMember = "AgrupacionID";
            this.Agrupaciones_checkedComboBoxEdit.Size = new System.Drawing.Size(139, 20);
            this.Agrupaciones_checkedComboBoxEdit.TabIndex = 3;
            // 
            // AgrupacionesSelectedListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FiltrarAgrupacion_dropDownButton);
            this.Controls.Add(this.Agrupaciones_checkedComboBoxEdit);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "AgrupacionesSelectedListBox";
            this.Size = new System.Drawing.Size(181, 21);
            ((System.ComponentModel.ISupportInitialize)(this.agrupacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Agrupaciones_checkedComboBoxEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource agrupacionBindingSource;
        private DevExpress.XtraEditors.DropDownButton FiltrarAgrupacion_dropDownButton;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem SoloCatalogo_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem MostrarNoCatalogo_barButtonItem;
        private DevExpress.XtraBars.BarButtonItem MostrarTodos_barButtonItem;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.CheckedComboBoxEdit Agrupaciones_checkedComboBoxEdit;
    }
}
