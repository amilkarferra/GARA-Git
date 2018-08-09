using System.Drawing;
using System.IO;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace DXApplication9.ReportesSistema
{
    public partial class M2XtraReport : DevExpress.XtraReports.UI.XtraReport
    {
        //NegocioDataContext _negocioDataContext = new NegocioDataContext();
        public M2XtraReport(OrdenDeTrabajo anOrdenDeTrabajo)
        {
            InitializeComponent();
            OrdenDeTrabajo_linqServerModeSource.QueryableSource = new NegocioDataContext().OrdenDeTrabajo.Where(c=>c.OrdenDeTrabajoID==anOrdenDeTrabajo.OrdenDeTrabajoID);
            linqServerModeSource1.QueryableSource = OrdenDeTrabajo.GetAgrupacionDeArtistasParticipantes(anOrdenDeTrabajo.OrdenDeTrabajoID).OrderBy(c => c.Artista.NomencladorCargo.PesoDeCargo).ThenBy(c => c.Artista.Nombre);
            ConfiguracionGeneral configuracion = (new NegocioDataContext()).ConfiguracionGeneral.FirstOrDefault();
            if (configuracion.LogoAgencia != null)
            {
                MemoryStream ms = new MemoryStream(configuracion.LogoAgencia);
                Bitmap imagenBitmap = new Bitmap(ms);
                xrPictureBox1.Image = imagenBitmap;
            }

            NombreAgencia1_xrTableCell.Text = configuracion.Agencia.Trim();
            GerenteRechumxrTableCell.Text = configuracion.EncargadoRecrusosHumanos.Trim();
            if (anOrdenDeTrabajo.TipoMonedaId == (int)Enumerados.Moneda.Cup)
            {
                MonedaCUC_xrTableCell.Text = "";
                MonedaCUP_xrTableCell.Text = "X";
                NumeroContrato_xrTableCell.Text = configuracion.NumeroCuentaEmpresaMN;
            }
            else
            {
                MonedaCUC_xrTableCell.Text = "X";
                MonedaCUP_xrTableCell.Text = "";
                NumeroContrato_xrTableCell.Text = configuracion.NumeroCuentaEmpresaDiv;
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
                aTable.Rows.Add(new XRTableRow());
            }
            
        }

    }
        }

    
    



