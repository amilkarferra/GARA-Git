using System;
using System.Globalization;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class HojaNotificacionXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        NegocioDataContext GlobalDataContext = new NegocioDataContext();
        private Proyectos _Proyecto = null;

        public HojaNotificacionXtraReport(Guid aProyectoId)
        {
            InitializeComponent();
            ProyectolinqServerModeSource.QueryableSource = (GlobalDataContext.Proyectos.Where(c => c.ProyectoID == aProyectoId));
            _Proyecto = GlobalDataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == aProyectoId);
            var _Configuracion = GlobalDataContext.ConfiguracionGeneral.FirstOrDefault();
            DirigidoA_xrRichText.Text = DirigidoA_xrRichText1.Text = string.Format("A: {0}, {1}", _Configuracion.NombreJefeDeDptoTramite, _Configuracion.CargoJefeDptoTramite);
            FechaConfeccion_xrRichText.Text = FechaConfeccion_xrRichText1.Text = string.Format("{0}, {1} ", "La Habana", (_Proyecto.FechaConfeccion).ToString("D", CultureInfo.CreateSpecificCulture("es-ES")));
            ConfigurarTextoNotificacion();
            NombreJefeGerComerc_xrRichText.Text = NombreJefeGerComerc_xrRichText1.Text = _Configuracion.NombreDeJefeAgencia.Trim();
            CargoJefeComercial_xrRichText.Text = CargoJefeComercial_xrRichText1.Text = _Configuracion.CargoDeJefeDeAgencia.Trim();
            Agencia_xrRichText.Text = Agencia_xrRichText1.Text = _Configuracion.Agencia;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
      
         
        }
        private void ConfigurarTextoNotificacion()
        {
            string _Texto = "Por medio del presente documento, le notificamos proyecto para ";
            if (_Proyecto.EsTramiteMigratorio)
            {
                _Texto += _Proyecto.GetTextoFundamentacionTramitesMigratorios(false);
                TextoNotificacion_xrRichText.Text = TextoNotificacion_xrRichText1.Text = _Texto;
                //var Integrantes = _Proyecto.ParticipantesDeProyectos.ToList();
                //var i = 0;
                //foreach (var integrante in Integrantes)
                //{
                //    i++;
                //    bool _EsUltimo = Integrantes.Count == i;
                //    bool _EsPrimero = i == 1;
                //    //La Confeccion de pasaporte de pasaporte oficial a favor de 
                //    _Texto += string.Format("{0} {1} a favor de {2}", !_EsPrimero ? " , " : "", integrante.TipoTramiteMigratorio.SplitUpperCase().Replace("confeccion", "confección").TipoOracion(), integrante.NombreCompleto.TipoFrase());
                //    if (_EsUltimo)
                //    {
                //        int _UltimaComaPos = _Texto.LastIndexOf(",");
                //        StringBuilder _CausaFinal = new StringBuilder(_Texto);
                //        _CausaFinal[_UltimaComaPos] = 'y';
                //        TextoNotificacion_xrRichText.Text = TextoNotificacion_xrRichText1.Text = _CausaFinal.ToString().Trim();
                //    }
                //}
            }
            else
            {
                Participantes_Detail.Visible = false;
                var _ParticipanteDeProyecto = _Proyecto.ParticipantesDeProyectos.FirstOrDefault();
                if (_ParticipanteDeProyecto != null)
                {
                    TextoNotificacion_xrRichText.Text = TextoNotificacion_xrRichText1.Text = string.Format("{0} {1} de la agrupación {2} ",
                        "Por medio del presente documento, le notificamos proyecto para realizar ",_Proyecto.TipoProyecto.Trim()==Enumerados.TipoProyecto.Comercial.ToString()?"Contrato Comercial":"Gira Promocional", _Proyecto.Agrupacion.Nombre);
                }
            }
        }
    
    }

}
