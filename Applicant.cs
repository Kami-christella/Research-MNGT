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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Research_PMS
{
    public partial class Applicant : Form
    {
        public Applicant()
        {
            InitializeComponent();
        }

        public void clearAllData()
        {
            sidTXT.Text = "";
            namestxt.Text = "";
            yeartxt.Text = "";
            gpatxt.Text = "";
            proposaltxt.Text = "";
            searchSID.Text = "";
            projectCOMBO.SelectedItem = null;

        }

        private void applyBTN_Click(object sender, EventArgs e)
        {
            String SID = sidTXT.Text.Trim();
            String Names = namestxt.Text.Trim();
            String year = yeartxt.Text.Trim();
            String GPA = gpatxt.Text.Trim();
            String project = projectCOMBO.SelectedItem?.ToString();
            String research = proposaltxt.Text.Trim();
            
            


            // Convert Score and Semester to integers for comparison
            if (!int.TryParse(year, out int yearValue))
            {
                MessageBox.Show("Invalid Number. Please enter a valid number.");
                return;
            }

            if (yearValue < 3)
            {
                MessageBox.Show("You are not allowed to apply!");
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
                String query = "INSERT INTO Applications VALUES (@sid, @names,@year,@gpa, @project,@research,'PENDING')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@sid", SID);
                cmd.Parameters.AddWithValue("@names", Names);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@gpa", GPA);
                cmd.Parameters.AddWithValue("@project", project);
                cmd.Parameters.AddWithValue("@research", research);

                // Execute query
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                // Check conditions based on score and semester

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Application saved successfully");
                }
                else
                {
                    MessageBox.Show("No data inserted.");
                }
            }
            clearAllData();
        }

        private void updateBTN_Click(object sender, EventArgs e)
        {
            String SID = sidTXT.Text.Trim();
            String Names = namestxt.Text.Trim();
            String year = yeartxt.Text.Trim();
            String GPA = gpatxt.Text.Trim();
            String project = projectCOMBO.SelectedItem?.ToString();
            String research = proposaltxt.Text.Trim();


            // Convert Score and Semester to integers for comparison
            if (!int.TryParse(year, out int yearValue))
            {
                MessageBox.Show("Invalid Number. Please enter a valid number.");
                return;
            }

            if (yearValue < 3)
            {
                MessageBox.Show("You are not allowed to apply!");
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
                String query = "UPDATE  Applications SET FullName=@names,YearOfStudy=@year,GPA=@gpa,ProjectOfInterest=@project,Description=@research where SID=@sid";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@sid", SID);
                cmd.Parameters.AddWithValue("@names", Names);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@gpa", GPA);
                cmd.Parameters.AddWithValue("@project", project);
                cmd.Parameters.AddWithValue("@research", research);

                // Execute query
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                // Check conditions based on score and semester

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Application updated successfully");
                }
                else
                {
                    MessageBox.Show("No data updated.");
                }
            }
            clearAllData();
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            //  String SID = positionCombo.SelectedItem?.ToString();
            String SID = searchSID.Text.Trim();



            //if (string.IsNullOrEmpty(position) && string.IsNullOrEmpty(description))
            //{
            //    MessageBox.Show("Please insert value.");
            //    return;
            //}



            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
            String query = "Delete from  Applications where SID=@SID";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SID", SID);

            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Application  deleted!");
                //this.Hide();
                //Form1 lo = new Form1();
                //lo.Show();
            }
            else
            {
                MessageBox.Show("Application not  deleted");
            }
            clearAllData();
        }
        private void viewStatus_Click(object sender, EventArgs e)
        {
            String SID = searchSID.Text.Trim();

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True"))
            {
                String query = "SELECT Status FROM Applications WHERE SID = @SID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SID", SID);

                conn.Open();

                // Use ExecuteReader to get the status
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Check if there is at least one result
                    {
                        // Assuming status is a string column in your database
                        string status = reader["Status"].ToString();
                        MessageBox.Show(status);
                        // Optionally: this.Hide();
                        // Form1 lo = new Form1();
                        // lo.Show();
                    }
                    else
                    {
                        MessageBox.Show("Not ID Found");
                    }
                }
            }
            clearAllData();
        }


    }
}
