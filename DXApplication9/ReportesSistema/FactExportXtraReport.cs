using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DXApplication9.ReportesSistema
{
    public partial class FactExportXtraReport : XtraReport
    {
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        readonly OrdenDeTrabajo AGlobalOrdenDeTrabajo;
        public FactExportXtraReport(OrdenDeTrabajo anActividad)
        {

            AGlobalOrdenDeTrabajo = anActividad;
            InitializeComponent();
            var importes = AGlobalDataContext.ImportesDeFacturaEnFrontera.Where(c => c.ActividadId == anActividad.OrdenDeTrabajoID);
            if (!importes.Any())
            {
               
                XtraMessageBox.Show("Antes debe insertarle conceptos a la factura seleccionada",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
               Dispose();
            }
            //if (importes.Count() < 10)
            //{
            //    AddEmptyRowsToTable(Detail_xrTable, 10 - importes.Count());
            //}
            linqServerModeSource1.QueryableSource = AGlobalDataContext.ImportesDeFacturaEnFrontera.Where(c => c.ActividadId == anActividad.OrdenDeTrabajoID);
            var configuracion = (new NegocioDataContext()).ConfiguracionGeneral.FirstOrDefault();
            if (configuracion.LogoAgencia != null)
            {
                MemoryStream ms = new MemoryStream(configuracion.LogoAgencia);
                Bitmap imagenBitmap = new Bitmap(ms);
                xrPictureBox1.Image = imagenBitmap;
            }
            NombreEmpresa_xrTableCell.Text = configuracion.Agencia;
            TelEmp_xrTableCell.Text = configuracion.TelefonosAgencia;
            DirEmpre_xrTableCell.Text = configuracion.DireccionEmpresa;
            NombreFirmaFactura_xrTableCell.Text = configuracion.NombreJefeComercial;
            CargoFirmaFactura_xrTableCell.Text = configuracion.CargoJefeComercial;
            NombreEmpresa2_xrTableCell.Text = configuracion.Agencia;
            NitxrTableCell.Text = configuracion.NitAgencia.Trim();
            var cuenta = configuracion.CuentasEmpresa.Where(c => c.TipoMonedaId == AGlobalOrdenDeTrabajo.TipoMonedaId).FirstOrDefault();
            if (cuenta != null)
            {
                CuentaEmpresa_xrTableCell.Text = configuracion.CuentasEmpresa.Where(c => c.TipoMonedaId == AGlobalOrdenDeTrabajo.TipoMonedaId).FirstOrDefault().NumeroCuenta;
                TitularEmpresa_xrTableCell.Text = configuracion.CuentasEmpresa.Where(c => c.TipoMonedaId == AGlobalOrdenDeTrabajo.TipoMonedaId).FirstOrDefault().Titular;

            }
            if (AGlobalOrdenDeTrabajo != null)
            {
                if (AGlobalOrdenDeTrabajo.TipoMoneda.CuentasEmpresa != null)
                {
                    var firstOrDefault = AGlobalOrdenDeTrabajo.TipoMoneda.CuentasEmpresa.FirstOrDefault();
                    if (firstOrDefault != null) CuentaEmpresa_xrTableCell.Text = firstOrDefault.NumeroCuenta;
                    CuentasEmpresa cuentasEmpresa = AGlobalOrdenDeTrabajo.TipoMoneda.CuentasEmpresa.FirstOrDefault();
                    if (cuentasEmpresa != null)
                        TitularEmpresa_xrTableCell.Text = cuentasEmpresa.Titular;
                }

                CuentaCliente_xrTableCell.Text = anActividad.NumeroCuenta;
                TitularCliente_xrTableCell.Text = anActividad.TitularCuenta;

                if (AGlobalOrdenDeTrabajo.Agrupacion.EsProyecto)
                {
                    
                    var proyectoReferencia =
                        AGlobalDataContext.Proyectos.FirstOrDefault(
                            c => c.ProyectoID == AGlobalOrdenDeTrabajo.ProyectosId);
                    if (proyectoReferencia != null)
                        UnidadArtistica_xrTableCell.Text = proyectoReferencia.NombreProyecto;
                }
            
            
            }


        }


        /// <summary>
        /// Para insertar una cantidad determinada de filas vacias a una columna y poder llenar 
        /// una pagina.
        /// <Author>Amilkar Ferrá</Author>
        /// </summary>
        /// <param name="aTable"></param>
        /// <param name="aNumberOfRows"></param>
        public void AddEmptyRowsToTable(XRTable aTable, int aNumberOfRows)
        {
            for (int i = 0; i < aNumberOfRows; i++)
            {
                aTable.Rows.Add(new XRTableRow(){Height = 20,BorderWidth = 1,Borders = BorderSide.All});
            }

        }

        private void FactExportXtraReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //var importes = _globalDataContext.ImportesDeFacturaEnFrontera.Where(c => c.ActividadId == globalOrdenDeTrabajo.OrdenDeTrabajoID);
            //if (importes.Count() < 10)
            //{
            //    AddEmptyRowsToTable(Detail_xrTable, 10 - importes.Count());
            //}
            //XRTable table = ((XRTable)sender);
            //table.LocationF = new DevExpress.Utils.PointFloat(0F, 0F);
            //table.Height = 100;
            //table.AdjustSize();
          //  Detail_xrTable.InsertRowBelow(Detail_xrTable.Rows[Detail_xrTable.Rows.Count - 1]);


        }

        private void FactExportXtraReport_AfterPrint(object sender, EventArgs e)
        {
         //   Detail_xrTable.InsertRowBelow(Detail_xrTable.Rows[Detail_xrTable.Rows.Count - 1]);
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {

            //Detail_xrTable.InsertRowBelow(Detail_xrTable.Rows[Detail_xrTable.Rows.Count - 1]);
        }

        private void Detail_xrTable_AfterPrint(object sender, EventArgs e)
        {
            Detail_xrTable.InsertRowBelow(Detail_xrTable.Rows[Detail_xrTable.Rows.Count - 1]);

        }

        private void Detail_xrTable_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            Detail_xrTable.InsertRowBelow(Detail_xrTable.Rows[Detail_xrTable.Rows.Count - 1]);

        }

        private void Detail_xrTable_Draw(object sender, DrawEventArgs e)
        {
            Detail_xrTable.InsertRowBelow(Detail_xrTable.Rows[Detail_xrTable.Rows.Count - 1]);

        }

        private void Detail_xrTableRow_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableRow row = (XRTableRow) sender;
            
        }

        

    }
}
