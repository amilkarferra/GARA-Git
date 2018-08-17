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
            var dc = new NegocioDataContext();
            tipoMonedaBindingSource.DataSource = dc.TipoMoneda;
            nomencladorEscalasDeIngresoBindingSource.DataSource = dc.NomencladorEscalasDeIngreso;
            FechaInicial_dateEdit.DateTime = Utils.PrimerDiaAnnoEnCurso;
            FechaFinal_dateEdit.DateTime = Utils.UltimoDiaAnnoEnCurso;
        }

        private void OK_simpleButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            IngresosPersonalesSegunEscalaDeValores_XtraReport reporte = new IngresosPersonalesSegunEscalaDeValores_XtraReport(Convert.ToInt32(Escala_lookUpEdit.EditValue), FechaInicial_dateEdit.DateTime,FechaFinal_dateEdit.DateTime,Convert.ToInt32(TipoMoneda_lookUpEdit.EditValue));
            reporte.CreateDocument();
            reporte.ShowPreviewDialog();
        }

        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Escala_lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            var escalaIngresoId = Convert.ToInt32(Escala_lookUpEdit.EditValue);
            var escala = new NegocioDataContext().NomencladorEscalasDeIngreso.FirstOrDefault(c=>c.NomencladorEscalaIngresoID== escalaIngresoId);
            ImporteMaximo_textEdit.EditValue = escala.ImporteMaximo;
            ImporteMinimo_textEdit.EditValue = escala.ImporteMinimo;
        }
    }
}