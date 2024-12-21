using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class CustomerForms : Form
    {
        private List<Customer> _customers;
        private string _filePath = "customers.txt";

        public CustomerForms()
        {
            InitializeComponent();
            _customers = new List<Customer>(); // Inicia a lista
            LoadCustomersFromFile();           // Carrega os dados do ficheiro
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = true;
            dgvCustomers.DataSource = _customers; // Conecta a lista ao DataGridView
        }

        private void RefreshCustomersGrid()
        {
            dgvCustomers.DataSource = null;  // Limpa a fonte de dados
            dgvCustomers.DataSource = _customers; // Reatribui a lista ao DataGridView
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var name = Prompt.ShowDialog("Digite o nome do cliente:", "Adicionar Cliente");
            var email = Prompt.ShowDialog("Digite o email do cliente:", "Adicionar Cliente");

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
            {
                int newId = _customers.Count + 1;
                _customers.Add(new Customer(newId, name, email));
                RefreshCustomersGrid();
                SaveCustomersToFile();
            }
            else
            {
                MessageBox.Show("Os campos Nome e Email são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvCustomers.SelectedRows[0].Index;

                // Validação do índice
                if (selectedIndex >= 0 && selectedIndex < _customers.Count)
                {
                    _customers.RemoveAt(selectedIndex); // Remove o cliente
                    RefreshCustomersGrid();
                    SaveCustomersToFile();
                }
                else
                {
                    MessageBox.Show("Índice inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvCustomers.SelectedRows[0].Index;

                if (selectedIndex >= 0 && selectedIndex < _customers.Count)
                {
                    var customer = _customers[selectedIndex];

                    var newName = Prompt.ShowDialog("Digite o novo nome:", "Atualizar Cliente");
                    var newEmail = Prompt.ShowDialog("Digite o novo email:", "Atualizar Cliente");

                    if (!string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(newEmail))
                    {
                        customer.Name = newName;
                        customer.Email = newEmail;

                        RefreshCustomersGrid();
                        SaveCustomersToFile();
                        MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Os campos Nome e Email são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validação para garantir que o índice é válido
            if (e.RowIndex >= 0 && e.RowIndex < _customers.Count)
            {
                var customer = _customers[e.RowIndex];
                MessageBox.Show($"Cliente Selecionado:\nID: {customer.ID}\nNome: {customer.Name}\nEmail: {customer.Email}",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveCustomersToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var customer in _customers)
                {
                    writer.WriteLine($"{customer.ID};{customer.Name};{customer.Email}");
                }
            }
        }

        private void LoadCustomersFromFile()
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
                            string name = parts[1];
                            string email = parts[2];
                            _customers.Add(new Customer(id, name, email));
                        }
                    }
                }
            }
        }
    }
}
