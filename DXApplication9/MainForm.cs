using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Application;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DXApplication9.Code;
using DXApplication9.ReportesSistema;
using DXApplication9.UserControls;

namespace DXApplication9
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly NegocioDataContext AGlobalDataContext = new NegocioDataContext();
        public MainForm()
        {
            InitializeComponent();
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem2, true);
            VerificaSiHayAdministrador();
            AperturaDeSesion();
            VerificaCorrectaConfiguracion();
            VerificaNomencladoresPrincipales();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                this.Text += string.Format("- v{0}", ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));
            }
            var lista = Enumerados.ListaDeEnumerados(typeof(Enumerados.EstadoOrdenDeTrabajo));
            var b = lista;
            //Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //Text += " " + String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor,
            //    version.Revision, version.Build);
            //CorreScriptiInicializarMonedasDeProyectos();
            //CorresScriptCompletaCargoArtistas();
            //CorreScriptPasarCargos();
            //CorrerScriptEliminaNominasRepetidas();
            //CorrerScriptEliminaEspaciosEnNombreDeIntegrantes();
            //CorrerScriptPonerOrden2016Pagadas();
            //CorrerScriptEliminaParticipantesDeActividadSinNomina();
            //CorrerScriptInsertaFechaDeAltasAlosVacios();
            Proyectos.InsertaAgrupacionProyecto();
        }
        private void VerificaNomencladoresPrincipales()
        {
            List<string> errores = new List<string>();
            if (!AGlobalDataContext.Municipio.Any())
                errores.Add("-No están definidos los municipios");
            if (!AGlobalDataContext.NomencladorCargo.Any())
                errores.Add("-Nomenclador de cargos vacio");
            if (!AGlobalDataContext.Agrupacion.Any())
                errores.Add("-No existe agrupación creada aún");
            if (!AGlobalDataContext.Paises.Any())
                errores.Add("-Nomenclador de Paises vacio");
            if (!AGlobalDataContext.Provincia.Any())
                errores.Add("-Nomenclador de Provincias vacio");
            if (!AGlobalDataContext.TipoMoneda.Any())
                errores.Add("-No existen Monedas definidas aún");
            if (!AGlobalDataContext.ResponsabilidadEmpresario.Any())
                errores.Add("-No existen Responsabilidades de empresarios definidos aún");
            if (!AGlobalDataContext.ControlClientes.Any())
                errores.Add("-No existen contrato insertado en el sistema aún");
            RichTextBox text = new RichTextBox
            {
                Height = 56,
                Lines = errores.ToArray(),
                Dock = DockStyle.Fill
            };
            if (errores.Any())
                XtraDialog.Show(text, "Nomencladores sin definir", MessageBoxButtons.OK);

        }

        private void VerificaInicializacionDeSistema()
        {
            VerificaSiHayAdministrador();
            VerificaCorrectaConfiguracion();
        }

        private void VerificaCorrectaConfiguracion()
        {
            if (!AGlobalDataContext.ConfiguracionGeneral.Any())
            {
                if (LoginHelper.UsuarioRegistrado.EsAdministrador())
                {
                    PopupConfiguracionGeneralXtraForm configuracion = new PopupConfiguracionGeneralXtraForm();
                    if (configuracion.ShowDialog() != DialogResult.OK)
                    {
                        XtraMessageBox.Show(
                            "Para un correcto funcionamiento del sistema se debe proceder a su configuración, por favor contacte con el administrador si nota algún problema",
                            "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Para un correcto funcionamiento del sistema se debe proceder a su configuración, por favor contacte con el administrador si nota algún problema",
                     "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }

        }

        private void VerificaSiHayAdministrador()
        {
            var aDc = new NegocioDataContext();
            if (aDc.Usuario.Any(c => c.RoleId == (int)Enumerados.Roles.Administrador)) return;

            aDc.Usuario.InsertOnSubmit(new Usuario
            {
                Cargo = "Administrador",
                NombreCompleto = "Administrador",
                NombreUsuario = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("Admin123", BCrypt.Net.BCrypt.GenerateSalt()),
                RoleId = (int)Enumerados.Roles.Administrador
            });
            aDc.SubmitChanges();
        }
        /// <summary>
        /// pone el cargo que tiene el Artista En AgrupacionArtista  en la Tabla Artista
        /// </summary>
        private void CorresScriptCompletaCargoArtistas()
        {
            var globalDataContext = new NegocioDataContext();
            var artistas = globalDataContext.Artista;
            var grupos = globalDataContext.Agrupacion;
            foreach (var agrupacion in grupos)
            {
                foreach (var artista in artistas)
                {
                    var agrupacionDeArtista =
                        globalDataContext.AgrupacionDeArtista.FirstOrDefault(
                            c => c.ArtistaId == artista.ArtistaID && c.AgrupacionId == agrupacion.AgrupacionID);
                    if (agrupacionDeArtista != null)
                    {
                        if (!string.IsNullOrEmpty(agrupacionDeArtista.AbrevDesempenno))
                        {
                            artista.AbrevDesempenno = agrupacionDeArtista.AbrevDesempenno;
                            artista.NomencladorCargoId = agrupacionDeArtista.NomencladorCargoId; globalDataContext.SubmitChanges();
                        }
                    }
                }
            }

        }

        private void CorreScriptiInicializarMonedasDeProyectos()
        {
            var dc = new NegocioDataContext();
            var proyectos = dc.Proyectos;
            foreach (var proyectose in proyectos)
            {
                if (proyectose.Presentacion.Any())
                {
                    var firstOrDefault = proyectose.Presentacion.FirstOrDefault();
                    if (firstOrDefault != null)
                        proyectose.TipoMonedaId = firstOrDefault.TipoMonedaId;
                    dc.SubmitChanges();
                }
            }
        }

        //private void CorrerScriptEliminaEspaciosEnNombreDeIntegrantes()
        //{
        //     var dc = new NegocioDataContext();
        //    var artistas = dc.Artista;
        //    foreach (var artista in artistas)
        //    {
        //        artista.Nombre = artista.Nombre.Trim();
        //        artista.PrimerApellido = artista.PrimerApellido.Trim();
        //        artista.SegundoApellido = artista.SegundoApellido.Trim();
        //        dc.SubmitChanges(ConflictMode.ContinueOnConflict);
        //    }

        //}

        private void CorrerScriptInsertaFechaDeAltasAlosVacios()
        {
            var dc = new NegocioDataContext();
            var actualizar = dc.AgrupacionDeArtista.Where(c => c.FechaAlta == null);
            foreach (var agrupacionDeArtista in actualizar)
            {
                agrupacionDeArtista.FechaAlta = agrupacionDeArtista.Artista.FechaDeAlta ?? Convert.ToDateTime("1/1/2000");
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Elimina los participantes de actividad que de actividades sin nominas asociadas, en un prinicipio
        /// se insertaban los participantes de actividad al crear la actividad pero llenaba mucho la base de datos
        /// y muchas actividades no llevaban nominas por lo que se insertaban por gusto, luego se insertaron al crear
        /// la nomina.
        /// </summary>
        private void CorrerScriptEliminaParticipantesDeActividadSinNomina()
        {
            var dc = new NegocioDataContext();
            var ordenesId = dc.Nomina.Select(c => c.DocumentoReferenciaId);
            var ordenesSinNomina = dc.OrdenDeTrabajo.Where(c => !ordenesId.Contains(c.OrdenDeTrabajoID));
            foreach (var ordenDeTrabajo in ordenesSinNomina)
            {
                if (!ordenDeTrabajo.TieneNominaAsociada)
                {
                    dc.ParticipantesDeAcividad.DeleteAllOnSubmit(ordenDeTrabajo.ParticipantesDeAcividad);

                }

            }
            dc.SubmitChanges();
        }

        //private void CorrerScriptPonerOrden2016Pagadas()
        //{
        //    using (NegocioDataContext dataContext = new NegocioDataContext())
        //    {
        //        var ordenesViejas = dataContext.OrdenDeTrabajo.Where(c => c.Anno == 2016 && (c.Estado==(int)Enumerados.EstadoOrdenDeTrabajo.Realizada|| c.Estado==(int)Enumerados.EstadoOrdenDeTrabajo.Cerrada));
        //        foreach (var ordenDeTrabajo in ordenesViejas)
        //            ordenDeTrabajo.Estado = (int) Enumerados.EstadoOrdenDeTrabajo.Pagada;
        //        dataContext.SubmitChanges();
        //    }
        //}

        private void CorrerScriptEliminaNominasRepetidas()
        {
            using (NegocioDataContext globalDataContext = new NegocioDataContext())
            {
                var consecutivos = globalDataContext.Nomina.DistinctBy(c => c.Consecutivo).Select(c => c.Consecutivo);
                List<int> consecutivosRepetidos = new List<int>();
                foreach (var consecutivo in consecutivos)
                {
                    //var consecutivos1 = _GlobalDataContext.Nomina.Count(c=>c.Consecutivo == consecutivo)
                    if (globalDataContext.Nomina.Count(c => c.Consecutivo == consecutivo) > 1)
                    {
                        var cantidad =
                            globalDataContext.Nomina.Where(c => c.Consecutivo == consecutivo)
                                .DistinctBy(c => c.Anno)
                                .Count();
                        if (cantidad < 2)
                            consecutivosRepetidos.Add(consecutivo);
                    }
                }
                //var nominasToFix =_GlobalDataContext.Nomina.Where(c => consecutivosRepetidos.Contains(c.Consecutivo));
                foreach (var consecutivoRepetido in consecutivosRepetidos)
                {
                    var vecesRepetidas = globalDataContext.Nomina.Count(c => c.Consecutivo == consecutivoRepetido);
                    for (int i = 0; i < vecesRepetidas - 1; i++)
                    {
                        globalDataContext.Nomina.DeleteOnSubmit(
                            globalDataContext.Nomina.FirstOrDefault(c => c.Consecutivo == consecutivoRepetido));
                        globalDataContext.SubmitChanges();
                    }

                }
            }
        }

        /// <summary>
        /// Para pasar los cargos que tienen los artistas a la tabla agrupacion de artistas debe hacerse solamente una vez
        /// </summary>
        //private void CorreScriptPasarCargos()
        //{
        //    XtraMessageBox.Show(
        //        "ahora correra un script para darle mantenimiento al sistema, si este mensaje lo ve 2 veces por favor avisele al administrador de sistemas");
        //    using (NegocioDataContext dataContext = new NegocioDataContext())
        //    {
        //        var agrupacionesDeArtistas = dataContext.AgrupacionDeArtista;
        //        foreach (var agrupacionesDeArtista in agrupacionesDeArtistas)
        //        {
        //            agrupacionesDeArtista.NomencladorCargoId = agrupacionesDeArtista.Artista.NomencladorCargoId ?? 1;
        //            agrupacionesDeArtista.AbrevDesempenno = agrupacionesDeArtista.Artista.AbrevDesempenno;
        //        }
        //        dataContext.SubmitChanges();
        //    }
        //}

        private void AperturaDeSesion()
        {
            #region Registro de Usuario
            LoginXtraForm form = new LoginXtraForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            //  if(Dns.g)
            if (form.ShowDialog() != DialogResult.OK)
            {
                Environment.Exit(1);
            }

            // splashScreenManager1.ShowWaitForm();
            //var mLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //var Version = System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileVersion;
            // MessageBox.Show(Version);
            Usuario anUsuariouser = LoginHelper.UsuarioRegistrado;
            Comercial_ribbonPage.Visible = anUsuariouser.RoleId == (int)Enumerados.Roles.Comercial || anUsuariouser.RoleId == (int)Enumerados.Roles.Administrador || anUsuariouser.RoleId == (int)Enumerados.Roles.SuperAdministrador;
            Economia_ribbonPage.Visible = anUsuariouser.RoleId == (int)Enumerados.Roles.Economico || anUsuariouser.RoleId == (int)Enumerados.Roles.Administrador || anUsuariouser.RoleId == (int)Enumerados.Roles.SuperAdministrador;
            Administracion_ribbonPage.Visible = anUsuariouser.RoleId == (int)Enumerados.Roles.Administrador || anUsuariouser.RoleId == (int)Enumerados.Roles.SuperAdministrador;
            Juridico_ribbonPage.Visible = anUsuariouser.RoleId == (int)Enumerados.Roles.Juridico || anUsuariouser.RoleId == (int)Enumerados.Roles.Administrador || anUsuariouser.RoleId == (int)Enumerados.Roles.SuperAdministrador;
            RecursosHumanos_ribbonPage.Visible = anUsuariouser.RoleId == (int)Enumerados.Roles.RecursosHumanos || anUsuariouser.RoleId == (int)Enumerados.Roles.Administrador || anUsuariouser.RoleId == (int)Enumerados.Roles.SuperAdministrador;

            //Administracion_ribbonPage.Visible = true;

            #endregion
        }

        private void ListaDeIntegrantesbarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = FindControl("ArtistasForm") as XtraForm;
            if (form != null) form.Activate();
            else
            {


                ArtistasForm integrantesForm = new ArtistasForm { MdiParent = this };
                integrantesForm.Show();
                //Dispose();
            }
        }
        private void AgrupacionbarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {

            var xtraForm = FindControl("AgrupacionesForm") as XtraForm;
            if (xtraForm != null) xtraForm.Activate();
            else
            {


                AgrupacionesForm form = new AgrupacionesForm { MdiParent = this };
                form.Show();
            }


        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var xtraForm = FindControl("ProyectoListForm") as XtraForm;
            if (xtraForm != null) xtraForm.Activate();
            else
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
                ProyectoListForm form = new ProyectoListForm { MdiParent = this };
                form.Show();
            }
            Reportes_ribbonPageGroup.Enabled = true;
        }

        private void OT_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var _Form = FindControl("OrdenDeTrabajoXtraForm") as OrdenDeTrabajoXtraForm;
            //if (_Form != null)
            //{
            //     if (_Form.TipoActividad == Enumerados.TipoActividad.OrdenDeTrabajo) _Form.Activate();
            //    return;
            //}

            //if (MainSplashScreenManager.IsSplashFormVisible) MainSplashScreenManager.CloseWaitForm();
            //MainSplashScreenManager.ShowWaitForm();
            OrdenDeTrabajoXtraForm ordenDeTrabajoXtraForm = new OrdenDeTrabajoXtraForm(Enumerados.TipoActividad.OrdenDeTrabajo) { MdiParent = this };
            ordenDeTrabajoXtraForm.Show();
        }

        private void ListaPaises_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var xtraForm = FindControl("PaisForm") as PaisForm;
            if (xtraForm != null) xtraForm.Activate();
            else
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
                PaisForm form = new PaisForm { MdiParent = this };
                form.Show();
            }
        }

        /// <summary>
        /// enable or disable ListaDeIntegrantesbarButtonItem
        /// </summary>
        /// <param name="aState">true if enable, false if disable</param>
        public void EnableListaIntegrantesButton(bool aState)
        {
            ListaDeIntegrantesbarButtonItem.Enabled = aState;
        }


        /// <summary>
        /// enable or disable ListaDeIntegrantesbarButtonItem
        /// </summary>
        /// <param name="aState">true if enable, false if disable</param>
        public void EnableListaAgrupacionesButton(bool aState)
        {
            AgrupacionbarButtonItem.Enabled = aState;
        }

        private void ProyectosBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            // var _IntegranteForm = (IntegrantesForm)ActiveMdiChild;
            //   _IntegranteForm.splitContainerControl2.PanelVisibility = SplitPanelVisibility.Both;
        }

        private Control FindControl(string strControlName)
        {
            if (strControlName.Length == 0 || Controls.Find(strControlName, true).Length == 0)
                return null;

            return Controls.Find(strControlName, true)[0];
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ConfigForm configProyFundForm = new ConfigForm { MdiParent = this };
            //configProyFundForm.Show();
        }

        private void Empresarios_barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            EmpresariosForm empresariosForm = new EmpresariosForm { MdiParent = this };
            empresariosForm.Show();
        }



        private void Responsabilidad_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ResponsabilidadEmpresarioForm form = new ResponsabilidadEmpresarioForm { MdiParent = this };
            form.Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            var formularioDeProyectos = (ProyectoListForm)ActiveMdiChild;
            if (formularioDeProyectos != null) formularioDeProyectos.MuestraReporteDeProyecto();
            else
            {
                MessageBox.Show("Seleccione un proyecto en la Ventana de Proyectos");
            }
        }

        private void ProyectoInsituto_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(MdiParent, typeof(ReportesWaitForm), true, true);
            }
            catch (Exception)
            {

                SplashScreenManager.CloseForm();
                SplashScreenManager.ShowForm(MdiParent, typeof(ReportesWaitForm), true, true);

            }
            var formularioDeProyectos = (ProyectoListForm)ActiveMdiChild;
            Proyectos proyecto = formularioDeProyectos.GetSelectedProyecto();
            if (formularioDeProyectos != null)
            {

                if (proyecto.EsTramiteMigratorio)
                {
                    MessageBox.Show("No Aplicable", "No Aplicable", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                proyecto.MostrarReporteProyectoInstituto();
            }
            else
            {
                MessageBox.Show("Seleccione un proyecto en la Ventana de Proyectos");
            }
        }

        private void ProyectoFundamentacion_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var formularioDeProyectos = (ProyectoListForm)ActiveMdiChild;
                if (formularioDeProyectos != null)
                {
                    formularioDeProyectos.GetSelectedProyecto().MostrarReporteFundamentacion();



                }
                else
                {
                    MessageBox.Show("Seleccione un proyecto en la Ventana de Proyectos");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se puede realizar la accion");
            }
        }

        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var formularioDeProyectos = (ProyectoListForm)ActiveMdiChild;
            if (formularioDeProyectos != null)
            {

                if (formularioDeProyectos.GetSelectedProyecto().TipoProyecto == Enumerados.TipoProyecto.TramiteMigratorio.ToString())
                {
                    MessageBox.Show("No Aplicable", "No Aplicable", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                formularioDeProyectos.GetSelectedProyecto().MostrarReporteProyectoEconomico();
            }
            else
            {
                MessageBox.Show("Seleccione un proyecto en la Ventana de Proyectos");
            }
        }

        private void PlanSalida_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetProyectoSeleccionado().MuestraPlanillaSalida();
        }

        private Proyectos GetProyectoSeleccionado()
        {
            var formularioDeProyectos = (ProyectoListForm)ActiveMdiChild;
            if (formularioDeProyectos != null) return formularioDeProyectos.GetSelectedProyecto();
            MessageBox.Show("Seleccione un proyecto en la Ventana de Proyectos");
            return null;
        }


        public void CerrandoListaDeProyectos()
        {
            Reportes_ribbonPageGroup.Enabled = false;
            ListaProyectosbarButtonItem.Enabled = true;
        }

        public void MuestraProyectos()
        {
            var form = FindControl("ProyectoListForm") as XtraForm;
            if (form != null) form.Activate();
            else
            {

                ProyectoListForm proyectoListForm = new ProyectoListForm { MdiParent = this };
                proyectoListForm.Show();
                Reportes_ribbonPageGroup.Enabled = true;
                //ribbonControl.SelectedPage = Hhhhhh;
            }

        }

        private void RegistroClientes_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var xtraForm = FindControl("RegistroClientes_XtraForm") as RegistroClientesXtraForm;
            Muestraformulario(xtraForm, Enumerados.TipoFormulario.RegistroClientes);
        }
        private void Monedas_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var xtraForm = FindControl("MonedaXtraForm") as MonedaXtraForm;
            Muestraformulario(xtraForm, Enumerados.TipoFormulario.Moneda);
        }
        public void EnableButton(string registroclientesBarbuttonitem, bool b)
        {
            switch (registroclientesBarbuttonitem)
            {
                case "RegistroClientes_barButtonItem":
                    RegistroClientes_barButtonItem.Enabled = b;
                    break;
                case "OT_barButtonItem":
                    OT_barButtonItem.Enabled = b;
                    break;
            }
        }

        private void VistaPrevia_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChildForm = ActiveMdiChild; if (activeMdiChildForm != null)
            {
                var grid = Utils.GetAllControlsRecusrvive<GridControl>(activeMdiChildForm)[0];
                grid.ShowRibbonPrintPreview();
                //foreach (GridControl _GridControl in Grids) {
                //    if (_GridControl.IsFocused)
                //    {
                //      _GridControl.ShowRibbonPrintPreview();
                //    }
            }
        }



        //if (_ActiveMdiChildForm != null && _ActiveMdiChildForm.Name == "IntegrantesForm")
        //{
        //    var _IntegrantesForm = _ActiveMdiChildForm as IntegrantesForm;
        //    if (_IntegrantesForm != null) _IntegrantesForm.Integrantes_gridControl.ShowRibbonPrintPreview();
        //}


        private void MainForm_MdiChildActivate(object sender, EventArgs e)
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

        private void ProcesaNominaOrdenTrabajo_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm form = new IngresosXtraForm(Enumerados.TipoActividad.OrdenDeTrabajo) { MdiParent = this };
            form.Show();
        }



        private void Muestraformulario(XtraForm aXtraForm, Enumerados.TipoFormulario aTipoDeFormulario)
        {

            if (aXtraForm != null) aXtraForm.Activate();

            else
            {


                switch (aTipoDeFormulario)
                {
                    case Enumerados.TipoFormulario.Moneda:
                        MonedaXtraForm form = new MonedaXtraForm { MdiParent = this };
                        form.Show();
                        break;
                    case Enumerados.TipoFormulario.RegistroClientes:
                        RegistroClientesXtraForm registroXtraForm = new RegistroClientesXtraForm { MdiParent = this };
                        registroXtraForm.Show();
                        break;
                    //case Enumerados.TipoFormulario.NomencladorEstadosContratos:
                    //    EstadoDeContratosXtraForm estadoDeContratosXtraForm = new EstadoDeContratosXtraForm { MdiParent = this };
                    //    estadoDeContratosXtraForm.Show();break;

                    default:
                        break;
                }
                //TODO ver como pasar parametro por clase para que construya cualquier tipo de XTraformsplashScreenManager1.ShowWaitForm();

            }
        }

        private void ListadoNominas_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm form = new ListadoNominasXtraForm { MdiParent = this };
            form.Show();
        }

        private void Usuarios_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraForm form = new UsuariosXtraForm { MdiParent = this };
            form.Show();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            var xtraForm = FindControl("RegistroClientes_XtraForm") as RegistroClientesXtraForm;
            Muestraformulario(xtraForm, Enumerados.TipoFormulario.RegistroClientes);
        }

        private void FactExporFront_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var _Form = FindControl("OrdenDeTrabajoXtraForm") as OrdenDeTrabajoXtraForm;
            //if (_Form.TipoActividad == Enumerados.TipoActividad.Factura) _Form.Activate();
            //else
            //{

            OrdenDeTrabajoXtraForm ordenDeTrabajoXtraForm = new OrdenDeTrabajoXtraForm(Enumerados.TipoActividad.Factura) { MdiParent = this };
            ordenDeTrabajoXtraForm.Show();

            //}
        }

        private void NomencladorDeCargos_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CargosXtraForm cargosXtraForm = new CargosXtraForm { MdiParent = this };
            cargosXtraForm.Show();
        }

        private void LogOut_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var formualriosAbiertos = MdiChildren;
            foreach (var formulario in formualriosAbiertos)
            {
                formulario.Dispose();
            }
            AperturaDeSesion();
        }

        private void ListadoIntegranteReporteGeneral_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            GeneralReportIntegrantesPorUA reporte = new GeneralReportIntegrantesPorUA();
            reporte.CreateDocument();
            reporte.ShowRibbonPreview();
        }

        private void RegExportacionesReport_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportacionesXtraReport reporte = new ExportacionesXtraReport();
            reporte.CreateDocument();
            reporte.ShowPreviewDialog();
        }

        private void catalogo_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            CatalogoXtraReport reporte = new CatalogoXtraReport();
            reporte.CreateDocument();
            reporte.ShowPreviewDialog();
        }

        private void ReporteEscalaValores_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopupEscalaIngresosPersonalesXtraForm popup = new PopupEscalaIngresosPersonalesXtraForm();
            popup.Show(this);
        }

        private void Config_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopupConfiguracionGeneralXtraForm form = new PopupConfiguracionGeneralXtraForm();
            form.Show();
        }

        private void PersonasQueFirman_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
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
            var form = FindControl("CargosDeFirmantesXtraForm") as CargosDeFirmantesXtraForm;
            if (form != null) form.Activate();
            else
            {
                CargosDeFirmantesXtraForm formulario = new CargosDeFirmantesXtraForm { MdiParent = this };
                formulario.Show();
            }
        }

        private void ConfigFirmasReportes_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
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
            var form = FindControl("ConfigFirmasReportesXtraForm") as CargosDeFirmantesXtraForm;
            if (form != null) form.Activate();
            else
            {
                ConfigFirmasReportesXtraForm formulario = new ConfigFirmasReportesXtraForm { MdiParent = this };
                formulario.Show();
            }
        }


        public string GetCpuid()
        {
            string cpuId = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuId == "")
                {
                    //Remark gets only the first CPU ID
                    cpuId = mo.Properties["processorID"].Value.ToString();

                }
            }
            //XtraMessageBox.Show(cpuID,"Informacion",MessageBoxButtons.OK);
            return cpuId;
        }

        private void RolesPie_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                RolesPorReporteUserControl configuracion = new RolesPorReporteUserControl();
                if (XtraDialog.Show(configuracion, "Configurando Permisos de Edición", MessageBoxButtons.OKCancel) ==
                    DialogResult.OK)
                {

                    var registros = AGlobalDataContext.ConfigurarPiePorRole;
                    AGlobalDataContext.ConfigurarPiePorRole.DeleteAllOnSubmit(registros);
                    AGlobalDataContext.SubmitChanges();

                    var nodos = configuracion.treeList1.GetAllCheckedNodes();
                    foreach (var nodo in nodos)
                    {
                        if (!nodo.HasChildren)
                        {
                            var reporteId = Convert.ToInt32(nodo.GetValue("Id")) / 1000;
                            var roleId = Convert.ToInt32(nodo.GetValue("Id")) % 1000;
                            AGlobalDataContext.ConfigurarPiePorRole.InsertOnSubmit(new ConfigurarPiePorRole
                            {
                                ReporteID = reporteId,
                                RoleID = roleId
                            });
                            AGlobalDataContext.SubmitChanges();
                        }
                    }
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Error en la operacion",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void RepIngPorGrupo_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var popup = new PopupAgrupacionMonedaFechaXtraForm(true);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                var agrupaciones = popup.AgrupacionesIds;
                if (agrupaciones == null) return;
                XtraReport reporte = new XtraReport();
                reporte.CreateDocument();
                foreach (var agrupacionId in agrupaciones)
                {
                    OnatDeUnidadArtistica_XtraReport reporteActual = new OnatDeUnidadArtistica_XtraReport(agrupacionId, popup.FechaFinal, popup.FechaInicial, popup.TipoMonedaId);
                    reporteActual.CreateDocument();
                    reporte.Pages.AddRange(reporteActual.Pages);
                }
                reporte.ShowRibbonPreviewDialog();
            }
        }

        private void SolicitudDinero_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Popup = new PopupFechaMonedaXtraUserControl();
            if (XtraDialog.Show(Popup, "Seleccione Fecha y Moneda", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                while (!Popup.ValidateForm())
                {
                    XtraMessageBox.Show("Entrada de datos incorrecta, intente nuevamente", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Popup.Dispose();
                    Popup = new PopupFechaMonedaXtraUserControl();
                    XtraDialog.Show(Popup, "Seleccione Fecha y Moneda", MessageBoxButtons.OKCancel);
                }
                var reporte = new SolicitudDineroXtraReport(Popup.FechaInicial, Popup.FechaFinal, Popup.MonedaId);
                Popup.Dispose();
                reporte.CreateDocument();
                //  reporte.ShowPreviewDialog();
                reporte.ShowRibbonPreviewDialog();
            }
        }

        private void NomencladorEstado_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var xtraForm = FindControl("EstadoDeContratosXtraForm") as EstadoDeContratosXtraForm;
            //Muestraformulario(xtraForm, Enumerados.TipoFormulario.NomencladorEstadosContratos);
        }

        private void Deudas_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeudasHistoricoXtraForm deudasXtraForm = new DeudasHistoricoXtraForm() { MdiParent = this };
            deudasXtraForm.Show();
        }

        private void ReporteDeudas_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopupAgrupacionMonedaFechaXtraForm popup = new PopupAgrupacionMonedaFechaXtraForm();
            if (popup.ShowDialog() == DialogResult.OK)
            {
                var agrupacionesIds = popup.AgrupacionesIds;
                var fechaIncial = popup.FechaInicial;
                var fechaFinal = popup.FechaFinal;
                var TipoMonedaId = popup.TipoMonedaId;
                XtraReport reportePadre = new XtraReport();
                reportePadre.CreateDocument();
                foreach (var agrupacionId in agrupacionesIds)
                {
                    var historicos = AGlobalDataContext.HistoricoDeuda.Where(c => c.AgrupacionId == agrupacionId && c.TipoMonedaId == TipoMonedaId && c.Fecha >= fechaIncial && c.Fecha <= fechaFinal);
                    if (historicos.Any())
                    {

                        DeudaHistoricoXtraReport reporte =
                            new DeudaHistoricoXtraReport(agrupacionId, TipoMonedaId, fechaIncial, fechaFinal);
                        reporte.CreateDocument();
                        reportePadre.Pages.AddRange(reporte.Pages);
                    }
                }
                reportePadre.ShowRibbonPreviewDialog();
            }
        }

        private void ReporteGrupoConDeudas_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            HistoricoDeudaTodosGruposXtraReport report = new HistoricoDeudaTodosGruposXtraReport();
            report.CreateDocument();
            report.ShowRibbonPreviewDialog();
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            Utils.MuestraInformacion("Esta opción se encuentra dando clic en Integrantes");
        }

        private void NuevaNomina_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm form = new IngresosXtraForm(Enumerados.TipoActividad.OrdenDeTrabajo) { MdiParent = this };
            form.Show();
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void UnidadASupe_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var xtraForm = FindControl("AgrupacionesForm") as XtraForm;
            if (xtraForm != null) xtraForm.Activate();
            else
            {
                AgrupacionesForm form = new AgrupacionesForm { MdiParent = this };
                form.Show();
            }

        }

        private void ProdccionInterna_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OrdenDeTrabajoXtraForm ordenDeTrabajoXtraForm = new OrdenDeTrabajoXtraForm(Enumerados.TipoActividad.ProduccionInterna) { MdiParent = this };
            ordenDeTrabajoXtraForm.Show();
        }

        private void EscalaSalarial_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            EscalaSalarialXtraForm escalaXtraForm = new EscalaSalarialXtraForm();
            escalaXtraForm.Show();
        }

        private void barButtonItem24_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            RepertoriosLista_XtraForm Form = new RepertoriosLista_XtraForm { MdiParent = this };
            Form.Show();
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            EsquemaDeIngresosDeUA Form = new EsquemaDeIngresosDeUA { MdiParent = this };
            Form.Show();
        }

        private void NoAportanSeguridadSocial_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            NomencladorNoEscalaSalarialXtraForm Form = new NomencladorNoEscalaSalarialXtraForm { MdiParent = this };
            Form.Show();
        }

        private void NomTipoCargo_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            NomencladorTipoCargosXtraForm Form = new NomencladorTipoCargosXtraForm { MdiParent = this };
            Form.Show();
        }

        private void NomencladorEscValores_barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            NomencladorEscalasDeValores_RibbonForm Form = new NomencladorEscalasDeValores_RibbonForm { MdiParent = this };
            Form.Show();
        }
    }
}
