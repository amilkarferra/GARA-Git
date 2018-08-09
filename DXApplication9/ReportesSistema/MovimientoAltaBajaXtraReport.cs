using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class MovimientoAltaBajaXtraReport : DXApplication9.ReportesSistema.GaraXtraReport
    {
        public MovimientoAltaBajaXtraReport(AgrupacionDeArtista anAgrupacionDeArtista, Enumerados.TipoMovimiento aTipoMovimiento)
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource = new NegocioDataContext().AgrupacionDeArtista.Where(c=>c.AgrupacionDeArtistaID==anAgrupacionDeArtista.AgrupacionDeArtistaID);
            OcultaFirmas();
            switch (aTipoMovimiento)
            {
                case Enumerados.TipoMovimiento.Alta:
                    if (anAgrupacionDeArtista.FechaAlta == null)
                    {
                        Utils.MuestraError("El integrante debe tener asignada una fecha de firma del contrato");
                        break;
                    }
                    Fecha_xrLabel.Text = Convert.ToDateTime(anAgrupacionDeArtista.FechaAlta).ToLongDateString();
                    break;
                case Enumerados.TipoMovimiento.Baja:
                    if (anAgrupacionDeArtista.FechaBaja == null)
                    {
                        Utils.MuestraError("El integrante debe tener asignada una fecha de baja");
                        break;
                    }
                    Fecha_xrLabel.Text = Convert.ToDateTime(anAgrupacionDeArtista.FechaBaja).ToLongDateString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("aTipoMovimiento", aTipoMovimiento, null);
            }

            Director_xrLabel.Text += " " + anAgrupacionDeArtista.Agrupacion.Nombre;
            TipoMovimeinto_xrLabel.Text = aTipoMovimiento.StringValue();
        }

    }
}
