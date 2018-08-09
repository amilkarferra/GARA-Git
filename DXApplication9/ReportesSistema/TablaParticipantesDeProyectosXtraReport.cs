using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace DXApplication9.ReportesSistema
{
    public partial class TablaParticipantesDeProyectosXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public TablaParticipantesDeProyectosXtraReport(Guid aProyectoId)
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource = (new NegocioDataContext()).ParticipantesDeProyectos.Where(c => c.ProyectoId == aProyectoId).OrderBy(c=>c.Artista.Orden);
        }

    }
}
