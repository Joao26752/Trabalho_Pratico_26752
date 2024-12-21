namespace Trabalho_Pratico_26752
{
    partial class AssistanceForms
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAssistances;
        private System.Windows.Forms.Button btnAddAssistance;
        private System.Windows.Forms.Button btnAssignTechnician;
        private System.Windows.Forms.Button btnCompleteTicket;

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
            this.dgvAssistances = new System.Windows.Forms.DataGridView();
            this.btnAddAssistance = new System.Windows.Forms.Button();
            this.btnAssignTechnician = new System.Windows.Forms.Button();
            this.btnCompleteTicket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssistances)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvAssistances
            // 
            this.dgvAssistances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssistances.Location = new System.Drawing.Point(12, 12);
            this.dgvAssistances.Name = "dgvAssistances";
            this.dgvAssistances.ReadOnly = true;
            this.dgvAssistances.Size = new System.Drawing.Size(760, 250);
            this.dgvAssistances.TabIndex = 0;

            // 
            // btnAddAssistance
            // 
            this.btnAddAssistance.Location = new System.Drawing.Point(12, 280);
            this.btnAddAssistance.Name = "btnAddAssistance";
            this.btnAddAssistance.Size = new System.Drawing.Size(200, 40);
            this.btnAddAssistance.TabIndex = 1;
            this.btnAddAssistance.Text = "Adicionar Ticket";
            this.btnAddAssistance.UseVisualStyleBackColor = true;
            this.btnAddAssistance.Click += new System.EventHandler(this.btnAddAssistance_Click);

            // 
            // btnAssignTechnician
            // 
            this.btnAssignTechnician.Location = new System.Drawing.Point(275, 280);
            this.btnAssignTechnician.Name = "btnAssignTechnician";
            this.btnAssignTechnician.Size = new System.Drawing.Size(200, 40);
            this.btnAssignTechnician.TabIndex = 2;
            this.btnAssignTechnician.Text = "Atribuir Técnico";
            this.btnAssignTechnician.UseVisualStyleBackColor = true;
            this.btnAssignTechnician.Click += new System.EventHandler(this.btnAssignTechnician_Click);

            // 
            // btnCompleteTicket
            // 
            this.btnCompleteTicket.Location = new System.Drawing.Point(550, 280);
            this.btnCompleteTicket.Name = "btnCompleteTicket";
            this.btnCompleteTicket.Size = new System.Drawing.Size(200, 40);
            this.btnCompleteTicket.TabIndex = 3;
            this.btnCompleteTicket.Text = "Concluir Ticket";
            this.btnCompleteTicket.UseVisualStyleBackColor = true;
            this.btnCompleteTicket.Click += new System.EventHandler(this.btnCompleteTicket_Click);

            // 
            // AssistanceForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 341);
            this.Controls.Add(this.btnCompleteTicket);
            this.Controls.Add(this.btnAssignTechnician);
            this.Controls.Add(this.btnAddAssistance);
            this.Controls.Add(this.dgvAssistances);
            this.Name = "AssistanceForms";
            this.Text = "Gestão de Assistências";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssistances)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
