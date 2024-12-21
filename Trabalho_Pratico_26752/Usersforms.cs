using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Trabalho_Pratico_26752
{
    public partial class UsersForm : Form
    {
        private List<User> _users;
        private string _filePath = "users.txt";

        public UsersForm()
        {
            InitializeComponent();
            _users = LoadUsersFromFile();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgvUsers.AutoGenerateColumns = true;
            dgvUsers.DataSource = _users;
        }

        private List<User> LoadUsersFromFile()
        {
            var users = new List<User>();

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
                            string username = parts[0];
                            string password = parts[1];
                            string role = parts[2];
                            users.Add(new User(username, password, role));
                        }
                    }
                }
            }

            return users;
        }

        private void SaveUsersToFile()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var user in _users)
                {
                    writer.WriteLine($"{user.Username};{user.Password};{user.Role}");
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var username = Prompt.ShowDialog("Digite o nome do utilizador:", "Adicionar Utilizador");
            var password = Prompt.ShowDialog("Digite a palavra-passe:", "Adicionar Utilizador");
            var role = Prompt.ShowDialog("Digite o papel (Admin, Technician, Client):", "Adicionar Utilizador");

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(role))
            {
                _users.Add(new User(username, password, role));
                RefreshUserGrid();
                SaveUsersToFile();
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvUsers.SelectedRows[0].Index;
                _users.RemoveAt(selectedIndex);
                RefreshUserGrid();
                SaveUsersToFile();
            }
            else
            {
                MessageBox.Show("Selecione um utilizador para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshUserGrid()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _users;
        }
    }
}
