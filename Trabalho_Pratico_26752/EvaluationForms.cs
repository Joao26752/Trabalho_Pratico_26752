using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class EvaluationForms : Form
    {
        private List<Assistance> _assistances; // Lista de assistências

        public EvaluationForms()
        {
            InitializeComponent();
            _assistances = new List<Assistance>(); // Inicia a lista
            InitializeDataGridView();
        }

        // Método para inicializar o DataGridView com as avaliações
        private void InitializeDataGridView()
        {
            dgvEvaluations.AutoGenerateColumns = true; // Gera automaticamente as colunas
            dgvEvaluations.DataSource = _assistances; // Define a fonte de dados
        }

        // Método para atualizar o DataGridView com as avaliações
        private void RefreshEvaluationGrid()
        {
            dgvEvaluations.DataSource = null; // Limpa a fonte de dados
            dgvEvaluations.DataSource = _assistances; // Reatribui a lista ao DataGridView
        }

        // Evento de clique para atualizar uma avaliação
        private void btnUpdateEvaluation_Click(object sender, EventArgs e)
        {
            if (dgvEvaluations.SelectedRows.Count > 0) // Verifica se há assistências selecionadas
            {
                var selectedAssistance = _assistances[dgvEvaluations.SelectedRows[0].Index]; // Obtem a assistência selecionada

                var newRatingText = Prompt.ShowDialog("Digite a nova avaliação (1-10):", "Atualizar Avaliação"); // Solicita a nova avaliação
                if (int.TryParse(newRatingText, out int newRating) && newRating >= 1 && newRating <= 10) // Verifica se a avaliação é válida
                {
                    selectedAssistance.Rating = newRating; // Atualiza a avaliação
                    RefreshEvaluationGrid(); // Atualiza o DataGridView

                    MessageBox.Show("Avaliação atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); // Exibe uma mensagem de sucesso
                }
                else
                {
                    MessageBox.Show("Avaliação inválida. Digite um número entre 1 e 10.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe uma mensagem de erro
                }
            }
            else
            {
                MessageBox.Show("Selecione uma assistência para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Exibe uma mensagem de aviso
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();
            var filteredAssistances = _assistances.Where(a => a.Description.ToLower().Contains(searchTerm) || a.Customer.Name.ToLower().Contains(searchTerm)).ToList();
            dgvEvaluations.DataSource = null;
            dgvEvaluations.DataSource = filteredAssistances;
        }
    }
}
