using System;
using System.Windows.Forms;

namespace Trabalho_Pratico_26752
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent(); // Inicializa os componentes do formulário
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForms();
            customerForm.Show();
        }

        private void btnManageAssistances_Click(object sender, EventArgs e)
        {
            var assistanceForm = new AssistanceForms();
            assistanceForm.Show();
        }

        private void btnManageOperators_Click(object sender, EventArgs e)
        {
            var operatorForm = new OperatorForms();
            operatorForm.Show();
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForms();
            productForm.Show();
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new ReportsForm(new System.Collections.Generic.List<Classes.Assistance>(), new System.Collections.Generic.List<Classes.KnownProblem>());
            reportsForm.Show();
        }
    }
}

