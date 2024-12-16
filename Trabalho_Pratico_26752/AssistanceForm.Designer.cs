namespace Trabalho_Pratico_26752
{
    partial class AssistanceForms
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAssistances;
        private System.Windows.Forms.Button btnAddAssistance;
        private System.Windows.Forms.Button btnRemoveAssistance;

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
            this.dgvAssistances = new System.Windows.Forms.DataGridView();
            this.btnAddAssistance = new System.Windows.Forms.Button();
            this.btnRemoveAssistance = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAssistances)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAssistances
            this.dgvAssistances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssistances.Location = new System.Drawing.Point(12, 12);
            this.dgvAssistances.Size = new System.Drawing.Size(600, 300);
            this.dgvAssistances.Name = "dgvAssistances";

            // btnAddAssistance
            this.btnAddAssistance.Text = "Adicionar Assistência";
            this.btnAddAssistance.Location = new System.Drawing.Point(630, 50);
            this.btnAddAssistance.Click += new System.EventHandler(this.btnAddAssistance_Click);

            // btnRemoveAssistance
            this.btnRemoveAssistance.Text = "Remover Assistência";
            this.btnRemoveAssistance.Location = new System.Drawing.Point(630, 100);
            this.btnRemoveAssistance.Click += new System.EventHandler(this.btnRemoveAssistance_Click);

            // AssistanceForms
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAssistances);
            this.Controls.Add(this.btnAddAssistance);
            this.Controls.Add(this.btnRemoveAssistance);
            this.Text = "Gerenciamento de Assistências";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssistances)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
