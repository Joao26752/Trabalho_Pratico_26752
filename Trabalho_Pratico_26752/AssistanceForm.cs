using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class AssistanceForms : Form
    {
        private List<Assistance> _assistances = new List<Assistance>(); // Lista de assistências

        public AssistanceForms()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        // Método para inicializar o DataGridView com as assistências
        private void InitializeDataGridView()
        {
            dgvAssistances.AutoGenerateColumns = false; // Desativa a geração automática de colunas

            // Adicionar colunas ao DataGridView
            dgvAssistances.Columns.Add("ID", "ID");
            dgvAssistances.Columns.Add("Description", "Descrição");
            dgvAssistances.Columns.Add("Status", "Estado");
            dgvAssistances.Columns.Add("Technician", "Técnico");

            // Associar propriedades das colunas aos campos da classe
            dgvAssistances.Columns["ID"].DataPropertyName = "ID";
            dgvAssistances.Columns["Description"].DataPropertyName = "Description";
            dgvAssistances.Columns["Status"].DataPropertyName = "Status";
            dgvAssistances.Columns["Technician"].DataPropertyName = "AssignedTechnician.Name";

            // Permitir ordenação nas colunas
            dgvAssistances.Columns["ID"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAssistances.Columns["Description"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAssistances.Columns["Status"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAssistances.Columns["Technician"].SortMode = DataGridViewColumnSortMode.Automatic;

            RefreshAssistanceGrid(); // Atualiza o DataGridView
        }

        // Método para atualizar o DataGridView com as assistências
        private void RefreshAssistanceGrid()
        {
            dgvAssistances.DataSource = null; // Limpa a fonte de dados
            dgvAssistances.DataSource = _assistances; // Reatribui a lista ao DataGridView
        }

        // Evento de clique para adicionar uma nova assistência
        private void btnAddAssistance_Click(object sender, EventArgs e)
        {
            // Solicita ao usuário os dados para criar o ticket
            var customerName = Prompt.ShowDialog("Digite o nome do cliente:", "Adicionar Ticket");
            var description = Prompt.ShowDialog("Digite a descrição do ticket:", "Adicionar Ticket");

            if (!string.IsNullOrEmpty(customerName) && !string.IsNullOrEmpty(description))
            {
                // Simula a criação de um cliente
                var customer = new Customer(_assistances.Count + 1, customerName, $"{customerName.ToLower()}@example.com");

                // Cria o ticket
                var newAssistance = new Assistance(_assistances.Count + 1, customer, AssistanceType.TechnicalSupport, description);

                _assistances.Add(newAssistance);
                RefreshAssistanceGrid(); // Atualiza a interface
                SaveAssistancesToFile(); // Grava as alterações no ficheiro

                MessageBox.Show("Ticket adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento de clique para atribuir um técnico
        private void btnAssignTechnician_Click(object sender, EventArgs e)
        {
            if (dgvAssistances.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvAssistances.SelectedRows[0].Index;
                var selectedAssistance = _assistances[selectedIndex];

                // Simula a seleção de um técnico
                var technicianName = Prompt.ShowDialog("Digite o nome do técnico:", "Atribuir Técnico");
                if (!string.IsNullOrEmpty(technicianName))
                {
                    var technician = new Operator(1, technicianName, $"{technicianName.ToLower()}@example.com", "Manhã");

                    // Atribui o técnico ao ticket
                    try
                    {
                        selectedAssistance.AssignTechnician(technician);
                        RefreshAssistanceGrid(); // Atualiza a interface
                        SaveAssistancesToFile(); // Grava as alterações no ficheiro

                        MessageBox.Show("Técnico atribuído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atribuir técnico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nome do técnico é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Selecione um ticket para atribuir um técnico.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento de clique para concluir um ticket
        private void btnCompleteTicket_Click(object sender, EventArgs e)
        {
            if (dgvAssistances.CurrentRow == null)
            {
                MessageBox.Show("Selecione um ticket para concluir.", "Seleção Obrigatória", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvAssistances.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvAssistances.SelectedRows[0].Index;
                var selectedAssistance = _assistances[selectedIndex];

                if (selectedAssistance.Status == AssistanceRequestStatus.InProgress)
                {
                    try
                    {
                        selectedAssistance.CompleteTicket();
                        RefreshAssistanceGrid(); // Atualiza o DataGridView
                        SaveAssistancesToFile(); // Grava as alterações no ficheiro

                        MessageBox.Show("Ticket concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao concluir o ticket: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("O ticket não pode ser concluído pois não está em progresso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Selecione um ticket para concluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento de clique para pesquisar tickets
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();
            var filteredAssistances = _assistances.Where(a => a.Description.ToLower().Contains(searchTerm) || a.AssignedTechnician.Name.ToLower().Contains(searchTerm)).ToList();
            dgvAssistances.DataSource = null;
            dgvAssistances.DataSource = filteredAssistances;
        }

        // Método para guardar as assistências num ficheiro
        private void SaveAssistancesToFile()
        {
            // Implementar lógica para salvar assistências em arquivo
            Console.WriteLine("Assistências guardadas no ficheiro.");
        }
    }
}
