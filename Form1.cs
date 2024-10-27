using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Research_PMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //public static 

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash returns a byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string of hexadecimal digits
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Convert each byte to hex
                }
                return builder.ToString();
            }
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            String Email = emailTB.Text.Trim();
            String password = passwordTB.Text.Trim();
            String Role = roleCOMBO.Text.Trim();
            String hashedPassword = HashPassword(password);


            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
            string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND Password = @Password AND Role=@Role";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.AddWithValue("@Password", hashedPassword);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            if (count == 1 && Role == "Faculty")
            {
                MessageBox.Show("Login Successfull");

                AdminDashboard admin = new AdminDashboard();
                this.Hide();
                admin.Show();
            }
            else if (count == 1 && Role == "Students")
            {
                MessageBox.Show("Login Successfull");

                Applicant land = new Applicant();
                this.Hide();
                land.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Credentials");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup land = new Signup();
            this.Hide();
            land.Show();
        }
    }
    }

