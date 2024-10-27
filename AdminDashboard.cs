using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Research_PMS
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        public void clearAllData()
        {
            idtxt.Text = "";
            comboBox1.SelectedItem = null;

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
           
            String query = "SELECT * FROM Applications";

            try
            {
                // Open connection
                conn.Open();

                // Create the SqlDataAdapter to execute the query and fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query result
                adapter.Fill(dataTable);

                // Bind the data to the DataGridView control
                dataGridView1.DataSource = dataTable;

                MessageBox.Show("Applicants listed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
            finally
            {
                // Close the connection
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String SID = idtxt.Text.Trim();
         String status= comboBox1.Text.Trim();


            // Convert Score and Semester to integers for comparison
            if (!int.TryParse(SID, out int yearValue))
            {
                MessageBox.Show("Invalid Number. Please enter a valid number.");
                return;
            }

            if (yearValue < 0)
            {
                MessageBox.Show("You are not allowed to apply!");
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
                String query = "UPDATE  Applications SET Status=@status where SID=@sid";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@sid", SID);
                cmd.Parameters.AddWithValue("@status", status);

                // Execute query
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                // Check conditions based on score and semester

                if (rowsAffected > 0)
                {
                    MessageBox.Show("status updated successfully");
                }
                else
                {
                    MessageBox.Show("No data updated.");
                }
            }
            clearAllData();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
            // SQL query to select all applicants from the Application table
            String query = "SELECT * FROM Projects";

            try
            {
                // Open connection
                conn.Open();

                // Create the SqlDataAdapter to execute the query and fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query result
                adapter.Fill(dataTable);

                // Bind the data to the DataGridView control
                dataGridView1.DataSource = dataTable;

                MessageBox.Show("Applicants listed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
            finally
            {
                // Close the connection
                conn.Close();
            }
        }
    }
}
