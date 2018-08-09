using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Native;
using DXApplication9.ReportesSistema;

namespace DXApplication9
{
    public partial class PopupCuentasDeBanco : DevExpress.XtraEditors.XtraForm
    {
        readonly NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private readonly ControlClientes AGlobalControlClientes;
        public PopupCuentasDeBanco(ControlClientes controlClientes)
        {
            InitializeComponent();
            AGlobalControlClientes = controlClientes;
            gridControl1.DataSource =
                AGlobalDataContext.CuentasBancariasDeCliente.Where(c => c.ControlClienteId == AGlobalControlClientes.ControlClienteID);
            TipoMoneda_repositoryItemLookUpEdit.DataSource = AGlobalDataContext.TipoMoneda.Where(c => c.OrdenDeTrabajo );
            
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
            AGlobalDataContext.CuentasBancariasDeCliente.Where(c => c.CuentaBancariaID == AGlobalControlClientes.ControlClienteID);

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var monedasUsadas =AGlobalDataContext.CuentasBancariasDeCliente.Where(c => c.ControlClienteId == AGlobalControlClientes.ControlClienteID).Select(d=>d.TipoMonedaId);
            int[] monedasIds = new int[DynamicQueryable.Count(monedasUsadas)];
            int i = 0;
            foreach (var monedaUsada    in monedasUsadas)
            {
                monedasIds[i] = monedaUsada;
                i++;
            }
          
          
         TipoMoneda_repositoryItemLookUpEdit.DataSource = AGlobalDataContext.TipoMoneda.Where(c =>!monedasIds.Contains(c.TipoMonedaID));
         TipoMoneda_repositoryItemLookUpEdit.ForceInitialize();
         gridView1.SetRowCellValue(e.RowHandle, colControlClienteId, AGlobalControlClientes.ControlClienteID);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Dispose();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var gridView = gridView1;
            Point clickPoint = gridControl1.PointToClient(MousePosition);
            var hitInfo = gridView.CalcHitInfo(clickPoint);
            if (hitInfo.InRowCell)
            {
                int rowHandle = hitInfo.RowHandle;
                GridColumn column = hitInfo.Column;
                //MessageBox.Show(column.Name + " "+rowHandle);
                if (column == Del_gridColumn)
                {
                    CuentasBancariasDeCliente cuenta = (CuentasBancariasDeCliente)gridView.GetRow(rowHandle);
                    if (
                        MessageBox.Show("Esta acción es irreversible", "Atención", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        AGlobalDataContext.CuentasBancariasDeCliente.DeleteOnSubmit(cuenta);

                        AGlobalDataContext.SubmitChanges();
                        gridView1.DeleteRow(rowHandle);
                    }
                }
            }
        }


    }
}