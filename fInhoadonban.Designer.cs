namespace project_quanlybanhang
{
    partial class fInhoadonban
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewerHoaDonBan = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerHoaDonBan
            // 
            this.reportViewerHoaDonBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerHoaDonBan.LocalReport.ReportEmbeddedResource = "project_quanlybanhang.ReportHoaDonBan.rdlc";
            this.reportViewerHoaDonBan.Location = new System.Drawing.Point(0, 0);
            this.reportViewerHoaDonBan.Name = "reportViewerHoaDonBan";
            this.reportViewerHoaDonBan.ServerReport.BearerToken = null;
            this.reportViewerHoaDonBan.Size = new System.Drawing.Size(860, 744);
            this.reportViewerHoaDonBan.TabIndex = 0;
            // 
            // fInhoadonban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 744);
            this.Controls.Add(this.reportViewerHoaDonBan);
            this.Name = "fInhoadonban";
            this.Text = "fInhoadonban";
            this.Load += new System.EventHandler(this.fInhoadonban_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerHoaDonBan;
    }
}