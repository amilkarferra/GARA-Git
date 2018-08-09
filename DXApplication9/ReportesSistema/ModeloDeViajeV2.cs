using System;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace DXApplication9.ReportesSistema
{
    public partial class ModeloDeViajeV2 : GaraXtraReport
    {
        public ModeloDeViajeV2(Proyectos aProyectos)
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource = new NegocioDataContext().Proyectos.Where(c=>c.ProyectoID==aProyectos.ProyectoID);
            ComercialxrCheckBox.Checked = aProyectos.EsComercial;
            Intercambio_xrCheckBox.Checked = aProyectos.EsIntercambio;
            Promocion_xrCheckBox.Checked = aProyectos.EsPromocional;
            Dias_xrLabel.Text = Convert.ToString(((DateTime)aProyectos.FechaFinal - (DateTime)aProyectos.FechaInicial).Days);
            ConformaPiedDeFirmas((int)Enumerados.Reportes.ModeloDeViajeV2);
            //xrPictureBox1.Visible = false;
            //DatosContactoxrRichText.Visible = false;
        }

    }
}