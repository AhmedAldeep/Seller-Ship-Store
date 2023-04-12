using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace IS_PROJECT_20
{
    public partial class User_Register : UserControl
    {
        public User_Register()
        {
            InitializeComponent();
            bunifuMaterialTextbox1.Text = string.Empty;
            bunifuMaterialTextbox2.Text = string.Empty;
            //bunifuMaterialTextbox4.Text = string.Empty;
            //bunifuMaterialTextbox5.Text = string.Empty;
            bunifuMaterialTextbox6.Text = string.Empty;
            bunifuMaterialTextbox7.Text = string.Empty;
            bunifuMaterialTextbox8.Text = string.Empty;
            bunifuMaterialTextbox9.Text = string.Empty;
        }

        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            bool flag = false;
            String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
            SqlConnection con = new SqlConnection(MYCON);
            if (metroTextBox2.Text != metroTextBox3.Text)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPassword Don't Match ");
            }
            else if (bunifuMaterialTextbox1.Text == string.Empty)
            {
                bunifuMaterialTextbox1.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Name ");
            }
            else if (bunifuMaterialTextbox2.Text == string.Empty)
            {
                bunifuMaterialTextbox2.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter your Username ");
            }
            else if (metroComboBox1.Text == string.Empty)
            {
                metroComboBox1.BackColor = Color.Red;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Gender ");
            }
            else if (metroTextBox2.Text == string.Empty)
            {
                metroTextBox2.ForeColor = Color.Red;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Password ");
            }
            else if (metroTextBox3.Text == string.Empty)
            {
                metroTextBox3.ForeColor = Color.Red;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Repeat Password ");
            }
            else if (bunifuMaterialTextbox7.Text == string.Empty)
            {
                bunifuMaterialTextbox7.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Credit Card Number ");
            }
            else if (bunifuMaterialTextbox6.Text == string.Empty)
            {
                bunifuMaterialTextbox6.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Mobile ");
            }
            else if (bunifuMaterialTextbox8.Text == string.Empty)
            {
                bunifuMaterialTextbox8.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Email ");
            }
            else if (!this.bunifuMaterialTextbox8.Text.Contains('@') || !this.bunifuMaterialTextbox8.Text.Contains('.'))
            {
                bunifuMaterialTextbox8.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Invalid Email .. Please Enter A Valid Email");
            }
            else if (bunifuMaterialTextbox9.Text == string.Empty)
            {
                bunifuMaterialTextbox9.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Address ");
            }
            else
            {
                metroComboBox1.BackColor = Color.CornflowerBlue;
                bunifuMaterialTextbox1.LineIdleColor = Color.CornflowerBlue;
                bunifuMaterialTextbox2.LineIdleColor = Color.CornflowerBlue;
                bunifuMaterialTextbox4.LineIdleColor = Color.CornflowerBlue;
                bunifuMaterialTextbox5.LineIdleColor = Color.CornflowerBlue;
                bunifuMaterialTextbox6.LineIdleColor = Color.CornflowerBlue;
                bunifuMaterialTextbox7.LineIdleColor = Color.CornflowerBlue;
                bunifuMaterialTextbox8.LineIdleColor = Color.CornflowerBlue;
                bunifuMaterialTextbox9.LineIdleColor = Color.CornflowerBlue;
                con.Open();
                SqlCommand cmd = new SqlCommand("Select username from [User]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader re = cmd.ExecuteReader();
                while (re.Read())
                {
                    if (re["username"].ToString() == bunifuMaterialTextbox2.Text)
                    {
                        flag = true;
                        break;
                    }
                }

                re.Close();
                if (flag == true)
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tThe Username is already Exist ");
                else
                {

                    string query = "INSERT INTO [User] (username,password,FullName,address,email,phone,gender,Credit_Card) Values ('" + this.bunifuMaterialTextbox2.Text + "','" + this.metroTextBox2.Text + "','" + this.bunifuMaterialTextbox1.Text + "','" + this.bunifuMaterialTextbox9.Text + "','" + this.bunifuMaterialTextbox8.Text + "','" + this.bunifuMaterialTextbox6.Text + "','" + this.metroComboBox1.Text + "','" + this.bunifuMaterialTextbox7.Text + "') ";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    try
                    {
                        cmd1.ExecuteNonQuery();
                        MetroFramework.MetroMessageBox.Show(this, "\n\n\tResgister Complete  ");
                        bunifuMaterialTextbox1.Text = null;
                        bunifuMaterialTextbox2.Text = null;
                        bunifuMaterialTextbox4.Text = null;
                        bunifuMaterialTextbox5.Text = null;
                        bunifuMaterialTextbox6.Text = null;
                        bunifuMaterialTextbox7.Text = null;
                        bunifuMaterialTextbox8.Text = null;
                        bunifuMaterialTextbox9.Text = null;
                        metroComboBox1.Text = null;
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message);
                    }
                }

            }
        }
    }
}
