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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

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

        private void signupBTN_Click(object sender, EventArgs e)
        {
            String NamesOrId = emailTB.Text.Trim();
            String password = passwordTB.Text.Trim();

            // Ensure the SelectedItem is cast to a string
            String Role = roleCOMBO.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(Role))
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            String hashedPassword = HashPassword(password);

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=Research_pms;Integrated Security=True;TrustServerCertificate=True");
            String query = "INSERT INTO Users (Email, Role, Password) VALUES (@NamesOrId, @Role, @password)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@NamesOrId", NamesOrId);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.AddWithValue("@password", hashedPassword);

            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Signup successfully!");
                this.Hide();
                Form1 lo = new Form1();
                lo.Show();
            }
            else
            {
                MessageBox.Show("SignUp Failed.");
            }
        }
    }
}
