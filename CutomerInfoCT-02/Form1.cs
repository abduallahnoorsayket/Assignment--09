using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CutomerInfoCT_02.BLL;
using CutomerInfoCT_02.Model;

namespace CutomerInfoCT_02
{
    public partial class CustomerInfo : Form

    {
         CustomerManager _customerManager = new CustomerManager();

        Customer _customer = new Customer();

        public CustomerInfo()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            //Set  Mandatory
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("contact Can not be Empty!!!");
                return;
            }




            if (codeTextBox.Text.Length != 4)
                //if (_customer.Code.Length != 4)
            {
                MessageBox.Show("Code  must be 4 char!");
                return;
            }

            if (contactTextBox.Text.Length != 11)
            // if (_customer.Contact.Length != 11)
            {
                MessageBox.Show(" Contact must be 11 char!");
                return;
            }



            //Check UNIQUE
            _customer.Code = codeTextBox.Text;

            if (_customerManager.IsCodeExists(_customer.Code))
            {
                MessageBox.Show(codeTextBox.Text + "Already Exists!");
                return;
            }

            _customer.Contact = Convert.ToDouble(contactTextBox.Text);

            if (_customerManager.IsContactExists(contactTextBox.Text))
            {
                MessageBox.Show(contactTextBox.Text + "Already Exists!");
                return;
            }

            //Set Price as Mandatory
            //Add/Insert Item
            // bool isAdded = _itemManager.Add(_item.Name,_item.Price);
            _customer.Name = nameTextBox.Text;
            _customer.Address = addressTextBox.Text;
            _customer.Did = Convert.ToInt32(districtComboBox.Text);

            bool isAdded = _customerManager.Add(_customer);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            //showDataGridView.DataSource = dataTable;
            dataGridView.DataSource = _customerManager.Display();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code  Can not be Empty!!!");
                return;
            }


         dataGridView.DataSource = _customerManager.Search(codeTextBox.Text);

   }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView.Rows[e.RowIndex].Cells["Slno"].Value = (e.RowIndex + 1).ToString();
            
        }



        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            districtComboBox.DataSource = _customerManager.DistrictCombo();
        }



        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CurrentRow.Selected = true;
            codeTextBox.Text = dataGridView.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
            nameTextBox.Text = dataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
            addressTextBox.Text = dataGridView.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
            contactTextBox.Text = dataGridView.Rows[e.RowIndex].Cells["Contact"].FormattedValue.ToString();
            saveButton.Text = "update";

        }





    }
}

