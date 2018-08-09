using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class SolicitudDineroXtraReport :GaraXtraReport
    {
        public SolicitudDineroXtraReport(DateTime aFechaIncial,DateTime aFechaFinal,int aMonedaId)
        {
            InitializeComponent();
            OcultaFirmas();
            rangoFecha_xrLabel.Text = String.Format("Desde {0} - Hasta {1}",aFechaIncial.ToShortDateString(),aFechaFinal.ToShortDateString());
            linqServerModeSource1.QueryableSource =
                GlobalDataContext.OrdenDeTrabajo.Where(
                    c =>
                        c.FechaFinalActividad >= aFechaIncial && c.FechaFinalActividad <= aFechaFinal && 
                        c.Estado != (int)Enumerados.EstadoOrdenDeTrabajo.Cancelada && c.FechaSolicitudDePago==null && c.TipoMonedaId == aMonedaId && c.TipoActividad == (int)Enumerados.TipoActividad.OrdenDeTrabajo);
            }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {OrdenDeTrabajo ordenActual = (OrdenDeTrabajo)GetCurrentRow();
            if (ordenActual != null)
            {
                 FechaActividad_xrTableCell.Text = (ordenActual.FechaFinalActividad).AddDays(-7).ToShortDateString();
               // Importe_xrTableCell.Text = (ordenActual.ImportePorActividad*ordenActual.CantidadActividades).ToString();

            }
           
        }

    }
}
