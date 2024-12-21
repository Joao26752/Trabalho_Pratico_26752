            Trabalho_Pratico_26752
            {
                partial class AssistanceForms
                {
                    private System.ComponentModel.IContainer components = null;
                    private System.Windows.Forms.DataGridView dgvAssistances;
                    private System.Windows.Forms.Button btnAddAssistance;
                    private System.Windows.Forms.Button btnAssignTechnician;
                    private System.Windows.Forms.Button btnCompleteTicket;
                    private System.Windows.Forms.TextBox txtSearch;
                    private System.Windows.Forms.Button btnSearch;

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
                        this.txtSearch = new System.Windows.Forms.TextBox();
                        this.btnSearch = new System.Windows.Forms.Button();
                        ((System.ComponentModel.ISupportInitialize)(this.dgvAssistances)).BeginInit();
                        this.SuspendLayout();

                        // 
                        // txtSearch
                        // 
                        this.txtSearch.Location = new System.Drawing.Point(12, 320);
                        this.txtSearch.Name = "txtSearch";
                        this.txtSearch.Size = new System.Drawing.Size(200, 20);
                        this.txtSearch.TabIndex = 1;

                        // 
                        // btnSearch
                        // 
                        this.btnSearch.Location = new System.Drawing.Point(220, 320);
                        this.btnSearch.Name = "btnSearch";
                        this.btnSearch.Size = new System.Drawing.Size(75, 23);
                        this.btnSearch.TabIndex = 2;
                        this.btnSearch.Text = "Search";
                        this.btnSearch.UseVisualStyleBackColor = true;
                        this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

                        // 
                        // dgvAssistances
                        // 
                        this.dgvAssistances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        this.dgvAssistances.Location = new System.Drawing.Point(12, 12);
                        this.dgvAssistances.Name = "dgvAssistances";
                        this.dgvAssistances.ReadOnly = true;
                        this.dgvAssistances.Size = new System.Drawing.Size(600, 300);
                        this.dgvAssistances.TabIndex = 0;

                        // 
                        // btnAddAssistance
                        // 
                        this.btnAddAssistance.Location = new System.Drawing.Point(630, 50);
                        this.btnAddAssistance.Name = "btnAddAssistance";
                        this.btnAddAssistance.Size = new System.Drawing.Size(150, 30);
                        this.btnAddAssistance.TabIndex = 3;
                        this.btnAddAssistance.Text = "Adicionar Ticket";
                        this.btnAddAssistance.UseVisualStyleBackColor = true;
                        this.btnAddAssistance.Click += new System.EventHandler(this.btnAddAssistance_Click);

                        // 
                        // btnAssignTechnician
                        // 
                        this.btnAssignTechnician.Location = new System.Drawing.Point(630, 100);
                        this.btnAssignTechnician.Name = "btnAssignTechnician";
                        this.btnAssignTechnician.Size = new System.Drawing.Size(150, 30);
                        this.btnAssignTechnician.TabIndex = 4;
                        this.btnAssignTechnician.Text = "Atribuir Técnico";
                        this.btnAssignTechnician.UseVisualStyleBackColor = true;
                        this.btnAssignTechnician.Click += new System.EventHandler(this.btnAssignTechnician_Click);

                        // 
                        // btnCompleteTicket
                        // 
                        this.btnCompleteTicket.Location = new System.Drawing.Point(630, 150);
                        this.btnCompleteTicket.Name = "btnCompleteTicket";
                        this.btnCompleteTicket.Size = new System.Drawing.Size(150, 30);
                        this.btnCompleteTicket.TabIndex = 5;
                        this.btnCompleteTicket.Text = "Concluir Ticket";
                        this.btnCompleteTicket.UseVisualStyleBackColor = true;
                        this.btnCompleteTicket.Click += new System.EventHandler(this.btnCompleteTicket_Click);

                        // 
                        // AssistanceForms
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(800, 450);
                        this.Controls.Add(this.btnSearch);
                        this.Controls.Add(this.txtSearch);
                        this.Controls.Add(this.btnCompleteTicket);
                        this.Controls.Add(this.btnAssignTechnician);
                        this.Controls.Add(this.btnAddAssistance);
                        this.Controls.Add(this.dgvAssistances);
                        this.Name = "AssistanceForms";
                        this.Text = "Gestão de Assistências";
                        ((System.ComponentModel.ISupportInitialize)(this.dgvAssistances)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();
                    }

                    #endregion
                }
            }
