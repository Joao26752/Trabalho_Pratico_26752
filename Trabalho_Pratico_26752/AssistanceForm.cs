using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class AssistanceForms : Form
    {
        private List<Assistance> _assistances;
        private string _filePath = "assistances.txt";

        public AssistanceForms()
        {
            InitializeComponent();
            _assistances = new List<Assistance>();
            LoadAssistancesFromFile();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvAssistances.AutoGenerateColumns = true;
            dgvAssistances.DataSource = _assistances;
        }

        private void RefreshAssistanceGrid()
        {
            dgvAssistances.DataSource = null;
            dgvAssistances.DataSource = _assistances;
        }

        private void btnAddAssistance_Click(object sender, EventArgs e)
        {
            var description = Prompt.ShowDialog("Digite a descrição da assistência:", "Adicionar Assistência");

            if (!string.IsNullOrEmpty(description))
            {
                int newId = _assistances.Count + 1;
                var assistance = new Assistance(newId, null, AssistanceType.TechnicalSupport, description);
                _assistances.Add(assistance);
                RefreshAssistanceGrid();
                SaveAssistancesToFile();
            }
            else
            {
                MessageBox.Show("O campo Descrição é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvAssistances_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _assistances.Count)
            {
                var assistance = _assistances[e.RowIndex];
                MessageBox.Show($"Assistência Selecionada:\nID: {assistance.ID}\nDescrição: {assistance.Description}\nEstado: {assistance.Status}",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoveAssistance_Click(object sender, EventArgs e)
        {
            if (dgvAssistances.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvAssistances.SelectedRows[0].Index;

                if (selectedIndex >= 0 && selectedIndex < _assistances.Count)
                {
                    _assistances.RemoveAt(selectedIndex);
                    RefreshAssistanceGrid();
                    SaveAssistancesToFile();
                }
                else
                {
                    MessageBox.Show("Índice inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma assistência para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SaveAssistancesToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var assistance in _assistances)
                {
                    writer.WriteLine($"{assistance.ID};{assistance.Description};{assistance.Status};{assistance.Rating}");
                }
            }
        }

        private void LoadAssistancesFromFile()
        {
            if (File.Exists(_filePath))
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                }
            }
        }
    }
}


