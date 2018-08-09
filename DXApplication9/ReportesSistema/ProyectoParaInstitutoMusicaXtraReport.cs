using System;
using System.Globalization;

namespace DXApplication9.ReportesSistema
{
    public partial class ProyectoParaInstitutoMusicaXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ProyectoParaInstitutoMusicaXtraReport(Proyectos aProyecto)
        {
            InitializeComponent();
            Agrupacion_xrLabel.Text = aProyecto.Agrupacion.Nombre.Trim();
            Pais_xrLabel.Text = aProyecto.Paises.NombrePais.Trim();
            if (aProyecto.FechaInicial != null)
                if (aProyecto.FechaFinal != null)
                    FechaRango_xrLabel.Text = string.Format("Desde {0} hasta el {1}",
                        ((DateTime) aProyecto.FechaInicial).ToString("d", CultureInfo.CreateSpecificCulture("es-ES")),
                        ((DateTime) aProyecto.FechaFinal).ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
           LugarDePresentacion_xrLabel.Text =aProyecto.GetLugaresDePresentacion();
            RegimenTrabajo_xrLabel.Text = aProyecto.RegimenDeTrabajo.Trim();
            EmpresarioAsume_xrLabel.Text = aProyecto.EmpresarioAsume.Trim().TipoOracion().Acabado();
            ValorContrato_xrLabel.Text += aProyecto.ValorDelContrato + " " + aProyecto.TipoMoneda.Abreviatura;
            IngresoArtista_xrLabel.Text += aProyecto.IngresoUnidadArtistica + " " + aProyecto.TipoMoneda.Abreviatura;
            IngresoAgencia_xrLabel.Text += aProyecto.IngresoAgencia + " " + aProyecto.TipoMoneda.Abreviatura;
            DatosDeEmpresario_xrLabel.Text = string.Format("{0}. {1},{2}.Dirección: {3}, Tel. {4}, email: {5}", aProyecto.ControlClientes.NombreDeEntidad, aProyecto.ControlClientes.Representante, aProyecto.ControlClientes.CargoRepresentante, aProyecto.ControlClientes.Dirección, aProyecto.ControlClientes.Teléfono, aProyecto.ControlClientes.Email);//TODO: VER COMO MANEJAR LA DISTRIBUCION DE LA AGENCIA Y DEL ARTISTA


        }

       
    }
}
