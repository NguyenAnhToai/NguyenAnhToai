namespace project_quanlybanhang
{
    partial class fInHoaDonNhap
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
            this.reportViewerHoaDonNhap = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerHoaDonNhap
            // 
            this.reportViewerHoaDonNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerHoaDonNhap.LocalReport.ReportEmbeddedResource = "project_quanlybanhang.Report_HoaDonNhap.rdlc";
            this.reportViewerHoaDonNhap.Location = new System.Drawing.Point(0, 0);
            this.reportViewerHoaDonNhap.Name = "reportViewerHoaDonNhap";
            this.reportViewerHoaDonNhap.ServerReport.BearerToken = null;
            this.reportViewerHoaDonNhap.Size = new System.Drawing.Size(841, 730);
            this.reportViewerHoaDonNhap.TabIndex = 0;
            // 
            // fInHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 730);
            this.Controls.Add(this.reportViewerHoaDonNhap);
            this.Name = "fInHoaDonNhap";
            this.Text = "fInHoaDonNhap";
            this.Load += new System.EventHandler(this.fInHoaDonNhap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerHoaDonNhap;
    }
}