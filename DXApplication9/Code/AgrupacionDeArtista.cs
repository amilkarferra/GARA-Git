using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication9
{
    partial class AgrupacionDeArtista
    {
        /// <summary>
        /// Determina si un artista estando en un grupo tuvo alguna factura, orden de trabajo o proyecto 
        /// </summary>
        public bool TieneActividadHistorica
        {
            get
            {
                using (NegocioDataContext aDataContext = new NegocioDataContext())
                {
                    if (
                        aDataContext.ParticipantesDeAcividad.Any(
                            c => c.ArtistaId == ArtistaId && c.OrdenDeTrabajo.AgrupacionId == AgrupacionId) ||
                        aDataContext.ParticipantesDeProyectos.Any(
                            c => c.ArtistaId == ArtistaId && c.Proyectos.AgrupacionId == AgrupacionId))
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public ParticipantesDeProyectos ToParticipante(Guid aProyectoId, NegocioDataContext aNegocioDataContext = null)
        {
            try
            {
                NegocioDataContext dataContext = aNegocioDataContext ?? new NegocioDataContext();
                Proyectos proyecto = dataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == aProyectoId);
                if (proyecto != null)
                {

                    // var _FirstOrDefault = AgrupacionDeArtista.FirstOrDefault(c => c.TipoVinculo ==(int)Enumerados.TipoVinculoDeArtista.PrimerVinculo);
                    // if (_FirstOrDefault != null) {
                    ParticipantesDeProyectos participante = new ParticipantesDeProyectos();
                    {
                        //AgrupacionDeArtista agrupacionArtista = dataContext.AgrupacionDeArtista.FirstOrDefault(c => c.ArtistaId == ArtistaID && c.AgrupacionId == proyecto.AgrupacionId);
                        participante.ProyectoId = proyecto.ProyectoID;
                        participante.ArtistaId = ArtistaId;
                        //var primerVinculo = PrimerVinculoAgrupacionDeArtista ?? AgrupacionDeArtista.FirstOrDefault(c => c.FechaBaja == null);
                        participante.EsInvitado = !(AgrupacionId == proyecto.AgrupacionId);
                        //participante.TipoParticipante = GetTipoParticipante(agrupacionArtista.AgrupacionDeArtistaID).ToString();
                        participante.AgrupacionId = AgrupacionId;
                        participante.Desempenno = AbrevDesempenno;

                    };
                    //if (Pasaportes.Any())
                    //{
                    //    participante.NumeroDePasaporte = Pasaportes.FirstOrDefault().NumeroPasaporte;
                    //}
                    return participante;
                    //}
                }
                return null;
            }
            catch (Exception exception)
            {
                return null;
            }
        }


    }
}
