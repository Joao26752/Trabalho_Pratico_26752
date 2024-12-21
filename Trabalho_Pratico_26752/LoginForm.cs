using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Trabalho_Pratico_26752
{
    public partial class LoginForm : Form
    {
        private List<User> _users;

        public LoginForm()
        {
            InitializeComponent();
            _users = LoadUsersFromFile();
        }

        // Método para carregar os utilizadores de um ficheiro
        private List<User> LoadUsersFromFile()
        {
            var users = new List<User>();
            string filePath = "users.txt";

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
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

        // Evento de clique para efetuar o login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Verifica se o utilizador existe e a palavra-passe está correta
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Proceder para o próximo formulário ou funcionalidade
            }
            else
            {
                MessageBox.Show("Nome de utilizador ou palavra-passe inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class User
    {
        public string Username { get; }
        public string Password { get; }
        public string Role { get; }

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
