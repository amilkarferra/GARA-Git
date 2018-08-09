using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication9.ReportesSistema
{
    public partial class DeudaHistoricoXtraReport : DXApplication9.ReportesSistema.GaraXtraReport
    {

        public DeudaHistoricoXtraReport(int anAgrupacionId, int aTipoMonedaId, DateTime aFechaInicial, DateTime aFechaFinal)
        {
            InitializeComponent();
            OcultaFirmas();
            var historicos = new NegocioDataContext().HistoricoDeuda.Where(c => c.AgrupacionId == anAgrupacionId && c.TipoMonedaId == aTipoMonedaId && c.Fecha >= aFechaInicial && c.Fecha <= aFechaFinal);
            if (!historicos.Any())
            {
                XtraMessageBox.Show("No existen datos para mostrar", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RangoFecha_xrLabel.Text = "Sin deudas";
            }
          
                linqServerModeSource1.QueryableSource = historicos;

                RangoFecha_xrLabel.Text = String.Format("{0} - {1}, ", aFechaInicial > Convert.ToDateTime("1/1/2017") ? aFechaInicial.ToShortDateString() : "Origen", aFechaFinal > Convert.ToDateTime("1/1/2017") ? aFechaFinal.ToShortDateString() : "Actualidad");
         
          

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var historico = ((HistoricoDeuda)GetCurrentRow());
            Acción_xrTableCell.Text =
                ((Enumerados.TipoGestionDeuda)
                    Enum.Parse(typeof(Enumerados.TipoGestionDeuda),
                        historico.TipoIncrementoDeuda.ToString())).ToString();

           // Acumulado_xrTableCell.Text = historico.EsInicializacion ? historico.importe.ToString() : ((historico.DeudaAnterior + (historico.TipoIncrementoDeuda == Convert.ToInt32(Enumerados.TipoGestionDeuda.NuevaDeuda) ? (historico.importe) : (historico.importe) * -1))).ToString();
            Acumulado_xrTableCell.Text = historico.DeudaResultante.ToString();
        }

    }
}
