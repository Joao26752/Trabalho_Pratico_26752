using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class OperatorForms : Form
    {
        private List<Operator> _operators;
        private string _filePath = "operators.txt";

        public OperatorForms()
        {
            InitializeComponent();
            _operators = new List<Operator>();
            LoadOperatorsFromFile();
            InitializeDataGridView();
        }

        // Método para inicializar o DataGridView com os operadores
        private void InitializeDataGridView()
        {
            dgvOperators.AutoGenerateColumns = true;
            dgvOperators.DataSource = _operators;
        }

        // Método para atualizar o DataGridView com os operadores
        private void RefreshOperatorGrid()
        {
            dgvOperators.DataSource = null;
            dgvOperators.DataSource = _operators;
        }

        // Evento de clique para adicionar um novo operador
        private void btnAddOperator_Click(object sender, EventArgs e)
        {
            var name = Prompt.ShowDialog("Digite o nome do operador:", "Adicionar Operador");
            var shift = Prompt.ShowDialog("Digite o turno do operador:", "Adicionar Operador");

            // Verifica se o nome e o turno não estão vazios
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(shift))
            {
                int newId = _operators.Count + 1;
                var newOperator = new Operator(newId, name, $"{name.ToLower()}@example.com", shift);
                _operators.Add(newOperator);
                RefreshOperatorGrid();
                SaveOperatorsToFile();

                MessageBox.Show("Operador adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento de clique para remover um operador
        private void btnRemoveOperator_Click(object sender, EventArgs e)
        {
            if (dgvOperators.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvOperators.SelectedRows[0].Index;

                // Validação do índice
                if (selectedIndex >= 0 && selectedIndex < _operators.Count)
                {
                    _operators.RemoveAt(selectedIndex);
                    RefreshOperatorGrid();
                    SaveOperatorsToFile();

                    MessageBox.Show("Operador removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Índice inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um operador para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para guardar os operadores num ficheiro
        private void SaveOperatorsToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var op in _operators)
                {
                    writer.WriteLine($"{op.ID};{op.Name};{op.Email};{op.Shift}");
                }
            }
            Console.WriteLine("Operadores guardados no ficheiro.");
        }

        // Método para carregar os operadores de um ficheiro
        private void LoadOperatorsFromFile()
        {
            if (File.Exists(_filePath))
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(';');
                        if (parts.Length == 4)
                        {
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            string email = parts[2];
                            string shift = parts[3];

                            _operators.Add(new Operator(id, name, email, shift));
                        }
                    }
                }
            }
        }

        private void dgvOperators_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _operators.Count)
            {
                var op = _operators[e.RowIndex];
                MessageBox.Show($"Operador Selecionado:\nID: {op.ID}\nNome: {op.Name}\nTurno: {op.Shift}",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
