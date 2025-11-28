using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_GUI
{
    public partial class Form1 : Form
    {
        // Lists to store objects
        private List<Customer> customerList = new List<Customer>();
        private List<Product> productList = new List<Product>();


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCustID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (!int.TryParse(txtCustID.Text, out int id))
            {
                MessageBox.Show("Please enter a valid number for Customer ID.");
                return;
            }

            string name = txtCustName.Text;
            string email = txtCustEmail.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Name and Email cannot be empty.");
                return;
            }

            // Create object
            Customer c = new Customer(id, name, email);

            // Store in list
            customerList.Add(c);

            // Show in ListBox
            lstCustomers.Items.Add(c.DisplayInfo());

            // Optional: clear inputs
            txtCustID.Clear();
            txtCustName.Clear();
            txtCustEmail.Clear();
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
