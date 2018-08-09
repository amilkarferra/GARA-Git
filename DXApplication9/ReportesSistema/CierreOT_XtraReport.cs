using System;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class CierreOtXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CierreOtXtraReport(Guid[] ordenesDeTrabajoId)
        {
            var dc = new NegocioDataContext();
            InitializeComponent();
            linqServerModeSource1.QueryableSource = dc.OrdenDeTrabajo.Where(c => ordenesDeTrabajoId.Contains(c.OrdenDeTrabajoID));
            Comercial_xrLabel.Text = LoginHelper.UsuarioRegistrado.NombreCompleto.Trim();
            var ot = dc.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == ordenesDeTrabajoId[0]);
            if (ot != null && ot.TipoActividad == Enumerados.TipoActividad.ProduccionInterna.ToEntero())
                ParaContratador_xrTableCell.Text = "Porciento Arrendamiento";

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var actividad = (OrdenDeTrabajo) GetCurrentRow();
            Descuentos_xrTableCell.Text =
                Decimal.Round(actividad.DescuentoPorActividad.Sum(c => c.Importe), 2).ToString();
        }

    }}
