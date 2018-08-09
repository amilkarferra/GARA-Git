using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class ConsultaPoliticaAnexo2XtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ConsultaPoliticaAnexo2XtraReport(Proyectos aProyecto)
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource = (new NegocioDataContext().Proyectos.Where(c => c.ProyectoID == aProyecto.ProyectoID));

        }

    }
}
