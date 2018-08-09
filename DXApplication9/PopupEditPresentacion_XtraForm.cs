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
    public partial class PopupEditPresentacionXtraForm : DevExpress.XtraEditors.XtraForm
    {
        private Presentacion APresentacion;
        private NegocioDataContext AGlobalDatacontext ;
        private Proyectos AProyecto;
        public PopupEditPresentacionXtraForm(Presentacion apresentacion, NegocioDataContext dataContext )
        {   
            InitializeComponent();
            AGlobalDatacontext = dataContext ;
            APresentacion = AGlobalDatacontext.Presentacion.FirstOrDefault(c => c.PresentacionID == apresentacion.PresentacionID);
            AProyecto = AGlobalDatacontext.Proyectos.FirstOrDefault(c => c.ProyectoID == apresentacion.ProyectoId);
            Desde_dateEdit.Properties.MinValue = Hasta_dateEdit.Properties.MinValue = (DateTime)AProyecto.FechaInicial;
            Desde_dateEdit.Properties.MaxValue = Hasta_dateEdit.Properties.MaxValue = (DateTime)AProyecto.FechaFinal;
            Lugar_textEdit.EditValue = APresentacion.Lugar;
            Escenario_textEdit.EditValue = APresentacion.Escenario;
            Cachet_textEdit.EditValue = APresentacion.Cachet;
            Cantidad_textEdit.EditValue = APresentacion.Cantidad;
            Desde_dateEdit.EditValue = APresentacion.Desde;
            Hasta_dateEdit.EditValue = APresentacion.Hasta;

        }


        public PopupEditPresentacionXtraForm(Proyectos aProyecto, NegocioDataContext dataContext)
        {
            InitializeComponent();
            AGlobalDatacontext = dataContext ;
            AProyecto = AGlobalDatacontext.Proyectos.FirstOrDefault(c => c.ProyectoID == aProyecto.ProyectoID);
            APresentacion = new Presentacion();
            if (AProyecto != null)
            {
                if (AProyecto.FechaInicial != null)
                {
                    Desde_dateEdit.Properties.MinValue = (DateTime)AProyecto.FechaInicial;
                    Hasta_dateEdit.Properties.MinValue = (DateTime)AProyecto.FechaInicial;
                }
                if (AProyecto.FechaFinal != null)
                {
                    Desde_dateEdit.Properties.MaxValue = (DateTime)AProyecto.FechaFinal;
                    Hasta_dateEdit.Properties.MaxValue = (DateTime)AProyecto.FechaFinal;
                }
            }
        }

        private void Salvar_simpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dxValidationProvider1.Validate()) return;
                APresentacion.Lugar = Lugar_textEdit.EditValue.ToString();
                APresentacion.Escenario = Escenario_textEdit.EditValue.ToString();
                APresentacion.Cantidad = (int)Cantidad_textEdit.EditValue;
                APresentacion.Cachet = Convert.ToDecimal(Cachet_textEdit.EditValue);
                APresentacion.Desde = Desde_dateEdit.DateTime;
                APresentacion.Hasta = Hasta_dateEdit.DateTime;
                APresentacion.TipoMonedaId = AProyecto.TipoMonedaId;
                APresentacion.ProyectoId = AProyecto.ProyectoID;
                if(APresentacion.PresentacionID==0)
                    AGlobalDatacontext.Presentacion.InsertOnSubmit(APresentacion);
                AGlobalDatacontext.SubmitChanges();
                DialogResult=DialogResult.OK;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void Salir_simpleButton_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Abort;
        }


    }
}