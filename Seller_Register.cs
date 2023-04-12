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
    public partial class Seller_Register : UserControl
    {

        public Seller_Register()
        {
            InitializeComponent();
            bunifuMaterialTextbox1.Text = string.Empty;
            bunifuMaterialTextbox2.isPassword = true;
            bunifuMaterialTextbox4.Text = string.Empty;
            bunifuMaterialTextbox5.Text = string.Empty;
        }
        // Seller Register
        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            bool flag = false;
            String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
            SqlConnection con = new SqlConnection(MYCON);
            if (bunifuMaterialTextbox1.Text == string.Empty)
            {
                bunifuMaterialTextbox1.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your UserName ");
            }
            else if (bunifuMaterialTextbox2.Text == string.Empty)
            {
                bunifuMaterialTextbox2.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Password ");
            }
            else if (bunifuMaterialTextbox3.Text == string.Empty)
            {
                bunifuMaterialTextbox3.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Repeat Your Password ");
            }
            else if (bunifuMaterialTextbox2.Text != bunifuMaterialTextbox3.Text)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPassword Don't Match ");
            }
            else if (bunifuMaterialTextbox4.Text==string.Empty)
            {
                bunifuMaterialTextbox4.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Phone");
            }
            else if (bunifuMaterialTextbox5.Text == string.Empty)
            {
                bunifuMaterialTextbox5.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Email");
            }
            else if (!this.bunifuMaterialTextbox5.Text.Contains('@') || !this.bunifuMaterialTextbox5.Text.Contains('.'))
            {
                bunifuMaterialTextbox5.LineIdleColor = Color.DarkRed;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Invalid Email .. Please Enter A Valid Email");
            }
            else
            {
                bunifuMaterialTextbox1.LineIdleColor = Color.CornflowerBlue;
                bunifuMaterialTextbox2.LineIdleColor = Color.CornflowerBlue;
                bunifuMaterialTextbox3.LineIdleColor = Color.CornflowerBlue;
                con.Open();
                SqlCommand cmd = new SqlCommand("Select username from [Seller]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader re = cmd.ExecuteReader();
                while (re.Read())
                {
                    if (re["username"].ToString() == bunifuMaterialTextbox1.Text)
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

                    string query = "INSERT INTO [Seller] (username,password,phone,EMAIL) Values ('" + this.bunifuMaterialTextbox1.Text + "','" + this.bunifuMaterialTextbox2.Text + "','"+this.bunifuMaterialTextbox4.Text+ "','" + this.bunifuMaterialTextbox5.Text + "') ";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    try
                    {
                        cmd1.ExecuteNonQuery();
                        MetroFramework.MetroMessageBox.Show(this, "\n\n\tResgister Complete  ");
                        bunifuMaterialTextbox1.Text = null;
                        bunifuMaterialTextbox2.Text = null;
                        bunifuMaterialTextbox3.Text = null;
                        bunifuMaterialTextbox4.Text = null;
                        bunifuMaterialTextbox5.Text = null;

                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message);
                    }
                }

            }

        }

        private void BunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
