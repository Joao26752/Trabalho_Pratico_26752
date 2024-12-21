namespace Trabalho_Pratico_26752
{
    partial class mainform
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageAssistances;
        private System.Windows.Forms.Button btnManageOperators;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnGenerateReports;

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
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnManageAssistances = new System.Windows.Forms.Button();
            this.btnManageOperators = new System.Windows.Forms.Button();
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.btnGenerateReports = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // btnManageCustomers
            this.btnManageCustomers.Location = new System.Drawing.Point(50, 50);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(200, 40);
            this.btnManageCustomers.Text = "Clientes";
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);

            // btnManageAssistances
            this.btnManageAssistances.Location = new System.Drawing.Point(50, 110);
            this.btnManageAssistances.Name = "btnManageAssistances";
            this.btnManageAssistances.Size = new System.Drawing.Size(200, 40);
            this.btnManageAssistances.Text = "Assistências";
            this.btnManageAssistances.Click += new System.EventHandler(this.btnManageAssistances_Click);

            // btnManageOperators
            this.btnManageOperators.Location = new System.Drawing.Point(50, 170);
            this.btnManageOperators.Name = "btnManageOperators";
            this.btnManageOperators.Size = new System.Drawing.Size(200, 40);
            this.btnManageOperators.Text = "Operadores";
            this.btnManageOperators.Click += new System.EventHandler(this.btnManageOperators_Click);

            // btnManageProducts
            this.btnManageProducts.Location = new System.Drawing.Point(50, 230);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(200, 40);
            this.btnManageProducts.Text = "Produtos";
            this.btnManageProducts.Click += new System.EventHandler(this.btnManageProducts_Click);

            // btnGenerateReports
            this.btnGenerateReports.Location = new System.Drawing.Point(50, 290);
            this.btnGenerateReports.Name = "btnGenerateReports";
            this.btnGenerateReports.Size = new System.Drawing.Size(200, 40);
            this.btnGenerateReports.Text = "Relatórios";
            this.btnGenerateReports.Click += new System.EventHandler(this.btnGenerateReports_Click);

            // mainform
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageCustomers);
            this.Controls.Add(this.btnManageAssistances);
            this.Controls.Add(this.btnManageOperators);
            this.Controls.Add(this.btnManageProducts); // Adiciona o botão ao formulário
            this.Controls.Add(this.btnGenerateReports);
            this.Name = "mainform";
            this.Text = "Gestão de Helpdesk";
            this.ResumeLayout(false);
        }
    }
}
