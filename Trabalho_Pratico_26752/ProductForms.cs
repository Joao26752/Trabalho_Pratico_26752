using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{

    public partial class ProductForms : Form
    {
        
     private string _filePath = "products.txt";

        private void SaveProductsToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var product in _products)
                {
                    writer.WriteLine($"{product.ProductID};{product.Name};{product.Description}");
                }
            }
        }

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
                            _products.Add(new Product { ProductID = id, Name = name, Description = description });
                        }
                    }
                }
            }
        }

        private List<Product> _products;

        public ProductForms()
        {
            InitializeComponent();
            _products = new List<Product>();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvProducts.AutoGenerateColumns = true;
            dgvProducts.DataSource = _products;
        }

        private void RefreshProductGrid()
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _products;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var name = Prompt.ShowDialog("Digite o nome do produto:", "Adicionar Produto");
            var description = Prompt.ShowDialog("Digite a descrição do produto:", "Adicionar Produto");

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                int newId = _products.Count + 1;
                _products.Add(new Product { ProductID = newId, Name = name, Description = description });
                RefreshProductGrid();
            }
            else
            {
                MessageBox.Show("Os campos Nome e Descrição são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _products.Count)
            {
                var product = _products[e.RowIndex];
                MessageBox.Show($"Produto Selecionado:\nID: {product.ProductID}\nNome: {product.Name}\nDescrição: {product.Description}",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvProducts.SelectedRows[0].Index;

                if (selectedIndex >= 0 && selectedIndex < _products.Count)
                {
                    _products.RemoveAt(selectedIndex);
                    RefreshProductGrid();
                    SaveProductsToFile();
                }
                else
                {
                    MessageBox.Show("Índice inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
