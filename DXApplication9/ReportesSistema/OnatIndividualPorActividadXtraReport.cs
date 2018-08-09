using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class OnatIndividualPorActXtraReport : GaraXtraReport
    {
        NegocioDataContext ADc = new NegocioDataContext();
        private DateTime AFechaFinal;
        private DateTime AFechaInicial;
        private int AMonedaId;
        private IQueryable<OrdenDeTrabajo> ActividadesImplicadas;
        private List<ParticipantesDeAcividad>  AParticipantesLista = new List<ParticipantesDeAcividad>(); 
        public OnatIndividualPorActXtraReport(DateTime fechaInicial, DateTime fechaFinal, int agrupacionId, int monedaId)
        {
            InitializeComponent();
            AFechaFinal = fechaFinal;
            AFechaInicial = fechaInicial;
            AMonedaId = monedaId;
            ActividadesImplicadas = ADc.Nomina.Where(c => c.FechaEmision >= AFechaInicial && c.FechaEmision <= AFechaFinal && c.OrdenDeTrabajo.TipoMonedaId == AMonedaId).Select(c => c.OrdenDeTrabajo);
            foreach (var actividad in ActividadesImplicadas)
            {
                AParticipantesLista.AddRange(actividad.ParticipantesDeAcividad.ToList());
            }
            linqServerModeSource1.QueryableSource =
                ADc.AgrupacionDeArtista.Where(
                    c => c.AgrupacionId == agrupacionId && (c.FechaBaja == null || c.FechaBaja > fechaInicial)).Select(c=>c.Artista);

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var artista = (Artista)GetCurrentRow();
            if (artista != null)
            {
                var importe = Decimal.Round(AParticipantesLista.Where(c => c.ArtistaId == artista.ArtistaID).Sum(c => c.Importe),2);
                //var importe = ADc.Artista.Where(c=>ActividadesImplicadas.Contains(c.ParticipantesDeAcividad.))
                // var importe = Decimal.Round(Convert.ToDecimal(artista.ParticipantesDeAcividad.Where(c=>c.OrdenDeTrabajo.Nomina.)Sum(c => c.Importe)), 2);
                var aporteOnat = AParticipantesLista.Where(c => c.ArtistaId == artista.ArtistaID)
                    .Sum(c => c.Importe * 5 / 100).RedondeaDecimal();
                NombreCompleto_xrTableCell.Text = artista.NombreCompleto.TipoFrase();
                Importe_xrTableCell.Text = importe.ToString();
                //var aporteOnat = Decimal.Round(importe*5/100,2);
                Onat_xrTableCell.Text = aporteOnat.ToString();
            }

        }

    }
}
