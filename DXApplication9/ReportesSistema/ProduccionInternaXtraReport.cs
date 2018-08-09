﻿using System.Drawing;
using System.IO;
using System.Linq;

namespace DXApplication9.ReportesSistema
{
    public partial class ProduccionInternaXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ProduccionInternaXtraReport(OrdenDeTrabajo anOrdenDeTrabajo)
        {
         
            InitializeComponent();

            //Modelo_Nombre_xrTableCell.Text = string.Format("Modelo de {0}",
             //   Enumerados.TipoActividad.ProduccionInterna.StringValue());
           linqServerModeSource1.QueryableSource = (new NegocioDataContext()).OrdenDeTrabajo.Where(c => c.OrdenDeTrabajoID  == anOrdenDeTrabajo.OrdenDeTrabajoID);

            ConfiguracionGeneral configuracion = (new NegocioDataContext()).ConfiguracionGeneral.FirstOrDefault();

            if (configuracion.LogoAgencia != null)
            {
                MemoryStream ms = new MemoryStream(configuracion.LogoAgencia);
                Bitmap imagenBitmap = new Bitmap(ms);
                xrPictureBox1.Image = imagenBitmap;
            }
            if (!string.IsNullOrEmpty(configuracion.CorreoElectronico))
                EmailAgencia_xrTableCell.Text = configuracion.CorreoElectronico.Trim();
            if (!string.IsNullOrEmpty(anOrdenDeTrabajo.ControlClientes.Email))
                EmailCliente_xrTableCell5.Text = anOrdenDeTrabajo.ControlClientes.Email.Trim();
            NombreGerenteComercialxrTableCell.Text = configuracion.NombreJefeComercial.Trim();
            AgenciaNombre_xrTableCell.Text = configuracion.Agencia;
            NumeroOrden_xrTableCell.Text = anOrdenDeTrabajo.NumeroDeOrden.Split('/')[0];
            NombreAgrupacion_xrTableCell.Text = anOrdenDeTrabajo.Agrupacion.Nombre;
            CantInt_xrTableCell.Text = OrdenDeTrabajo.GetAgrupacionDeArtistasParticipantes(anOrdenDeTrabajo.OrdenDeTrabajoID).Count().ToString();
            NumeroContrato_xrTableCell.Text = anOrdenDeTrabajo.NumeroContrato;
            NombreEmpresario_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.NombreDeEntidad;
            NombreRepresentanteEmpresa_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.Representante;
            CargoEmpresario_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.CargoRepresentante;
            DireccionEmpresario_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.Dirección;
            TelEmpresa_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.Teléfono;
            FechaDesde_xrTableCell.Text = anOrdenDeTrabajo.FechaIncialActividad.ToShortDateString();
            FechaHasta_xrTableCell.Text = anOrdenDeTrabajo.FechaFinalActividad.ToShortDateString();
           // FechaVigencia_xrTableCell.Text = (anOrdenDeTrabajo.ControlClientes.Vigencia).ToString();
            FechaConfeccion1_xrTableCell.Text = anOrdenDeTrabajo.FechaConfeccion.ToShortDateString();
            PrecioPorPresentacion_xrTableCell.Text = decimal.Round(anOrdenDeTrabajo.ImportePorActividad, 2).ToString("N");
            CantContratadas_xrTableCell.Text = CantContratadas1_xrTableCell.Text = anOrdenDeTrabajo.CantidadActividades.ToString("D");
            ImporteTotal_xrTableCell.Text = ImporteTotal1_xrTableCell.Text = decimal.Round(anOrdenDeTrabajo.CantidadActividades * anOrdenDeTrabajo.ImportePorActividad, 2).ToString("N");
            ImporteTotal_xrTableCell.XlsxFormatString = ImporteTotal1_xrTableCell.XlsxFormatString = "n2";
            CargoRepAgencia_xrTableCell.Text = configuracion.CargoDeJefeDeAgencia;
            NombreJefeAgencia_xrTableCell.Text = configuracion.NombreDeJefeAgencia;
            DireccionAgencia_xrTableCell.Text = configuracion.DireccionEmpresa;
            TelAgencia_xrTableCell.Text = configuracion.TelefonosAgencia;
            LugarDePresentacion_xrTableCell.Text = anOrdenDeTrabajo.LugarDePresentacion;
            AgenciaNombre_xrTableCell.Text = configuracion.Agencia;
            if (configuracion.CargoJefeComercial != null)CargoFirmanteAgenciaxrTableCell.Text = configuracion.CargoJefeComercial.Trim();
            if (anOrdenDeTrabajo.TipoMonedaId == (int)Enumerados.Moneda.Cup)
            {
                MonedaCUC_xrTableCell.Text = "";
                MonedaCUP_xrTableCell.Text = "X";
                NombreCuentaAgencia_xrTableCell.Text = configuracion.NombreCuentaEmpresaMN;
                NumeroCuentaAgencia_xrTableCell.Text = configuracion.NumeroCuentaEmpresaMN;
            }
            else
            {
                MonedaCUC_xrTableCell.Text = "X";
                MonedaCUP_xrTableCell.Text = "";
                NombreCuentaAgencia_xrTableCell.Text = configuracion.NombreCuentaEmpresaDIV;
                NumeroCuentaAgencia_xrTableCell.Text = configuracion.NumeroCuentaEmpresaDiv;
            }
            if (anOrdenDeTrabajo.EsPorCover)
            {
                ImporteTotal1_xrTableCell.Text =
                    ImporteTotal_xrTableCell.Text = PrecioPorPresentacion_xrTableCell.Text = "Cover";
            }


        }

        //public OrdenDeTrabajoXtraReport(Guid anOrdenDeTrabajoId)
        //{
        //    using (var _dataContext = new NegocioDataContext())
        //    {
        //        linqServerModeSource1.QueryableSource =
        //            _dataContext.ParticipantesDeAcividad.Where(
        //                c => c.OrdenDeTrabajo.OrdenDeTrabajoID == anOrdenDeTrabajoId);

        //        OrdenDeTrabajo anOrdenDeTrabajo = 
        //            _dataContext.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == anOrdenDeTrabajoId);
        //        InitializeComponent();
        //        ConfiguracionGeneral _Configuracion = (new NegocioDataContext()).ConfiguracionGeneral.FirstOrDefault();
        //        NombreGerenteComercialxrTableCell.Text = _Configuracion.NombreJefeComercial.Trim();

        //        NombreAgencia_xrTableCell.Text = _Configuracion.Agencia;
        //        NumeroOrden_xrTableCell.Text = anOrdenDeTrabajo.NumeroDeOrden.Split('/')[0];
        //        NombreAgrupacion_xrTableCell.Text = anOrdenDeTrabajo.Agrupacion.Nombre;
        //        CantInt_xrTableCell.Text = anOrdenDeTrabajo.ParticipantesDeAcividad.Count.ToString();
        //        NumeroContrato_xrTableCell.Text = anOrdenDeTrabajo.NumeroContrato;
        //        NombreEmpresario_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.NombreDeEntidad;
        //        NombreRepresentanteEmpresa_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.Representante;
        //        CargoEmpresario_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.CargoRepresentante;
        //        DireccionEmpresario_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.Dirección;
        //        TelEmpresa_xrTableCell.Text = anOrdenDeTrabajo.ControlClientes.Teléfono;
        //        FechaDesde_xrTableCell.Text = anOrdenDeTrabajo.FechaIncialActividad.ToShortDateString();
        //        FechaHasta_xrTableCell.Text = anOrdenDeTrabajo.FechaFinalActividad.ToShortDateString();
        //        FechaVigencia_xrTableCell.Text =
        //            FechaConfeccion1_xrTableCell.Text = anOrdenDeTrabajo.FechaConfeccion.ToShortDateString();
        //        PrecioPorPresentacion_xrTableCell.Text = anOrdenDeTrabajo.ImportePorActividad.ToString();
        //        CantContratadas_xrTableCell.Text =
        //            CantContratadas1_xrTableCell.Text = anOrdenDeTrabajo.CantidadActividades.ToString();
        //        ImporteTotal_xrTableCell.Text =
        //            ImporteTotal1_xrTableCell.Text =
        //                (anOrdenDeTrabajo.CantidadActividades * anOrdenDeTrabajo.ImportePorActividad).ToString();
        //        CargoRepAgencia_xrTableCell.Text = _Configuracion.CargoDeJefeDeAgencia;
        //        NombreJefeAgencia_xrTableCell.Text = _Configuracion.NombreDeJefeAgencia;
        //        DireccionAgencia_xrTableCell.Text = _Configuracion.DireccionEmpresa;
        //        TelAgencia_xrTableCell.Text = _Configuracion.TelefonosAgencia;
        //        LugarDePresentacion_xrTableCell.Text = anOrdenDeTrabajo.LugarDePresentacion;
        //        if (anOrdenDeTrabajo.TipoMonedaId == (int)Enumerados.Moneda.CUP)
        //        {
        //            MonedaCUC_xrTableCell.Text = "";
        //            MonedaCUP_xrTableCell.Text = "X";
        //            NombreCuentaAgencia_xrTableCell.Text = _Configuracion.NombreCuentaEmpresaMN;
        //            NumeroContrato_xrTableCell.Text = _Configuracion.NumeroCuentaEmpresaMN;
        //        }
        //        else
        //        {
        //            MonedaCUC_xrTableCell.Text = "X";
        //            MonedaCUP_xrTableCell.Text = "";
        //            NombreCuentaAgencia_xrTableCell.Text = _Configuracion.NombreCuentaEmpresaDIV;
        //            NumeroContrato_xrTableCell.Text = _Configuracion.NumeroCuentaEmpresaDiv;
        //        }

        //        if (anOrdenDeTrabajo.EsPorCover)
        //        {
        //            ImporteTotal1_xrTableCell.Text =
        //                ImporteTotal_xrTableCell.Text = PrecioPorPresentacion_xrTableCell.Text = "Cover";
        //        }
                
        //    }
        //}

    }
}
