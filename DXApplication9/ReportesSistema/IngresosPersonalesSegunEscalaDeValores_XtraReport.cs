 using System;
using System.Drawing;
using System.Collections;
 using System.Collections.Generic;
 using System.ComponentModel;
 using System.Globalization;
 using DevExpress.XtraReports.UI;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class IngresosPersonalesSegunEscalaDeValores_XtraReport : DXApplication9.ReportesSistema.GaraXtraReport
    {
        public IngresosPersonalesSegunEscalaDeValores_XtraReport(int escalaDeValoresId, DateTime fechaInicial, DateTime fechaFinal, int monedaId)
        {
            InitializeComponent();
            
            List<ParticipantesDeAcividad> participantesLista = new List<ParticipantesDeAcividad>();
            NegocioDataContext dc = new NegocioDataContext();
            var EscalaValor =
                dc.NomencladorEscalasDeIngreso.FirstOrDefault(c => c.NomencladorEscalaIngresoID == escalaDeValoresId);
            var importeMinimo = EscalaValor.ImporteMinimo;
            decimal importeMaximo = 0;


            RangoValor_xrTableCell.Text = EscalaValor.Descripcion;
            var actividadesImplicadas = dc.Nomina.Where(
                c =>
                    c.FechaEmision >= fechaInicial && c.FechaEmision <= fechaFinal &&
                    c.OrdenDeTrabajo.TipoMonedaId == monedaId).Select(c => c.OrdenDeTrabajo);

            foreach (var actividad in actividadesImplicadas)
            {
                participantesLista.AddRange(actividad.ParticipantesDeAcividad.ToList());
            }

            var test = participantesLista.GroupBy(part => part.ArtistaId)
                .Select(grouping => new 
                {
                    key = grouping.Key,
                    artistaId = grouping.Select(a => a.ArtistaId).FirstOrDefault(),
                    TotalPrice = grouping.Sum(p => p.Importe),
                    retenido = grouping.Sum(p => p.Importe * 5 / 100)
                });
            var enumerable = test.ToList();
            if (EscalaValor.ImporteMaximo == null)
            {
                importeMaximo = enumerable.Max(c => c.TotalPrice);
            }
            else
            {
                importeMaximo = (decimal) EscalaValor.ImporteMaximo;
            }

            var enRango = enumerable.Where(c => c.TotalPrice >= importeMinimo && c.TotalPrice <= importeMaximo);
            Cant_xrTableCell.Text = enRango.Count().ToString();
            var ingreso = enRango.Sum(c => c.TotalPrice.RedondeaDecimal());
            IngArt_xrTableCell.Text = ingreso.ToString();
            Retenido_xrTableCell.Text = enRango.Sum(c => (c.TotalPrice*5/100).RedondeaDecimal()).ToString();
            var indiceIngreInst = ConfiguracionGeneral.ConfiguracionActual.IndiceParticipacionInstitucion;
            if (indiceIngreInst != null)
                IngArt_xrTableCell.Text = (((decimal)indiceIngreInst) * ingreso).RedondeaDecimal().ToString();
        }
    }
}
