using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class ConsultaPoliticaXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ConsultaPoliticaXtraReport(Proyectos aProyectos)
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource = (new NegocioDataContext().Proyectos.Where(c=>c.ProyectoID==aProyectos.ProyectoID));
           // TipoProyecto_xrLabel.Text = Enum.GetName(typeof (Enumerados.TipoProyecto), aProyectos.TipoProyectoId);
            TipoProyecto_xrLabel.Text = (((Enum)(Enum.Parse(typeof(Enumerados.TipoProyecto), aProyectos.TipoProyectoId.ToString()))).StringValue());if (aProyectos.TipoPasaporte != null)
                TipoPasaporte_xrLabel.Text = (((Enum)(Enum.Parse(typeof(Enumerados.TipoPasaporte), aProyectos.TipoPasaporte.ToString()))).StringValue());
        }

    }}
