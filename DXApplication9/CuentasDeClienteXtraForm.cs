using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication9
{
    public partial class CuentasDeClienteXtraForm : DevExpress.XtraEditors.XtraForm
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private ControlClientes AControlClientes;
        public CuentasDeClienteXtraForm(ControlClientes aControlCliente)
        {
            AControlClientes = aControlCliente;
            InitializeComponent();
            cuentasBancariasDeClienteBindingSource.DataSource = AGlobalDataContext.CuentasBancariasDeCliente.Where(c => c.ControlClienteId == aControlCliente.ControlClienteID);
            tipoMonedaBindingSource.DataSource = AGlobalDataContext.TipoMoneda;
        }

        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            var cuenta = (CuentasBancariasDeCliente)gridView1.GetRow(gridView1.GetSelectedRows()[0]);
            cuenta.ControlClienteId = AControlClientes.ControlClienteID;
            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                if (AControlClientes.CuentasBancariasDeCliente.Any(c => c.TipoMonedaId == cuenta.TipoMonedaId))
                {
                    MessageBox.Show("Ya existe una cuenta para esa moneda");
                    return;
                }
            }
            AGlobalDataContext.SubmitChanges();
            
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var cuenta = (CuentasBancariasDeCliente) e.Row;
            cuenta.ControlClienteId = AControlClientes.ControlClienteID;
            if (cuenta.CuentaBancariaID == 0 &&
                AControlClientes.CuentasBancariasDeCliente.Any(c => c.TipoMonedaId == cuenta.TipoMonedaId))
            {
                MessageBox.Show("Ya existe una cuenta para esa moneda");
                return;
            }
            AGlobalDataContext.SubmitChanges();
        }
    }
}