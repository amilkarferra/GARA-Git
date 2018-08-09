using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace DXApplication9
{
    public partial class PopupCierreProyectoXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public Proyectos AProyecto;
        public OrdenDeTrabajo AFactura;
        public PopupCierreProyectoXtraForm(Proyectos aProyectos)
        {
            InitializeComponent();
            AProyecto = aProyectos;
            AFactura = AProyecto.FacturaDeCierre;
            if (AFactura != null)
            {
                FechaCierre_dateEdit.DateTime = Convert.ToDateTime(AFactura.FechaLiquidacion);
                Cache_textEdit.EditValue = AFactura.ImporteCache;
                DietaTotal_textEdit.EditValue = AFactura.ImporteDieta;
                if (AFactura.FechaDePago != null)
                {
                    Cobrado_checkEdit.Checked = true;
                    FechaCobro_dateEdit.DateTime = Convert.ToDateTime(AFactura.FechaDePago);
                }
                Notas_memoEdit.Text = AFactura.Observaciones;
            }
        }

        private void Cobrado_checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            FechaCobro_dateEdit.Enabled = Cobrado_checkEdit.Checked;
        }

        private void Aceptar_simpleButton_Click(object sender, EventArgs e)
        {
            SalvarCierre();
        }

        private void SalvarCierre()
        {
            try
            {
                var dc = new NegocioDataContext();
                if(AFactura!=null)
                AFactura.EliminaImportesDeFactura();
                if (!dxValidationProvider1.Validate()) return;
                if (Cobrado_checkEdit.Checked && !Cobrado_dxValidationProvider.Validate()) return;
                if (AFactura == null)
                    AFactura = new OrdenDeTrabajo();

                AFactura.FechaLiquidacion = FechaCierre_dateEdit.DateTime;
                var firstOrDefault = dc.Agrupacion.FirstOrDefault(c=>c.EsProyecto);
                if (firstOrDefault != null)
                AFactura.AgrupacionId = AProyecto.AgrupacionId;
                AFactura.ProyectosId = AProyecto.ProyectoID;
                AFactura.TipoMonedaId = AProyecto.TipoMonedaId;
                AFactura.ImporteFinal = Decimal.Round(Convert.ToDecimal(Cache_textEdit.EditValue), 2);
                AFactura.FechaFinalActividad = Convert.ToDateTime(AProyecto.FechaFinal);
                AFactura.FechaIncialActividad = Convert.ToDateTime(AProyecto.FechaInicial);
                AFactura.FechaConfeccion = Convert.ToDateTime(AProyecto.FechaConfeccion);
                AFactura.ClienteQueContrataId = Convert.ToInt32(AProyecto.ControlClienteId);
                AFactura.Anno = AProyecto.Anno;
                AFactura.LugarDePresentacion = AProyecto.Paises.NombrePais;
                AFactura.NumeroContrato = AProyecto.ControlClientes.NumeroContratoString;
                AFactura.CantidadActividades = 1;
                AFactura.ImportePorActividad = Convert.ToDecimal(Cache_textEdit.EditValue);
                AFactura.EsPorCover = false;
                AFactura.TipoActividad = Enumerados.TipoActividad.Factura.ToEntero();
                AFactura.PorCientoUnidadArtistica = 100;
                AFactura.PorcientoCliente = 0;
                AFactura.Estado = (short) Enumerados.EstadoProyecto.Cerrado;
                AFactura.Observaciones = Notas_memoEdit.Text;
                if (AFactura.OrdenDeTrabajoID == Guid.Empty) {
                    AFactura.Consecutivo = OrdenDeTrabajo.GetProximoConsecutivo(Enumerados.TipoActividad.Factura);
                    AFactura.OrdenDeTrabajoID = Guid.NewGuid();
                    dc.OrdenDeTrabajo.InsertOnSubmit(AFactura);
                }
                dc.SubmitChanges();
                dc.ImportesDeFacturaEnFrontera.InsertOnSubmit(new ImportesDeFacturaEnFrontera
                {
                    Cantidad = 1,
                    Descripción = string.Format("Caché del Proyecto {0} - {1}", AProyecto.ConsecutivoString, AProyecto.NombreProyecto),
                    ImporteUnitario = Convert.ToDecimal(Cache_textEdit.EditValue),
                    TipoImporte = Enumerados.TipoImporteFacturas.Cache.ToEntero(),
                    ActividadId = AFactura.OrdenDeTrabajoID
                });

                if (DietaTotal_textEdit.EditValue != null)
                {
                    dc.ImportesDeFacturaEnFrontera.InsertOnSubmit(new ImportesDeFacturaEnFrontera
                    {
                        Cantidad = 1,
                        Descripción = string.Format("Dieta del Proyecto {0} - {1}", AProyecto.ConsecutivoString, AProyecto.NombreProyecto),
                        ImporteUnitario = Convert.ToDecimal(DietaTotal_textEdit.EditValue),
                        TipoImporte = Enumerados.TipoImporteFacturas.Dieta.ToEntero(),
                        ActividadId = AFactura.OrdenDeTrabajoID

                    });
                }
                AProyecto = dc.Proyectos.FirstOrDefault(c => c.ProyectoID == AProyecto.ProyectoID);
                AProyecto.FacturaDeProyectoId = AFactura.OrdenDeTrabajoID;
                AProyecto.EstadoProyecto=Enumerados.EstadoProyecto.Cerrado.ToEntero();
                dc.SubmitChanges();
                //AFactura.InsertaImporteIntegrantes();
                Utils.MuestraInformacion(string.Format("Datos salvados correctamente, factura asociada {0}",AFactura.ConsecutivoString));
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                Utils.MuestraError();
                DialogResult = DialogResult.Abort;
            }
        }

        private void Salir_simpleButton_Click(object sender, EventArgs e)
        {
            if (AFactura !=null && AFactura.OrdenDeTrabajoID == Guid.Empty && dxValidationProvider1.Validate())
            {
                if (
                    XtraMessageBox.Show("Desea Guardar los cambios del cierre", "Seleccione", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    SalvarCierre();
                }
            }
            Close();
        }
    }
}