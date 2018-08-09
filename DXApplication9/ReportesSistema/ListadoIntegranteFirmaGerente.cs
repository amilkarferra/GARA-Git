using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class ListadoIntegranteFirmaGerente : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private int ACount = 0;
        public ListadoIntegranteFirmaGerente(Proyectos aProyecto)
        {
            InitializeComponent();
            linqServerModeSource1.QueryableSource =
                AGlobalDataContext.ParticipantesDeProyectos.Where(c => c.ProyectoId == aProyecto.ProyectoID).OrderBy(c=>c.Artista.Orden);
            ConfiguracionGeneral configuracion =AGlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            string[] pie = new string[3];
            pie[0] = configuracion.NombreDeJefeAgencia;
            pie[1] = configuracion.CargoDeJefeDeAgencia;
            pie[2] = configuracion.Agencia;
            PieFirmaGerente_xrLabel.Lines = pie;
            ListadoIntegrantes_xrLabel.Text += aProyecto.Agrupacion.Nombre.ToUpper();}

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ACount++;
            var integrante = (ParticipantesDeProyectos) GetCurrentRow();
            if(integrante!=null)
            Integrante_xrLabel.Text = string.Format("{0} - {1}",ACount , integrante.NombreCompleto.TipoFrase());

        }

    }
}
