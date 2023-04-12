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
    public partial class Add_Spare : UserControl
    {
        string Title = "";
        string Title2 = "";
        string Seller_Username;
        public Add_Spare(string U)
        {
            InitializeComponent();
            Seller_Username = U;
        }
        // add new spare part
        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            bool flag = false;
            String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
            SqlConnection con = new SqlConnection(MYCON);
            if (bunifuMaterialTextbox1.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Enter SPARE PART Code  ");

            }
            else if (bunifuMaterialTextbox3.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Select SPARE PART PRICE ");

            }
            else if (bunifuMaterialTextbox2.Text == string.Empty)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Write The spare Part ammount");

            }
            else if (metroComboBox3.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Spare Part Name ");

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Product_Code from [Car_Part]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader re = cmd.ExecuteReader();
                while (re.Read())
                {
                    if (re["Product_Code"].ToString() == bunifuMaterialTextbox1.Text)
                    {
                        flag = true;
                        break;
                    }
                }

                re.Close();
                if (flag == true)
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tThere Are Spare Code With Same Code ");
                else
                {
                    string query = "INSERT INTO [Car_Part] (Product_Code,Part_Name,Price,Seller_Username,ammount,Part_Image) Values ('" + this.bunifuMaterialTextbox1.Text + "','" + this.metroComboBox3.Text + "','" + this.bunifuMaterialTextbox3.Text + "','" + Seller_Username + "','" + this.bunifuMaterialTextbox2.Text + "','" + Title + "') ";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    try
                    {
                        cmd1.ExecuteNonQuery();
                        pictureBox1.Image = null;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        MetroFramework.MetroMessageBox.Show(this, "\n\n\t Spare Car Added ");
                        bunifuMaterialTextbox1.Text = null;
                        bunifuMaterialTextbox2.Text = null;
                        bunifuMaterialTextbox3.Text = null;
                        metroComboBox3.Text = null;
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message);
                    }
                }
            }
        }
        // add photo
        private void Label1_Click(object sender, EventArgs e)
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
