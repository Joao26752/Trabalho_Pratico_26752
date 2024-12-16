using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class EvaluationForms : Form
    {
        private List<Assistance> _assistances;

        public EvaluationForms()
        {
            InitializeComponent();
            _assistances = new List<Assistance>();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvEvaluations.AutoGenerateColumns = true;
            dgvEvaluations.DataSource = _assistances;
        }

        private void RefreshEvaluationGrid()
        {
            dgvEvaluations.DataSource = null;
            dgvEvaluations.DataSource = _assistances;
        }

        private void btnUpdateEvaluation_Click(object sender, EventArgs e)
        {
            if (dgvEvaluations.SelectedRows.Count > 0)
            {
                var selectedAssistance = _assistances[dgvEvaluations.SelectedRows[0].Index];

                var newRatingText = Prompt.ShowDialog("Digite a nova avaliação (1-10):", "Atualizar Avaliação");
                if (int.TryParse(newRatingText, out int newRating) && newRating >= 1 && newRating <= 10)
                {
                    selectedAssistance.Rating = newRating;
                    RefreshEvaluationGrid();
                }
                else
                {
                    MessageBox.Show("Avaliação inválida. Deve ser um número entre 1 e 10.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma assistência para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
