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
    public partial class ADMIN_CARS : UserControl
    {
        
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        public ADMIN_CARS()
        {
            InitializeComponent();
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
        // UPDATE BUTTON
        private void MetroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(MYCON);
            string query = "update [Cars] set price='" + this.bunifuMaterialTextbox3.Text + "',Color='" + this.metroComboBox2.Text + "' where Product_code ='" + this.bunifuMaterialTextbox1.Text + "' ;";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                reader = cmd1.ExecuteReader();
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t  Your Car Information has Been Edited");

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
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

                path = d[1].ToString();
                pictureBox2.ImageLocation = path;
            }
        }
        // Delete Button
        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            string query = "Delete from Cars where Product_code='" + this.bunifuMaterialTextbox1.Text + "' ;";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.CommandText = query;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            MetroFramework.MetroMessageBox.Show(this, "\n\n\t  Your Car Deleted From Sales");
        }

        private void MetroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
