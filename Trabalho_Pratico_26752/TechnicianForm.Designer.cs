namespace Trabalho_Pratico_26752
{
    partial class TechnicianForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTechnicians;
        private System.Windows.Forms.Button btnAddTechnician;
        private System.Windows.Forms.Button btnRemoveTechnician;

        /// <summary>
        /// Limpar recursos utilizados.
        /// </summary>
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
        /// Método obrigatório para suporte ao Designer.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTechnicians = new System.Windows.Forms.DataGridView();
            this.btnAddTechnician = new System.Windows.Forms.Button();
            this.btnRemoveTechnician = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicians)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvTechnicians
            // 
            this.dgvTechnicians.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTechnicians.Location = new System.Drawing.Point(12, 12);
            this.dgvTechnicians.Name = "dgvTechnicians";
            this.dgvTechnicians.ReadOnly = true;
            this.dgvTechnicians.Size = new System.Drawing.Size(760, 250);
            this.dgvTechnicians.TabIndex = 0;

            // 
            // btnAddTechnician
            // 
            this.btnAddTechnician.Location = new System.Drawing.Point(12, 280);
            this.btnAddTechnician.Name = "btnAddTechnician";
            this.btnAddTechnician.Size = new System.Drawing.Size(200, 40);
            this.btnAddTechnician.TabIndex = 1;
            this.btnAddTechnician.Text = "Adicionar Técnico";
            this.btnAddTechnician.UseVisualStyleBackColor = true;
            this.btnAddTechnician.Click += new System.EventHandler(this.btnAddTechnician_Click);

            // 
            // btnRemoveTechnician
            // 
            this.btnRemoveTechnician.Location = new System.Drawing.Point(250, 280);
            this.btnRemoveTechnician.Name = "btnRemoveTechnician";
            this.btnRemoveTechnician.Size = new System.Drawing.Size(200, 40);
            this.btnRemoveTechnician.TabIndex = 2;
            this.btnRemoveTechnician.Text = "Remover Técnico";
            this.btnRemoveTechnician.UseVisualStyleBackColor = true;
            this.btnRemoveTechnician.Click += new System.EventHandler(this.btnRemoveTechnician_Click);

            // 
            // TechnicianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 341);
            this.Controls.Add(this.btnRemoveTechnician);
            this.Controls.Add(this.btnAddTechnician);
            this.Controls.Add(this.dgvTechnicians);
            this.Name = "TechnicianForm";
            this.Text = "Gestão de Técnicos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicians)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
