using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace DXApplication9.ReportesSistema
{
    public partial class SolicitudDePagoXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        private NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        private decimal AGlobalImporteFinal;
        private bool EsFacturaDeProyecto = false;

        //public SolicitudDePagoXtraReport(Guid[] ordenesDeTrabajoId)
        //{
        //    //InitializeComponent();

        //    //Actividad_objectDataSource.DataSource =
        //    //   var ordenes = _GlobalDataContext.OrdenDeTrabajo.Where(c => ordenesDeTrabajoId.Contains(c.OrdenDeTrabajoID));
        //    //SolicitudDePagoXtraReport(ordenes);
        //    //Configuracion_objectDataSource.DataSource = _GlobalDataContext.ConfiguracionGeneral;
        //    ////ConfiguracionGeneral configuracion = (new NegocioDataContext()).ConfiguracionGeneral.FirstOrDefault();

        //    //OrdenDeTrabajo primeraActividad =
        //    //    _GlobalDataContext.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == ordenesDeTrabajoId[0]);
        //    //if (primeraActividad != null)
        //    //{
        //    //    Concepto_xrTableCell.Text = string.Format("Pago de presentaciones de {0}",
        //    //        primeraActividad.Agrupacion.Nombre);
        //    //    Cabecera_xrTableCell.Text = String.Format("Numero de {0}",
        //    //        primeraActividad.TipoActividad == (int) Enumerados.TipoActividad.OrdenDeTrabajo
        //    //            ? "Orden De Trabajo"
        //    //            : "Factura");
        //    //}
        //    //NombrePersona_xrTableCell.Text = anOrdenDeTrabajo.Agrupacion.Nombre_de_Persona_Recibe_Cheque;
        //    //FechaAprobado_xrTableCell.Text = DateTime.Today.ToString();
        //    //Moneda_xrTableCell.Text = anOrdenDeTrabajo.TipoMoneda.Abreviatura;
        //    //Concepto_xrTableCell.Text = string.Format("{0}: {1}", "Pago de Orden de Trabajo Numero",
        //    //    anOrdenDeTrabajo.ConsecutivoString);
        //    //Gerente_xrTableCell.Text = configuracion.NombreJefeComercial;
        //    //Importe_xrTableCell.Text = anOrdenDeTrabajo.ImporteConDescuento.ToString();
        //    //ImporteLetras_xrTableCell.Text = Utils.NumeroTexto(anOrdenDeTrabajo.ImporteConDescuento);
        //    var numeroClass = new NumLetra();
        //    //var letraNumero=NumeroClass.Convertir(anOrdenDeTrabajo.ImporteConDescuento.ToString(), true);
        //    //ImporteLetras_xrTableCell.Text = letraNumero;


        //}
        public SolicitudDePagoXtraReport(IEnumerable<OrdenDeTrabajo> ordenesDeTrabajo)
        {
            InitializeComponent();
            NombreUsuario_xrTableCell.Text = LoginHelper.UsuarioRegistrado.NombreCompleto;
            Actividad_objectDataSource.DataSource = ordenesDeTrabajo;
            //_GlobalDataContext.OrdenDeTrabajo.Where(c => ordenesDeTrabajo..Contains(c.OrdenDeTrabajoID));
            Configuracion_objectDataSource.DataSource = AGlobalDataContext.ConfiguracionGeneral;
            //ConfiguracionGeneral configuracion = (new NegocioDataContext()).ConfiguracionGeneral.FirstOrDefault();

            OrdenDeTrabajo primeraActividad = ordenesDeTrabajo.First();
            if (primeraActividad != null & primeraActividad.TipoActividad != (int)Enumerados.TipoActividad.Proyecto && !primeraActividad.EsFacturaDeProyecto)
            {
                Concepto_xrTableCell.Text = string.Format("Pago de presentaciones de {0}",
                    primeraActividad.Agrupacion.Nombre);
                Cabecera_xrTableCell.Text = String.Format("Número de {0}",
                    primeraActividad.TipoActividad == (int)Enumerados.TipoActividad.OrdenDeTrabajo
                        ? "Orden De Trabajo"
                        : "Factura");
            }
            else if (primeraActividad.EsFacturaDeProyecto)
            {
                CodigoProyecto_xrTableCell.Text = primeraActividad.ProyectoAsociado.ConsecutivoString;
                CabeceraImportes_xrTableRow.Visible = false;
                EsFacturaDeProyecto = true;
                Concepto_xrTableCell.Text = string.Format("pago de {0} {1} gira {2}",
                    primeraActividad.ImporteCache > 0 ? "caché" : "",
                    primeraActividad.ImporteDieta > 0 ? " y de dieta" : "",
                    primeraActividad.ProyectoAsociado.NombreProyecto);
                decimal descuentoOnat = 0;
                if (primeraActividad.ImporteCache > 0)
                {

                    TotalCachet_xrTableRow.Visible = true;
                    DescuentoOnat_xrTableRow.Visible = true;
                    TotalCachet_xrTableCell.Text = primeraActividad.ImporteCache.ToString();
                    descuentoOnat = decimal.Round((primeraActividad.ImporteCache * (decimal)0.05), 2);
                    DescuentoOnat_xrTableCell.Text ='-' + descuentoOnat.ToString();
                    SubtotalCachet_xrTableRow.Visible = true;
                    SubTotalCachet_xrTableCell.Text =(primeraActividad.ImporteCache - descuentoOnat).ToString();
                }
                if (primeraActividad.ImporteDieta > 0)
                {
                    Dieta_xrTableRow.Visible = true;
                    Dieta_xrTableCell.Text = primeraActividad.ImporteDieta.ToString();
                }
                var netoACobrar = primeraActividad.ImporteCache - descuentoOnat + primeraActividad.ImporteDieta;
                AGlobalImporteFinal = netoACobrar;ACobrar_xrTableRow.Visible = true;
                ACobrar_xrTableCell.Text = netoACobrar.ToString();
                Detail.Visible = false;
                ImporteTotal_xrTableCell.DataBindings.Clear();
                ImporteTotal_xrTableCell.Text = AGlobalImporteFinal.ToString();
                ImporteLetras_xrTableCell.DataBindings.Clear();

                //Concepto_xrTableCell.Text = string.Format("Pago de presentaciones de {0}",
                //    agrupacion.Nombre);
                //Cabecera_xrTableCell.Text = "Número de Factura";

            }

            Fecha_xrTableCell.Text = FechaAprobacion_xrTableCell.Text = DateTime.Today.ToShortDateString();
        }


        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            OrdenDeTrabajo ordenActual = (OrdenDeTrabajo)GetCurrentRow();
            decimal importe = 0;
            if (ordenActual.EsFacturaDeProyecto)
            {
                importe = AGlobalImporteFinal;
            }
            else
            {
                  importe = ordenActual.ImporteNetoQueSeCobraReal;
            }
            ConsecutivoString_xrTableCell.Text = ordenActual.ConsecutivoString;
           
            // _GlobalImporteFinal += importe*95/100;
            Importe_xrTableCell.Text = importe.ToString();
        }

        private void ImporteTotal_xrTableCell_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = decimal.Round(AGlobalImporteFinal, 2);
            e.Handled = true;

        }



        private void ImporteTotal_xrTableCell_SummaryReset(object sender, EventArgs e)
        {
            if(!EsFacturaDeProyecto)
            AGlobalImporteFinal = 0;
        }


        private void ImporteTotal_xrTableCell_SummaryRowChanged(object sender, EventArgs e)
        {
            if (!EsFacturaDeProyecto)
            {
                OrdenDeTrabajo ordenActual = (OrdenDeTrabajo) GetCurrentRow();
                decimal importe = ordenActual.ImporteNetoQueSeCobraReal;
                AGlobalImporteFinal += importe;
                Importe_xrTableCell.Text = importe.ToString();
            }
            else
            {
                Importe_xrTableCell.Text = AGlobalImporteFinal.ToString();

            }
        }




        private void ImporteLetras_xrTableCell_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            //var NumeroClass = new NumLetra();
            //var letraNumero = NumeroClass.Convertir(_GlobalImporteFinal.ToString(), true);
            //e.Result = letraNumero;
            //e.Handled = true;

        }

        private void ImporteTotal_xrTableCell_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            var numeroClass = new NumLetra();
            var letraNumero = numeroClass.Convertir(AGlobalImporteFinal.ToString(), true);
            ImporteLetras_xrTableCell.Text = letraNumero;
        }

        private void ImporteLetras_xrTableCell_SummaryCalculated(object sender, TextFormatEventArgs e)
        {

        }

        private void ImporteLetras_xrTableCell_SummaryGetResult_1(object sender, SummaryGetResultEventArgs e)
        {
            var numeroClass = new NumLetra();
            var letraNumero = numeroClass.Convertir(AGlobalImporteFinal.ToString(), true);
            e.Result = letraNumero;
            e.Handled = true;
        }


    }
}
