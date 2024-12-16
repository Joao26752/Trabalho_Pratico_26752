namespace Trabalho_Pratico_26752
{
    partial class ProductForms
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnAddProduct;

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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // dgvProducts
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 12);
            this.dgvProducts.Size = new System.Drawing.Size(600, 300);

            // btnAddProduct
            this.btnAddProduct.Location = new System.Drawing.Point(630, 50);
            this.btnAddProduct.Size = new System.Drawing.Size(150, 40);
            this.btnAddProduct.Text = "Adicionar Produto";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);

            // ProductForms
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnAddProduct);
            this.Text = "Gestão de Produtos";
            this.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
        }
    }
}
