using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using DXApplication9.ReportesSistema;
namespace DXApplication9
{

    public partial class CierraOtXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private OrdenDeTrabajo AAct;
        NegocioDataContext AGlobalDataContext = new NegocioDataContext();




        public CierraOtXtraForm(OrdenDeTrabajo ordenDeTrabajo)
        {
            InitializeComponent();
            Print_dropDownButton.Enabled = ordenDeTrabajo.FechaLiquidacion != null;
            if (ordenDeTrabajo.TipoActividad == Enumerados.TipoActividad.ProduccionInterna.ToEntero())
                PorcientoCttoExterno_layoutControlItem.Text = "Porciento Arrendamiento";
            Text += " " + ordenDeTrabajo.ConsecutivoString;
            AAct = ordenDeTrabajo;
            CalculaDeuda();
            Moneda_label.Text = AAct.TipoMoneda.Abreviatura;
            if (AAct.FechaLiquidacion != null)
            {
                FechaCierre_dateEdit.EditValue = AAct.FechaLiquidacion;
                IngresoTotalActividadTotal_textEdit.EditValue = AAct.ImporteFinal;
                PorcientoCliente_textEdit.EditValue = AAct.PorcientoCliente ?? 0;
                PorCientoQueSeIngresa_textEdit.EditValue = AAct.PorcientoCliente == null
                    ? 100
                    : 100 - AAct.PorcientoCliente;
                ActualizaImporteIngresoClienteEmpresa();
                Descuentos_buttonEdit.EditValue = AAct.Descuentos;
                ParaUAPorciento_textEdit.EditValue = AAct.PorCientoUnidadArtistica ?? 0;
                PorCientoUtilidadAgencia_textEdit.EditValue = 100 - Convert.ToInt32(ParaUAPorciento_textEdit.EditValue);
                ActualizaImporteAgenciaUnidadArtistica();
                ImporteDistribuirConDesc_textEdit.EditValue = AAct.ImporteConDescuento;
                UtillidadAgenciaImporte_textEdit.EditValue = AAct.ImporteUtilidadAgencia;
                Nota_memoExEdit.EditValue = AAct.Nota;
                try
                {
                    if (Convert.ToString(AAct.Cheque) != string.Empty)
                    {
                        Cheque_textEdit.EditValue = AAct.Cheque;
                        if (Convert.ToString(AAct.FechaEntregaCheque) != String.Empty)
                        {
                            FechaEntregaCheque_dateEdit.DateTime = Convert.ToDateTime(AAct.FechaEntregaCheque);
                        }
                        else
                        {
                            FechaEntregaCheque_dateEdit.DateTime = DateTime.Now;
                        }

                    }
                }
                catch (Exception)
                {

                    throw;
                }
                Observacion_memoEdit.EditValue = AAct.Observaciones;
            }
            if (AAct.Estado == (int)Enumerados.EstadoOrdenDeTrabajo.Cobrada)
            {
                if (AAct.Cheque != null) Cheque_textEdit.EditValue = AAct.Cheque; if (AAct.FechaEntregaCheque != null) FechaEntregaCheque_dateEdit.EditValue = AAct.FechaEntregaCheque;
            }
            if (AAct.Estado == (int)Enumerados.EstadoOrdenDeTrabajo.Realizada)
            {
                FechaCierre_dateEdit.EditValue = (AAct.FechaLiquidacion ?? DateTime.Today);
                IngresoTotalActividadTotal_textEdit.EditValue = AAct.EsPorCover
                ? 0
                : decimal.Round(AAct.ImportePorActividad * AAct.CantidadActividades, 2);
                PorcientoCliente_textEdit.EditValue = 0;
                PorCientoQueSeIngresa_textEdit.EditValue = 100;
                ActualizaImporteIngresoClienteEmpresa();
                ParaUAPorciento_textEdit.EditValue = AAct.Agrupacion.PorcientoContratado ?? 15;
                PorCientoUtilidadAgencia_textEdit.EditValue = 100 - Convert.ToInt32(ParaUAPorciento_textEdit.EditValue);
                ActualizaImporteAgenciaUnidadArtistica();
                Descuentos_buttonEdit.EditValue = AAct.Descuentos;
                ImporteDistribuirConDesc_textEdit.EditValue = decimal.Round(Convert.ToDecimal(ParaUAImporteSinDescuento_textEdit.EditValue), 2) -
                                                              decimal.Round(Convert.ToDecimal(Descuentos_buttonEdit.EditValue), 2);

            }

            decimal.Round(Convert.ToDecimal(AAct.ImporteFinal), 2);
            PorcientoCliente_textEdit.EditValue = AAct.PorcientoCliente ?? 0;
            PorCientoQueSeIngresa_textEdit.EditValue = AAct.PorcientoCliente == null
                ? 100
                : 100 - AAct.PorcientoCliente;
            ActualizaImporteIngresoClienteEmpresa();

            #region Commented
            //Implementando en caso de que la orden no haya sido previamente cerrada
            //if (ordenDeTrabajo.FechaLiquidacion == null)
            //{

            //    Descuentos_buttonEdit.EditValue = ordenDeTrabajo.GetDescuento();
            //    //Puede darse el caso de que le hayan introducido datos pero no esta cerrada la orden
            //    if (act.ImporteFinal != null)
            //    {
            //        IngresoTotalActividadTotal_textEdit.EditValue = decimal.Round((decimal)act.ImporteFinal, 2);
            //        PorcientoCliente_textEdit.EditValue = act.PorcientoCliente ?? 0;
            //        PorCientoQueSeIngresa_textEdit.EditValue = act.PorcientoCliente == null
            //            ? 100
            //            : 100 - act.PorcientoCliente;
            //        ActualizaImporteIngresoClienteEmpresa();
            //    }
            //        //caso que no es cover y por lo tanto tiene un valor el importe de actividad
            //    else if (act.ImporteFinal == null && !act.EsPorCover)
            //    {
            //        IngresoTotalActividadTotal_textEdit.EditValue = decimal.Round(act.ImportePorActividad * act.CantidadActividades, 2);
            //        PorcientoCliente_textEdit.EditValue = act.PorcientoCliente ?? 0;
            //        PorCientoQueSeIngresa_textEdit.EditValue = act.PorcientoCliente == null
            //            ? 100
            //            : 100 - act.PorcientoCliente;
            //        ActualizaImporteIngresoClienteEmpresa();
            //    }
            //    ParaUAPorciento_textEdit.EditValue = act.PorCientoUnidadArtistica??act.Agrupacion.PorcientoContratado;
            //    PorCientoUtilidadAgencia_textEdit.EditValue = 100 - Convert.ToInt32(PorcientoCliente_textEdit.EditValue);
            //    //ActualizaImporteIngresoClienteEmpresa();
            //}
            //else//caso que ya este cerrado
            //{
            //    FechaCierre_dateEdit.EditValue = act.FechaLiquidacion;
            //    Descuentos_buttonEdit.EditValue = act.GetDescuento();
            //    if (act.ImporteFinal != null)
            //    {
            //        IngresoTotalActividadTotal_textEdit.EditValue = decimal.Round(act.ImportePorActividad * act.CantidadActividades, 2);
            //        PorcientoCliente_textEdit.EditValue = act.PorcientoCliente ?? 0;
            //        PorCientoQueSeIngresa_textEdit.EditValue = act.PorcientoCliente == null
            //            ? 100
            //            : 100 - act.PorcientoCliente;
            //        ActualizaImporteIngresoClienteEmpresa();
            //    } 


            //    ParaUAPorciento_textEdit.EditValue = (act.PorCientoUnidadArtistica);
            //    Cheque_textEdit.EditValue = ordenDeTrabajo.Cheque;Observacion_memoEdit.EditValue = ordenDeTrabajo.Observaciones;
            //}

            #endregion
        }

        private void ActualizaImporteAgenciaUnidadArtistica()
        {
            try
            {
                int porcientoAgencia = Convert.ToInt32(PorCientoUtilidadAgencia_textEdit.EditValue);
                decimal importeIngresaAgencia = decimal.Round(Convert.ToDecimal(ImporteIngresaAgencia_textEdit.EditValue), 2);
                decimal importeUtilidadAgencia = decimal.Round(importeIngresaAgencia * porcientoAgencia / 100, 2);
                decimal importeIngresaArtistaSinDescuento = decimal.Round(importeIngresaAgencia - importeUtilidadAgencia, 2);

                UtillidadAgenciaImporte_textEdit.EditValue = importeUtilidadAgencia;
                ParaUAImporteSinDescuento_textEdit.EditValue = decimal.Round(importeIngresaAgencia -
                                                               decimal.Round(porcientoAgencia * importeIngresaAgencia / 100, 2), 2);
                ImporteDistribuirConDesc_textEdit.EditValue = importeIngresaArtistaSinDescuento - Convert.ToDecimal(Descuentos_buttonEdit.EditValue);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ActualizaImporteIngresoClienteEmpresa()
        {

            if (PorCientoQueSeIngresa_textEdit.EditValue != null && PorcientoCliente_textEdit.EditValue != null &&
                IngresoTotalActividadTotal_textEdit.EditValue != null)
            {

                try
                {
                    int porcientoCliente = Convert.ToInt32(PorcientoCliente_textEdit.EditValue);
                    ImporteCliente_textEdit.EditValue = porcientoCliente *
                                                               (decimal.Round(
                                                                   (decimal)IngresoTotalActividadTotal_textEdit.EditValue, 2)) / 100;
                    ImporteIngresaAgencia_textEdit.EditValue = (decimal)IngresoTotalActividadTotal_textEdit.EditValue -
                                                               (decimal)ImporteCliente_textEdit.EditValue;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        //private void Ok_simpleButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (_globalOrdenDeTrabajo.CierraOrdenDeTrabajo(FechaCierre_dateEdit.DateTime,
        //            //Convert.ToDecimal(PorCientoUA_textEdit.EditValue),Convert.ToDecimal(ImporteDescontar_textEdit.EditValue), Convert.ToDecimal(ImporteFinal_textEdit.EditValue),  Convert.ToString(Conceptop_memoEdit.EditValue)))
        //        {
        //            MessageBox.Show("Orden cerrada correctamente");
        //            Dispose();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        MessageBox.Show("No se pudo cerrar la orden");
        //    }
        //}

        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        //private void PresentaDescuento_checkBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (PresentaDescuento_checkBox.Checked)
        //    {
        //        //verifico que halla importe asignado
        //        if (ImporteDescontar_textEdit.EditValue == null)
        //        {
        //            MessageBox.Show("Inserte Importe de la Actividad");
        //            return;
        //        }
        //        MuestraControlesDescuento(true);
        //    }
        //    else
        //    {
        //        MuestraControlesDescuento(false);
        //    }
        //}

        //private void MuestraControlesDescuento(bool b)
        //{
        //    ImporteDescontar_textEdit.Enabled = b;
        //    Conceptop_memoEdit.Enabled = b;
        //}

        //private void ImporteTextEdit_TextChanged(object sender, EventArgs e)
        //{
        //    ActualizaImporteFinal();
        //}

        //private void ActualizaImporteFinal()
        //{
        //    ImporteFinal_textEdit.EditValue = Convert.ToDecimal(ImporteTextEdit.EditValue) - _globalOrdenDeTrabajo.GetDescuento();
        //}






        //private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    gridView1.SetRowCellValue(e.RowHandle, colDocumentoReferenciaId, _globalOrdenDeTrabajo.OrdenDeTrabajoID);
        //}

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            AGlobalDataContext.SubmitChanges();
            //gridControl1.DataSource = dc.DescuentoPorActividad.Where(c => c.DocumentoReferenciaId == _globalOrdenDeTrabajo.OrdenDeTrabajoID);
            //ActualizaImporteFinal();
        }

        //private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        //{
        //    var _column = gridView1.FocusedColumn;
        //    if (_column != colImporte) return;
        //    var descuentoAcumulado = _globalOrdenDeTrabajo.GetDescuento();
        //    if (descuentoAcumulado + Convert.ToDecimal(e.Value) > _globalOrdenDeTrabajo.ImporteFinal)
        //    {
        //        e.Valid = false;
        //        e.ErrorText = "El descuento total no puede exceder el importe de la actividad";
        //    }

        //    //            switch (_FieldName)
        //    //            {
        //    ////case "Desde":
        //    //                    //{
        //    //                    //    Presentacion_gridView.Columns["Hasta"].RealColumnEdit.
        //    //                    //    }
        //    //                    //    break;
        //    //            }
        //    //            //    case "Hasta":
        //    //            //    {
        //    //            //        if ((DateTime)e.Value > FechaFinalDateEdit.DateTime)
        //    //            //        {
        //    //            //            e.Valid = false;
        //    //            //            e.ErrorText = "Verifique Fecha";}
        //    //            //        break;
        //    //            //    }
        //}

        //private void gridView1_Click(object sender, EventArgs e)
        //{
        //    var gridView = gridView1;
        //    Point clickPoint = gridControl1.PointToClient(MousePosition);
        //    var hitInfo = gridView.CalcHitInfo(clickPoint);
        //    if (hitInfo.InRowCell)
        //    {
        //        int rowHandle = hitInfo.RowHandle;
        //        GridColumn column = hitInfo.Column;
        //        //MessageBox.Show(column.Name + " "+rowHandle);
        //        if (column == Delete_gridColumn)
        //        {
        //            if (
        //                MessageBox.Show("Esta acción no es reversible, esta seguro", "Atención", MessageBoxButtons.YesNo,
        //                    MessageBoxIcon.Hand) == DialogResult.Yes)
        //            {
        //                DescuentoPorActividad descuentoPorActividad = (DescuentoPorActividad)gridView.GetRow(rowHandle);
        //                dc.DescuentoPorActividad.DeleteOnSubmit(descuentoPorActividad);
        //                dc.SubmitChanges();
        //                gridControl1.DataSource = dc.DescuentoPorActividad.Where(c => c.DocumentoReferenciaId == _globalOrdenDeTrabajo.OrdenDeTrabajoID);

        //            }
        //        }
        //    }
        //}

        private void Ok_simpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                var fechaDeEntregaCheque = string.IsNullOrEmpty(Convert.ToString(Cheque_textEdit.EditValue))
                    ? FechaEntregaCheque_dateEdit.DateTime
                    : Convert.ToDateTime(FechaEntregaCheque_dateEdit.EditValue);
                //string numeroCheque = Convert.ToString(Cheque_textEdit.EditValue);
                if (
                    AAct.CierraOrdenDeTrabajo(
                        FechaCierre_dateEdit.EditValue == null ? DateTime.Today : FechaCierre_dateEdit.DateTime,
                        Convert.ToDecimal(ParaUAPorciento_textEdit.EditValue),
                        Decimal.Round((decimal)IngresoTotalActividadTotal_textEdit.EditValue, 2),
                        Convert.ToString(Cheque_textEdit.EditValue),
                        Convert.ToString(Observacion_memoEdit.EditValue).Trim(),
                        (Convert.ToDecimal(PorcientoCliente_textEdit.EditValue)), fechaDeEntregaCheque,
                        Convert.ToString(Nota_memoExEdit.EditValue))
                    )
                {
                    AAct =
                        new NegocioDataContext().OrdenDeTrabajo.FirstOrDefault(
                            c => c.OrdenDeTrabajoID == AAct.OrdenDeTrabajoID);
                    if (AAct.TieneDeudaHistorico)
                        AAct.EliminaHistoricoDeudas();

                    if (AAct.Agrupacion.GetDeuda(AAct.TipoMonedaId) > 0 &&
                        (Convert.ToDecimal(Descuentos_buttonEdit.EditValue) <= 0))
                    {
                        XtraMessageBox.AllowHtmlText = true;
                        if (XtraMessageBox.Show(
                            "La Agrupación tiene deuda en esta moneda<br><b>Desea Regresar a la ventana de cierre para registrar algún descuento?",
                            "Información",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        {
                            
                        }
                    }
                    else
                    {
                        if (Convert.ToDecimal(Descuentos_buttonEdit.EditValue) > 0)
                            AAct.InsertaHistoricoDeudas((DateTime)AAct.FechaLiquidacion);
                    }
                    Print_dropDownButton.Enabled = true;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cerrar la Orden");

            }

        }

        private void Descuentos_simpleButton_Click(object sender, EventArgs e)
        {
            PopupDescuentosXtraForm descuentosXtraform = new PopupDescuentosXtraForm(AAct);

            if (descuentosXtraform.ShowDialog() == DialogResult.OK)
            {
                Descuentos_buttonEdit.EditValue = AAct.Descuentos;
                ImporteDistribuirConDesc_textEdit.EditValue = AAct.ImporteConDescuento;
            }
        }

        //public void ActulizaPorcientos()
        //{
        //    try
        //    {

        //    }
        //}

        private void CambiaPorciento(object sender, KeyEventArgs e = null)
        {
            try
            {
                //  decimal importeBase = decimal.Round((decimal) (_globalOrdenDeTrabajo.ImporteFinal - _globalOrdenDeTrabajo.GetDescuento()),2);
                //  double _ImporteTotal = Convert.ToDouble(importeBase);
                if (ImporteIngresaAgencia_textEdit.EditValue == null) return;
                TextEdit porcentItem = (TextEdit)sender;
                TextEdit complementaryItem = porcentItem == PorCientoUtilidadAgencia_textEdit
                    ? ParaUAPorciento_textEdit
                    : PorCientoUtilidadAgencia_textEdit;
                complementaryItem.EditValue = (100 - Convert.ToDecimal(porcentItem.EditValue));
                UtillidadAgenciaImporte_textEdit.EditValue = decimal.Round((decimal)ImporteIngresaAgencia_textEdit.EditValue *
                    (decimal)(PorCientoUtilidadAgencia_textEdit.EditValue) / 100, 2);

                ParaUAImporteSinDescuento_textEdit.EditValue = decimal.Round((decimal)ImporteIngresaAgencia_textEdit.EditValue -
                                                   (decimal)UtillidadAgenciaImporte_textEdit.EditValue, 2);
                ImporteDistribuirConDesc_textEdit.EditValue =
                    Convert.ToDecimal(ParaUAImporteSinDescuento_textEdit.EditValue) -
                    Convert.ToDecimal(Descuentos_buttonEdit.EditValue);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void CambiaPorciento()
        {
            CambiaPorciento(ParaUAPorciento_textEdit);
        }

        //Cambia los porcientos pactados entre el cliente y la empresa segun lo acordado 
        private void CambiaPorcientoAntesDistribucion(object sender, KeyEventArgs e = null)
        {
            try
            {
                if (IngresoTotalActividadTotal_textEdit.EditValue == null) return;
                TextEdit porcentItem = (TextEdit)sender;
                TextEdit complementaryItem = porcentItem == PorcientoCliente_textEdit
                    ? PorCientoQueSeIngresa_textEdit
                    : PorcientoCliente_textEdit;
                complementaryItem.EditValue = (100 - Convert.ToDecimal(porcentItem.EditValue));
                ImporteIngresaAgencia_textEdit.EditValue =
                    decimal.Round(
                        (decimal)IngresoTotalActividadTotal_textEdit.EditValue * (decimal)PorCientoQueSeIngresa_textEdit.EditValue / 100,
                        2);



                ImporteCliente_textEdit.EditValue = (decimal)IngresoTotalActividadTotal_textEdit.EditValue * Convert.ToInt32(PorcientoCliente_textEdit.EditValue) / 100;
            }
            catch (Exception)
            {
                return;
            }

        }

        private void CambiarImporte(object sender, KeyEventArgs e = null)
        {
            if (ImporteIngresaAgencia_textEdit.EditValue != null)
            {
                decimal importeTotal = Convert.ToDecimal(ImporteIngresaAgencia_textEdit.EditValue);
                if (importeTotal <= 0) return;
                TextEdit importeItem = (TextEdit)sender;
                TextEdit complementaryItem = (importeItem != UtillidadAgenciaImporte_textEdit
                    ? UtillidadAgenciaImporte_textEdit
                    : ParaUAImporteSinDescuento_textEdit);
                if (importeItem.EditValue != null)
                {
                    complementaryItem.EditValue = importeTotal - Convert.ToDecimal(importeItem.EditValue);
                    if (UtillidadAgenciaImporte_textEdit.EditValue != null)
                        PorCientoUtilidadAgencia_textEdit.EditValue = 100 * Convert.ToDecimal(UtillidadAgenciaImporte_textEdit.EditValue) /
                                                              importeTotal;
                }
            }
            if (PorCientoUtilidadAgencia_textEdit.EditValue != null)
                ParaUAPorciento_textEdit.EditValue = 100 - Convert.ToDecimal(PorCientoUtilidadAgencia_textEdit.EditValue);
        }

        private void ParaUAPorciento_textEdit_TextChanged(object sender, EventArgs e)
        {
            CambiaPorciento(ParaUAPorciento_textEdit);
        }

        private void Descuentos_buttonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (AAct.Agrupacion.GetDeuda(AAct.TipoMonedaId) <= 0)
            {
                XtraMessageBox.AllowHtmlText = true;
                if (
                    XtraMessageBox.Show(
                        String.Format(
                            "La Agrupacion {0} no tiene deuda en {1}, no se le puede aplicar ningún descuento. <br> Debe antes insertar una deuda en el botón Ingresar Deuda o desde la ventana Deudas.</br> ¿Desea asignar ahora alguna deuda a la Unidad Artística?",
                            AAct.Agrupacion.Nombre, AAct.TipoMoneda.Abreviatura), "Atención", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    PopupGestionDeudaXtraForm popup = new PopupGestionDeudaXtraForm(AAct.AgrupacionId,
                        AGlobalDataContext, AAct.TipoMonedaId);
                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        AGlobalDataContext = new NegocioDataContext();
                        AAct =
                            AGlobalDataContext.OrdenDeTrabajo.FirstOrDefault(
                                c => c.OrdenDeTrabajoID == AAct.OrdenDeTrabajoID);
                        CalculaDeuda();
                    }
                }
                else
                    return;
            }
            PopupDescuentosXtraForm descuentosXtraform = new PopupDescuentosXtraForm(AAct);

            if (descuentosXtraform.ShowDialog() == DialogResult.OK)
            {
                Descuentos_buttonEdit.EditValue = AAct.Descuentos;
                ImporteDistribuirConDesc_textEdit.EditValue = Decimal.Round((decimal)ParaUAImporteSinDescuento_textEdit.EditValue -
                                                              (decimal)Descuentos_buttonEdit.EditValue, 2);
            }
        }

        private void ImporteDistr_textEdit_EditValueChanged(object sender, EventArgs e)
        {
            //la cambiar el importe a distribuir debo enviar a cambiar los importes finales
            if (ImporteIngresaAgencia_textEdit.EditValue != null)
                ActualizaImporteAgenciaUnidadArtistica();
        }

        private void PorcientoCliente_textEdit_KeyUp(object sender, KeyEventArgs e)
        {
            CambiaPorcientoAntesDistribucion(sender);
        }

        private void Descuentos_buttonEdit_EditValueChanged(object sender, EventArgs e)
        {
            ActualizaImporteConDescuento();
        }

        //Actualiza el valor se va a distribuir entre el artista y la agencia 
        private void ActualizaImporteConDescuento()
        {
            ImporteDistribuirConDesc_textEdit.EditValue = Decimal.Round((decimal)ParaUAImporteSinDescuento_textEdit.EditValue -
                                                           AAct.Descuentos, 2);
        }

        private void ImporteDistribuirConDesc_textEdit_EditValueChanged(object sender, EventArgs e)
        {
            CambiaPorciento();
        }

        private void PorcientoCliente_textEdit_EditValueChanged(object sender, EventArgs e)
        {
            CambiaPorcientoAntesDistribucion(sender);
        }

        private void PorCientoQueSeIngresa_textEdit_EditValueChanged(object sender, EventArgs e)
        {
            CambiaPorcientoAntesDistribucion(sender);
        }

        private void ImporteTotal_textEdit_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                ActualizaImporteIngresoClienteEmpresa();
                ActualizaImporteAgenciaUnidadArtistica();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Cheque_textEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(FechaCierre_dateEdit.EditValue) != String.Empty)
                FechaEntregaCheque_dateEdit.EditValue = Convert.ToString(AAct.FechaEntregaCheque) != String.Empty ? AAct.FechaEntregaCheque :
                                                        FechaCierre_dateEdit.DateTime;
        }

        private void Deudas_simpleButton_Click(object sender, EventArgs e)
        {
            PopupGestionDeudaXtraForm popup = new PopupGestionDeudaXtraForm(AAct.AgrupacionId, AGlobalDataContext, AAct.TipoMonedaId);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                AGlobalDataContext = new NegocioDataContext();
                AAct = AGlobalDataContext.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == AAct.OrdenDeTrabajoID);
                CalculaDeuda();
            }
        }

        private void CalculaDeuda()
        {
            var deuda = AAct.Agrupacion.GetDeuda(AAct.TipoMonedaId);
            if (deuda > 0)
            {
                Deuda_label.Text = decimal.Round(deuda, 2).ToString();
                Moneda_label.BackColor = Deuda_label.BackColor = Color.DarkSalmon;

            }
            else
            {
                Deuda_label.Text = "0.00";
                Moneda_label.BackColor = Deuda_label.BackColor = Color.LightGreen;
            }

        }

        private void CierraOtXtraForm_Load(object sender, EventArgs e)
        {

        }

        private void DeudasReporte_simpleButton_Click(object sender, EventArgs e)
        {
            var reporte = new DeudaHistoricoXtraReport(AAct.AgrupacionId, AAct.TipoMonedaId, DateTime.MinValue,
                DateTime.MaxValue);
            reporte.CreateDocument();
            reporte.ShowRibbonPreviewDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var array = new Guid[1];
            array[0] = AAct.OrdenDeTrabajoID;
            XtraReport cierreReport = new CierreOtXtraReport(array);
            //cierreReport.CreateDocument();
            Utils.PrintReport(cierreReport,2);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var array = new Guid[1];
            array[0] = AAct.OrdenDeTrabajoID;
            XtraReport cierreReport = new CierreOtXtraReport(array);
            cierreReport.CreateDocument();
            cierreReport.ShowRibbonPreviewDialog();}

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var array = new Guid[1];
            array[0] = AAct.OrdenDeTrabajoID;
            XtraReport cierreReport = new CierreOtXtraReport(array);
            //cierreReport.CreateDocument();
            Utils.PrintReport(cierreReport, 1);
        }
    }
}