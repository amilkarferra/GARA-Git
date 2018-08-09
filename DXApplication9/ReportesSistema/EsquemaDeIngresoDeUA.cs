using System;
using DXApplication9.Code;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraEditors.DXErrorProvider;

namespace DXApplication9.ReportesSistema
{
    public partial class EsquemaDeIngresosDeUA : XtraForm
    {
        private readonly NegocioDataContext _dc = new NegocioDataContext();
        DateTime _desde = Utils.PrimerDiaAnnoEnCurso;
        DateTime _hasta = Utils.UltimoDiaAnnoEnCurso;
        int _monedaId = TipoMoneda.MonedaPrincipal.TipoMonedaID;
        int[] _agrupacionesIds;  
        public EsquemaDeIngresosDeUA()
        {
            InitializeComponent();
            agrupacionBindingSource.DataSource = _dc.Agrupacion.Where(c=>c.PerteneceACatalogo);
            tipoMonedaBindingSource.DataSource = _dc.TipoMoneda;
            _agrupacionesIds = _dc.Agrupacion.Where(c => c.PerteneceACatalogo).Select(a => a.AgrupacionID).ToArray();
            moneda_barEditItem.EditValue = TipoMoneda.MonedaPrincipal.TipoMonedaID;
            CheckedComboBoxEditCheckAll();//por defecto se seleccionan todos los grupos
            Hasta_repositoryItemDateEdit.MaxValue = Desde_repositoryItemDateEdit.MaxValue = Utils.UltimoDiaAnnoEnCurso;
            Desde_barEditItem.EditValue = _desde;
            Hasta_barEditItem.EditValue = _hasta;
            ActualizaDataSource(true);
        }

        private void ActualizaDataSource(bool isFirstLoad)
        {


            if (!isFirstLoad)
            {
                string mensajeError = "";
                _desde = Desde_barEditItem.EditValue == null ? _desde : Convert.ToDateTime(Desde_barEditItem.EditValue);
                if(Desde_barEditItem.EditValue==null)
                    mensajeError += "- La Fecha Inicial no se ha seleccionado,<br> Se utilizará el primer día del año en curso.<br>";


                _hasta = Hasta_barEditItem.EditValue == null ? _hasta : Convert.ToDateTime(Hasta_barEditItem.EditValue);
                if (Hasta_barEditItem.EditValue == null)
                    mensajeError += "- La Fecha Final no se ha seleccionado,<br> Se utilizará el último día del año en curso.<br>";

                if (_desde > _hasta)
                {
                    mensajeError += "- La Fecha Inicial no puede ser posterior a la Fecha Final,<br> Se utilizará como fecha final el último día del año en curso.<br>";
                    _hasta = Utils.UltimoDiaAnnoEnCurso;
                }


                _agrupacionesIds = Agrupaciones_barEditItem.EditValue != null ? Agrupaciones_barEditItem.EditValue.ToString().Split(',').Select(c => Convert.ToInt32(c)).ToArray()
                   : _dc.Agrupacion.Where(c => c.PerteneceACatalogo).Select(a => a.AgrupacionID).ToArray();
                if (Agrupaciones_barEditItem.EditValue == null)
                {
                    mensajeError += "- No se han seleccionado Unidades Artísticas, se mostrarán los datos de todas las que pertenecen al catálog.<br>";
                }

                _monedaId = moneda_barEditItem.EditValue == null ? TipoMoneda.MonedaPrincipal.TipoMonedaID: Convert.ToInt32(moneda_barEditItem.EditValue);
                if (moneda_barEditItem.EditValue == null)
                {
                    mensajeError += "- No se ha seleccionado la moneda a filtrar, se mostrarán los datos de la moneda "+TipoMoneda.MonedaPrincipal.Abreviatura +".<br>";
                    moneda_barEditItem.EditValue = TipoMoneda.MonedaPrincipal.TipoMonedaID;
                }


                if (!string.IsNullOrEmpty(mensajeError))
                    Utils.MuestraError(mensajeError);
            }
            ActualizaTitulo();
            importeDeAgrupacionBindingSource.DataSource = _dc.OrdenDeTrabajo.Where(c => _agrupacionesIds.Contains(c.AgrupacionId) && c.Nomina.FechaEmision > _desde && c.Nomina.FechaEmision < _hasta && c.TipoMonedaId == _monedaId).GroupBy(c => c.AgrupacionId).
                   Select(c => new ImporteDeAgrupacion
                   {
                       Agrupacion = c.First().Agrupacion,
                       IngresoAcumulado = (decimal)c.Sum(a => a.ImporteFinal),
                       Moneda = c.First().TipoMoneda.Abreviatura
                   });
        }

        private void ActualizaTitulo()
        {
            chartControl1.Titles[0].Text = string.Format("Ingresos desde {0} Hasta {1} <br> Moneda {2}",_desde.ToShortDateString(),_hasta.ToShortDateString(),TipoMoneda.GetMonedaById(_monedaId).Abreviatura);
        }

        private void Filtrar_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActualizaDataSource(false);
        }

        public void CheckedComboBoxEditCheckAll()
        {
            Agrupaciones_barEditItem.EditValue =
                String.Join(Agrupaciones_repositoryItemCheckedComboBoxEdit.SeparatorChar.ToString(), _agrupacionesIds);
        }

        private void Agrupaciones_repositoryItemCheckedComboBoxEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null) 
            if (e.Button.Tag.ToString().ToUpper() == "SHOWALL")
            {
                agrupacionBindingSource.DataSource = _dc.Agrupacion;
                Utils.MuestraInformacion("Listado de Unidades Artísticas Actualizado");
                e.Button.Visible = false;
                Agrupaciones_repositoryItemCheckedComboBoxEdit.Buttons[2].Visible = true;
                    Agrupaciones_repositoryItemCheckedComboBoxEdit.Buttons[1].Visible = false;

            }
           else  if (e.Button.Tag.ToString().ToUpper() == "SHOWCATALOG")
            {
                agrupacionBindingSource.DataSource = _dc.Agrupacion.Where(c=>c.PerteneceACatalogo);
                Utils.MuestraInformacion("Listado de Unidades Artísticas Actualizado");
                e.Button.Visible = false;
                Agrupaciones_repositoryItemCheckedComboBoxEdit.Buttons[1].Visible = true;
                Agrupaciones_repositoryItemCheckedComboBoxEdit.Buttons[2].Visible = false;
            }
        }


    }
}