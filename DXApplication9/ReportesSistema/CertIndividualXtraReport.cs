using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

//using DevExpress.DXCore.Controls.XtraEditors;

namespace DXApplication9.ReportesSistema
{
    public partial class CertIndividualXtraReport : GaraXtraReport
    {

        public CertIndividualXtraReport(int anArtistaId)
        {
            var anArtista = GlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == anArtistaId);
            if (anArtista == null)
            {
                Utils.MuestraInformacion("Error al realizar la acción");
                Dispose();
                
            }
            ConfiguracionGeneral aconf = GlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            AgrupacionDeArtista agrupacionDeArtista =
                GlobalDataContext.AgrupacionDeArtista.FirstOrDefault(
                    c =>
                        c.TipoVinculo == (int) Enumerados.TipoVinculoDeArtista.PrimerVinculo &&
                        c.ArtistaId == anArtista.ArtistaID && c.FechaBaja==null);
            if (agrupacionDeArtista == null)
            {
                XtraMessageBox.Show(
                    "El integrante no esta configurado como primer vinculo, por lo qeu no se puede emitir el certifico",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Dispose();
            }
            InitializeComponent();
            TextoGerente_xrLabel.Text = string.Format("{0},{1} de la {2}, sita en {3}.",aconf.NombreDeJefeAgencia,aconf.CargoDeJefeDeAgencia,aconf.Agencia,aconf.DireccionEmpresa);
            CertificoTexto_xrLabel.Text += string.Format(" Que  {0} se desempeña como {1} ({2}) en la Unidad Artística {3} perteneciente a nuestro catálogo.", anArtista.NombreCompleto,agrupacionDeArtista.NomencladorCargo.Descripcion,agrupacionDeArtista.AbrevDesempenno,agrupacionDeArtista.Agrupacion.Nombre);
            Constancia_xrLabel.Text = String.Format("Y para que así conste se firma la presente en la Habana el {0}.",
                DateTime.Today.ToString("D"));
            ConformaPiedDeFirmas((int)Enumerados.Reportes.CertificoIndividualXtraReport);
        }

    }
}
