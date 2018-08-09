using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication9.UserControls
{
    public partial class PopupFechaMonedaXtraUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public DateTime FechaInicial;
        public DateTime FechaFinal;
        public int MonedaId;
        
        public PopupFechaMonedaXtraUserControl()
        {
            InitializeComponent();
            tipoMonedaBindingSource.DataSource = (new NegocioDataContext()).TipoMoneda.Where(c=>c.OrdenDeTrabajo);
            dateEdit1.DateTime = GetMiercolesAnterior();

        }

        public bool ValidateForm()
        {
            var validate1 = dxValidationProvider1.Validate();
            var validate2 = dxValidationProvider2.Validate();
            var aBool = validate1 && validate2;return aBool;
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            FechaInicial = dateEdit1.DateTime;
            Fecha_dateEdit.DateTime = FechaInicial.AddDays(7);
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            FechaFinal = Fecha_dateEdit.DateTime;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            MonedaId = Convert.ToInt32(Moneda_lookUpEdit.EditValue);
        }


        private DateTime GetMiercolesProximo()
        {
            DateTime dia= DateTime.Today;
            while (dia.DayOfWeek!=DayOfWeek.Wednesday)
            {
                dia = dia.AddDays(1);
            }
            return dia;
        }
        private DateTime GetMiercolesAnterior()
        {
            DateTime dia = DateTime.Today;
            while (dia.DayOfWeek != DayOfWeek.Wednesday)
            {
                dia = dia.AddDays(-1);
            }
            return dia;
        }
        
    }
}
