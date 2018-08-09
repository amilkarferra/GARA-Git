using System;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class EntregaOtEconomiaXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public EntregaOtEconomiaXtraReport(Guid[] ordenesDeTrabajoId )
        {
            
            InitializeComponent();
            linqServerModeSource2.QueryableSource = (new NegocioDataContext()).OrdenDeTrabajo.Where(c=> ordenesDeTrabajoId.Contains(c.OrdenDeTrabajoID));
            Comercial_xrLabel.Text = LoginHelper.UsuarioRegistrado.NombreCompleto.Trim();
            //this.DataSource = ordenesDeTrabajo;
            //DetailReport.DataMember = "OrdenDeTrabajo";
            //Detail1.Height = 30;
            //Detail1.Controls.Add(CreateBoundLabel("Consecutivo", Color.Gold, 0));
        }

      
    }
}
