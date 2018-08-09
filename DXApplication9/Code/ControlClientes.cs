using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using DXApplication9.ReportesSistema;
using DynamicQueryable = DXApplication9.ReportesSistema.DynamicQueryable;

namespace DXApplication9
{
    public partial class ControlClientes
    {
        public bool EsNacional
        {
            get
            {
                return Paises.Codigo == 53;
            }
        }

        public string NumeroContratoString
        {
            get
            {
                return String.Format("{0}/{1}", NumeroContrato, FechaContrato.Year);
            }
        }

        public string ProyectoAsociadoString
        {
            get
            {
                if (!EsNacional)
                {
                    var dc = new NegocioDataContext();
                    var proyecto = dc.Proyectos.FirstOrDefault(c => c.ControlClienteId == ControlClienteID);
                    return proyecto != null ? proyecto.NombreProyecto : "-sin proyecto-";
                }
                else { return "Proyecto nacional"; }
            }
        }

        //public static int GetProximoConsecutivo(bool  esNacional)
        //{
        //    try
        //    {
        //        var annoTrabajo = ConfiguracionGeneral.Anno;
        //        if (annoTrabajo == 0)
        //        {
        //            Utils.MuestraError("Inserte el numero de año de trabajo en la configuración General");
        //            return 0;
        //        }
        //        var clientesDelAnno = new NegocioDataContext().ControlClientes.Where(c => c.FechaContrato.Year == annoTrabajo);
        //        ControlClientes ultimaActividad = clientesDelAnno.OrderByDescending(c => c.NumeroContrato).FirstOrDefault(c=>c.EsNacional==esNacional));
        //        int ultimoConsecutivo = 0;
        //        if (ultimaActividad != null)
        //        {
        //            ultimoConsecutivo = ultimaActividad.Consecutivo;
        //        }
        //        return ultimoConsecutivo + 1;
        //    }
        //    catch (Exception)
        //    {

        //        return 0;
        //    }
        //}
        public static int GetProximoNumeroContrato(bool nacional)
        {
            NegocioDataContext dataContext = new NegocioDataContext();
            int ultimoNumero = 0;
            var cubaId = Paises.PaisIdDeCuba;
            var configuracion = dataContext.ConfiguracionGeneral.FirstOrDefault(c => c.Agencia != null);
            try
            {
                var contratosDelAño = dataContext.ControlClientes.Where(c => c.FechaContrato.Year == configuracion.AnnoDeTrabajo);
                if (contratosDelAño.Any())
                {
                    var controlClienteses = contratosDelAño.Where(c => nacional ? c.PaisId == cubaId : c.PaisId != cubaId);
                    if (controlClienteses.Any())
                        ultimoNumero =
                            DynamicQueryable.FirstOrDefault(controlClienteses.OrderByDescending(c => c.NumeroContrato))
                                .NumeroContrato;
                }
                else
                if (nacional
                    ? configuracion.PrimerNumeroContratoNacionalAnual != null
                    : configuracion.PrimerNumeroContratoInternacionalAnual != null)
                    ultimoNumero =
                        (int)
                            (nacional
                                ? configuracion.PrimerNumeroContratoNacionalAnual
                                : configuracion.PrimerNumeroContratoInternacionalAnual);

                return Convert.ToInt32(ultimoNumero) + 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public ControlClientes DuplicarContrato()
        {
            try
            {
                ControlClientes nuevoControl = new ControlClientes
                {
                    Dirección = Dirección,
                    Email = Email,
                    EmpresarioId = EmpresarioId,
                    CargoRepresentante = CargoRepresentante,
                    EstadoId = Enumerados.EstadoContrato.PorRecoger.ToEntero(),
                    FechaContrato = DateTime.Today,
                    Nit = Nit,
                    PaisId = PaisId,
                    Representante = Representante,
                    Reup = Reup,
                    NombreDeEntidad = NombreDeEntidad,
                    NumeroContrato = GetProximoNumeroContrato(EsNacional),
                    Teléfono = Teléfono,
                    Vigencia = DateTime.Today.AddYears(1)
                };
               nuevoControl.Salvar();
                return nuevoControl;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Salvar()
        {
            try
            {
                var dc = new NegocioDataContext();
                if (ControlClienteID != 0) //update
                {
                    //TODO Implementar el update
                }
                else
                {
                    dc.ControlClientes.InsertOnSubmit(this);
                }
                dc.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
