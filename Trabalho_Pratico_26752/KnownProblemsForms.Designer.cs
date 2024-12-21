            Trabalho_Pratico_26752
            {
                partial class KnownProblemsForm
                {
                    private System.ComponentModel.IContainer components = null;
                    private System.Windows.Forms.DataGridView dgvKnownProblems;
                    private System.Windows.Forms.Button btnAddProblem;
                    private System.Windows.Forms.Button btnRemoveProblem;
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
                        this.dgvKnownProblems = new System.Windows.Forms.DataGridView();
                        this.btnAddProblem = new System.Windows.Forms.Button();
                        this.btnRemoveProblem = new System.Windows.Forms.Button();
                        this.txtSearch = new System.Windows.Forms.TextBox();
                        this.btnSearch = new System.Windows.Forms.Button();

                        ((System.ComponentModel.ISupportInitialize)(this.dgvKnownProblems)).BeginInit();
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

                        // dgvKnownProblems
                        this.dgvKnownProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        this.dgvKnownProblems.Location = new System.Drawing.Point(12, 12);
                        this.dgvKnownProblems.Name = "dgvKnownProblems";
                        this.dgvKnownProblems.Size = new System.Drawing.Size(600, 300);
                        this.dgvKnownProblems.TabIndex = 0;

                        // btnAddProblem
                        this.btnAddProblem.Text = "Adicionar Problema";
                        this.btnAddProblem.Location = new System.Drawing.Point(630, 50);
                        this.btnAddProblem.Click += new System.EventHandler(this.btnAddProblem_Click);

                        // btnRemoveProblem
                        this.btnRemoveProblem.Text = "Remover Problema";
                        this.btnRemoveProblem.Location = new System.Drawing.Point(630, 100);
                        this.btnRemoveProblem.Click += new System.EventHandler(this.btnRemoveProblem_Click);

                        // KnownProblemsForm
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                        this.ClientSize = new System.Drawing.Size(800, 450);
                        this.Controls.Add(this.btnSearch);
                        this.Controls.Add(this.txtSearch);
                        this.Controls.Add(this.dgvKnownProblems);
                        this.Controls.Add(this.btnAddProblem);
                        this.Controls.Add(this.btnRemoveProblem);
                        this.Text = "Gestão de Problemas Conhecidos";

                        ((System.ComponentModel.ISupportInitialize)(this.dgvKnownProblems)).EndInit();
                        this.ResumeLayout(false);
                    }
                }
            }
