using System;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class DictamenXtraReport : GaraXtraReport
    {
        public DictamenXtraReport(int anArtistaId)
        {
            try
            {
                Artista anArtista = GlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == anArtistaId);
                if (anArtista == null) return;
                InitializeComponent();
                Configuracion_objectDataSource.DataSource = GlobalDataContext.ConfiguracionGeneral;
                Artista_objectDataSource.DataSource =
                    GlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == anArtistaId);
                var trayectoriasActuales = anArtista.TrayectoriasActuales;
                var trayectorias = GlobalDataContext.TrayectoriaArtista.Where(c => c.ArtistaId == anArtista.ArtistaID).ToList();
                trayectorias.AddRange(trayectoriasActuales);
                TrayectoriaArtista_objectDataSource.DataSource = trayectorias;
                Edad_xrTableCell.Text = String.Format("{0} años", anArtista.Edad);

                ConformaPiedDeFirmas(Convert.ToInt32(Enumerados.Reportes.DictamenXtraReport));
                var agrupacionDeArtista = anArtista.PrimerVinculoAgrupacionDeArtista;
                if (agrupacionDeArtista != null)
                {
                    Agrupacion_xrTableCell.Text =
                        agrupacionDeArtista.Agrupacion.Nombre;
                    FechaAlta_xrTableCell.Text = anArtista.PrimerVinculoAgrupacionDeArtista.FechaAlta.ToString();
                }
                else
                {
                    Utils.MuestraError("El integrante no tiene configurado primer vinculo");
                }

            }
            catch (Exception)
            {
                Utils.MuestraError("Error al  generar la información");
            }
        }
    }
}
