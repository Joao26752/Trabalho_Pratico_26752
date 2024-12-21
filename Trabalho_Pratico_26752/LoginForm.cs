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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var user = _users.Find(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                MessageBox.Show($"Bem-vindo, {user.Username}! Perfil: {user.Role}", "Login Bem-sucedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var mainForm = new mainform(user.Role);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Utilizador ou palavra-passe incorretos!", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
