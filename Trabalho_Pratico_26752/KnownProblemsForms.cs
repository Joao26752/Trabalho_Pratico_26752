using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class KnownProblemsForm : Form
    {
        private List<KnownProblem> _problems; // Lista de problemas conhecidos
        private string _filePath = "problemasconhecidos.txt"; // Caminho do ficheiro

        public KnownProblemsForm()
        {
            InitializeComponent();
            _problems = new List<KnownProblem>(); // Inicia a lista
            LoadProblemsFromFile(); // Carrega os dados do ficheiro
            InitializeDataGridView();
        }

        // Método para inicializar o DataGridView com os problemas conhecidos
        private void InitializeDataGridView()
        {
            dgvKnownProblems.AutoGenerateColumns = true; // Gera automaticamente as colunas
            dgvKnownProblems.DataSource = _problems; // Define a fonte de dados
        }

        // Método para atualizar o DataGridView com os problemas conhecidos
        private void RefreshProblemsGrid()
        {
            dgvKnownProblems.DataSource = null; // Limpa a fonte de dados
            dgvKnownProblems.DataSource = _problems; // Reatribui a lista ao DataGridView
        }

        // Evento de clique para adicionar um novo problema
        private void btnAddProblem_Click(object sender, EventArgs e)
        {
            var description = Prompt.ShowDialog("Digite a descrição do problema:", "Adicionar Problema");
            var solution = Prompt.ShowDialog("Digite a solução do problema:", "Adicionar Problema");

            // Verifica se os campos não estão vazios
            if (!string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(solution))
            {
                int newId = _problems.Count + 1; // Gera um novo ID
                var newProblem = new KnownProblem(newId, description, solution); // Cria um novo problema
                _problems.Add(newProblem); // Adiciona o problema à lista
                RefreshProblemsGrid(); // Atualiza o DataGridView
                SaveProblemsToFile(); // Guarda os problemas no ficheiro

                MessageBox.Show("Problema adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); // Exibe uma mensagem de sucesso
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Exibe uma mensagem de erro
            }
        }

        // Evento de clique para remover um problema
        private void btnRemoveProblem_Click(object sender, EventArgs e)
        {
            if (dgvKnownProblems.SelectedRows.Count > 0) // Verifica se há problemas selecionados
            {
                int selectedIndex = dgvKnownProblems.SelectedRows[0].Index; // Obtem o índice do problema selecionado

                // Validação do índice
                if (selectedIndex >= 0 && selectedIndex < _problems.Count)
                {
                    _problems.RemoveAt(selectedIndex); // Remove o problema da lista
                    RefreshProblemsGrid(); // Atualiza o DataGridView
                    SaveProblemsToFile(); // Guarda os problemas no ficheiro

                    MessageBox.Show("Problema removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); // Exibe uma mensagem de sucesso
                }
                else
                {
                    MessageBox.Show("Índice inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe uma mensagem de erro
                }
            }
            else
            {
                MessageBox.Show("Selecione um problema para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Exibe uma mensagem de aviso
            }
        }

        // Método para guardar os problemas num ficheiro
        private void SaveProblemsToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var problem in _problems) // Itera sobre a lista de problemas
                {
                    writer.WriteLine($"{problem.ID};{problem.Description};{problem.Solution}"); // Escreve as informações do problema no ficheiro
                }
            }
            Console.WriteLine("Problemas guardados no ficheiro."); // Exibe uma mensagem no console
        }

        // Método para carregar os problemas de um ficheiro
        private void LoadProblemsFromFile()
        {
            if (File.Exists(_filePath)) // Verifica se o ficheiro existe
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) // Itera sobre as linhas do ficheiro
                    {
                        var parts = line.Split(';'); // Divide a linha em partes
                        if (parts.Length == 3) // Verifica se a linha tem as informações necessárias
                        {
                            int id = int.Parse(parts[0]); // Converte o ID para inteiro
                            string description = parts[1]; // Obtem a descrição
                            string solution = parts[2]; // Obtem a solução

                            _problems.Add(new KnownProblem(id, description, solution)); // Cria um novo problema e adiciona à lista
                        }
                    }
                }
            }
        }

        private void dgvProblems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _problems.Count)
            {
                var problem = _problems[e.RowIndex];
                MessageBox.Show($"Problema Selecionado:\nID: {problem.ID}\nDescrição: {problem.Description}\nSolução: {problem.Solution}",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();
            var filteredProblems = _problems.Where(p => p.Description.ToLower().Contains(searchTerm) || p.Solution.ToLower().Contains(searchTerm)).ToList();
            dgvKnownProblems.DataSource = null;
            dgvKnownProblems.DataSource = filteredProblems;
        }
    }
}
