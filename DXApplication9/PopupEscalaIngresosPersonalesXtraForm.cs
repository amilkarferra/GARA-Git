using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DXApplication9.ReportesSistema;

namespace DXApplication9.Code
{
    public partial class PopupEscalaIngresosPersonalesXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public PopupEscalaIngresosPersonalesXtraForm()
        {
            InitializeComponent();
            tipoMonedaBindingSource.DataSource = new NegocioDataContext().TipoMoneda;
        }

        private void OK_simpleButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            IngresosPersonalesEscalaValoresXtraReport reporte = new IngresosPersonalesEscalaValoresXtraReport(Convert.ToDecimal(ImporteMinimo_textEdit.EditValue), Convert.ToDecimal(ImporteMaximo_textEdit.EditValue),FechaInicial_dateEdit.DateTime
                ,FechaFinal_dateEdit.DateTime,Convert.ToInt32(TipoMoneda_lookUpEdit.EditValue));
            reporte.CreateDocument();
            reporte.ShowPreviewDialog();
        }

        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}