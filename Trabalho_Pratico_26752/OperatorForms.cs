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

        private void InitializeDataGridView()
        {
            dgvOperators.AutoGenerateColumns = true;
            dgvOperators.DataSource = _operators;
        }

        private void RefreshOperatorGrid()
        {
            dgvOperators.DataSource = null;
            dgvOperators.DataSource = _operators;
        }

        private void btnAddOperator_Click(object sender, EventArgs e)
        {
            var name = Prompt.ShowDialog("Digite o nome do operador:", "Adicionar Operador");
            var shift = Prompt.ShowDialog("Digite o turno do operador:", "Adicionar Operador");

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(shift))
            {
                int newId = _operators.Count + 1;
                _operators.Add(new Operator(newId, name, $"{name.ToLower()}@example.com", shift));
                RefreshOperatorGrid();
                SaveOperatorsToFile();
            }
            else
            {
                MessageBox.Show("Os campos Nome e Turno são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnRemoveOperator_Click(object sender, EventArgs e)
        {
            if (dgvOperators.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvOperators.SelectedRows[0].Index;

                if (selectedIndex >= 0 && selectedIndex < _operators.Count)
                {
                    _operators.RemoveAt(selectedIndex);
                    RefreshOperatorGrid();
                    SaveOperatorsToFile();
                }
                else
                {
                    MessageBox.Show("Índice inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um operador para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SaveOperatorsToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var op in _operators)
                {
                    writer.WriteLine($"{op.ID};{op.Name};{op.Email};{op.Shift}");
                }
            }
        }

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
    }
}
