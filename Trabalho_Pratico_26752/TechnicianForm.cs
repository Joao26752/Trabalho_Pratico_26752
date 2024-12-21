using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class TechnicianForm : Form
    {
        private List<Operator> _technicians; // Lista de técnicos
        private string _filePath = "technicians.txt"; // Caminho do ficheiro

        public TechnicianForm()
        {
            InitializeComponent();
            _technicians = new List<Operator>();
            LoadTechniciansFromFile();
            InitializeDataGridView();
        }

        // Método para inicializar o DataGridView com os técnicos
        private void InitializeDataGridView()
        {
            dgvTechnicians.AutoGenerateColumns = true;
            dgvTechnicians.DataSource = _technicians;
        }

        // Método para atualizar o DataGridView com os técnicos
        private void RefreshTechnicianGrid()
        {
            dgvTechnicians.DataSource = null;
            dgvTechnicians.DataSource = _technicians;
        }

        // Evento de clique para adicionar um novo técnico
        private void btnAddTechnician_Click(object sender, EventArgs e)
        {
            var name = Prompt.ShowDialog("Digite o nome do técnico:", "Adicionar Técnico");
            var email = Prompt.ShowDialog("Digite o endereço de e-mail do técnico:", "Adicionar Técnico");
            var shift = Prompt.ShowDialog("Digite o turno do técnico:", "Adicionar Técnico");

            // Verifica se os campos não estão vazios
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(shift))
            {
                int newId = _technicians.Count + 1;
                var newTechnician = new Operator(newId, name, email, shift);
                _technicians.Add(newTechnician);
                RefreshTechnicianGrid();
                SaveTechniciansToFile();

                MessageBox.Show("Técnico adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento de clique para remover um técnico
        private void btnRemoveTechnician_Click(object sender, EventArgs e)
        {
            if (dgvTechnicians.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvTechnicians.SelectedRows[0].Index;

                // Validação do índice
                if (selectedIndex >= 0 && selectedIndex < _technicians.Count)
                {
                    _technicians.RemoveAt(selectedIndex);
                    RefreshTechnicianGrid();
                    SaveTechniciansToFile();

                    MessageBox.Show("Técnico removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Índice inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um técnico para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para guardar os técnicos num ficheiro
        private void SaveTechniciansToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var tech in _technicians)
                {
                    writer.WriteLine($"{tech.ID};{tech.Name};{tech.Email};{tech.Shift}");
                }
            }
            Console.WriteLine("Técnicos guardados no ficheiro.");
        }

        // Método para carregar os técnicos de um ficheiro
        private void LoadTechniciansFromFile()
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

                            _technicians.Add(new Operator(id, name, email, shift));
                        }
                    }
                }
            }
        }
    }
}
