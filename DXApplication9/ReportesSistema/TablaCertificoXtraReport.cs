using System.Globalization;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class TablaCertificoXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext _GlobalDataContext = new NegocioDataContext();
        public TablaCertificoXtraReport(Proyectos aProyecto)
        {
           
            InitializeComponent();
          //  Landscape = true;
            Integrantes_linqServerModeSource.QueryableSource =
                _GlobalDataContext.ParticipantesDeProyectos.Where(c => c.ProyectoId == aProyecto.ProyectoID && c.AgrupacionId  == c.Proyectos.AgrupacionId).OrderBy(c => c.Artista.Orden);
            PorMedio_xrRichText.Text =
                string.Format("{0} {1} tienen el estatus laboral que a continuación se acredita: ", "Por medio de la Presente certificamos que los integrantes de la agrupación ", aProyecto.Agrupacion.Nombre);
            ParaQueConste_xrRichText.Text = string.Format("Y para que así conste firman la presente el  {0} ", (aProyecto.FechaConfeccion).ToString("D", CultureInfo.CreateSpecificCulture("es-ES")));
            Configuracion_linqServerModeSource.QueryableSource = _GlobalDataContext.ConfiguracionGeneral;
            NombreEspecialista_xrLabel.Text = LoginHelper.UsuarioRegistrado.NombreCompleto;
            #region Conformacion de Texto de Viajan como invitado
            IQueryable<ParticipantesDeProyectos> _Invitados =
                   _GlobalDataContext.ParticipantesDeProyectos.Where(c => c.ProyectoId == aProyecto.ProyectoID && c.AgrupacionId!=c.Proyectos.AgrupacionId).OrderBy(c=>c.Artista.Orden);
            int _CantInv = _Invitados.Count();
            if (_Invitados.Count() > 0)
            {
                string _TextoViajanComo = string.Format("{0} como {1} ", _CantInv > 1 ? "Viajan" : "Viaja", _CantInv > 1 ? "invitados" : "invitado");
                foreach (var _Invitado in _Invitados)
                { if (_Invitado.NombreCompleto != null) if (_Invitado.Artista.Organismo != null) _TextoViajanComo += string.Format(", {0} de {1}",_Invitado.NombreCompleto,_Invitado.Artista.Organismo.Trim().TipoFrase()); }var _TextoFinal = _TextoViajanComo.Acabado();
                ViajanComo_xrRichText.Text = _TextoFinal;
            } 
            #endregion
        }

        
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var _Participante = (ParticipantesDeProyectos)GetCurrentRow();
            if (_Participante != null && _Participante.TipoParticipante!=Enumerados.TipoParticipante.Invitado.ToString())
            {
                NombreCompletoxrLabel.Text = _Participante.NombreCompleto.TipoFrase();
                Ocupacion_xrLabel.Text = _Participante.Artista.AbrevDesempenno.TipoFrase();
                if (_Participante.Artista.FechaIngresoSector != null) FechaEntradaSector_xrLabel.Text = _Participante.Artista.FechaIngresoSector.Value.Year.ToString();
                StatusLaboral_xrLabel.Text = _Participante.Artista.StatusLaboral.TipoFrase();
                Ci_xrLabel.Text = _Participante.Artista.CarnetIdentidad;
            }
        }

    }
}


