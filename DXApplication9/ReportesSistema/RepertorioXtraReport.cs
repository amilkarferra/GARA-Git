using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class RepertorioXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext AGlobalDataContext = (new NegocioDataContext());public RepertorioXtraReport(Proyectos aProyecto)
        {
            InitializeComponent();
            ConfiguracionGeneral configuracion = AGlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            var presentaciones = AGlobalDataContext.Presentacion.Where(c => c.ProyectoId == aProyecto.ProyectoID).ToArray();
            var canciones =
                AGlobalDataContext.Repertorio.Where(c => c.ProyectoId == aProyecto.ProyectoID).Select(c => c.Cancion).ToArray();
            #region Tabla de Presentaciones

            for (var i = 0; i < ((presentaciones.Count()) > 13 ? 13 : presentaciones.Count()); i++)
            {
                Preesntacion_xrTable.Rows[i].Cells[1].Text = presentaciones[i].Lugar;
                Preesntacion_xrTable.Rows[i].Cells[2].Text = presentaciones[i].Escenario;
                Preesntacion_xrTable.Rows[i].Cells[3].Text = presentaciones[i].FechaString;
            }
            #endregion
            #region Tabla De Repertorio
            for (var i = 0; i < ((canciones.Count()) > 12 ? 12 : canciones.Count()); i++)
            {
                Repertorio_xrTable.Rows[i+1].Cells[1].Text = canciones[i].Titulo;
                Repertorio_xrTable.Rows[i+1].Cells[2].Text = canciones[i].Autor;
                Repertorio_xrTable.Rows[i+1].Cells[3].Text = canciones[i].Sociedad;
            }
            #endregion

            Agrupacion_xrLabel.Text = aProyecto.Agrupacion.Nombre.TipoFrase();
            Pais_xrLabel.Text = aProyecto.Paises.NombrePais;

            FechaAnno_xrTableCell.Text = aProyecto.FechaConfeccion.Year.ToString();
            FechaMesxrTableCell.Text = aProyecto.FechaConfeccion.Month.ToString();
            FechaDia_xrTableCell.Text = aProyecto.FechaConfeccion.Day.ToString();
            if (aProyecto.FechaFinal != null) {
                FechaAnnoHasta_xrLabel.Text = aProyecto.FechaFinal.Value.Year.ToString();
                FechaMesHasta_xrLabel.Text = aProyecto.FechaFinal.Value.Month.ToString();
                FechaDiaHasta_xrLabel.Text = aProyecto.FechaFinal.Value.Day.ToString();
            }
            if (aProyecto.FechaInicial != null)
            {
                desdeAnno_xrLabel.Text = aProyecto.FechaInicial.Value.Year.ToString();
                desdeMes_xrLabel.Text = aProyecto.FechaInicial.Value.Month.ToString();
                desdeDia_xrLabel.Text = aProyecto.FechaInicial.Value.Day.ToString();}
            NombreEmpresario_xrLabel.Text += aProyecto.ControlClientes.NombreDeEntidad.Trim().TipoFrase();
            DireccionEmpresario_xrLabel.Text += aProyecto.ControlClientes.Dirección;
            Telefono_xrLabel.Text += aProyecto.ControlClientes.Teléfono;
            Email_xrLabel.Text += aProyecto.ControlClientes.Email;
            Entidad_xrTableCell.Text += configuracion.Agencia;
            TelefonoAgencia_xrTableCell.Text += configuracion.TelefonosAgencia;
            NombreRepreentanteEmpresa_xrTableCell.Text += configuracion.NombreDeJefeAgencia.Trim().TipoFrase();
           
            }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //var _Presentacion = (Presentacion)GetCurrentRow();
            //_ConsecutivoPresentacion++;
            //ConsecutivoPresentacion_xrLabel.Text = _ConsecutivoPresentacion.ToString();
            //Ciudad_xrLabel.Text = _Presentacion.Lugar;
            //Escemario_xrLabel.Text = _Presentacion.Escenario;
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //_ConsecutivoRepertorio++;
            //var _Cancion = (Cancion) GetCurrentRow();
            //TituloCancion_xrLabel.Text = _Cancion.Titulo;
            //AutorCancion_xrLabel.Text = _Cancion.Autor;
            //SociedadCancion_xrLabel.Text = _Cancion.Sociedad;
            //ConsecutivoRepertorio_xrLabel.Text = _ConsecutivoRepertorio.ToString();
        }

        private void Presentacion_DetailReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //    Presentacion _Presentacion = (Presentacion) GetCurrentRow();
            //    if (_Presentacion.Hasta == null || _Presentacion.Desde == _Presentacion.Hasta)
            //    {
            //        if (_Presentacion.Desde != null)
            //            FechaExacta_xrLabel.Text = _Presentacion.Desde.Value.ToShortDateString();
            //        FechaExacta_xrLabel.Text = "";
            //    }
            //    else
            //    {
            //        if (_Presentacion.Desde != null)
            //            FechaExacta_xrLabel.Text = string.Format("Desde el {0} hasta el {1}",_Presentacion.Desde.Value.ToShortDateString(), _Presentacion.Hasta.Value.ToShortDateString());
            //    }
            //    FechaExacta_xrLabel.Text = (_Presentacion.Hasta == null || _Presentacion.Desde == _Presentacion.Hasta
            //        ? _Presentacion.Desde.Value.ToShortDateString()
            //        : _Presentacion.Desde.Value.ToShortDateString());
        }

    }
}
