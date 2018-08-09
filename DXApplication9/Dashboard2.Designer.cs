namespace DXApplication9
{
    partial class Dashboard2
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
            DevExpress.DashboardCommon.Dimension dimension1 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension2 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension3 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.ChartPane chartPane1 = new DevExpress.DashboardCommon.ChartPane();
            DevExpress.DashboardCommon.SimpleSeries simpleSeries1 = new DevExpress.DashboardCommon.SimpleSeries();
            DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters msSqlConnectionParameters1 = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table2 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table3 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table4 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column6 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression6 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column7 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression7 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column8 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression8 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Join join1 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Join join2 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo2 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.Join join3 = new DevExpress.DataAccess.Sql.Join();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo3 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard2));
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            this.chartDashboardItem1 = new DevExpress.DashboardCommon.ChartDashboardItem();
            this.dashboardSqlDataSource2 = new DevExpress.DashboardCommon.DashboardSqlDataSource();
            this.dashboardObjectDataSource1 = new DevExpress.DashboardCommon.DashboardObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // chartDashboardItem1
            // 
            dimension1.DataMember = "Agrupacion.Nombre";
            dimension1.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending;
            dimension2.DataMember = "Nomina.FechaEmision";
            dimension3.DataMember = "TipoMoneda.Abreviatura";
            this.chartDashboardItem1.Arguments.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension1,
            dimension2,
            dimension3});
            this.chartDashboardItem1.AxisX.TitleVisible = false;
            this.chartDashboardItem1.ComponentName = "chartDashboardItem1";
            measure1.DataMember = "ImporteFinal";
            this.chartDashboardItem1.DataItemRepository.Clear();
            this.chartDashboardItem1.DataItemRepository.Add(measure1, "DataItem0");
            this.chartDashboardItem1.DataItemRepository.Add(dimension1, "DataItem1");
            this.chartDashboardItem1.DataItemRepository.Add(dimension2, "DataItem2");
            this.chartDashboardItem1.DataItemRepository.Add(dimension3, "DataItem3");
            this.chartDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.chartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.chartDashboardItem1.Name = "Gráfico 1";
            chartPane1.Name = "Panel 2";
            chartPane1.PrimaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.PrimaryAxisY.ShowGridLines = true;
            chartPane1.PrimaryAxisY.TitleVisible = true;
            chartPane1.SecondaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.SecondaryAxisY.ShowGridLines = false;
            chartPane1.SecondaryAxisY.TitleVisible = true;
            simpleSeries1.AddDataItem("Value", measure1);
            chartPane1.Series.AddRange(new DevExpress.DashboardCommon.ChartSeries[] {
            simpleSeries1});
            this.chartDashboardItem1.Panes.AddRange(new DevExpress.DashboardCommon.ChartPane[] {
            chartPane1});
            this.chartDashboardItem1.ShowCaption = true;
            // 
            // dashboardSqlDataSource2
            // 
            this.dashboardSqlDataSource2.ComponentName = "dashboardSqlDataSource2";
            this.dashboardSqlDataSource2.ConnectionName = "artistasConnectionString";
            msSqlConnectionParameters1.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer;
            msSqlConnectionParameters1.DatabaseName = "artistas";
            msSqlConnectionParameters1.ServerName = ".\\SQLExpress";
            this.dashboardSqlDataSource2.ConnectionParameters = msSqlConnectionParameters1;
            this.dashboardSqlDataSource2.Name = "Origen de datos SQL 1";
            columnExpression1.ColumnName = "Nombre";
            table1.MetaSerializable = "<Meta X=\"30\" Y=\"30\" Width=\"125\" Height=\"229\" />";
            table1.Name = "Agrupacion";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "FechaEmision";
            table2.MetaSerializable = "<Meta X=\"340\" Y=\"210\" Width=\"125\" Height=\"172\" />";
            table2.Name = "Nomina";
            columnExpression2.Table = table2;
            column2.Expression = columnExpression2;
            columnExpression3.ColumnName = "Abreviatura";
            table3.MetaSerializable = "<Meta X=\"340\" Y=\"30\" Width=\"125\" Height=\"134\" />";
            table3.Name = "TipoMoneda";
            columnExpression3.Table = table3;
            column3.Expression = columnExpression3;
            columnExpression4.ColumnName = "Anno";
            table4.MetaSerializable = "<Meta X=\"185\" Y=\"30\" Width=\"125\" Height=\"666\" />";
            table4.Name = "OrdenDeTrabajo";
            columnExpression4.Table = table4;
            column4.Expression = columnExpression4;
            columnExpression5.ColumnName = "ImporteFinal";
            columnExpression5.Table = table4;
            column5.Expression = columnExpression5;
            columnExpression6.ColumnName = "PorCientoUnidadArtistica";
            columnExpression6.Table = table4;
            column6.Expression = columnExpression6;
            columnExpression7.ColumnName = "DobleVinculo";
            columnExpression7.Table = table1;
            column7.Expression = columnExpression7;
            columnExpression8.ColumnName = "PerteneceACatalogo";
            columnExpression8.Table = table1;
            column8.Expression = columnExpression8;
            selectQuery1.Columns.Add(column1);
            selectQuery1.Columns.Add(column2);
            selectQuery1.Columns.Add(column3);
            selectQuery1.Columns.Add(column4);
            selectQuery1.Columns.Add(column5);
            selectQuery1.Columns.Add(column6);
            selectQuery1.Columns.Add(column7);
            selectQuery1.Columns.Add(column8);
            selectQuery1.Name = "Agrupacion";
            relationColumnInfo1.NestedKeyColumn = "AgrupacionId";
            relationColumnInfo1.ParentKeyColumn = "AgrupacionID";
            join1.KeyColumns.Add(relationColumnInfo1);
            join1.Nested = table4;
            join1.Parent = table1;
            relationColumnInfo2.NestedKeyColumn = "TipoMonedaID";
            relationColumnInfo2.ParentKeyColumn = "TipoMonedaId";
            join2.KeyColumns.Add(relationColumnInfo2);
            join2.Nested = table3;
            join2.Parent = table4;
            relationColumnInfo3.NestedKeyColumn = "DocumentoReferenciaId";
            relationColumnInfo3.ParentKeyColumn = "OrdenDeTrabajoID";
            join3.KeyColumns.Add(relationColumnInfo3);
            join3.Nested = table2;
            join3.Parent = table4;
            selectQuery1.Relations.Add(join1);
            selectQuery1.Relations.Add(join2);
            selectQuery1.Relations.Add(join3);
            selectQuery1.Tables.Add(table1);
            selectQuery1.Tables.Add(table4);
            selectQuery1.Tables.Add(table3);
            selectQuery1.Tables.Add(table2);
            this.dashboardSqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
            this.dashboardSqlDataSource2.ResultSchemaSerializable = resources.GetString("dashboardSqlDataSource2.ResultSchemaSerializable");
            // 
            // dashboardObjectDataSource1
            // 
            this.dashboardObjectDataSource1.ComponentName = "dashboardObjectDataSource1";
            this.dashboardObjectDataSource1.DataSource = typeof(DXApplication9.OrdenDeTrabajo);
            this.dashboardObjectDataSource1.Name = "Origen de datos de objeto 1";
            // 
            // Dashboard2
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardSqlDataSource2,
            this.dashboardObjectDataSource1});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.chartDashboardItem1});
            dashboardLayoutItem1.DashboardItem = this.chartDashboardItem1;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1});
            dashboardLayoutGroup1.DashboardItem = null;
            this.LayoutRoot = dashboardLayoutGroup1;
            this.Title.Text = "Tablero de control";
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        private DevExpress.DashboardCommon.ChartDashboardItem chartDashboardItem1;
        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource1;
        private DevExpress.DashboardCommon.DashboardSqlDataSource dashboardSqlDataSource2;
    }
}
