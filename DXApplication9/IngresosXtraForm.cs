using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DevExpress.DXCore.Controls.XtraEditors.DXErrorProvider;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DXApplication9.Properties;
using DXApplication9.ReportesSistema;
using DXApplication9.UserControls;
using DXValidationProvider = DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider;

namespace DXApplication9
{

    public partial class IngresosXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private OrdenDeTrabajo AGlobalActividad;
        private bool AOrdenSalvada;

        private static class Global
        {
            public static int TipoIngreso { get; set; }
        }

        public Enumerados.TipoActividad TipoIngreso;
        private NegocioDataContext AGlobalDataContext = new NegocioDataContext();

        private enum TipoDistribucion
        {
            Asignar = 1,
            Distribuir = 2,
            Limpiar = 3,
            DistribuirDiferencia = 4,
            Retencion = 5
        }

        //public class DocumentoReferencia
        //{
        //    /// <summary>
        //    /// Id seria el Id del proyecto o de la orden de trabajo segun sea el caso
        //    /// </summary>
        //    public Guid Id { get; set; }



        //    public string Referencia { get; set; }
        //    public string Descripcion { get; set; }
        //    public string Fecha { get; set; }
        //    public decimal Importe { get; set; }
        //    public string Agrupacion { get; set; }

        //    public string Moneda { get; set; }

        //    public string Empresa { get; set; }
        //}

        //public class LocalIngresoPorArtista
        //{
        //    public int ArtistaID { get; set; }
        //    public decimal Importe { get; set; }
        //    public decimal Dieta { get; set; }

        //    public string NombreCompleto { get; set; }
        //    public decimal AporteOnat { get; set; }

        //    //public IngresoPorArtista ToIngresoPorArtista()
        //    //{
        //    //    IngresoPorArtista _IngresoPorArtista = new IngresoPorArtista
        //    //    {
        //    //        ArtistaId = ArtistaID,
        //    //        Dieta = Dieta,
        //    //        Importe = Importe
        //    //    };
        //    //    return _IngresoPorArtista;
        //    //}
        //}
        /// <summary>
        /// Para comenzar una nomina
        /// </summary>
        /// <param name="aTipoIngreso"></param>
        public IngresosXtraForm(Enumerados.TipoActividad aTipoIngreso)
        {
            TipoIngreso = aTipoIngreso;
            InitializeComponent();
            agrupacionBindingSource.DataSource = AGlobalDataContext.Agrupacion;
            Moneda_lookUpEdit.Properties.DataSource = AGlobalDataContext.TipoMoneda;
            PopulaSearchActividadGrid();
            Datos_tabbedControlGroup.SelectedTabPage = Documentos_layoutControlGroup;

        }
        /// <summary>
        /// Opcion de edicion de una nomina ya guardada
        /// </summary>
        /// <param name="aNomina"></param>
        public IngresosXtraForm(Nomina aNomina)
        {
            int tipoActividad = aNomina.OrdenDeTrabajo.TipoActividad;
            if (tipoActividad == (int)Enumerados.TipoActividad.OrdenDeTrabajo)
                TipoIngreso = Enumerados.TipoActividad.OrdenDeTrabajo;
            else if (tipoActividad == (int)Enumerados.TipoActividad.Factura)
                TipoIngreso = Enumerados.TipoActividad.Factura;
            else if (tipoActividad == (int)Enumerados.TipoActividad.Proyecto)
                TipoIngreso = Enumerados.TipoActividad.Proyecto;
            InitializeComponent();
            Datos_tabbedControlGroup.SelectedTabPage = Documentos_layoutControlGroup;
            agrupacionBindingSource.DataSource = AGlobalDataContext.Agrupacion;
            Moneda_lookUpEdit.Properties.DataSource = AGlobalDataContext.TipoMoneda;
            PopulaSearchActividadGrid();
            AOrdenSalvada = true;
            ActualizaDiferencia();
            AGlobalActividad = aNomina.OrdenDeTrabajo;
            MuestraControlesParaProyectos(AGlobalActividad.EsFacturaDeProyecto);
            Referencia_searchLookUpEdit.EditValue = aNomina.OrdenDeTrabajo.OrdenDeTrabajoID;
            Referencia_searchLookUpEdit.Enabled = false;

        }

        private void PopulaSearchActividadGrid(bool isUpdate = false)
        {
            ordenDeTrabajoBindingSource.DataSource = isUpdate
                           ? AGlobalDataContext.OrdenDeTrabajo.Where(
                               c =>
                                   c.Estado == (int)Enumerados.EstadoOrdenDeTrabajo.Cerrada ||
                                   c.Estado == (int)Enumerados.EstadoOrdenDeTrabajo.CerradaCobrada)
                                   :AGlobalDataContext.OrdenDeTrabajo.Where(c=>c.Estado!=Enumerados.EstadoOrdenDeTrabajo.Cancelada.ToEntero()).OrderByDescending(c => c.Anno).ThenBy(c => c.Consecutivo)
                                   ;
            switch (TipoIngreso)
            {
                case Enumerados.TipoActividad.Proyecto:
                    {
                        Global.TipoIngreso = (int)Enumerados.TipoActividad.Proyecto;

                        break;
                    }
                default:
                    {
                        Global.TipoIngreso = (int)Enumerados.TipoActividad.OrdenDeTrabajo;

                        SetControlesSetEnableStatus(false);
                        // ProyectoSearch_layoutControlItem.HideToCustomization();
                        DiferenciaDieta_layoutControlItem.HideToCustomization();
                        break;
                    }
            }
        }
        /// <summary>
        /// habilita o desabilita controles para que permita o no permita edicion
        /// </summary>
        /// <param name="aStatus"></param>
        private void SetControlesSetEnableStatus(bool aStatus)
        {
            Agrupacion_LookUpEdit.Enabled = Fecha_dateEdit.Enabled = Moneda_lookUpEdit.Enabled = Descripcion_textEdit.Enabled = aStatus;
        }

        private void IngresosXtraForm_Load(object sender, EventArgs e)
        {

            //switch (TipoIngreso)
            //{
            //    case Enumerados.TipoIngreso.OrdenDeTrabajo:
            //    {
            //        Referencia_searchLookUpEdit.Properties.DataSource = (new NegocioDataContext()).OrdenDeTrabajo.Select(c => new DocumentoReferencia {Descripcion = c.GetDescripcion(), Fecha = c.FechaIncialActividad, Id = c.OrdenDeTrabajoID, Importe = c.ImportePorActividad*c.CantidadActividades,Referencia = c.NumeroDeOrden,AgrupacionId = c.AgrupacionId, MonedaId = c.Moneda}).ToList();
            //            break;
            //        }
            //    case Enumerados.TipoIngreso.ProyectoInternacional:
            //        {
            //            break;
            //        }
            //    case Enumerados.TipoIngreso.OtroIngreso:
            //        {
            //            break;
            //        }
            //}
        }

        private void searchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);
            }
            catch (Exception)
            {

                SplashScreenManager.CloseForm();
                SplashScreenManager.ShowForm(MdiParent, typeof(WaitForm1), true, true);

            }
            switch (TipoIngreso)
            {
                default:
                    {
                        Guid id = (Guid)Referencia_searchLookUpEdit.EditValue;
                        AGlobalActividad =
                             AGlobalDataContext.OrdenDeTrabajo.FirstOrDefault(c => c.OrdenDeTrabajoID == id);
                        MuestraControlesParaProyectos(AGlobalActividad.EsFacturaDeProyecto);
                        Agrupacion_LookUpEdit.EditValue = AGlobalActividad.AgrupacionId;
                        Fecha_dateEdit.DateTime = AGlobalActividad.FechaIncialActividad;
                        Moneda_lookUpEdit.EditValue = AGlobalActividad.TipoMonedaId;
                        IngresoActividad_textEdit.EditValue = AGlobalActividad.ImportePorActividad * AGlobalActividad.CantidadActividades;
                        Descripcion_textEdit.Text = AGlobalActividad.GetDescripcion();
                        PorCientoCliente_textEdit.EditValue = AGlobalActividad.PorcientoCliente;
                        IngresoCliente_textEdit.EditValue = AGlobalActividad.ImporteIngresaCliente;
                        PorCientoIngAgencia_textEdit.EditValue = 100 -
                                                                 (Convert.ToInt32(PorCientoCliente_textEdit.EditValue));
                        IngresoAgencia_textEdit.EditValue = AGlobalActividad.ImporteIngresaAgencia;
                        if (AGlobalActividad.PorCientoUnidadArtistica != null)
                            ParaUAPorciento_textEdit.EditValue = AGlobalActividad.PorCientoUnidadArtistica;
                        ParaUAImporteSinDescuento_textEdit.EditValue =
                            AGlobalActividad.ImporteUnidadArtisticaSinDescuento;
                        ParaEmpUtPorciento_textEdit.EditValue = AGlobalActividad.PorcientoUtilidadEmpresa;
                        // 100 - Convert.ToDecimal(ParaUAPorciento_textEdit.EditValue);
                        UtilidadEmpImporte_textEdit.EditValue = AGlobalActividad.ImporteUtilidadAgencia;

                        ActualizaDescuentos();

                        if (AGlobalActividad.TieneNominaAsociada)
                        {
                            var nomina = AGlobalActividad.GetNominaAsociada();
                            ConsecutivoNomina_textEdit.EditValue = nomina.Consecutivo;
                            FechaNomina_dateEdit.EditValue = nomina.FechaEmision;
                        }
                        else
                        {
                            ConsecutivoNomina_textEdit.EditValue = string.Format("{0}/{1}", Nomina.GetProximoConsecutivo(),
                                AGlobalActividad.Anno);
                            if (AGlobalActividad.ParticipantesDeAcividad.Count == 0)
                            {
                                if (!AGlobalActividad.EsFacturaDeProyecto)
                                    AGlobalActividad.InsertaParticipantesDeActividad();
                                else
                                {
                                    AGlobalActividad.InsertaParticipantesDeActividadDeProyecto();
                                }
                            }

                            FechaNomina_dateEdit.DateTime = DateTime.Today;
                        }
                        PopulaParticipantesGridControl();
                        try
                        {
                            SplashScreenManager.CloseForm();
                        }
                        catch
                        {

                            //donothing
                        }
                        break;
                    }
                case Enumerados.TipoActividad.Proyecto:
                    {
                        break;
                    }



            }
        }

        private void MuestraDatosDeDieta(bool v)
        {
            
            if (v)
            {
                

            }
            else
            {
                
            }

        }

        private void MuestraControlesParaProyectos(bool muestra = false)
        {
            colDieta.Visible = muestra;
            //MuestraDatosDeDieta(muestra);
            if (muestra)
            {
                DiferenciaDieta_layoutControlItem.RestoreFromCustomization(DiferenciaImporte_layoutControlItem, InsertType.Right);
                DietaTotal_textEdit.EditValue = AGlobalActividad.ImporteDieta;
                Dieta_layoutControlItem.RestoreFromCustomization(Moneda_layoutControlItem, InsertType.Bottom);
                SoloPartProy_layoutControlItem.RestoreFromCustomization(EliminaIntegrante_layoutControlItem, InsertType.Left);
            }
            else
            {
                SoloPartProy_layoutControlItem.HideToCustomization();
                DiferenciaDieta_layoutControlItem.HideToCustomization();
                Dieta_layoutControlItem.HideToCustomization();
            }
        }

        private void PopulaParticipantesGridControl()
        {
            
            participantesDeAcividadBindingSource.DataSource =
                            AGlobalDataContext.ParticipantesDeAcividad.Where(c => c.ActividadId == AGlobalActividad.OrdenDeTrabajoID);
        }


        private void gridView1_CustomColumnDisplayText(object sender,
            DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //elimina los ceros de las celdas
            if (e.Column == colAporteOnat || e.Column == colDieta || e.Column == colImporteArtista)
                if (Convert.ToDecimal(e.Value) == 0) e.DisplayText = "";
            if (e.Column == colArtistaId)
            {
                Int32 artistaId = (int)e.Value;
                string nombreCompleto =
                    AGlobalDataContext.Artista.FirstOrDefault(c => c.ArtistaID == artistaId).NombreCompleto;
                e.DisplayText = nombreCompleto.Trim();
            }
        }

        private void gridView1_CalcPreviewText(object sender, DevExpress.XtraGrid.Views.Grid.CalcPreviewTextEventArgs e)
        {
            decimal importeDelArtista = (decimal)gridView1.GetRowCellValue(e.RowHandle, colImporteArtista);
            e.PreviewText = string.Format(decimal.Round((importeDelArtista * 5) / 100).ToString());
        }

        private void gridView1_CellValueChanged(object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colImporteArtista)
            {
                decimal importe = (decimal)e.Value;
                decimal aporteOnat = decimal.Round(importe * 5 / 100, 2);
                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[3], aporteOnat);

            }

        }


        private void AsignarImporteAtodos(TipoDistribucion aTipoDistribucion, bool soloSeleccionados = false, Enumerados.TipoImporteFacturas aTipoIMporte = Enumerados.TipoImporteFacturas.Cache)
        {
            decimal importe = 0;
            bool esCachet = aTipoIMporte == Enumerados.TipoImporteFacturas.Cache;
            TextEdit diferenciaControl = esCachet ? Diferencia_textEdit : DiferenciaDieta_textEdit;
            GridColumn selectColumn = aTipoIMporte == Enumerados.TipoImporteFacturas.Cache ? colImporteArtista : colDieta;
            int cantidadIntegrantes = soloSeleccionados ? gridView1.GetSelectedRows().Count() : gridView1.RowCount;

            if (aTipoDistribucion == TipoDistribucion.DistribuirDiferencia)
                importe = Convert.ToDecimal(diferenciaControl.EditValue);
            else
            {
                importe = aTipoDistribucion == TipoDistribucion.Limpiar
                    ? 0
                    : Convert.ToDecimal(ImporteUAaProcesar_textEdit.EditValue);
            }

            if (!soloSeleccionados)
                for (var i = 0; i < gridView1.RowCount; i++)
                {
                    decimal valor =
                        decimal.Round(
                            importe / (aTipoDistribucion == TipoDistribucion.Distribuir ? cantidadIntegrantes : 1), 2,
                            MidpointRounding.ToEven);
                    gridView1.SetRowCellValue(i, selectColumn, valor);


                }
            else
            {
                var selectedRowsHandles = gridView1.GetSelectedRows();
                if (aTipoDistribucion != TipoDistribucion.DistribuirDiferencia &&
                    aTipoDistribucion != TipoDistribucion.Retencion)
                    foreach (var rowHandle in selectedRowsHandles)
                    {
                        gridView1.SetRowCellValue(rowHandle, selectColumn,
                            decimal.Round(
                                importe / (aTipoDistribucion == TipoDistribucion.Distribuir ? cantidadIntegrantes : 1),
                                2, MidpointRounding.ToEven));
                    }
                else if (aTipoDistribucion == TipoDistribucion.DistribuirDiferencia)

                    foreach (var selectedRowsHandle in selectedRowsHandles)
                    {
                        decimal cellValue =
                            Convert.ToDecimal(gridView1.GetRowCellValue(selectedRowsHandle, selectColumn));
                        decimal diferencia =
                            Decimal.Round(Convert.ToDecimal(diferenciaControl.EditValue) / cantidadIntegrantes, 2,
                                MidpointRounding.ToEven);
                        gridView1.SetRowCellValue(selectedRowsHandle, selectColumn,
                            decimal.Round(cellValue + diferencia, 2, MidpointRounding.ToEven));
                    }
                else if (aTipoDistribucion == TipoDistribucion.Retencion)

                    foreach (var selectedRowsHandle in selectedRowsHandles)
                    {
                        gridView1.SetRowCellValue(selectedRowsHandle, colRetencion,
                            decimal.Round(Convert.ToDecimal(ImporteUAaProcesar_textEdit.EditValue), 2,
                                MidpointRounding.ToEven));

                    }
            }
        }



        private void ActualizaDiferencia()
        {

            try
            {
                gridView1.UpdateSummary();

                var diferenciaImporte = AGlobalActividad.ImporteRestaPorDistribuir;
                var diferenciaDieta = AGlobalActividad.DietaRestaPorDistribuir;
                Diferencia_textEdit.EditValue = diferenciaImporte;
                DiferenciaDieta_textEdit.EditValue = diferenciaDieta;
                if (diferenciaImporte != 0)
                {
                    Diferencia_textEdit.BackColor = Color.DarkRed;
                    Diferencia_textEdit.ForeColor = Color.WhiteSmoke;
                    Print_simpleButton.Enabled = false;
                    Distribucion_layoutControlGroup.CaptionImage = Resources.error_16x16;

                }
                else
                {
                    Diferencia_textEdit.BackColor = Color.DarkGreen;
                    Diferencia_textEdit.ForeColor = Color.WhiteSmoke;
                    Print_simpleButton.Enabled = AOrdenSalvada;
                    Distribucion_layoutControlGroup.CaptionImage = Resources.apply_16x16;
                }
                if (diferenciaDieta != 0)
                {
                    DiferenciaDieta_textEdit.BackColor = Color.DarkRed;
                    DiferenciaDieta_textEdit.ForeColor = Color.WhiteSmoke;
                    Print_simpleButton.Enabled = false;
                    Distribucion_layoutControlGroup.CaptionImage = Resources.error_16x16;

                }
                else
                {
                    DiferenciaDieta_textEdit.BackColor = Color.DarkGreen;
                    DiferenciaDieta_textEdit.ForeColor = Color.WhiteSmoke;
                    Print_simpleButton.Enabled = AOrdenSalvada;
                    Distribucion_layoutControlGroup.CaptionImage = Resources.apply_16x16;
                }
            }
            catch (Exception)
            {
                Diferencia_textEdit.BackColor = Color.DarkRed;
                Diferencia_textEdit.ForeColor = Color.WhiteSmoke;
                Diferencia_textEdit.EditValue = TotalDistribuir_textEdit.EditValue;
                Distribucion_layoutControlGroup.CaptionImage = Resources.error_16x16;

                Print_simpleButton.Enabled = false;

            }
        }

        private void imageComboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            //Distribuir Importe total entre todos
            int seleccion = Convert.ToInt32(Accion_imageComboBoxEdit.EditValue);
            if (seleccion == 0 || seleccion == 1)
            {
                ImporteUAaProcesar_textEdit.EditValue = ImporteDistribuirConDesc_textEdit.EditValue;
                ImporteUAaProcesar_textEdit.Enabled = Convert.ToInt32(Accion_imageComboBoxEdit.EditValue) == 1;
            }
            else if (seleccion == 3) //caso de la diferencia
            {
                ImporteUAaProcesar_textEdit.EditValue = Diferencia_textEdit.EditValue;
            }
            else if (seleccion == 13) //caso de la diferencia
            {
                ImporteUAaProcesar_textEdit.EditValue = AGlobalActividad.ImporteDieta;
            }
            else
            {
                ImporteUAaProcesar_textEdit.Enabled = true;
                ImporteUAaProcesar_textEdit.EditValue = 0;

            }
            EjecutarAccion_simpleButton.Enabled = true;
        }

        private void ProcesarBucle_simpleButton_Click(object sender, EventArgs e)
        {
            //int _CantidadIntegrantes = gridView1.RowCount;


            switch (Convert.ToInt32(Accion_imageComboBoxEdit.EditValue))
            {
                case 0: //Distribuir Importe total entre todos
                    {
                        AsignarImporteAtodos(TipoDistribucion.Distribuir);
                    }
                    break;
                case 1: //Distribuir importe entre todos
                    {
                        AsignarImporteAtodos(TipoDistribucion.Distribuir);
                    }
                    break;
                case 2: //distribuir importe entre seleccionados
                    {
                        AsignarImporteAtodos(TipoDistribucion.Distribuir, true);
                    }
                    break;
                case 3: //distribuir diferencia entre seleccionados 
                    {
                        //TotalDistribuir_textEdit.Enabled = false;
                        AsignarImporteAtodos(TipoDistribucion.DistribuirDiferencia, true);
                    }
                    break;
                case 4: //distribuir dieta entre seleccionados
                    {
                        //  AsignarImporteAtodos("Dieta", TipoDistribucion.Distribuir, true);
                    }
                    break;
                case 5: //Asignar Importe a todos
                    {
                        AsignarImporteAtodos(TipoDistribucion.Asignar);
                    }
                    break;
                case 6: //Asignar Importe a seleccionados
                    {
                        AsignarImporteAtodos(TipoDistribucion.Asignar, true);

                    }
                    break;
                case 7: //Asignar dieta para todos
                    {
                        AsignarImporteAtodos(TipoDistribucion.Asignar, false, Enumerados.TipoImporteFacturas.Dieta);

                    }
                    break;
                case 8: //Asignar dieta a seleccionados
                    {
                        AsignarImporteAtodos(TipoDistribucion.Asignar, true, Enumerados.TipoImporteFacturas.Dieta);
                    }
                    break;
                case 9: //Limpiar importe de todos
                    {
                        AsignarImporteAtodos(TipoDistribucion.Limpiar);
                    }
                    break;
                case 10: //Limpiar importe de seleccionados
                    {
                        AsignarImporteAtodos(TipoDistribucion.Limpiar, true);

                    }
                    break;
                case 11: //Limpiar dieta de todos
                    {
                        AsignarImporteAtodos(TipoDistribucion.Limpiar);
                    }
                    break;
                case 12: //Limpiar dieta de seleccionados
                    {
                        AsignarImporteAtodos(TipoDistribucion.Limpiar, true);
                    }
                    break;
                case 13: //Distribuir Dieta Total entre todos
                    {
                        AsignarImporteAtodos(TipoDistribucion.Distribuir, false, Enumerados.TipoImporteFacturas.Dieta);
                    }
                    break;
                case 14: //Distribuir Diferencia de dieta entre seleccionados
                    {
                        AsignarImporteAtodos(TipoDistribucion.DistribuirDiferencia, true, Enumerados.TipoImporteFacturas.Dieta);
                    }
                    break;


            }

            AGlobalDataContext.SubmitChanges();
            ActualizaDiferencia();
        }

        private void Ok_simpleButton_Click(object sender, EventArgs e)
        {
            SalvaValoresDeCierre();
            //dxValidationProvider1.RemoveControlError(Referencia_searchLookUpEdit);
            if (!SeValidaTab(Documentos_layoutControlGroup, Documentos_dxValidationProvider)) return;
            if (!SeValidaTab(Distribucion_layoutControlGroup, Distribucion_dxValidationProvider)) return;
            //Guid docReferenciaGuid = new Guid();

            try
            {

                if (!AGlobalActividad.TieneNominaAsociada)
                {
                    Int32 anno = ConfiguracionGeneral.EsCierre
                        ///en el caso de que se este cerrando las nominas que se hagan aparecen un año antes de la configuracion , 
                        /// esto permite que el sistema este trabajando por ejemeplo en el año 2018 (ordenes de trabajo, facturas, contratos salen con fechas 2018)
                        /// sin embargo las nominas salen el año anterior porque la contabilidad no ha cerrado el año

                        ? ConfiguracionGeneral.Anno - 1
                        : ConfiguracionGeneral.Anno;
                    Nomina nuevaNomina = new Nomina
                    {
                        Anno = anno,
                        AgrupacionId = AGlobalActividad.AgrupacionId,
                        FechaEmision = FechaNomina_dateEdit.DateTime,
                        Consecutivo =
                            Convert.ToInt32(ConsecutivoNomina_textEdit.EditValue.ToString()
                                .Substring(0, ConsecutivoNomina_textEdit.EditValue.ToString().LastIndexOf('/'))),
                        DocumentoReferenciaId = AGlobalActividad.OrdenDeTrabajoID
                    };
                    AGlobalDataContext.Nomina.InsertOnSubmit(nuevaNomina);

                }


                AGlobalActividad.SetEstado();
                AGlobalDataContext.SubmitChanges();
                AOrdenSalvada = true;
                ActualizaDiferencia();


                if (TipoIngreso == Enumerados.TipoActividad.OrdenDeTrabajo ||
                    TipoIngreso == Enumerados.TipoActividad.Factura)
                {
                    for (var i = 0; i < gridView1.RowCount; i++)
                    {
                        ParticipantesDeAcividad participante = (ParticipantesDeAcividad)gridView1.GetRow(i);
                        ParticipantesDeAcividad participanteDc =
                            AGlobalDataContext.ParticipantesDeAcividad.FirstOrDefault(
                                c => c.ParticipanteDeActividadID == participante.ParticipanteDeActividadID);
                        participanteDc.Importe = participante.Importe;
                        //participanteDc.Retencion = participante.Retencion;
                        participanteDc.ActividadId = AGlobalActividad.OrdenDeTrabajoID;
                    }
                }
                AGlobalDataContext.SubmitChanges();
                AGlobalActividad.SetEstado();
                AGlobalDataContext.SubmitChanges();
                //Guardo datos reales de la nomina

            }
            catch (Exception)
            {

                MessageBox.Show("Por favor revise los datos insertados");
            }

        }

        private void SalvaValoresDeCierre()
        {
            var actividad =
                AGlobalDataContext.OrdenDeTrabajo.FirstOrDefault(
                    c => c.OrdenDeTrabajoID == AGlobalActividad.OrdenDeTrabajoID);
            actividad.PorcientoCliente = Convert.ToInt32(PorCientoCliente_textEdit.EditValue);
            actividad.PorCientoUnidadArtistica = Convert.ToInt32(ParaUAPorciento_textEdit.EditValue);
            actividad.ImporteFinal =
                decimal.Round(Convert.ToDecimal(IngresoActividad_textEdit.EditValue), 2);
            AGlobalDataContext.SubmitChanges();
            AGlobalActividad = actividad;
            ActualizaDiferencia();
            SeValidaTab(Documentos_layoutControlGroup, Documentos_dxValidationProvider);
            SeValidaTab(Distribucion_layoutControlGroup, Distribucion_dxValidationProvider);
        }

        private bool SeValidaTab(LayoutControlGroup aTab, DXValidationProvider aDxValidationProvider)
        {
            var tab = aTab;

            if (!aDxValidationProvider.Validate())
            {
                tab.CaptionImage = Properties.Resources.error_16x16;
                // tab.Text += " Error";
                return false;
            }
            if (tab.CaptionImage != null)
            {
                tab.CaptionImage = Properties.Resources.apply_16x16;
                //tab.Text = tab.Text.Right(5);
            }

            return true;
        }


        private void CambiaPorciento(object sender, KeyEventArgs e = null)
        {
            try
            {
                double importeTotal = Convert.ToDouble(IngresoAgencia_textEdit.EditValue);
                if (importeTotal <= 0) return;
                TextEdit porcentItem = (TextEdit)sender;
                TextEdit complementaryItem = porcentItem == ParaEmpUtPorciento_textEdit
                    ? ParaUAPorciento_textEdit
                    : ParaEmpUtPorciento_textEdit;
                complementaryItem.EditValue = (100 - Convert.ToDecimal(porcentItem.EditValue));
                UtilidadEmpImporte_textEdit.EditValue = importeTotal *
                                                        Convert.ToDouble(ParaEmpUtPorciento_textEdit.EditValue) /
                                                        100;
                ParaUAImporteSinDescuento_textEdit.EditValue = importeTotal *
                                                               Convert.ToDouble(ParaUAPorciento_textEdit.EditValue) /
                                                               100;
                if (ParaUAImporteSinDescuento_textEdit.EditValue != null)
                    ImporteDistribuirConDesc_textEdit.EditValue =
                        (decimal.Round(Convert.ToDecimal(ParaUAImporteSinDescuento_textEdit.EditValue), 2) -
                         AGlobalActividad.Descuentos).ToString();
            }
            catch (Exception)
            {
                return;
            }

        }

        private void CambiarImporte(object sender, KeyEventArgs e = null)
        {
            if (IngresoActividad_textEdit.EditValue != null)
            {
                decimal importeTotal = Convert.ToDecimal(IngresoActividad_textEdit.EditValue);
                if (importeTotal <= 0) return;
                TextEdit importeItem = (TextEdit)sender;
                TextEdit complementaryItem = (importeItem != UtilidadEmpImporte_textEdit
                    ? UtilidadEmpImporte_textEdit
                    : ParaUAImporteSinDescuento_textEdit);
                if (importeItem.EditValue != null)
                {
                    complementaryItem.EditValue = importeTotal - Convert.ToDecimal(importeItem.EditValue);
                    if (UtilidadEmpImporte_textEdit.EditValue != null)
                        ParaEmpUtPorciento_textEdit.EditValue = 100 *
                                                                Convert.ToDecimal(UtilidadEmpImporte_textEdit.EditValue) /
                                                                importeTotal;
                }
            }
            if (ParaEmpUtPorciento_textEdit.EditValue != null)
                ParaUAPorciento_textEdit.EditValue = 100 - Convert.ToDecimal(ParaEmpUtPorciento_textEdit.EditValue);
            if (ParaUAImporteSinDescuento_textEdit.EditValue != null)
                TotalDistribuir_textEdit.EditValue =
                    decimal.Round(Convert.ToDecimal(ParaUAImporteSinDescuento_textEdit.EditValue), 2) -
                    AGlobalActividad.Descuentos;
        }


        private void Porciento_textEdit_Validating(object sender, CancelEventArgs e)
        {
            //if (Convert.ToDecimal(((TextEdit)sender).EditValue) > 100)
            //    e.Cancel = true;
        }

        private void ParaUAPorciento_textEdit_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "no se puede exceder el 100 %";
        }

        private void ParaEmpPorciento_textEdit_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "no se puede exceder el 100 %";
        }

        private void tabbedControlGroup1_SelectedPageChanging(object sender,
            DevExpress.XtraLayout.LayoutTabPageChangingEventArgs e)
        {
            if (e.Page == Distribucion_layoutControlGroup)
            {
                decimal importeDistribuir = Convert.ToDecimal(ImporteDistribuirConDesc_textEdit.EditValue);
                if (importeDistribuir == 0)
                {
                    MessageBox.Show("Por favor realice antes la descomposición", "Un momento", MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    ParaUAImporteSinDescuento_textEdit.Focus();
                    e.Cancel = true;
                }
                else
                {
                    TotalDistribuir_textEdit.EditValue = importeDistribuir;
                    TotalDistribuir_textEdit.Enabled = false;
                    ActualizaDiferencia();
                }
            }

        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PopupDescuentosXtraForm popup = new PopupDescuentosXtraForm(AGlobalActividad);
            if (popup.ShowDialog() == DialogResult.OK)

                ActualizaDescuentos();
        }

        private void ActualizaDescuentos()
        {
            decimal descuento = AGlobalActividad.Descuentos;// IngresoActividad_textEdit.EditValue = __GlobalOrdenDeTrabajo.ImporteFinal;
            ImporteDistribuirConDesc_textEdit.EditValue = decimal.Round(Convert.ToDecimal(ParaUAImporteSinDescuento_textEdit.EditValue), 2) - descuento;
            Descuentos_buttonEdit.Text = descuento.ToString();
            AGlobalActividad.Descuento = descuento;
        }





        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

            AGlobalDataContext.SubmitChanges();
            ActualizaDiferencia();
            SeValidaTab(Distribucion_layoutControlGroup, Distribucion_dxValidationProvider);
            gridView1.RefreshData();
        }

        private void ParaUAPorciento_textEdit_TextChanged(object sender, EventArgs e)
        {
            CambiaPorciento(sender);
        }

        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }



        private void Print_simpleButton_Click(object sender, EventArgs e)
        {
            if (!SeValidaTab(Documentos_layoutControlGroup, Documentos_dxValidationProvider)) return;
            if (!SeValidaTab(Distribucion_layoutControlGroup, Distribucion_dxValidationProvider)) return;
            var nomina = AGlobalActividad.Nomina;

            if (nomina != null && !nomina.EstaCuadrada)
            {
                XtraMessageBox.Show("La nomina no está cuadrada", "Información",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            NominaXtraReport reporte = new NominaXtraReport(AGlobalActividad);
            reporte.CreateDocument();
            reporte.ShowPreview();

        }

        private void PorCientoCliente_textEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToDecimal(((TextEdit)sender).EditValue) > 100)
            {
                e.SuppressKeyPress = true;
                Utils.MuestraError("Este valor no puede ser mayot que 100");
                return;
            }
            PorCientoIngAgencia_textEdit.EditValue = 100 - Convert.ToInt32(((TextEdit)sender).EditValue);
            ActualizaDatosEmpresaCliente();
            ActualizaImporteAgenciaUnidadArtistica();
            ActualizaDescuentos();
        }

        private bool VerificaPorcientoBienEscrito(object sender, KeyEventArgs e)
        {
            if (Convert.ToDecimal(((TextEdit)sender).EditValue) > 100)
            {
                e.SuppressKeyPress = true;
                return false;
            }
            return true;
        }

        private void PorCientoIngAgencia_textEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToDecimal(((TextEdit)sender).EditValue) > 100)
            {
                e.SuppressKeyPress = true;
                Utils.MuestraError("Este valor no puede ser mayot que 100");
                return;
            }
            PorCientoCliente_textEdit.EditValue = 100 - Convert.ToInt32(((TextEdit)sender).EditValue);
            ActualizaDatosEmpresaCliente();
            ActualizaImporteAgenciaUnidadArtistica();
            ActualizaDescuentos();
        }

        private void ActualizaDatosEmpresaCliente()
        {
            if (PorCientoIngAgencia_textEdit.EditValue != null && PorCientoCliente_textEdit.EditValue != null &&
                IngresoActividad_textEdit.EditValue != null)
            {

                try
                {
                    int porcientoCliente = Convert.ToInt32(PorCientoCliente_textEdit.EditValue);
                    IngresoCliente_textEdit.EditValue = porcientoCliente *
                                                        (decimal.Round(
                                                            (decimal)IngresoActividad_textEdit.EditValue, 2)) / 100;
                    IngresoAgencia_textEdit.EditValue = (decimal)IngresoActividad_textEdit.EditValue -
                                                        (decimal)IngresoCliente_textEdit.EditValue;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        private void ActualizaImporteAgenciaUnidadArtistica()
        {
            try
            {
                int porcientoAgencia = Convert.ToInt32(ParaEmpUtPorciento_textEdit.EditValue);
                decimal importeIngresaAgencia = decimal.Round(Convert.ToDecimal(IngresoAgencia_textEdit.EditValue), 2);
                decimal importeUtilidadAgencia = decimal.Round(importeIngresaAgencia * porcientoAgencia / 100, 2);
                decimal importeIngresaArtistaSinDescuento = decimal.Round(
                    importeIngresaAgencia - importeUtilidadAgencia, 2);

                UtilidadEmpImporte_textEdit.EditValue = importeUtilidadAgencia;
                ParaUAImporteSinDescuento_textEdit.EditValue = decimal.Round(importeIngresaAgencia -
                                                                             decimal.Round(
                                                                                 porcientoAgencia * importeIngresaAgencia /
                                                                                 100, 2), 2);
                ImporteDistribuirConDesc_textEdit.EditValue = importeIngresaArtistaSinDescuento -
                                                              Convert.ToDecimal(Descuentos_buttonEdit.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void IngresoActividad_textEdit_KeyUp(object sender, KeyEventArgs e)
        {
            ActualizaDatosEmpresaCliente();
            ActualizaImporteAgenciaUnidadArtistica();
            ActualizaDescuentos();
        }

        private void Eliminar_simpleButton_Click(object sender, EventArgs e)
        {
            var participantesSeleccionados = GetparticipantesSeleccionados();
            if (
                MessageBox.Show(
                    string.Format(
                        "{0} estas seguro de lo que vas a hacer? Bueno, luego puedes insertar en el boton insertar",
                        LoginHelper.UsuarioRegistrado.NombreCompleto), "Atención", MessageBoxButtons.OKCancel) !=
                DialogResult.Cancel)
            {
                try
                {

                    AGlobalDataContext.ParticipantesDeAcividad.DeleteAllOnSubmit(participantesSeleccionados);
                    AGlobalDataContext.SubmitChanges();
                    gridView1.DeleteSelectedRows();
                }
                catch (Exception)
                {

                    MessageBox.Show("Error al completar la acción");
                }
            }
        }

        private IQueryable<ParticipantesDeAcividad> GetparticipantesSeleccionados()
        {

            var rowsSelected = gridView1.GetSelectedRows();
            int[] actividadesIds = new int[rowsSelected.Count()];
            for (int i = 0; i < rowsSelected.Count(); i++)
            {
                actividadesIds[i] = ((ParticipantesDeAcividad)gridView1.GetRow(rowsSelected[i])).ParticipanteDeActividadID;
            }

            var participantes =
                AGlobalDataContext.ParticipantesDeAcividad.Where(
                    c => actividadesIds.Contains(c.ParticipanteDeActividadID));

            return participantes;
        }

        private void Insertar_simpleButton_Click(object sender, EventArgs e)
        {
            //ArtistasForm ListadoArtista = new ArtistasForm(_GlobalActividad.AgrupacionId);

            int nombreGrupo = Convert.ToInt32(AGlobalActividad.AgrupacionId);
            ArtistasForm integrantesForm = new ArtistasForm(nombreGrupo);
            integrantesForm.InsertInegrante_buttonEdit.Visible = true;
            // _IntegrantesForm.SelectGroup(_GrupoId);
            if (integrantesForm.ShowDialog() == DialogResult.OK &&
                integrantesForm.Artista_gridView.GetSelectedRows().Count() > 0)
            {
                // List<Artista> _Artistas = new List<Artista>();
                var selectedRows = integrantesForm.Artista_gridView.GetSelectedRows();
                foreach (var selectedRow in selectedRows)
                {

                    Artista artista =
                        ((AgrupacionDeArtista)(integrantesForm.Artista_gridView.GetRow(selectedRow))).Artista;
                    if (!AGlobalDataContext.ParticipantesDeAcividad.Any(
                        c => c.ActividadId == AGlobalActividad.OrdenDeTrabajoID &&
                             c.ArtistaId == artista.ArtistaID))
                        AGlobalDataContext.ParticipantesDeAcividad.InsertOnSubmit(new ParticipantesDeAcividad
                        {
                            ActividadId = AGlobalActividad.OrdenDeTrabajoID,
                            ArtistaId = artista.ArtistaID
                        });
                    //  _Artistas.Add(_AgrupacionDeArtista.Artista);
                }
                //var _NuevosParticipantes = _Artistas.Select(c => c.ToParticipante(GetProyectoId(), _Configuracion.Agencia))
                //                .ToList();
                //        _GlobalDataContext.ParticipantesDeProyectos.InsertAllOnSubmit(_NuevosParticipantes);
                AGlobalDataContext.SubmitChanges();
                PopulaParticipantesGridControl();
            }
        }

        private void SalvarCierre_simpleButton_Click(object sender, EventArgs e)
        {
            SalvaValoresDeCierre();
        }

        private void ParaEmpUtPorciento_textEdit_TextChanged(object sender, EventArgs e)
        {
            CambiaPorciento(sender);
        }

        private void UtilidadEmpImporte_textEdit_TextChanged(object sender, EventArgs e)
        {
            CambiarImporte(sender);
        }

        private void ParaUAImporteSinDescuento_textEdit_TextChanged(object sender, EventArgs e)
        {
            CambiarImporte(sender);
        }

        private void MostrarParticipantesDeProyecto_simpleButton_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show("Esta acción eliminará toda la distribución realizada hasta el momento, esta seguro?","Atención",MessageBoxButtons.YesNo,MessageBoxIcon.Hand)==DialogResult.Yes)
            if (AGlobalActividad.EsFacturaDeProyecto)
            {
                AGlobalActividad.EliminarParticipantesDeActividad();
                AGlobalActividad.InsertaParticipantesDeActividadDeProyecto();
            }
            PopulaParticipantesGridControl();
            ActualizaDiferencia();
        }  
    }

}



