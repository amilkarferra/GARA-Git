using System;
using System.Globalization;
using System.Linq;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DXApplication9.ReportesSistema
{
    public partial class PlanillaSalida : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private bool AEsHabilitacionDePasaportes = false;
        public PlanillaSalida(Proyectos aProyecto, bool anHabilitacionDePasaporte = false)
        {
            AEsHabilitacionDePasaportes = anHabilitacionDePasaporte;
            var configuracionGeneral = AGlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            InitializeComponent();
            Agrupacion_xrLabel.Text = aProyecto.Agrupacion.Nombre;
            NombrePais_xrLine.Visible = TiempoEstancia_xrLine.Visible = (aProyecto.EsTramiteMigratorio || anHabilitacionDePasaporte);
            #region Nombre de Jefe Empresa

            string[] linesJefeEmpresa = new string[2];
            linesJefeEmpresa[0] = configuracionGeneral.Destinatario_O_DirigidoA;
            linesJefeEmpresa[1] = configuracionGeneral.CargoDestinatario;
            JefeEmpresa_xrLabel.Lines = linesJefeEmpresa;

            #endregion
            #region Nombre de Jefe Agencia

            string[] linesJefeAgencia = new string[2];
            linesJefeAgencia[0] = configuracionGeneral.NombreDeJefeAgencia;
            linesJefeAgencia[1] = configuracionGeneral.CargoDeJefeDeAgencia;
            JefeAgencia_xrLabel.Lines = linesJefeAgencia;
            #endregion

            Fecha_xrLabel.Text = aProyecto.FechaConfeccion.ToShortDateString();
            if (aProyecto.PasajesPagadosPor != null) PasajesPagadosPor_xrTableCell.Text = aProyecto.PasajesPagadosPor;
            IQueryable<ParticipantesDeProyectos> participantesDeProyectos = null;
            if (anHabilitacionDePasaporte)
            {
                participantesDeProyectos =
                    new NegocioDataContext().ParticipantesDeProyectos.Where(
                        c => c.ProyectoId == aProyecto.ProyectoID && c.TipoTramiteMigratorio != null)
                        .OrderBy(c => c.Artista.NomencladorCargo.PesoDeCargo);

            }
            else
            {
                participantesDeProyectos =
  new NegocioDataContext().ParticipantesDeProyectos.Where(c => c.ProyectoId == aProyecto.ProyectoID).OrderBy(c => c.Artista.NomencladorCargo.PesoDeCargo);

            }
            int rowsCount = participantesDeProyectos.Count() / 2;
            FillTable(rowsCount + 1);
            Participantes_linqServerModeSource.QueryableSource = participantesDeProyectos;
            var participanteArray = participantesDeProyectos.ToArray();
            var numeroParticipante = 0;
            for (var fila = 0; fila < rowsCount + 1; fila++)
            {
                for (var columna = 0; columna < 2; columna++)
                {
                    if (numeroParticipante < participanteArray.Length)
                    {
                        if (xrTable1.Rows[fila].Cells.Count != 2)
                            do
                            {
                                xrTable1.Rows[fila].Cells.Add(new XRTableCell());
                            } while (xrTable1.Rows[fila].Cells.Count < 2);
                        var agrupacionArtista =  
                            AGlobalDataContext.AgrupacionDeArtista.FirstOrDefault(
                                c =>
                                    c.ArtistaId == participanteArray[numeroParticipante].ArtistaId 
                                    && c.AgrupacionId == participanteArray[numeroParticipante].AgrupacionId); //COMENTO ESTA LINEA PORQUE NO RECUERDO OBJETIVO PUES DEBEN MOSTRARSE TODOS LOS INTEGRANTES INL
                        if (agrupacionArtista != null)
                            if(agrupacionArtista.AbrevDesempenno!=null)
                            xrTable1.Rows[fila].Cells[columna].Text = string.Format("{2}  {0}  -  {1}", participanteArray[numeroParticipante].NombreCompleto.TipoFrase(), agrupacionArtista.AbrevDesempenno, numeroParticipante + 1);
                        numeroParticipante++;
                    }

                }
            }

            if (aProyecto.Paises != null) if (aProyecto.EsTramiteMigratorio)
                    Pais_xrTableCell.Text = aProyecto.Paises.NombrePais;
            if ((aProyecto.FechaFinal != null && aProyecto.FechaInicial != null) && !(aProyecto.EsTramiteMigratorio))
                try
                {
                    Periodo_xrTableCell.Text = string.Format("desde el {0}, hasta el {1}",
                               ((DateTime)aProyecto.FechaInicial).ToString("d", CultureInfo.CreateSpecificCulture("es-ES")),
                              ((DateTime)aProyecto.FechaFinal).ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
                }
                catch
                {

                    //donothing
                }
            if (!(aProyecto.EsTramiteMigratorio || anHabilitacionDePasaporte) && aProyecto.ControlClientes != null)
            {
                if (aProyecto.ControlClientes.Representante != null) NombreEmpresario_xrLabel.Text = string.Format("{0}, {1} de {2}", aProyecto.ControlClientes.Representante, aProyecto.ControlClientes.CargoRepresentante, aProyecto.ControlClientes.NombreDeEntidad);
                if (aProyecto.ControlClientes.Dirección != null) Direccion_xrLabel.Text += aProyecto.ControlClientes.Dirección;
                if (aProyecto.ControlClientes.Email != null) Email_xrLabel.Text += aProyecto.ControlClientes.Email;
                if (aProyecto.ControlClientes.Teléfono != null) Tel_xrLabel.Text += aProyecto.ControlClientes.Teléfono;
            }
            // var _TipoDeProyecto = aProyecto.TipoProyecto;
            if (aProyecto.EsTramiteMigratorio || anHabilitacionDePasaporte)
            {
                Pais_xrTableCell.Text = aProyecto.EsTramiteMigratorio ? "" : aProyecto.Paises != null ? aProyecto.Paises.NombrePais : "";
                Periodo_xrTableCell1.Text = "";
                Causa_xrRichText.Text = aProyecto.GetTextoFundamentacionTramitesMigratorios(true);

            }
            else
            {
                //Causa_xrLabel.Text = _TipoDeProyecto.SplitUpperCase().TipoOracion();
                if (aProyecto.Paises != null) Pais_xrTableCell.Text = aProyecto.Paises.NombrePais;
            }
            if (aProyecto.EsComercial && !anHabilitacionDePasaporte)
            {
                Causa_xrRichText.Text = "Contrato Comercial";

            }
            if (aProyecto.EsPromocional && !anHabilitacionDePasaporte)
            {
                Causa_xrRichText.Text = "Gira Promocional";
            }
            // Causa_xrLabel.Lines+
            //    RellenaCausaDeProyecto();
        }

        public void FillTable(int aRowCount)
        {
            int cellsInRow = 2;
            int rowsCount = aRowCount >= 10 ? aRowCount : 10;
            xrTable1.Rows.Clear();
            xrTable1.Borders = BorderSide.Bottom;
            xrTable1.Borders = BorderSide.Top;
            // xrTable1.WidthF = 752;
            xrTable1.BeginInit();

            for (int i = 0; i < rowsCount; i++)
            {
                XRTableRow row = new XRTableRow();
                row.HeightF = 16;
                row.Borders = BorderSide.Bottom; row.Borders = BorderSide.Top;
                for (int j = 0; j < cellsInRow; j++)
                {
                    XRTableCell cell = new XRTableCell();
                    // cell.Padding = new PaddingInfo(0,0,2,0);
                    cell.WidthF = xrTable1.WidthF / 2;
                    //   cell.Font = new Font(new FontFamily("Times New Roman"),9);
                    row.Cells.Add(cell);
                }
                xrTable1.Rows.Add(row);
            }
            xrTable1.Rows.Add(new XRTableRow());
            xrTable1.AdjustSize();
            xrTable1.EndInit();

        }
    }
}