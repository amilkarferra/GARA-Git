using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class TablaIntegrantes : DevExpress.XtraReports.UI.XtraReport
    {
        public TablaIntegrantes(IQueryable aListaDeArtistas)
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource = aListaDeArtistas;
        }
    }
}
