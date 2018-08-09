using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DXApplication9.ReportesSistema;

namespace DXApplication9
{
    public partial class PopupAgrupacionMonedaFechaXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private bool _isForOnatAgrupacionReporte;

        public int AgrupacionId;
        public DateTime FechaFinal;
        public DateTime FechaInicial;
        public int TipoMonedaId;


        /// <summary>
        /// Abre un dialgo para seleccionar Agrupacion, Moneda y Rango de Fecha para luego mostrar un reporte
        /// </summary>
        /// <param name="isForOnatAgrupacion">Por defecto muestra el reporte de la deuda, en caso de pasarle true devuelve la onat de la agrupacion seleccionada</param>
        public PopupAgrupacionMonedaFechaXtraForm(bool isForOnatAgrupacion = false)
        {
            InitializeComponent();
            var dc = new NegocioDataContext();
            agrupacionBindingSource.DataSource = dc.Agrupacion.Where(c => c.PerteneceACatalogo).OrderBy(c => c.Nombre);
            tipoMonedaBindingSource.DataSource = dc.TipoMoneda.Where(c => c.OrdenDeTrabajo);
            _isForOnatAgrupacionReporte = isForOnatAgrupacion;
            FechaInicial_dateEdit.DateTime = Utils.PrimerDiaAnnoEnCurso;
            FechaFinal_dateEdit.DateTime = Utils.UltimoDiaAnnoEnCurso;
        }

        private void Ok_simpleButton_Click(object sender, EventArgs e)
        {
            if (FechaFinal_dateEdit.EditValue == null && FechaFinal_dateEdit.EditValue == null || FechaFinal_dateEdit.DateTime < FechaInicial_dateEdit.DateTime)
            {
                XtraMessageBox.Show("Verifique fechas", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!dxValidationProvider1.Validate()) return;
            AgrupacionId = Convert.ToInt32(Agrupacion_lookUpEdit.EditValue);
            FechaFinal = FechaFinal_dateEdit.DateTime;
            FechaInicial = FechaInicial_dateEdit.DateTime;
            TipoMonedaId = Convert.ToInt32(Moneda_lookUpEdit.EditValue);

            #region Reporte Historicos
            if (!_isForOnatAgrupacionReporte)
            {
                var historicos = new NegocioDataContext().HistoricoDeuda.Where(c => c.AgrupacionId == Convert.ToInt32(Agrupacion_lookUpEdit.EditValue) && c.TipoMonedaId == Convert.ToInt32(Moneda_lookUpEdit.EditValue) && c.Fecha >= FechaInicial_dateEdit.DateTime && c.Fecha <= FechaFinal_dateEdit.DateTime);
                if (!historicos.Any())
                {
                    XtraMessageBox.Show("No existen datos para mostrar", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DeudaHistoricoXtraReport reporte =
                        new DeudaHistoricoXtraReport(AgrupacionId,TipoMonedaId,FechaInicial ,FechaFinal );
                reporte.CreateDocument();
                reporte.ShowRibbonPreviewDialog();
            }
            #endregion

            #region Reporte Onat Por Agrupacion

            if (_isForOnatAgrupacionReporte)
            {
                DialogResult = DialogResult.OK;
                //OnatDeUnidadArtistica_XtraReport reporte = new OnatDeUnidadArtistica_XtraReport(AgrupacionId,FechaFinal,FechaInicial, TipoMonedaId);
                //reporte.CreateDocument();
                //reporte.ShowRibbonPreviewDialog();
            }

            #endregion



        }





        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}