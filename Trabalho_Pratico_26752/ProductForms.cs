using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{

    public partial class ProductForms : Form
    {
        // Lista de produtos
        private List<Product> _products;
        // Caminho do ficheiro
        private string _filePath = "products.txt";

        // Método para guardar os produtos num ficheiro
        private void SaveProductsToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var product in _products)
                {
                    writer.WriteLine($"{product.ProductID};{product.Name};{product.Description}");
                }
            }
            Console.WriteLine("Produtos guardados no ficheiro.");
        }

        // Método para carregar os produtos de um ficheiro
        private void LoadProductsFromFile()
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
                            string description = parts[2];

                            _products.Add(new Product(id, name, description));
                        }
                    }
                }
            }
        }

        public ProductForms()
        {
            InitializeComponent();
            _products = new List<Product>(); // Inicia a lista
            LoadProductsFromFile(); // Carrega os dados do ficheiro
            InitializeDataGridView();
        }

        // Método para inicializar o DataGridView com os produtos
        private void InitializeDataGridView()
        {
            dgvProducts.AutoGenerateColumns = true; // Gera automaticamente as colunas
            dgvProducts.DataSource = _products; // Define a fonte de dados
        }

        // Método para atualizar o DataGridView com os produtos
        private void RefreshProductGrid()
        {
            dgvProducts.DataSource = null; // Limpa a fonte de dados
            dgvProducts.DataSource = _products; // Reatribui a lista ao DataGridView
        }

        // Evento de clique para adicionar um novo produto
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var name = Prompt.ShowDialog("Introduza o nome do produto:", "Adicionar Produto");
            var description = Prompt.ShowDialog("Introduza a descrição do produto:", "Adicionar Produto");

            // Verifica se os campos não estão vazios
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                int newId = _products.Count + 1; // Gera um novo ID
                var newProduct = new Product(newId, name, description); // Cria um novo produto
                _products.Add(newProduct); // Adiciona o produto à lista
                RefreshProductGrid(); // Atualiza o DataGridView
                SaveProductsToFile(); // Guarda os produtos no ficheiro

                MessageBox.Show("Produto adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); // Exibe uma mensagem de sucesso
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Exibe uma mensagem de erro
            }
        }

        // Evento de clique para remover um produto
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0) // Verifica se há produtos selecionados
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index; // Obtem o índice do produto selecionado

                // Validação do índice
                if (selectedIndex >= 0 && selectedIndex < _products.Count)
                {
                    _products.RemoveAt(selectedIndex); // Remove o produto da lista
                    RefreshProductGrid(); // Atualiza o DataGridView
                    SaveProductsToFile(); // Guarda os produtos no ficheiro

                    MessageBox.Show("Produto removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); // Exibe uma mensagem de sucesso
                }
                else
                {
                    MessageBox.Show("Índice inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exibe uma mensagem de erro
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Exibe uma mensagem de aviso
            }
        }

        // Método para mostrar informações do produto selecionado
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _products.Count) // Verifica se o índice é válido
            {
                var product = _products[e.RowIndex]; // Obtem o produto selecionado
                MessageBox.Show($"Produto Selecionado:\nID: {product.ProductID}\nNome: {product.Name}\nDescrição: {product.Description}",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information); // Exibe uma mensagem com as informações do produto
            }
        }
    }
}
