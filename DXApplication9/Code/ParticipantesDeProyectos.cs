using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication9
{
    public partial class ParticipantesDeProyectos
    {
        public string NombreCompleto
        {
            get { return string.Format("{0}", Artista.NombreCompleto); }
        }

        //public int AgrupacionId
        //{
        //    get
        //    {
        //        if (ProyectoId != null)
        //        {
        //            int _AgrupacionIdProyecto = (int)ProyectoId;
        //            var _FirstOrDefault = Artista.AgrupacionDeArtista.FirstOrDefault(c => c.TipoVinculo ==(int)Enumerados.TipoVinculoDeArtista.PrimerVinculo);

        //            //En caso de que el artista tenga alguna agrupacion que coincida con la del proyecto pues entonces esa es la agrupacion con la que se queda de lo contrario devuelvo la primera agrupacion del artista
        //            if (_FirstOrDefault != null) return _FirstOrDefault.AgrupacionId;
        //        }
        //        return 0;
        //    }
        //}

        
        public string TipoParticipante
        {
            get
            {
                var artistaAgrupacion = new NegocioDataContext().AgrupacionDeArtista.FirstOrDefault(c => c.AgrupacionId == Proyectos.AgrupacionId && c.ArtistaId == ArtistaId);

                return GetTipoParticipante(artistaAgrupacion.AgrupacionDeArtistaID).ToString();
            }

        }

        //public int GetAgrupacionPrincipal()
        //{
        //    //En caso de que el artista tenga alguna agrupacion que coincida con la del proyecto pues entonces esa es la agrupacion con la que se queda de lo contrario devuelvo la primera agrupacion del artista
        //    var _FirstOrDefault = Artista.AgrupacionDeArtista.FirstOrDefault(c => c.TipoVinculo == Enumerados.TipoVinculoDeArtista.PrimerVinculo.ToString());
        //    if (_FirstOrDefault != null)
        //    {
        //        int _AgrupacionDeArtista = _FirstOrDefault.AgrupacionId;
        //        return _AgrupacionDeArtista;
        //    }
        //    return 0;
        //}

        private Enumerados.TipoParticipante GetTipoParticipante(int anAgrupacionArtistaId)
        {
            if (EsInvitado) return Enumerados.TipoParticipante.Invitado;
            return Enumerados.TipoParticipante.Integrante;
            //try
            //{
            //    AgrupacionDeArtista agrupacionArtista = (new NegocioDataContext()).AgrupacionDeArtista.FirstOrDefault(c => c.AgrupacionDeArtistaID == anAgrupacionArtistaId && c.FechaBaja == null);
            //    if (agrupacionArtista == null)
            //    {
            //        return Enumerados.TipoParticipante.Invitado;
            //    }
            //    else
            //    {
            //        if (agrupacionArtista.TipoVinculo == null)
            //            return Enumerados.TipoParticipante.Invitado;
            //        else
            //        {
            //            if (agrupacionArtista.TipoVinculo == Enumerados.TipoVinculoDeArtista.PrimerVinculo.ToEntero())
            //                return Enumerados.TipoParticipante.Integrante;
            //            return Enumerados.TipoParticipante.Invitado;
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //    return Enumerados.TipoParticipante.Invitado;

            //}
            //return Enumerados.TipoParticipante.Invitado;
        }

    }

}

