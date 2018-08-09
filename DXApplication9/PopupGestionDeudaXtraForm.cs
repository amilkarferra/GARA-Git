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
    public partial class PopupGestionDeudaXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private Agrupacion AAgrupacion;
        public NegocioDataContext AGlobalNegocioDataContext;
        public int ATipoMonedaId;
        private HistoricoDeuda AGlobalHistorico;
        private decimal Deuda;
        private Enumerados.TipoGestionDeuda TipoGestion;
        public PopupGestionDeudaXtraForm(int anAgrupacionID, NegocioDataContext aNegocioDataContext,int? aTipoMonedaId=null)
        {
            InitializeComponent();
            AGlobalNegocioDataContext = aNegocioDataContext;
            tipoMonedaBindingSource.DataSource = AGlobalNegocioDataContext.TipoMoneda.Where(c=>c.OrdenDeTrabajo);
            AGlobalHistorico = new HistoricoDeuda();
            AAgrupacion = AGlobalNegocioDataContext.Agrupacion.FirstOrDefault(c => c.AgrupacionID == anAgrupacionID);
            TipoGestionDeuda_lookUpEdit.Properties.DataSource =
                Enumerados.ListaDeEnumerados(typeof(Enumerados.TipoGestionDeuda));
            Fecha_dateEdit.DateTime = DateTime.Today;
            if (aTipoMonedaId != null)
            {
                Moneda_lookUpEdit.EditValue = aTipoMonedaId;
                Moneda_lookUpEdit.Enabled = false;
            }

           
        }

        public PopupGestionDeudaXtraForm(HistoricoDeuda anHistoricoDeuda, NegocioDataContext aNegocioDataContext)
        {
            InitializeComponent();

            AGlobalNegocioDataContext = aNegocioDataContext;
            AAgrupacion = anHistoricoDeuda.Agrupacion;
            ATipoMonedaId = anHistoricoDeuda.TipoMonedaId;
            AGlobalHistorico =
                aNegocioDataContext.HistoricoDeuda.FirstOrDefault(
                    c => c.HistoricoDeudaID == anHistoricoDeuda.HistoricoDeudaID);

            tipoMonedaBindingSource.DataSource = AGlobalNegocioDataContext.TipoMoneda.Where(c => c.OrdenDeTrabajo);
            AAgrupacion = AGlobalNegocioDataContext.Agrupacion.FirstOrDefault(c => c.AgrupacionID == anHistoricoDeuda.AgrupacionId);
            TipoGestionDeuda_lookUpEdit.Properties.DataSource = Enumerados.ListaDeEnumerados(typeof(Enumerados.TipoGestionDeuda));
            
            var esUltimo = anHistoricoDeuda.UltimaInsertada;
            Importe_calcEdit.Enabled = TipoGestionDeuda_lookUpEdit.Enabled = Porciento_TextEdit.Enabled= esUltimo;
            Moneda_lookUpEdit.Enabled = false;

            Importe_calcEdit.EditValue = anHistoricoDeuda.importe;
            TipoGestionDeuda_lookUpEdit.EditValue = anHistoricoDeuda.TipoIncrementoDeuda;
            Descripcion_memoEdit.Text = anHistoricoDeuda.Descripcion;
            Fecha_dateEdit.DateTime = DateTime.Today;
            Moneda_lookUpEdit.EditValue = anHistoricoDeuda.TipoMonedaId;

            if (!esUltimo)
            {
                XtraMessageBox.Show("Solo se podrá editar completamente la última acción por cada grupo y por cada moneda", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TipoGestionDeuda_lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            Importe_calcEdit.Enabled = Descripcion_memoEdit.Enabled = true;
            Enumerados.TipoGestionDeuda seleccion = (Enumerados.TipoGestionDeuda)Enum.Parse(typeof(Enumerados.TipoGestionDeuda),
                Convert.ToString(TipoGestionDeuda_lookUpEdit.EditValue));
            switch (seleccion)
            {
                case Enumerados.TipoGestionDeuda.NuevaDeuda:
                    Porciento_layoutControlItem.Enabled = false;
                    break;
                case Enumerados.TipoGestionDeuda.InicializarDeuda:
                    Porciento_layoutControlItem.Enabled = false;
                    break;
                case Enumerados.TipoGestionDeuda.RebajarDeuda:
                    Porciento_layoutControlItem.Enabled = true;

                    if (Deuda <= 0)
                    {
                        XtraMessageBox.Show("Esta Agrupación no tiene deuda alguna en el sistema", "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        TipoGestionDeuda_lookUpEdit.Reset();
                        
                    }
                    
                    break;
                

            }
        }

        private void Aceptar_simpleButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            Enumerados.TipoGestionDeuda seleccion = (Enumerados.TipoGestionDeuda)Enum.Parse(typeof(Enumerados.TipoGestionDeuda),
               Convert.ToString(TipoGestionDeuda_lookUpEdit.EditValue));
            AGlobalHistorico.AgrupacionId = AAgrupacion.AgrupacionID;
            AGlobalHistorico.EsInicializacion = Convert.ToInt32(TipoGestionDeuda_lookUpEdit.EditValue) ==
                                                Enumerados.TipoGestionDeuda.InicializarDeuda.ToEntero();
            AGlobalHistorico.TipoIncrementoDeuda = seleccion.ToEntero();
            AGlobalHistorico.TipoMonedaId = ATipoMonedaId;
            AGlobalHistorico.Fecha = DateTime.Now;
            var importe = Convert.ToDecimal(Importe_calcEdit.EditValue);
            AGlobalHistorico.importe = importe;
            AGlobalHistorico.Descripcion = Descripcion_memoEdit.Text;
            try
            {
                switch (seleccion)
                {
                    case Enumerados.TipoGestionDeuda.RebajarDeuda:
                        if (Deuda <= 0)
                        {
                            XtraMessageBox.Show("Esta Agrupación no tiene deuda alguna en el sistema", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            TipoGestionDeuda_lookUpEdit.EditValue = Enumerados.TipoGestionDeuda.NuevaDeuda.ToEntero();
                        }
                        else
                        {
                            if (importe > Deuda)
                            {
                                XtraMessageBox.Show("El importe no puede ser mayor que la deuda acumulada", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            if (AGlobalHistorico.HistoricoDeudaID == 0)
                                AGlobalNegocioDataContext.HistoricoDeuda.InsertOnSubmit(AGlobalHistorico);
                            AGlobalNegocioDataContext.SubmitChanges();
                        }
                        break;
                    default:
                        if (AGlobalHistorico.HistoricoDeudaID == 0)
                            AGlobalNegocioDataContext.HistoricoDeuda.InsertOnSubmit(AGlobalHistorico);
                        AGlobalNegocioDataContext.SubmitChanges();
                        break;
                }
              DialogResult=DialogResult.OK;
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Error en la Operación", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Moneda_lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ATipoMonedaId = Convert.ToInt32(Moneda_lookUpEdit.EditValue);
            Deuda = AAgrupacion.GetDeuda(ATipoMonedaId);
            if (Deuda > 0)
            {
                Deuda_labelControl.ForeColor = Color.Brown;
                Deuda_labelControl.BackColor = Color.LightCoral;
                Deuda_labelControl.Text = Deuda.ToString();
            }
            else
            {
                var listaSinRebajarDeuda = Enumerados.ListaDeEnumerados(typeof (Enumerados.TipoGestionDeuda));
                var itemDeRebaja = listaSinRebajarDeuda.FirstOrDefault(c=>c.Valor==Enumerados.TipoGestionDeuda.RebajarDeuda.ToEntero().ToString());
                listaSinRebajarDeuda.Remove(itemDeRebaja);
                TipoGestionDeuda_lookUpEdit.Properties.DataSource = listaSinRebajarDeuda;
            }
            TipoGestionDeuda_lookUpEdit.Enabled = true;

        }

        //private void ManejaHabilitacionDeControles()
        //{
        //    Porciento_TextEdit.Enabled =TipoGestion == Enumerados.TipoGestionDeuda.RebajarDeuda
            
        //}

        private void Salir_simpleButton_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

       

        private void Importe_textEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(TipoGestionDeuda_lookUpEdit.EditValue) ==
                Enumerados.TipoGestionDeuda.RebajarDeuda.ToEntero())
            {
                if (Importe_calcEdit.Value > Deuda) e.Handled = false;
            }
        }

        private void Porciento_TextEdit_TextChanged(object sender, EventArgs e)
        {
            if (Deuda > 0)
            {
                var porciento = Convert.ToInt32(Porciento_TextEdit.EditValue);
                decimal importe = Decimal.Round(Deuda * porciento / 100, 2);
                Importe_calcEdit.Text = importe.ToString();
            }

        }
    }
}