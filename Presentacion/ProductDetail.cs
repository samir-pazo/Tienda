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
    public partial class ProductDetail : Form
    {

        public string Operation { get; set; }

        public Product ProductUpdate { get; set; }

        public ProductDetail()
        {
            InitializeComponent();
        }

        private void ProductDetail_Load(object sender, EventArgs e)
        {
            LCategory lCategory = new LCategory();
            List<Category> listCate = lCategory.GetAll();
            cboCategory.DataSource = listCate;
            cboCategory.DisplayMember = nameof(Category.CategoryName);
            cboCategory.ValueMember = nameof(Category.CategoryId);

            if (Operation == "UPDATE_PRODUCT")
            {
                txtId.Text = ProductUpdate.ProductId.ToString();
                txtProductName.Text = ProductUpdate.ProductName;
                nudPrice.Value = Convert.ToDecimal(ProductUpdate.Price.ToString());
                nudStock.Value = Convert.ToDecimal(ProductUpdate.Stock.ToString());
                cboCategory.SelectedValue = ProductUpdate.CategoryId;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Product product = new Product();

            product.ProductName = txtProductName.Text.Trim();
            product.Price = nudPrice.Value;
            product.Stock = nudStock.Value;
            product.CategoryId = Convert.ToInt32(cboCategory.SelectedValue.ToString());

            //validacion

            if (product.ProductName.Length < 5)
            {
                txtProductName.Focus();
                MessageBox.Show("Nombre del Producto Obligatorio", "Mensaje");
                return;
            }


            LProduct lProduct = new LProduct();
            bool answer = false;


            if (Operation == "UPDATE_PRODUCT")
            {
                //se va a actualizar el registro
                product.ProductId = Convert.ToInt32(txtId.Text.Trim());
                answer = lProduct.Update(product);
            }
            else
            {
                //un registro nuevo
                answer = lProduct.Register(product);
            }


            if (!answer)
            {
                MessageBox.Show("Ocurrio un Error", "Mensaje");
                return;
            }


            MessageBox.Show("La Operacion se Realizo con exito.", "Mensaje");
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }
}
