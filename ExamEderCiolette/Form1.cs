using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace ExamEderCiolette
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source = INSTRUCTORIT; Initial Catalog = PhoneBook; " +
                                  "User ID = ProfileUser; Password = ProfileUser2019";
        private IEnumerable<object> query;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();
                string mySql = "INSERT INTO Contact (FirstName, LastName, Phone, Email) " +
                                " VALUES ('" + txtFirstName.Text + "','" + txtLastName.Text + "'," +
                                " '" + txtPhone.Text + "','" + txtEmail.Text + "')";

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                myCommand.ExecuteNonQuery();

                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                MessageBox.Show("Successfully Saved", "Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail");
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                string mySql = "DELETE FROM Contact WHERE ID = " + txtDelete.Text;

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                myCommand.ExecuteNonQuery();

                btnDelete.Text = "";
                MessageBox.Show("Successfully Deleted", "Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail");
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                string mySql = "UPDATE Contact SET FirstName = '" + txtFirstNameUp.Text + "', LastName = '" + txtLastNameUp.Text + "', Phone = '" + txtPhoneUp.Text + "', Email = '" + txtEmailUp.Text + "'" +
                "WHERE ID = '" + txtIdUp.Text + "'";

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                myCommand.ExecuteNonQuery();

                txtIdUp.Text = "";
                txtFirstNameUp.Text = "";
                txtLastNameUp.Text = "";
                txtPhoneUp.Text = "";
                txtEmailUp.Text = "";
                MessageBox.Show("Successfully Update", "Update");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail");
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {

            StreamWriter sw = File.CreateText(@"C:\temp\EderCiolette.txt");
            {
                SqlConnection myConnection = new SqlConnection(connectionString);

                try
                {
                    myConnection.Open();

                    SqlCommand myCommand = new SqlCommand();

                    string mySql = "SELECT * FROM Contact";

                    myCommand.Connection = myConnection;
                    myCommand.CommandText = mySql;

                    myCommand.ExecuteNonQuery();

                    MessageBox.Show("Successfully Backup", "Backup");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fail");
                }
                finally
                {
                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Close();
                }

            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                string mySql = "SELECT * FROM Contact";

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                SqlDataReader myReader;
                myReader = myCommand.ExecuteReader();

                DataTable myTable = new DataTable();
                myTable.Columns.Add("ID");
                myTable.Columns.Add("FirstName");
                myTable.Columns.Add("LastName");
                myTable.Columns.Add("Phone");
                myTable.Columns.Add("Email");


                while (myReader.Read())
                {
                    DataRow contact = myTable.NewRow();

                    contact["ID"] = myReader["ID"].ToString();
                    contact["FirstName"] = myReader["FirstName"].ToString();
                    contact["LastName"] = myReader["LastName"].ToString();
                    contact["Phone"] = myReader["Phone"].ToString();
                    contact["Email"] = myReader["Email"].ToString();

                    myTable.Rows.Add(contact);

                }

                gridResults.DataSource = myTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail!");
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }
        }

        private void BtnLinq_Click(object sender, EventArgs e)
        {
            
            //var results = from p in Contact 
            //              where p.LastName == "'SMITH'"
            //              select p;

            //foreach (var l in query)
            //{
            //    gridResults.Text = int.Parse(results.ToString());
            //}


        }
    }
}

