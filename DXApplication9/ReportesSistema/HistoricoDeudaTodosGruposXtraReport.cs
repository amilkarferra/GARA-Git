using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.XtraReports.UI;
using System.Linq;
using DXApplication9.ReportesSistema;
using System.Drawing;
using System.IO;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using System.Linq;

namespace DXApplication9
{
    public partial class HistoricoDeudaTodosGruposXtraReport : DXApplication9.ReportesSistema.GaraXtraReport
    {
        public class ShortHistorico
        {
            private string aMoneda;
            private decimal aImporte;
            private string anAgrupacion;

            public string Agrupacion
            {
                get { return anAgrupacion; }
                set { anAgrupacion = value; }
            }

           public string Moneda
            {
                get { return aMoneda; }
                set { aMoneda = value; }
            }

          public  decimal Importe
            {
                get { return aImporte; }
                set { aImporte = value; }
            }
        }
        public HistoricoDeudaTodosGruposXtraReport()
        {
            InitializeComponent();
            OcultaFirmas();
            var dc = new NegocioDataContext();
            List<ShortHistorico> historicos = new List<ShortHistorico>();
            IEnumerable<Agrupacion> GruposEnHistoricosConDeuda = dc.HistoricoDeuda.DistinctBy(c=>c.AgrupacionId).Select(c=>c.Agrupacion);
            foreach (var grupo in GruposEnHistoricosConDeuda)
            {
                var monedas =
                    dc.HistoricoDeuda.Where(c => c.AgrupacionId == grupo.AgrupacionID).DistinctBy(c => c.TipoMoneda).Select(c=>c.TipoMoneda);
                foreach (var moneda in monedas)
                {
                    if (grupo.GetDeuda(moneda.TipoMonedaID) > 0)
                    {
                        var shortHistorico = new ShortHistorico
                        {
                            Agrupacion = grupo.Nombre,
                            Importe = grupo.GetDeuda(moneda.TipoMonedaID),
                            Moneda = moneda.Abreviatura
                        };
                        historicos.Add(shortHistorico);
                    }
                    
                }
            }

            objectDataSource1.DataSource= historicos;

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var shorthistorico = (ShortHistorico) GetCurrentRow();
            Agrupacion_xrTableCell.Text = shorthistorico.Agrupacion;
            Moneda_xrTableCell.Text = shorthistorico.Moneda;
            Deuda_xrTableCell.Text = shorthistorico.Importe.ToString();
        }

    }
}
