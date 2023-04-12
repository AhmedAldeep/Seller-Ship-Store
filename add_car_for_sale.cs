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
using System.IO;
namespace IS_PROJECT_20
{
    public partial class add_car_for_sale : UserControl
    {
        string Seller_UserName;
        string Title = "";
        string Title2 = "";
        public add_car_for_sale(string U)
        {
            InitializeComponent();
            Seller_UserName = U;
        }
        // ADD CAR BUTTON
        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            bool flag = false;
            String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
            SqlConnection con = new SqlConnection(MYCON);
            if (bunifuMaterialTextbox1.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Enter Car Product Code  ");
                bunifuMaterialTextbox1.LineIdleColor = Color.DarkRed;
            }
            else if (metroComboBox3.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Car Name ");
                //bunifuMaterialTextbox2.LineIdleColor = Color.DarkRed;
            }
            else if (bunifuMaterialTextbox4.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Car Model");
                bunifuMaterialTextbox4.LineIdleColor = Color.DarkRed;
            }
            else if (bunifuMaterialTextbox3.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Car Price ");
                bunifuMaterialTextbox3.LineIdleColor = Color.DarkRed;
            }
            else if (bunifuMaterialTextbox7.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter The Bike Mileage");
                bunifuMaterialTextbox7.LineIdleColor = Color.DarkRed;
            }
            else if (metroComboBox1.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Car Engine");
                //bunifuMaterialTextbox6.LineIdleColor = Color.DarkRed;
            }
            else if (bunifuMaterialTextbox3.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Car Price ");
                bunifuMaterialTextbox3.LineIdleColor = Color.DarkRed;
            }
            else if (metroComboBox2.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter The Bike Mileage");
                //bunifuMaterialTextbox7.LineIdleColor = Color.DarkRed;
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Product_code from [Cars]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader re = cmd.ExecuteReader();
                while (re.Read())
                {
                    if (re["Product_code"].ToString() == bunifuMaterialTextbox1.Text)
                    {
                        flag = true;
                        break;
                    }
                }

                re.Close();
                if (flag == true)
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tThere Are Cars With Same Product Code ");
                else
                {
                    string query = "INSERT INTO [Cars] (Product_code,Car_Name,Model,Car_Image,price,Seller_username,Car_Engine,Mileage,Tank_Capacity,Color) Values ('" + this.bunifuMaterialTextbox1.Text + "','" + this.metroComboBox3.Text + "','" + this.bunifuMaterialTextbox4.Text + "','" + Title + "','" + this.bunifuMaterialTextbox3.Text + "','" + Seller_UserName + "','" + this.metroComboBox1.Text + "','" + this.bunifuMaterialTextbox7.Text + "','"+this.bunifuMaterialTextbox5.Text+"','" + metroComboBox2.Text + "') ";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    try
                    {

                        cmd1.ExecuteNonQuery();
                        pictureBox1.Image = null;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        MetroFramework.MetroMessageBox.Show(this, "\n\n\t Your Car Added ");
                        bunifuMaterialTextbox1.Text = null;
                        bunifuMaterialTextbox3.Text = null;
                        bunifuMaterialTextbox4.Text = null;
                        bunifuMaterialTextbox5.Text = null;
                        bunifuMaterialTextbox7.Text = null;
                        bunifuMaterialTextbox5.Text = null;
                        metroComboBox1.Text = null;
                        metroComboBox2.Text = null;
                        metroComboBox3.Text = null;
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message);
                    }
                }
            }
        }
        // ADD CAR IMAGE
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog obg = new OpenFileDialog();
            obg.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            obg.FilterIndex = 2;

            if (obg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = new Bitmap(obg.FileName);
                pictureBox1.Image = Image.FromFile(obg.FileName);
                Title = obg.FileName;
                Title2 = obg.SafeFileName.ToString();
            }
        }


    }
}
