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

namespace PR_7_Kandykova
{
    public partial class Form8 : Form
    {
        string connectionString = "Data Source=10.10.1.24;Initial Catalog=PR_7_Kan;Persist Security Info=True;User ID=pro-41;Password=IsPro-41";

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Contract";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlExpression = "INSERT INTO Contract " +
               "(Account, UserID, Amount, Period, ExpirationDate, Perset)" +
               " VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "', " +
               "'" + textBox4.Text + "', '" + Convert.ToDateTime(textBox5.Text) + "', '" + textBox6.Text + "')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlExpression = "UPDATE Contract SET Period=234 WHERE IDContact = 25 ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlExpression = "DELETE  FROM Contract WHERE Period=234 ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
