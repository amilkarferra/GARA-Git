using System;
using System.Linq;
using System.Collections.Generic;


namespace DXApplication9.ReportesSistema
{
    public partial class IngresosPersonalesEscalaValoresXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public IngresosPersonalesEscalaValoresXtraReport(decimal importeMinimo,decimal importeMaximo,DateTime fechaInicial, DateTime fechaFinal, int monedaId)
        {
            //importeMinimo = 0;
            //importeMaximo = 600;
            //fechaInicial = Convert.ToDateTime("27/3/2017");
            //fechaFinal = Convert.ToDateTime("27/3/2017");
            //monedaId = 1;
            InitializeComponent();
            List < ParticipantesDeAcividad > participantesLista= new List<ParticipantesDeAcividad>();
            NegocioDataContext dc = new NegocioDataContext();
            var firstOrDefault = dc.TipoMoneda.FirstOrDefault(c=>c.TipoMonedaID==monedaId);
            if (firstOrDefault != null)
                EscalaTexto_xrTableCell.Text=String.Format("Escala de Valores en {0}",firstOrDefault.Abreviatura);
            EscalaTexto_xrTableCell.Text = String.Format("de {0} hasta {1}",importeMinimo,importeMaximo);
            var actividadesImplicadas = dc.Nomina.Where(
                c =>
                    c.FechaEmision >= fechaInicial && c.FechaEmision <= fechaFinal &&
                    c.OrdenDeTrabajo.TipoMonedaId == monedaId).Select(c=>c.OrdenDeTrabajo);
            //List<OrdenDeTrabajo> actividadesImplicadas = new List<OrdenDeTrabajo>();
            //foreach (var nomina in nominas)
            //{
            //    actividadesImplicadas.Add(nomina.OrdenDeTrabajo);
            //}
            foreach (var actividad in actividadesImplicadas)
            {
                participantesLista.AddRange(actividad.ParticipantesDeAcividad.ToList());
            }
            //var artistas = participantesLista.GroupBy(c => c.ArtistaId);
            //var actividadesImplicadasIds = 
            //    dc.Nomina.Where(
            //        c =>
            //            c.FechaEmision >= fechaInicial && c.FechaEmision <= fechaFinal &&
            //            c.OrdenDeTrabajo.TipoMonedaId == monedaId).Select(c => c.OrdenDeTrabajo.OrdenDeTrabajoID).ToList();
           
            //var ParticipantesDeActividad = dc.Nomina.Where(
            //        c =>
            //            c.FechaEmision >= fechaInicial && c.FechaEmision <= fechaFinal &&
            //            c.OrdenDeTrabajo.TipoMonedaId == monedaId).Select(c => c.OrdenDeTrabajo);

            
          var test = from part in participantesLista
           group part by part.ArtistaId into grouping
           select new
           {
               grouping.Key,
               TotalPrice = grouping.Sum(p => p.Importe)
           };
            Cant_xrTableCell.Text = test.Count(c => c.TotalPrice >= importeMinimo && c.TotalPrice <= importeMaximo).ToString();
            IngArt_xrTableCell.Text = test.Where(c => c.TotalPrice >= importeMinimo && c.TotalPrice <= importeMaximo).Sum(c => c.TotalPrice).ToString();

            //foreach (var grp in priceQuery)
            //{
            //    Console.WriteLine("Category = {0}, Total price = {1}",
            //        grp.Key, grp.TotalPrice);
            //}
            
            



        }

    }
}
