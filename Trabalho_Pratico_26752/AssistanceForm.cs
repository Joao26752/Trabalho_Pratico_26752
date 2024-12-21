using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class AssistanceForms : Form
    {
        private List<Assistance> _assistances = new List<Assistance>();

        public AssistanceForms()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvAssistances.AutoGenerateColumns = false;

            dgvAssistances.Columns.Add("ID", "ID");
            dgvAssistances.Columns.Add("Description", "Descrição");
            dgvAssistances.Columns.Add("Status", "Estado");
            dgvAssistances.Columns.Add("Technician", "Técnico");

            dgvAssistances.Columns["ID"].DataPropertyName = "ID";
            dgvAssistances.Columns["Description"].DataPropertyName = "Description";
            dgvAssistances.Columns["Status"].DataPropertyName = "Status";
            dgvAssistances.Columns["Technician"].DataPropertyName = "AssignedTechnician.Name";

            RefreshAssistanceGrid();
        }

        private void RefreshAssistanceGrid()
        {
            dgvAssistances.DataSource = null;
            dgvAssistances.DataSource = _assistances;
        }

        private void btnCompleteTicket_Click(object sender, EventArgs e)
        {
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

        private void SaveAssistancesToFile()
        {
            // Implementar lógica para salvar assistências em arquivo
            Console.WriteLine("Assistências salvas no arquivo.");
        }
    }
}
