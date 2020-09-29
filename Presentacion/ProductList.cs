using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class ProductList : Form
    {
        private LProduct lProduct;
        public ProductList()
        {
            InitializeComponent();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            lProduct = new LProduct();

            ShowProducts(lProduct.GetAll());

        }


        public void ShowProducts(List<Product> listProduct)
        {
            gvProducts.DataSource = listProduct;
            gvProducts.AllowUserToAddRows = false;
            gvProducts.AllowUserToDeleteRows = false;
            gvProducts.AllowUserToOrderColumns = false;
            gvProducts.AllowUserToResizeRows = false;

            gvProducts.RowHeadersVisible = false;

            gvProducts.Columns[0].HeaderText = "ID";
            gvProducts.Columns[0].DataPropertyName = nameof(Product.ProductId);
            gvProducts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[0].Visible = true;

            gvProducts.Columns[1].HeaderText = "Nombre del Producto";
            gvProducts.Columns[1].DataPropertyName = nameof(Product.ProductName);
            gvProducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gvProducts.Columns[1].Visible = true;

            gvProducts.Columns[2].HeaderText = "Precio";
            gvProducts.Columns[2].DataPropertyName = nameof(Product.Price);
            gvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[2].Visible = true;

            gvProducts.Columns[3].HeaderText = "Stock";
            gvProducts.Columns[3].DataPropertyName = nameof(Product.Stock);
            gvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[3].Visible = true;

            gvProducts.Columns[4].HeaderText = "Categoria";
            gvProducts.Columns[4].DataPropertyName = nameof(Product.CategoryName);
            gvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[4].Visible = true;

            gvProducts.Columns[5].HeaderText = "ID CATEGORIA";
            gvProducts.Columns[5].DataPropertyName = nameof(Product.CategoryId);
            gvProducts.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gvProducts.Columns[5].Visible = false;

            gvProducts.RowsDefaultCellStyle.BackColor = Color.White;
            gvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.Wheat;

            gvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvProducts.MultiSelect = false;


        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            ProductDetail productDetail = new ProductDetail();
            DialogResult dialogResult = productDetail.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                //refresh
                ShowProducts(lProduct.GetAll());
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (gvProducts.SelectedRows.Count <= 0)
            {
                return;
            }

            Product product = new Product();
            product.ProductId = Convert.ToInt32(gvProducts.CurrentRow.Cells[nameof(Product.ProductId)].Value.ToString());
            product.ProductName = gvProducts.CurrentRow.Cells[nameof(Product.ProductName)].Value.ToString();
            product.Price = Convert.ToDecimal(gvProducts.CurrentRow.Cells[nameof(Product.Price)].Value.ToString());
            product.Stock = Convert.ToDecimal(gvProducts.CurrentRow.Cells[nameof(Product.Stock)].Value.ToString());
            product.CategoryId = Convert.ToInt32(gvProducts.CurrentRow.Cells[5].Value.ToString());


            ProductDetail productDetail = new ProductDetail();
            productDetail.Operation = "UPDATE_PRODUCT";
            productDetail.ProductUpdate = product;

            DialogResult dialogResult = productDetail.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                //refresh
                ShowProducts(lProduct.GetAll());
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (gvProducts.SelectedRows.Count <= 0)
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Desea eliminar el Producto?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dialogResult == DialogResult.Yes)
            {
                int productId = Convert.ToInt32(gvProducts.CurrentRow.Cells[nameof(Product.ProductId)].Value.ToString());

                
                bool answer = lProduct.Delete(productId);
                if (answer)
                {
                    MessageBox.Show("Se elimino el Producto", "Mensaje");
                    ShowProducts(lProduct.GetAll());
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ShowProducts(lProduct.GetByName(txtFilter.Text.Trim()));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowProducts(lProduct.GetAll());
        }
    }
}
