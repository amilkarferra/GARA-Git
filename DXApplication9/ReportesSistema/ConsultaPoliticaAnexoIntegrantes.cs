using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class ConsultaPoliticaAnexoIntegrantes : DevExpress.XtraReports.UI.XtraReport
    {
        public ConsultaPoliticaAnexoIntegrantes(Proyectos aProyectos)
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource =
                (new NegocioDataContext()).Proyectos.Where(c => c.ProyectoID == aProyectos.ProyectoID);
        }

    }
}
