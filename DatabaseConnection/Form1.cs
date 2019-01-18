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

namespace DatabaseConnection
{
    public partial class Form1 : Form
    {
        String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; // din prprietatile "localdb"
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String sqlCommand = "SELECT name,note FROM GRADES";  //selecteaza tot din baza de date
            using (connection)
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(sqlCommand,connection);

                DataTable dt = new DataTable();
                command.Fill(dt);
                StudentsDGV.AutoGenerateColumns = false;
                StudentsDGV.DataSource = dt;
            }
        }

       
    }
}
