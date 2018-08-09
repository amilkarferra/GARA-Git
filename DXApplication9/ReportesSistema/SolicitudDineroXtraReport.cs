using System;
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
            ExportOptions.Xlsx.SheetName = $"Solicitud de Dinero {rangoFecha_xrLabel.Text}";
            ExportOptions.Xls.SheetName = $"Solicitud de Dinero {rangoFecha_xrLabel.Text}";
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
            }
           
        }

    }
}
