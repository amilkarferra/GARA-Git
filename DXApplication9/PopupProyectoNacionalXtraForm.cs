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
    public partial class PopupProyectoNacionalXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private NegocioDataContext AGlobalDataContext;
        public Proyectos GlobalProyecto;
        public PopupProyectoNacionalXtraForm(Proyectos aProyecto = null, NegocioDataContext aDataContext = null)
        {
            AGlobalDataContext = aDataContext ?? new NegocioDataContext();
            InitializeComponent();
            tipoMonedaBindingSource.DataSource = AGlobalDataContext.TipoMoneda;
            controlClientesBindingSource.DataSource =
                AGlobalDataContext.ControlClientes.Where(
                    c =>
                        c.PaisId == Paises.PaisIdDeCuba &&
                        c.EstadoId != Convert.ToInt32(Enumerados.EstadoContrato.Cancelado));
            if (aProyecto != null)
            {
                GlobalProyecto =
                    AGlobalDataContext.Proyectos.FirstOrDefault(c => c.ProyectoID == aProyecto.ProyectoID);
                if (GlobalProyecto == null) return;
                NumeroProyecto_label.Text = aProyecto.Consecutivo.ToString();
                Nombre_textEdit.Text = aProyecto.NombreProyecto;
                FechaConfeccion_dateEdit.EditValue = aProyecto.FechaConfeccion;
                Desde_dateEdit.EditValue = aProyecto.FechaInicial;
                Hasta_dateEdit.EditValue = aProyecto.FechaFinal;
                Moneda_lookUpEdit.EditValue = aProyecto.TipoMonedaId;
                Contratos_SearchLookUpEdit.EditValue = aProyecto.ControlClienteId;
            }
            else
            {
                //NumeroProyecto_label.Text = Proyectos.GetConsecutivo().ToString();
                NumeroProyecto_label.Text = string.Format("{0}/{1}", Proyectos.GetConsecutivo(), ConfiguracionGeneral.Anno);
                NumeroProyecto_label.ForeColor = Color.OrangeRed;
                FechaConfeccion_dateEdit.DateTime = DateTime.Now;
            }
        }

        private void OksimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dxValidationProvider1.Validate())
                {
                    GlobalProyecto = GlobalProyecto ?? (new Proyectos());
                    GlobalProyecto.FechaConfeccion = FechaConfeccion_dateEdit.DateTime;
                    GlobalProyecto.FechaFinal = Hasta_dateEdit.DateTime;
                    GlobalProyecto.FechaInicial = Desde_dateEdit.DateTime;
                    GlobalProyecto.NombreProyecto = Nombre_textEdit.Text.Trim();
                    GlobalProyecto.TipoMonedaId = Convert.ToInt32(Moneda_lookUpEdit.EditValue);
                    GlobalProyecto.AgrupacionId = Proyectos.InsertaAgrupacionProyecto();
                    GlobalProyecto.ControlClienteId = Convert.ToInt32(Contratos_SearchLookUpEdit.EditValue);
                    
                    if (GlobalProyecto.ProyectoID == Guid.Empty)
                    {
                        GlobalProyecto.ProyectoID = Guid.NewGuid();
                        GlobalProyecto.Consecutivo = Proyectos.GetConsecutivo();
                        GlobalProyecto.PaisId = Paises.PaisIdDeCuba;
                        AGlobalDataContext.Proyectos.InsertOnSubmit(GlobalProyecto);
                        GlobalProyecto.TipoProyecto = Enumerados.TipoProyecto.ProyectoNacional.StringValue();
                        GlobalProyecto.TipoProyectoId = Convert.ToInt32(Enumerados.TipoProyecto.ProyectoNacional);
                        GlobalProyecto.CausaDeProyecto = "Proyecto Nacional";
                        GlobalProyecto.Anno = GlobalProyecto.Anno != 0 ? GlobalProyecto.Anno : ConfiguracionGeneral.Anno;
                        GlobalProyecto.EstadoProyecto = Enumerados.EstadoProyecto.EnEjecucion.Value();
                    }
                    AGlobalDataContext.SubmitChanges();
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Error en la operacion",
                       "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void Salir_simpleButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}