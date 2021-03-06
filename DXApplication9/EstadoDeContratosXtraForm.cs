﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace DXApplication9
{
    public partial class EstadoDeContratosXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private NegocioDataContext AGlobalDataContext = (new NegocioDataContext());
        public EstadoDeContratosXtraForm()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            bindingSource1.DataSource = AGlobalDataContext.EstadoContrato;
        }

        private void EstadosDeContratos_gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
        }

        private void EstadosDeContratos_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
           
            AGlobalDataContext.SubmitChanges();
        }

        private void EstadosDeContratos_gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.FieldName == "Descripcion")
            //{
            //    var view = EstadosDeContratos_gridView;
            //    EstadosDeContratos_gridView.SetRowCellValue(e.RowHandle,view.Columns["Abreviatura"],e.Value.ToString().Substring(0,30));
            //}
        }

        private void EstadoDeContratosXtraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)MdiParent).EnableButton("EstadoContrato_barButtonItem",true);
        }

        private void ribbonStatusBar1_Click(object sender, EventArgs e)
        {

        }

        private void Nuevo_barLargeButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopupEstadoContratoXtraForm popup = new PopupEstadoContratoXtraForm();
            if (popup.ShowDialog() == DialogResult.OK){
                AGlobalDataContext = new NegocioDataContext();
                bindingSource1.DataSource = AGlobalDataContext.EstadoContrato;
            }
        }

        private void EstadosDeContratos_gridView_DoubleClick(object sender, EventArgs e)
        {
            //EditaEstado();
        }




        public GridColumn GetClickedInformation(GridControl aGridControl, GridView agridView, out int rowHandle)
        {
            var gridView = agridView;
            Point clickPoint = aGridControl.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {
                rowHandle = hitInfo.RowHandle;
                GridColumn column = hitInfo.Column;
                return column;
            }
            rowHandle = 0;
            return null;


        }
    }
}