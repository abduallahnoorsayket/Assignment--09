
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CutomerInfoCT_02.Model;



namespace CutomerInfoCT_02.Repository
{
   public class CustomerRepository
    {


        public bool Add(Customer customer)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CustomerInfo; Integrated Security=True";
                // string connectionString = @"Server=PC-301-10\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO CustomerInfo (Code,Did,Name,Address,Contact) Values ('" + customer.Code + "','" + customer.Did + "','" + customer.Name + "', '" + customer.Address + "' ,  " + customer.Contact + " )";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //if (!isNameExists(nameTextBox.Text))
                //{
                //    //Insert
                //    int isExecuted = sqlCommand.ExecuteNonQuery();
                //    if (isExecuted > 0)
                //    {
                //        isAdded = true;
                //    }

                //}
                //else
                //{
                //    MessageBox.Show(nameTextBox.Text + "Already Exists!");
                //}


                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return isAdded;
        }



        public bool IsCodeExists(string code)
        {
            bool exists = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CustomerInfo; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM CustomerInfo WHERE Code='" + code + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return exists;
        }


        public bool IsContactExists(string contact)
        {
            bool exists = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CustomerInfo; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM CustomerInfo WHERE Contact='" + contact + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return exists;
        }




        public List<Customer> Display()
        {

            List<Customer> customers = new List<Customer>();

            //Connection
            string connectionString = @"Server=DESKTOP-LQ035EB; Database=CustomerInfo; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM CustomerInfo";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                 Customer customer= new Customer();
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Did = Convert.ToInt32(sqlDataReader["Did"]);
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                //item.Id = Convert.ToInt32(sqlDataReader["Id"]);
                customer.Contact = Convert.ToDouble(sqlDataReader["Contact"]);

                customers.Add(customer);
               // items.Add(item);
            }

           //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            //DataTable dataTable = new DataTable();
            //sqlDataAdapter.Fill(dataTable);


            //if (dataTable.Rows.Count > 0)
            //{
            //    return dataTable;
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    MessageBox.Show("No Data Found");
            //}

            //Close

            sqlConnection.Close();


            return customers;

        }



        public List<Customer> Search(string code)
        {
            //DataTable dataTable = new DataTable();
            List<Customer> customers = new List<Customer>();
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LQ035EB; Database=CustomerInfo; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM CustomerInfo WHERE Code='" + code + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();



                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Customer customer = new Customer();
                    customer.Code = sqlDataReader["Code"].ToString();
                    customer.Did = Convert.ToInt32(sqlDataReader["Did"]);
                    customer.Name = sqlDataReader["Name"].ToString();
                    customer.Address = sqlDataReader["Address"].ToString();
                    customer.Contact = Convert.ToDouble(sqlDataReader["Contact"]);

                    customers.Add(customer);
              }

                // SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                // DataTable dataTable = new DataTable();
                // sqlDataAdapter.Fill(dataTable);


                //if (dataTable.Rows.Count > 0)
                //{
                //    return true;
                //    //showDataGridView.DataSource = dataTable;
                //}
                //else
                //{
                //    MessageBox.Show("No Data Found");
                //}

                //Close
                sqlConnection.Close();

            }

            catch (Exception exeption)
            {
                // MessageBox.Show(exeption.Message);
            }


            return customers;
        }


        public List<Customer> DistrictCombo()
        {

            //List<Customer> customers = new List<Customer>();

            List<DistrictInfo> districts = new List<DistrictInfo>();

            //Connection
            string connectionString = @"Server=DESKTOP-LQ035EB; Database=CustomerInfo; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM District";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                DistrictInfo district = new DistrictInfo();

                district.District = sqlDataReader["District"].ToString();
                //Customer customer = new Customer();
                //customer.Code = sqlDataReader["Code"].ToString();
                //customer.Did = Convert.ToInt32(sqlDataReader["Did"]);
                //customer.Name = sqlDataReader["Name"].ToString();
                //customer.Address = sqlDataReader["Address"].ToString();
                //customer.Contact = Convert.ToDouble(sqlDataReader["Contact"]);

                //customers.Add(customer);



            }
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            //DataTable dataTable = new DataTable();
            //sqlDataAdapter.Fill(dataTable);
           //if (dataTable.Rows.Count > 0)
            //{
            //    return dataTable;
            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    MessageBox.Show("No Data Found");
            //}

            //Close

            sqlConnection.Close();


            return districts;

        }





    }
}
