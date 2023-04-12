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
    public partial class user_spare_part : UserControl
    {
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        string User_Username;
        string Seller_U;
        public user_spare_part(string U)
        {
            InitializeComponent();
            User_Username = U;
            string sql = "SELECT Product_Code,Part_Name,Price FROM Car_Part where ammount !=0";
            SqlConnection connection = new SqlConnection(MYCON);
            connection.Open();
            SqlCommand s = new SqlCommand(sql, connection);
            SqlDataAdapter sa = new SqlDataAdapter(s);
            DataTable da = new DataTable();
            sa.Fill(da);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = da;
            SqlCommandBuilder sb = new SqlCommandBuilder(sa);
            metroGrid1.DataSource = bsource;
            sa.Update(da);
            connection.Close();
            metroGrid1.Columns[2].Visible = false;
        }
        // ADD TO SHOPPING CART
        private void MetroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            int T = 0;
            int am = Int32.Parse(bunifuMaterialTextbox2.Text);
            int pri = Int32.Parse(bunifuMaterialTextbox3.Text);
            T = am * pri;
            string query = "INSERT INTO [Shopping_Cart] (Product_Code,user_username,ammount,price,seller_us) Values ('" + this.bunifuMaterialTextbox1.Text + "','" + User_Username + "','" + this.bunifuMaterialTextbox2.Text + "','" + this.bunifuMaterialTextbox3.Text + "','" + this.bunifuMaterialTextbox8.Text + "') ";
            SqlCommand cmd1 = new SqlCommand(query, con);
            try
            {

                cmd1.ExecuteNonQuery();
                pictureBox1.Image = null;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Added To Shopping Cart");
                bunifuMaterialTextbox1.Text = null;
                bunifuMaterialTextbox3.Text = null;
                bunifuMaterialTextbox4.Text = null;
                bunifuMaterialTextbox8.Text = null;
                bunifuMaterialTextbox2.Text = null;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        // Click Event
        private void MetroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = "";
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            string pro = metroGrid1.CurrentRow.Cells[0].Value.ToString();
            string pro2 = metroGrid1.CurrentRow.Cells[1].Value.ToString();
            string pro3 = metroGrid1.CurrentRow.Cells[2].Value.ToString();
            bunifuMaterialTextbox1.Text = pro;
            bunifuMaterialTextbox4.Text = pro2;
            bunifuMaterialTextbox3.Text = pro3;
            string q1 = "select ammount,Part_Image,Seller_Username from Car_Part where Product_code = '" + pro + "'";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            if (d.Read())
            {
                bunifuMaterialTextbox2.Text = d[0].ToString();
                path = d[1].ToString();
                bunifuMaterialTextbox8.Text = d[2].ToString();
                pictureBox1.ImageLocation = path;
            }
        }
    }
}
