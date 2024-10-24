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
    public partial class Projects : Form
    {
        public Projects()
        {
            InitializeComponent();
        }

        private void createBTN_Click(object sender, EventArgs e)
        {
            String title = titleTXT.Text.Trim();
            String description = descrTXT.Text.Trim();
            String duration = durationTXT.Text.Trim();
            String skills = skillsTXT.Text.Trim();
            String year = yearTXT.Text.Trim();

            // Convert Score and Semester to integers for comparison
            if (year==null)
            {
                MessageBox.Show("please enter value");
                return;
            }

           
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
                String query = "INSERT INTO Projects VALUES (@title, @description,@duration,@skills, @year)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@skills", skills);  
                cmd.Parameters.AddWithValue("@year", year);       

                // Execute query
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                // Check conditions based on score and semester

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Project saved successfull");
                }
                else
                {
                    MessageBox.Show("No data inserted.");
                }
            }
        }

        private void editBTN_Click(object sender, EventArgs e)
        {
            String title = titleTXT.Text.Trim();
            String description = descrTXT.Text.Trim();
            String duration = durationTXT.Text.Trim();
            String skills = skillsTXT.Text.Trim();
            String year = yearTXT.Text.Trim();

            // Convert Score and Semester to integers for comparison
            if (year == null)
            {
                MessageBox.Show("please enter value");
                return;
            }


            else
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
                String query = "UPDATE Projects set  Description=@description,Duration=@duration,RequiredSkills=@skills,YearRestrictions=@year where Title=@title";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@skills", skills);
                cmd.Parameters.AddWithValue("@year", year);

                // Execute query
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                // Check conditions based on score and semester

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Project updated successfull");
                }
                else
                {
                    MessageBox.Show("No data inserted.");
                }
            }
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            //  String SID = positionCombo.SelectedItem?.ToString();
            String title = searchTitle.Text.Trim();



            //if (string.IsNullOrEmpty(position) && string.IsNullOrEmpty(description))
            //{
            //    MessageBox.Show("Please insert value.");
            //    return;
            //}



            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
            String query = "Delete from  Projects where Title=@Title";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Title", title);

            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Project  deleted!");
                //this.Hide();
                //Form1 lo = new Form1();
                //lo.Show();
            }
            else
            {
                MessageBox.Show("Project not  deleted");
            }
        }
    }
}
