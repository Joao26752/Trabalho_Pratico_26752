namespace Trabalho_Pratico_26752
{
    partial class OperatorForms
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvOperators;
        private System.Windows.Forms.Button btnAddOperator;
        private System.Windows.Forms.Button btnRemoveOperator;

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
            this.dgvOperators = new System.Windows.Forms.DataGridView();
            this.btnAddOperator = new System.Windows.Forms.Button();
            this.btnRemoveOperator = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOperators)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOperators
            this.dgvOperators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperators.Location = new System.Drawing.Point(12, 12);
            this.dgvOperators.Size = new System.Drawing.Size(600, 300);
            this.dgvOperators.Name = "dgvOperators";

            // btnAddOperator
            this.btnAddOperator.Text = "Adicionar Operador";
            this.btnAddOperator.Location = new System.Drawing.Point(630, 50);
            this.btnAddOperator.Click += new System.EventHandler(this.btnAddOperator_Click);

            // btnRemoveOperator
            this.btnRemoveOperator.Text = "Remover Operador";
            this.btnRemoveOperator.Location = new System.Drawing.Point(630, 100);
            this.btnRemoveOperator.Click += new System.EventHandler(this.btnRemoveOperator_Click);

            // OperatorForms
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvOperators);
            this.Controls.Add(this.btnAddOperator);
            this.Controls.Add(this.btnRemoveOperator);
            this.Text = "Gerenciamento de Operadores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperators)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
