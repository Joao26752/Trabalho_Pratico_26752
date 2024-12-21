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

        private void InitializeDataGridView()
        {
            dgvTechnicians.AutoGenerateColumns = true;
            dgvTechnicians.DataSource = _technicians;
        }

        private void RefreshTechnicianGrid()
        {
            dgvTechnicians.DataSource = null;
            dgvTechnicians.DataSource = _technicians;
        }

        private void btnAddTechnician_Click(object sender, EventArgs e)
        {
            var name = Prompt.ShowDialog("Digite o nome do técnico:", "Adicionar Técnico");
            var email = Prompt.ShowDialog("Digite o email do técnico:", "Adicionar Técnico");
            var shift = Prompt.ShowDialog("Digite o turno do técnico:", "Adicionar Técnico");

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(shift))
            {
                int newId = _technicians.Count + 1;
                _technicians.Add(new Operator(newId, name, email, shift));
                RefreshTechnicianGrid();
                SaveTechniciansToFile();
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveTechnician_Click(object sender, EventArgs e)
        {
            if (dgvTechnicians.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvTechnicians.SelectedRows[0].Index;

                if (selectedIndex >= 0 && selectedIndex < _technicians.Count)
                {
                    _technicians.RemoveAt(selectedIndex);
                    RefreshTechnicianGrid();
                    SaveTechniciansToFile();
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

        private void SaveTechniciansToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var technician in _technicians)
                {
                    writer.WriteLine($"{technician.ID};{technician.Name};{technician.Email};{technician.Shift}");
                }
            }
        }

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
