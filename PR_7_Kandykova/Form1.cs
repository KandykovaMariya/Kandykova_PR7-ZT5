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
using System.Configuration;

namespace PR_7_Kandykova
{
    public partial class Form1 : Form
    { 
        
       //string connectionString = "Data Source=10.10.1.24;Initial Catalog=PR_7_Kan;Persist Security Info=True;User ID=pro-41;Password=IsPro-41";
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDataConnectionString"].ToString());

       

        public Form1()
        {
            InitializeComponent();
        }
        enum Role { Failed, Admin, User }

        static Role GetRole(string login, string password)
        {
            Role role = Role.Failed;
            using (var connection = new SqlConnection("Data Source=10.10.1.24;Initial Catalog=PR_7_Kan;Persist Security Info=True;User ID=pro-41;Password=IsPro-41"))
            {
                var command = new SqlCommand("Select [Role] From User_1 WHERE login=@Login AND password=@Password", connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        switch ((int)dataReader["Role"])
                        {
                            case 0: role = Role.User; break;
                            case 1: role = Role.Admin; break;
                        }
                    }
                }

            }
            return role;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString);


            //this.Hide();
            //Form2 f2 = new Form2();
            //f2.ShowDialog();
            Role role = GetRole(textBox1.Text, textBox2.Text);
            if (role == Role.Failed)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            else
            {
                if (role == Role.Admin)
                {
                    var f2 = new Form2();
                    f2.ShowDialog();
                }
                else if (role == Role.User)
                {
                    var f2 = new Form2();
                    f2.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
