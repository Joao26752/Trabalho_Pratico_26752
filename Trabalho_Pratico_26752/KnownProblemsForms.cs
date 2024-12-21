using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class KnownProblemsForm : Form
    {
        private List<KnownProblem> _problems;
        private string _filePath = "knownproblems.txt";

        public KnownProblemsForm()
        {
            InitializeComponent();
            _problems = new List<KnownProblem>();
            LoadProblemsFromFile();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvKnownProblems.AutoGenerateColumns = true;
            dgvKnownProblems.DataSource = _problems;
        }

        private void RefreshProblemsGrid()
        {
            dgvKnownProblems.DataSource = null;
            dgvKnownProblems.DataSource = _problems;
        }

        private void btnAddProblem_Click(object sender, EventArgs e)
        {
            var description = Prompt.ShowDialog("Digite a descrição do problema:", "Adicionar Problema");
            var solution = Prompt.ShowDialog("Digite a solução do problema:", "Adicionar Problema");

            if (!string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(solution))
            {
                int newId = _problems.Count + 1;
                _problems.Add(new KnownProblem { ProblemID = newId, Description = description, Solution = solution });
                RefreshProblemsGrid();
                SaveProblemsToFile();
            }
        }
        private void btnRemoveProblem_Click(object sender, EventArgs e)
        {
            if (dgvKnownProblems.SelectedRows.Count > 0) // Verifica se alguma linha está selecionada
            {
                int selectedIndex = dgvKnownProblems.SelectedRows[0].Index;

                // Remove o problema conhecido da lista
                _problems.RemoveAt(selectedIndex);

                RefreshProblemsGrid(); // Atualiza o DataGridView
                SaveProblemsToFile();  // Grava as alterações no ficheiro

                MessageBox.Show("Problema removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Selecione um problema para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvProblems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _problems.Count)
            {
                var problem = _problems[e.RowIndex];
                MessageBox.Show($"Problema Selecionado:\nID: {problem.ProblemID}\nDescrição: {problem.Description}\nSolução: {problem.Solution}",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SaveProblemsToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var problem in _problems)
                {
                    writer.WriteLine($"{problem.ProblemID};{problem.Description};{problem.Solution}");
                }
            }
        }

        private void LoadProblemsFromFile()
        {
            if (File.Exists(_filePath))
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(';');
                        if (parts.Length == 3)
                        {
                            int id = int.Parse(parts[0]);
                            string description = parts[1];
                            string solution = parts[2];
                            _problems.Add(new KnownProblem { ProblemID = id, Description = description, Solution = solution });
                        }
                    }
                }
            }
        }
    }
}
