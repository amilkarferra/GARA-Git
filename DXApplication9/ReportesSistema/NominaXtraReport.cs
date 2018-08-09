using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
//using DevExpress.DXCore.Controls.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using XtraMessageBox = DevExpress.XtraEditors.XtraMessageBox;

namespace DXApplication9.ReportesSistema
{
    public partial class NominaXtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal ATotalPaginaOnat = 0;
        private decimal ATotalReporteOnat = 0;
        private decimal ATotalPaginaCobrar;
        private decimal ATotalReporteCobrar;
        private decimal ATotalReporteDieta=0;

        public NominaXtraReport(OrdenDeTrabajo ot)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(ReportesWaitForm), true, true);
            }
            catch (Exception)
            {

                SplashScreenManager.CloseForm();
                SplashScreenManager.ShowForm(typeof(ReportesWaitForm), true, true);

            }
            var dc = new NegocioDataContext();
            var anOrdenDeTrabajo = dc.OrdenDeTrabajo.FirstOrDefault(c=>c.OrdenDeTrabajoID==ot.OrdenDeTrabajoID);
            InitializeComponent();
            if (anOrdenDeTrabajo.ImporteDieta==0)
            {
                Dieta_xrTableCell.Visible = false;
                DietaFooter_xrTableCell46.Visible = false;
                Dieta_xrTableCell46.Visible = false;
                DietaFooter_xrTableCell46.Visible = false;
                NetoAcobrarHeader_xrTableCell.Width = NetoCobrarDetail_xrTableCell.Width=NetoCobrarReport_xrTableCell.Width=NetoCobrarPage_xrTableCell.Width=120;

            }
            ConfiguracionGeneral configuracion = dc.ConfiguracionGeneral.FirstOrDefault();

            if (configuracion.LogoAgencia != null)
            {
                MemoryStream ms = new MemoryStream(configuracion.LogoAgencia);
                Bitmap imagenBitmap = new Bitmap(ms);
                xrPictureBox1.Image = imagenBitmap;
            }
            NombreAgencia_xrTableCell.Text = configuracion.Agencia.Trim();
            Descuentos_xrTableCell.Text = anOrdenDeTrabajo.Descuentos.ToString().Trim();
            IngresoActividad_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.ImporteFinal);
            PorCientoCLiente_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.PorcientoCliente);
            ImporteCliente_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.ImporteIngresaCliente);
            PorcientoIngresoEmpresa_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.PorCientoIngresaEmpresa);
            ImporteIngresaEmpresa_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.ImporteIngresaAgencia);
            PorCientoUtilidadEmpresa_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.PorcientoUtilidadEmpresa);
            ImporteUtilidadEmpresa_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.ImporteUtilidadAgencia);
            PorCientoUnidadArtistica_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.PorCientoUnidadArtistica);
            ImporteUnidadArtisticaSinDescuento_xrTableCell.Text =
                Convert.ToString(anOrdenDeTrabajo.ImporteUnidadArtisticaSinDescuento);
            Descuentos_xrTableCell.Text = Convert.ToString(-1*anOrdenDeTrabajo.Descuentos);
            IngresoArtistaConDescuento_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.ImporteConDescuento);
            Onat_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.Onat);
            Efectivo_xrTableCell.Text = Convert.ToString(anOrdenDeTrabajo.ImporteNetoQueSeCobraReal);

           

            //ImporteDistribuir_xrTableCell.Text = anOrdenDeTrabajo.ImporteConDescuento.ToString().Trim();
            ConsecutivoString_xrTableCell.Text = anOrdenDeTrabajo.GetNominaAsociada().ConsecutivoString;
            ActividadConsecutivo_xrLabel.Text = anOrdenDeTrabajo.ConsecutivoString;
            linqServerModeSource1.QueryableSource = 
                dc.ParticipantesDeAcividad.Where(
                    c => c.ActividadId == anOrdenDeTrabajo.OrdenDeTrabajoID);NombrerealizaNomina_xrLabel.Text = LoginHelper.UsuarioRegistrado.NombreCompleto.Trim();}




        private void OnatSumary_xrTableCell_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = ATotalPaginaOnat;
            e.Handled = true;
        }

        private void OnatSumary_xrTableCell_SummaryReset(object sender, EventArgs e)
        {
            ATotalPaginaOnat = 0;
        }

        private void OnatSumary_xrTableCell_SummaryRowChanged(object sender, EventArgs e)
        {
            decimal importe = decimal.Round((decimal) GetCurrentColumnValue("Importe"), 2);
            ATotalPaginaOnat += decimal.Round((importe*5/100),2);
        }

        private void ReportOnatSummary_xrTableCell_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = string.Format("Onat: {0}",ATotalReporteOnat); 
            e.Handled = true;
        }

        private void ReportOnatSummary_xrTableCell_SummaryReset(object sender, EventArgs e)
        {
            ATotalReporteOnat = 0;
        }

        private void ReportOnatSummary_xrTableCell_SummaryRowChanged(object sender, EventArgs e)
        {
            decimal importe = decimal.Round((decimal)GetCurrentColumnValue("Importe"), 2);
            ATotalReporteOnat += decimal.Round((importe * 5 / 100), 2);
        }

        private void NominaXtraReport_AfterPrint(object sender, EventArgs e)
        {

            try
            {
                SplashScreenManager.CloseForm();

            }
            catch
            {

            }
        }

        private void NetoCobrarPage_xrTableCell_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = ATotalPaginaCobrar;
            e.Handled = true;
        }

        private void NetoCobrarPage_xrTableCell_SummaryReset(object sender, EventArgs e)
        {
            ATotalPaginaCobrar = 0;
        }

        private void NetoCobrarPage_xrTableCell_SummaryRowChanged(object sender, EventArgs e)
        {
            decimal importe = decimal.Round((decimal) GetCurrentColumnValue("Importe"), 2);
           // decimal retencion = decimal.Round((decimal) GetCurrentColumnValue("Retencion"), 2);
            ATotalPaginaCobrar += decimal.Round(importe*95/100,2) ;
        }

        private void NetoCobrarReport_xrTableCell_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = ATotalReporteCobrar;
            e.Handled = true;
        }

        private void NetoCobrarReport_xrTableCell_SummaryReset(object sender, EventArgs e)
        {
            ATotalReporteCobrar = 0;
        }

        private void NetoCobrarReport_xrTableCell_SummaryRowChanged(object sender, EventArgs e)
        {
            decimal importe = decimal.Round((decimal)GetCurrentColumnValue("Importe"), 2);
           // decimal retencion = decimal.Round((decimal)GetCurrentColumnValue("Retencion"), 2);
            ATotalReporteCobrar += decimal.Round(importe * 95 / 100, 2) ;
        }

        private void NominaXtraReport_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch
            {

                //donothing
            }
        }

        private void NominaXtraReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch
            {

                //donothing
            }
        }

    }
}
