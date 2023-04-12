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
    public partial class User_Car : UserControl
    {
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        string User_Username;
        string Seller_U;
        public User_Car(string U)
        {
            InitializeComponent();
            User_Username= U;
            string sql = "SELECT Product_code,Car_Name,Model FROM Cars";
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
        // SEND EMAIL TO SELLER BUTTON
        private void MetroButton1_Click(object sender, EventArgs e)
        {

            USER_SENT_EMAIL USE = new USER_SENT_EMAIL(Seller_U,User_Username);
            USE.Show();
        }

        private void MetroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = "";
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            string pro = metroGrid1.CurrentRow.Cells[0].Value.ToString();
            string pro2 = metroGrid1.CurrentRow.Cells[1].Value.ToString();
            string pro3 = metroGrid1.CurrentRow.Cells[2].Value.ToString();
            bunifuMaterialTextbox1.Text = pro;
            bunifuMaterialTextbox2.Text = pro2;
            bunifuMaterialTextbox4.Text = pro3;
            string q1 = "select price,Car_Image,Car_Engine,Mileage,Tank_Capacity,Color,Seller_username from Cars where Product_code = '" + pro + "'";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            if (d.Read())
            {
                bunifuMaterialTextbox3.Text = d[0].ToString();
                bunifuMaterialTextbox6.Text = d[2].ToString();
                bunifuMaterialTextbox7.Text = d[3].ToString();
                bunifuMaterialTextbox5.Text = d[4].ToString();
                metroComboBox2.Text = d[5].ToString();
                bunifuMaterialTextbox8.Text = d[6].ToString();
                Seller_U = bunifuMaterialTextbox8.Text;
                path = d[1].ToString();
                pictureBox2.ImageLocation = path;
            }
        }
    }
}
