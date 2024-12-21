using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public partial class CustomerForms : Form
    {
        // Lista de clientes
        private List<Customer> _customers;
        // Caminho do ficheiro
        private string _filePath = "customers.txt";

        public CustomerForms()
        {
            InitializeComponent();
            // Inicia a lista
            _customers = new List<Customer>();
            // Carrega os dados do ficheiro
            LoadCustomersFromFile();
            InitializeDataGridView();
        }

        // Método para inicializar o DataGridView com os clientes
        private void InitializeDataGridView()
        {
            // Ativa a geração automática de colunas
            dgvCustomers.AutoGenerateColumns = true;
            // Define a fonte de dados
            dgvCustomers.DataSource = _customers;

            // Permitir ordenação em todas as colunas
            foreach (DataGridViewColumn column in dgvCustomers.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        // Método para atualizar o DataGridView com os clientes
        private void RefreshCustomersGrid()
        {
            // Limpa a fonte de dados
            dgvCustomers.DataSource = null;
            // Reatribui a lista ao DataGridView
            dgvCustomers.DataSource = _customers;
        }

        // Evento de clique para adicionar um novo cliente
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // Solicita o nome do cliente
            var name = Prompt.ShowDialog("Introduza o nome do cliente:", "Adicionar Cliente");
            // Solicita o endereço de e-mail do cliente
            var email = Prompt.ShowDialog("Introduza o endereço de e-mail do cliente:", "Adicionar Cliente");

            // Verifica se os campos não estão vazios
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
            {
                // Gera um novo ID
                int newId = _customers.Count + 1;
                // Cria um novo cliente
                var newCustomer = new Customer(newId, name, email);
                // Adiciona o cliente à lista
                _customers.Add(newCustomer);
                // Atualiza o DataGridView
                RefreshCustomersGrid();
                // Guarda os clientes no ficheiro
                SaveCustomersToFile();

                // Exibe uma mensagem de sucesso
                MessageBox.Show("Cliente adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Exibe uma mensagem de erro
                MessageBox.Show("Todos os campos são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento de clique para remover um cliente
        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            // Verifica se há clientes selecionados
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                // Obtem o índice do cliente selecionado
                int selectedIndex = dgvCustomers.SelectedRows[0].Index;

                // Validação do índice
                if (selectedIndex >= 0 && selectedIndex < _customers.Count)
                {
                    // Remove o cliente da lista
                    _customers.RemoveAt(selectedIndex);
                    // Atualiza o DataGridView
                    RefreshCustomersGrid();
                    // Guarda os clientes no ficheiro
                    SaveCustomersToFile();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Cliente removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Exibe uma mensagem de erro
                    MessageBox.Show("Índice inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Exibe uma mensagem de aviso
                MessageBox.Show("Selecione um cliente para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para guardar os clientes num ficheiro
        private void SaveCustomersToFile()
        {
            // Cria um StreamWriter para escrever no ficheiro
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                // Itera sobre a lista de clientes
                foreach (var customer in _customers)
                {
                    // Escreve as informações do cliente no ficheiro
                    writer.WriteLine($"{customer.ID};{customer.Name};{customer.Email}");
                }
            }
            // Exibe uma mensagem no console
            Console.WriteLine("Clientes guardados no ficheiro.");
        }

        // Método para carregar os clientes de um ficheiro
        private void LoadCustomersFromFile()
        {
            // Verifica se o ficheiro existe
            if (File.Exists(_filePath))
            {
                // Cria um StreamReader para ler do ficheiro
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    // Itera sobre as linhas do ficheiro
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Divide a linha em partes
                        var parts = line.Split(';');
                        // Verifica se a linha tem as informações necessárias
                        if (parts.Length == 3)
                        {
                            // Converte o ID para inteiro
                            int id = int.Parse(parts[0]);
                            // Obtem o nome e o endereço de e-mail
                            string name = parts[1];
                            string email = parts[2];

                            // Cria um novo cliente e adiciona à lista
                            _customers.Add(new Customer(id, name, email));
                        }
                    }
                }
            }
        }

        // Evento de clique para atualizar um cliente
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            // Verifica se há clientes selecionados
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                // Obtem o índice do cliente selecionado
                int selectedIndex = dgvCustomers.SelectedRows[0].Index;

                // Validação do índice
                if (selectedIndex >= 0 && selectedIndex < _customers.Count)
                {
                    // Obtem o cliente selecionado
                    var customer = _customers[selectedIndex];

                    // Solicita o novo nome do cliente
                    var newName = Prompt.ShowDialog("Introduza o novo nome:", "Atualizar Cliente");
                    // Solicita o novo endereço de e-mail do cliente
                    var newEmail = Prompt.ShowDialog("Introduza o novo endereço de e-mail:", "Atualizar Cliente");

                    // Verifica se os campos não estão vazios
                    if (!string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(newEmail))
                    {
                        // Atualiza as informações do cliente
                        customer.Name = newName;
                        customer.Email = newEmail;

                        // Atualiza o DataGridView
                        RefreshCustomersGrid();
                        // Guarda os clientes no ficheiro
                        SaveCustomersToFile();

                        // Exibe uma mensagem de sucesso
                        MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Exibe uma mensagem de erro
                        MessageBox.Show("Os campos Nome e Endereço de E-mail são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Exibe uma mensagem de aviso
                MessageBox.Show("Selecione um cliente para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento de clique em uma célula do DataGridView
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validação para garantir que o índice é válido
            if (e.RowIndex >= 0 && e.RowIndex < _customers.Count)
            {
                // Obtem o cliente selecionado
                var customer = _customers[e.RowIndex];
                // Exibe uma mensagem com as informações do cliente
                MessageBox.Show($"Cliente Selecionado:\nID: {customer.ID}\nNome: {customer.Name}\nEndereço de E-mail: {customer.Email}",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento de clique para procurar clientes
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Obtem o termo de pesquisa
            string searchTerm = txtSearch.Text.ToLower();
            // Filtra a lista de clientes
            var filteredCustomers = _customers.Where(c => c.Name.ToLower().Contains(searchTerm) || c.Email.ToLower().Contains(searchTerm)).ToList();
            // Atualiza o DataGridView
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = filteredCustomers;
        }
    }
}
