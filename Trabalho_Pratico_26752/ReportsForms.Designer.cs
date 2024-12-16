namespace Trabalho_Pratico_26752
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ComboBox cbReportType;
        private System.Windows.Forms.Label lblSelectReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.cbReportType = new System.Windows.Forms.ComboBox();
            this.lblSelectReport = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblSelectReport
            this.lblSelectReport.AutoSize = true;
            this.lblSelectReport.Location = new System.Drawing.Point(20, 20);
            this.lblSelectReport.Name = "lblSelectReport";
            this.lblSelectReport.Size = new System.Drawing.Size(170, 17);
            this.lblSelectReport.Text = "Selecione o Tipo de Relatório:";

            // cbReportType
            this.cbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReportType.Items.AddRange(new object[] {
                "Assistências Resolvidas",
                "Problemas Conhecidos"});
            this.cbReportType.Location = new System.Drawing.Point(20, 50);
            this.cbReportType.Name = "cbReportType";
            this.cbReportType.Size = new System.Drawing.Size(250, 24);

            // btnGenerateReport
            this.btnGenerateReport.Location = new System.Drawing.Point(20, 90);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(250, 30);
            this.btnGenerateReport.Text = "Gerar Relatório";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

            // ReportsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(this.lblSelectReport);
            this.Controls.Add(this.cbReportType);
            this.Controls.Add(this.btnGenerateReport);
            this.Text = "Relatórios";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
