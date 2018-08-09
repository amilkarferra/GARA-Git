namespace DXApplication9.ReportesSistema
{
    partial class CertIndividualXtraReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextoGerente_xrLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.CertificoTexto_xrLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.Constancia_xrLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.Constancia_xrLabel,
            this.CertificoTexto_xrLabel,
            this.TextoGerente_xrLabel});
            this.Detail.HeightF = 551.6666F;
            // 
            // TextoGerente_xrLabel
            // 
            this.TextoGerente_xrLabel.Dpi = 100F;
            this.TextoGerente_xrLabel.Font = new System.Drawing.Font("Arial", 11F);
            this.TextoGerente_xrLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 59.89584F);
            this.TextoGerente_xrLabel.Name = "TextoGerente_xrLabel";
            this.TextoGerente_xrLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextoGerente_xrLabel.SizeF = new System.Drawing.SizeF(650.0001F, 42.53125F);
            this.TextoGerente_xrLabel.StylePriority.UseFont = false;
            this.TextoGerente_xrLabel.StylePriority.UseTextAlignment = false;
            this.TextoGerente_xrLabel.Text = "TextoGerente_xrLabel";
            this.TextoGerente_xrLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            // 
            // CertificoTexto_xrLabel
            // 
            this.CertificoTexto_xrLabel.Dpi = 100F;
            this.CertificoTexto_xrLabel.Font = new System.Drawing.Font("Arial", 11F);
            this.CertificoTexto_xrLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 139.5417F);
            this.CertificoTexto_xrLabel.Name = "CertificoTexto_xrLabel";
            this.CertificoTexto_xrLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CertificoTexto_xrLabel.SizeF = new System.Drawing.SizeF(650F, 80.29168F);
            this.CertificoTexto_xrLabel.StylePriority.UseFont = false;
            this.CertificoTexto_xrLabel.StylePriority.UseTextAlignment = false;
            this.CertificoTexto_xrLabel.Text = "CERTIFICO:";
            this.CertificoTexto_xrLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            // 
            // Constancia_xrLabel
            // 
            this.Constancia_xrLabel.Dpi = 100F;
            this.Constancia_xrLabel.Font = new System.Drawing.Font("Arial", 11F);
            this.Constancia_xrLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 278.8646F);
            this.Constancia_xrLabel.Name = "Constancia_xrLabel";
            this.Constancia_xrLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Constancia_xrLabel.SizeF = new System.Drawing.SizeF(650.0001F, 60.76044F);
            this.Constancia_xrLabel.StylePriority.UseFont = false;
            this.Constancia_xrLabel.StylePriority.UseTextAlignment = false;
            this.Constancia_xrLabel.Text = "Constancia_xrLabel";
            this.Constancia_xrLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(226.3021F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(192.4479F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "CERTIFICACION";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // CertIndividualXtraReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.Configuracion_objectDataSource});
 
            this.Scripts.OnFillEmptySpace = "XtraReport1_FillEmptySpace";
            this.Version = "16.2";
            ((System.ComponentModel.ISupportInitialize)(this.Configuracion_objectDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.XRLabel TextoGerente_xrLabel;
        private DevExpress.XtraReports.UI.XRLabel CertificoTexto_xrLabel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel Constancia_xrLabel;


    }
}
