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
    public partial class User_spare_Search : UserControl
    {
        string SEARCH_COMBOBOX;
        string SEARCH_TEXTBOX;
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        public User_spare_Search()
        {
            InitializeComponent();
        }
        // EVENT PICTURE CLICK
        private void PictureBox3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(SEARCH_COMBOBOX);
            //MessageBox.Show(bunifuMaterialTextbox10.Text);
            string sql = "SELECT Product_code,Part_Name,Price FROM Car_Part where " + SEARCH_COMBOBOX + " = '" + this.bunifuMaterialTextbox10.Text.ToString() + "' ";
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
            metroGrid1.Visible = true;
        }

        private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH_COMBOBOX = metroComboBox1.Text.ToString();

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
            bunifuMaterialTextbox3.Text = pro3;
            string q1 = "select Seller_username,ammount,Part_Image from Car_Part where Product_code = '" + pro + "'";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            if (d.Read())
            {
                bunifuMaterialTextbox8.Text = d[0].ToString();
                bunifuMaterialTextbox4.Text = d[1].ToString();

                path = d[2].ToString();
                pictureBox1.ImageLocation = path;
            }
        }
    }
}
