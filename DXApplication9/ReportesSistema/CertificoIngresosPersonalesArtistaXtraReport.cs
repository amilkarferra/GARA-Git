using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class CertificoIngresosPersonalesArtistaXtraReport : GaraXtraReport
    {
        public CertificoIngresosPersonalesArtistaXtraReport(Artista anArtista, DateTime fechaIncial, DateTime FechaFinal)
        {
            var dc = new NegocioDataContext();
            var monedaCUC = dc.TipoMoneda.FirstOrDefault(c => c.Abreviatura.Trim() == "CUC");
            var monedaCUP = dc.TipoMoneda.FirstOrDefault(c => c.Abreviatura.Trim() == "CUP");
            if (monedaCUP == null || monedaCUC == null)
            {
                Utils.MuestraError("Antes debe definir una moneda con abreviatura CUC y otra con Abreviatura CUP");
                this.ClosePreview();
                return;
            }
            
            InitializeComponent();

            Configuracion_objectDataSource.DataSource = GlobalDataContext.ConfiguracionGeneral;

            NombreYApellidos_xrTableCell.Text = anArtista.NombreCompleto;
            CI_XrTableCell2.Text = anArtista.CarnetIdentidad.Trim();
            FechaIncial_xrTableCell.Text = fechaIncial.ToShortDateString();
            FechaFinal_xrTableCell.Text = FechaFinal.ToShortDateString();

            var importeParticipacionEmpresaCUC = anArtista.GetImportesDeParticipacionDeEmpresa(monedaCUC.TipoMonedaID, fechaIncial, FechaFinal).RedondeaDecimal();
            ImporteParticipacionEmpresaCUC_xrTableCell.Text = importeParticipacionEmpresaCUC.ToString();

            var importeParticipacionEmpresaCUP = anArtista.GetImportesDeParticipacionDeEmpresa(monedaCUP.TipoMonedaID, fechaIncial, FechaFinal).RedondeaDecimal();
            ImporteParticipacionEmpresaCUP_xrTableCell.Text = importeParticipacionEmpresaCUP.ToString();

            var importeCttoActividadesCUC = anArtista.GetImporteDeContratoDeServicio(monedaCUC.TipoMonedaID, fechaIncial, FechaFinal).RedondeaDecimal();
            ImportesActividadesCUC_xrTableCell.Text =importeCttoActividadesCUC.ToString();

            var importeCttoActividadesCUP = anArtista.GetImporteDeContratoDeServicio(monedaCUP.TipoMonedaID, fechaIncial, FechaFinal).RedondeaDecimal();
            ImportesActividadesCUP_xrTableCell.Text = importeCttoActividadesCUP.ToString();
            
            var ingresosPersonalesCUC = anArtista.GetIngresosPersonales(monedaCUC.TipoMonedaID, fechaIncial, FechaFinal).RedondeaDecimal();
            IngresosPersonalesCUC_xrTableCell.Text = ingresosPersonalesCUC.ToString();

            var impuestoSobreIngresosPersonalesCUC = (ingresosPersonalesCUC*5/100).RedondeaDecimal();
            ImpuestosRetenidosCUC_xrTableCell.Text = impuestoSobreIngresosPersonalesCUC.ToString();

            var ingresosPersonalesCUP = anArtista.GetIngresosPersonales(monedaCUP.TipoMonedaID, fechaIncial, FechaFinal).RedondeaDecimal();
            IngresosPersonalesCUP_xrTableCell.Text = ingresosPersonalesCUP.ToString();

            var impuestosSobreIngresosPersonalesCUP = (ingresosPersonalesCUP*5/100).RedondeaDecimal();
            ImpuestosRetenidosCUP_xrTableCell.Text = impuestosSobreIngresosPersonalesCUP.ToString();

            if (importeCttoActividadesCUC > 0)
            {
                var porcientoParticipacionEmpresaCUC = (importeParticipacionEmpresaCUC*100/
                                                       importeCttoActividadesCUC).RedondeaDecimal();
                PorcientoParticipacionEmpresaCUC_xrTableCell.Text = porcientoParticipacionEmpresaCUC.ToString();
            }
            else
            {
                PorcientoParticipacionEmpresaCUC_xrTableCell.Text = "-";
            }

            if (importeCttoActividadesCUP > 0)
            {

                var porcientoParticipacionEmpresaCUP = (importeParticipacionEmpresaCUP*100/
                                                       importeCttoActividadesCUP).RedondeaDecimal();
                PorcientoParticipacionEmpresaCUP_xrTableCell.Text = porcientoParticipacionEmpresaCUP.ToString();
            }
            else
            {
                PorcientoParticipacionEmpresaCUP_xrTableCell.Text = "-";
            }
            ConformaPiedDeFirmas(Enumerados.Reportes.CertificoIngresosPersonalesArtistaXtraReport.ToEntero());

        }

    }
}
