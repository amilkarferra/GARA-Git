namespace DXApplication9
{
    partial class HistoricoDeudaTodosGruposXtraReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.linqServerModeSource1 = new DevExpress.Data.Linq.LinqServerModeSource();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.Agrupacion_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Moneda_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Deuda_xrTableCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.linqServerModeSource2 = new DevExpress.Data.Linq.LinqServerModeSource();
            this.oDataServerModeSource1 = new DevExpress.Data.ODataLinq.ODataServerModeSource();
            //this.artistasDataSet = new DXApplication9.ArtistasDataSet();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DatosContactoxrRichText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oDataServerModeSource1)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.artistasDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 25F;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable1
            // 
            this.xrTable1.Dpi = 100F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow10});
            this.xrTable1.SizeF = new System.Drawing.SizeF(533.3333F, 25F);
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell7,
            this.xrTableCell2});
            this.xrTableRow10.Dpi = 100F;
            this.xrTableRow10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.StylePriority.UseBorders = false;
            this.xrTableRow10.StylePriority.UseFont = false;
            this.xrTableRow10.StylePriority.UseTextAlignment = false;
            this.xrTableRow10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableRow10.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Text = "Agrupación";
            this.xrTableCell1.Weight = 2.539050695597675D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 100F;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Moneda";
            this.xrTableCell7.Weight = 0.44801017920532904D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "Deuda";
            this.xrTableCell2.Weight = 0.79418912519699592D;
            // 
            // linqServerModeSource1
            // 
            this.linqServerModeSource1.ElementType = typeof(DXApplication9.HistoricoDeudaTodosGruposXtraReport.ShortHistorico);
            this.linqServerModeSource1.KeyExpression = "[HistoricoDeudaID]";
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 100F;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow11});
            this.xrTable2.SizeF = new System.Drawing.SizeF(533.3333F, 25F);
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.Agrupacion_xrTableCell,
            this.Moneda_xrTableCell,
            this.Deuda_xrTableCell});
            this.xrTableRow11.Dpi = 100F;
            this.xrTableRow11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.StylePriority.UseBorders = false;
            this.xrTableRow11.StylePriority.UseFont = false;
            this.xrTableRow11.Weight = 1D;
            // 
            // Agrupacion_xrTableCell
            // 
            this.Agrupacion_xrTableCell.Dpi = 100F;
            this.Agrupacion_xrTableCell.Name = "Agrupacion_xrTableCell";
            this.Agrupacion_xrTableCell.Weight = 3.5812506103515624D;
            // 
            // Moneda_xrTableCell
            // 
            this.Moneda_xrTableCell.Dpi = 100F;
            this.Moneda_xrTableCell.Name = "Moneda_xrTableCell";
            this.Moneda_xrTableCell.Text = "Moneda_xrTableCell";
            this.Moneda_xrTableCell.Weight = 0.63190399169921863D;
            // 
            // Deuda_xrTableCell
            // 
            this.Deuda_xrTableCell.Dpi = 100F;
            this.Deuda_xrTableCell.Name = "Deuda_xrTableCell";
            this.Deuda_xrTableCell.Text = "Deuda";
            this.Deuda_xrTableCell.Weight = 1.1201785278320315D;
            // 
            // oDataServerModeSource1
            // 
            this.oDataServerModeSource1.ElementType = null;
            this.oDataServerModeSource1.KeyExpressions = null;
            this.oDataServerModeSource1.Query = null;
            // 
            // artistasDataSet1
            // 
            //this.artistasDataSet.DataSetName = "ArtistasDataSet";
            //this.artistasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(DXApplication9.HistoricoDeudaTodosGruposXtraReport.ShortHistorico);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // HistoricoDeudaTodosGruposXtraReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.Configuracion_objectDataSource,
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
 
            this.Scripts.OnFillEmptySpace = "XtraReport1_FillEmptySpace";
            this.Version = "16.2";
            this.Controls.SetChildIndex(this.GroupHeader1, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DatosContactoxrRichText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oDataServerModeSource1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.artistasDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow11;
        private DevExpress.XtraReports.UI.XRTableCell Agrupacion_xrTableCell;
        private DevExpress.XtraReports.UI.XRTableCell Deuda_xrTableCell;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.Data.Linq.LinqServerModeSource linqServerModeSource1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell Moneda_xrTableCell;
        private DevExpress.Data.Linq.LinqServerModeSource linqServerModeSource2;
        private DevExpress.Data.ODataLinq.ODataServerModeSource oDataServerModeSource1;
      //  private ArtistasDataSet artistasDataSet;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;


    }
}
