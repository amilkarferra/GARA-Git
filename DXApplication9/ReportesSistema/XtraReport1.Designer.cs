namespace DXApplication9.ReportesSistema
{
    partial class XtraReport1
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
            DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table2 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.CustomExpression customExpression1 = new DevExpress.DataAccess.Sql.CustomExpression();
            DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Group group1 = new DevExpress.DataAccess.Sql.Group();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Group group2 = new DevExpress.DataAccess.Sql.Group();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression6 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Group group3 = new DevExpress.DataAccess.Sql.Group();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression7 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Group group4 = new DevExpress.DataAccess.Sql.Group();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression8 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Join join1 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Table table3 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Join join2 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo2 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReport1));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Legend legend1 = new DevExpress.XtraCharts.Legend();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView1 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings2 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.Moneda = new DevExpress.XtraReports.Parameters.Parameter();
            this.UnidadArtistica = new DevExpress.XtraReports.Parameters.Parameter();
            this.Desde = new DevExpress.XtraReports.Parameters.Parameter();
            this.Hasta = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "DXApplication9.Properties.Settings.artistasConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            columnExpression1.ColumnName = "Nombre";
            table1.Name = "Agrupacion";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "Abreviatura";
            table2.Name = "TipoMoneda";
            columnExpression2.Table = table2;
            column2.Expression = columnExpression2;
            column3.Alias = "Expr";
            customExpression1.Aggregate = DevExpress.DataAccess.Sql.AggregationType.Sum;
            customExpression1.Expression = "[OrdenDeTrabajo.ImporteFinal] * (100-[OrdenDeTrabajo.PorcientoCliente])/100";
            column3.Expression = customExpression1;
            columnExpression3.ColumnName = "AgrupacionID";
            columnExpression3.Table = table1;
            column4.Expression = columnExpression3;
            columnExpression4.ColumnName = "TipoMonedaID";
            columnExpression4.Table = table2;
            column5.Expression = columnExpression4;
            selectQuery1.Columns.Add(column1);
            selectQuery1.Columns.Add(column2);
            selectQuery1.Columns.Add(column3);
            selectQuery1.Columns.Add(column4);
            selectQuery1.Columns.Add(column5);
            selectQuery1.FilterString = "[OrdenDeTrabajo.Estado] <> 1s And [OrdenDeTrabajo.Estado] <> 3s";
            selectQuery1.GroupFilterString = "";
            columnExpression5.ColumnName = "TipoMonedaID";
            columnExpression5.Table = table2;
            group1.Expression = columnExpression5;
            columnExpression6.ColumnName = "AgrupacionID";
            columnExpression6.Table = table1;
            group2.Expression = columnExpression6;
            columnExpression7.ColumnName = "Nombre";
            columnExpression7.Table = table1;
            group3.Expression = columnExpression7;
            columnExpression8.ColumnName = "Abreviatura";
            columnExpression8.Table = table2;
            group4.Expression = columnExpression8;
            selectQuery1.Groups.Add(group1);
            selectQuery1.Groups.Add(group2);
            selectQuery1.Groups.Add(group3);
            selectQuery1.Groups.Add(group4);
            selectQuery1.Name = "Agrupacion_1";
            relationColumnInfo1.NestedKeyColumn = "AgrupacionId";
            relationColumnInfo1.ParentKeyColumn = "AgrupacionID";
            join1.KeyColumns.Add(relationColumnInfo1);
            table3.Name = "OrdenDeTrabajo";
            join1.Nested = table3;
            join1.Parent = table1;
            relationColumnInfo2.NestedKeyColumn = "TipoMonedaID";
            relationColumnInfo2.ParentKeyColumn = "TipoMonedaId";
            join2.KeyColumns.Add(relationColumnInfo2);
            join2.Nested = table2;
            join2.Parent = table3;
            selectQuery1.Relations.Add(join1);
            selectQuery1.Relations.Add(join2);
            selectQuery1.Tables.Add(table1);
            selectQuery1.Tables.Add(table3);
            selectQuery1.Tables.Add(table2);
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // Detail
            // 
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 0F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 132F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 132F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrChart1
            // 
            this.xrChart1.BorderColor = System.Drawing.Color.Black;
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart1.DataMember = "Agrupacion_1";
            this.xrChart1.DataSource = this.sqlDataSource1;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Dpi = 254F;
            this.xrChart1.Legend.Name = "Default Legend";
            legend1.Name = "Legend1";
            this.xrChart1.Legends.AddRange(new DevExpress.XtraCharts.Legend[] {
            legend1});
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 24.99998F);
            this.xrChart1.Name = "xrChart1";
            this.xrChart1.SeriesDataMember = "TipoMonedaID";
            series1.ArgumentDataMember = "Nombre";
            series1.Name = "Series 4";
            series1.SummaryFunction = "SUM([Expr])";
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.xrChart1.SeriesTemplate.ArgumentDataMember = "Expr";
            this.xrChart1.SeriesTemplate.View = stackedBarSeriesView1;
            this.xrChart1.SizeF = new System.Drawing.SizeF(2440.94F, 2809.044F);
            // 
            // Moneda
            // 
            this.Moneda.Description = "Moneda";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = "Agrupacion_1";
            dynamicListLookUpSettings1.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings1.DisplayMember = "Abreviatura";
            dynamicListLookUpSettings1.ValueMember = "TipoMonedaID";
            this.Moneda.LookUpSettings = dynamicListLookUpSettings1;
            this.Moneda.Name = "Moneda";
            this.Moneda.Type = typeof(int);
            this.Moneda.ValueInfo = "0";
            // 
            // UnidadArtistica
            // 
            this.UnidadArtistica.Description = "Unidad Artística:";
            dynamicListLookUpSettings2.DataAdapter = null;
            dynamicListLookUpSettings2.DataMember = "Agrupacion_1";
            dynamicListLookUpSettings2.DataSource = this.sqlDataSource1;
            dynamicListLookUpSettings2.DisplayMember = "Nombre";
            dynamicListLookUpSettings2.ValueMember = "AgrupacionID";
            this.UnidadArtistica.LookUpSettings = dynamicListLookUpSettings2;
            this.UnidadArtistica.MultiValue = true;
            this.UnidadArtistica.Name = "UnidadArtistica";
            this.UnidadArtistica.Type = typeof(int);
            this.UnidadArtistica.ValueInfo = "0";
            // 
            // Desde
            // 
            this.Desde.Description = "Desde:";
            this.Desde.Name = "Desde";
            this.Desde.Type = typeof(System.DateTime);
            // 
            // Hasta
            // 
            this.Hasta.Description = "Hasta:";
            this.Hasta.Name = "Hasta";
            this.Hasta.Type = typeof(System.DateTime);
            this.Hasta.ValueInfo = "2050-01-01";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart1});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 2834.044F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // XtraReport1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Agrupacion_1";
            this.DataSource = this.sqlDataSource1;
            this.Dpi = 254F;
            this.FilterString = "[AgrupacionID] In (?UnidadArtistica) And [TipoMonedaID] = ?Moneda And [FechaLiqui" +
    "dacion] >= ?Desde And [FechaLiquidacion] <= ?Hasta";
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(178, 150, 132, 132);
            this.PageHeight = 2159;
            this.PageWidth = 2794;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Moneda,
            this.UnidadArtistica,
            this.Desde,
            this.Hasta});
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.RollPaper = true;
            this.SnapGridSize = 25F;
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRChart xrChart1;
        private DevExpress.XtraReports.Parameters.Parameter Moneda;
        private DevExpress.XtraReports.Parameters.Parameter UnidadArtistica;
        private DevExpress.XtraReports.Parameters.Parameter Desde;
        private DevExpress.XtraReports.Parameters.Parameter Hasta;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
    }
}
