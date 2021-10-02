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
    public partial class Form3 : Form
    {
         string connectionString = "Data Source=10.10.1.24;Initial Catalog=PR_7_Kan;Persist Security Info=True;User ID=pro-41;Password=IsPro-41";

    public Form3()
        {
            InitializeComponent(); 
            
           

        }
       
        private void Form3_Load(object sender, EventArgs e)
        {
           
            string sql = "SELECT * FROM User_1";
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
          
            string sqlExpression = "INSERT INTO User_1 " +
                "(Login, Password, Name, Surename, Patronymic, Series, Number, Phone, Adress, E_mail, dateOfIssued, Issued, DateOfBirth, PlaceOfBirth)" +
                " VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" 
                + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" 
                + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + Convert.ToDateTime(textBox11.Text) + "', '" 
                + textBox12.Text + "', '" + Convert.ToDateTime(textBox13.Text) + "', '" + textBox14.Text + "')";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            string sqlExpression = "UPDATE User_1 SET Login=1 WHERE Login=2 ";
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
         
            string sqlExpression = "DELETE  FROM User_1 WHERE Login= 2 ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}

