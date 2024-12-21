namespace Trabalho_Pratico_26752
{
    partial class UsersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnRemoveUser;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();

            // dgvUsers
            this.dgvUsers.Location = new System.Drawing.Point(12, 12);
            this.dgvUsers.Size = new System.Drawing.Size(760, 250);
            this.dgvUsers.ReadOnly = true;

            // btnAddUser
            this.btnAddUser.Location = new System.Drawing.Point(12, 280);
            this.btnAddUser.Size = new System.Drawing.Size(200, 40);
            this.btnAddUser.Text = "Adicionar Utilizador";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);

            // btnRemoveUser
            this.btnRemoveUser.Location = new System.Drawing.Point(250, 280);
            this.btnRemoveUser.Size = new System.Drawing.Size(200, 40);
            this.btnRemoveUser.Text = "Remover Utilizador";
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);

            // UsersForm
            this.ClientSize = new System.Drawing.Size(784, 341);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnRemoveUser);
            this.Text = "Gestão de Utilizadores";
        }
    }
}
