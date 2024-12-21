Trabalho_Pratico_26752
{
    partial class EvaluationForms
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvEvaluations;
        private System.Windows.Forms.Button btnUpdateEvaluation;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;

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
            this.dgvEvaluations = new System.Windows.Forms.DataGridView();
            this.btnUpdateEvaluation = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluations)).BeginInit();
            this.SuspendLayout();

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(12, 320);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 1;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(220, 320);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // dgvEvaluations
            this.dgvEvaluations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvaluations.Location = new System.Drawing.Point(12, 12);
            this.dgvEvaluations.Name = "dgvEvaluations";
            this.dgvEvaluations.Size = new System.Drawing.Size(600, 300);
            this.dgvEvaluations.TabIndex = 0;

            // btnUpdateEvaluation
            this.btnUpdateEvaluation.Text = "Atualizar Avaliação";
            this.btnUpdateEvaluation.Location = new System.Drawing.Point(630, 50);
            this.btnUpdateEvaluation.Click += new System.EventHandler(this.btnUpdateEvaluation_Click);

            // EvaluationForms
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnUpdateEvaluation);
            this.Controls.Add(this.dgvEvaluations);
            this.Text = "Menu de Avaliação";

            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluations)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
