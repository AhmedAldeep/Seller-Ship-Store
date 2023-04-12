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
namespace IS_PROJECT_20
{
    public partial class User_Reply : MetroFramework.Forms.MetroForm
    {
        string SU;
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        public User_Reply(string U)
        {
            InitializeComponent();
            SU = U;
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            SqlCommand cod = new SqlCommand("Select email from [User] where username='" + SU + "' ;", con);
            SqlDataReader d = cod.ExecuteReader();
            try
            {
                if (d.Read())
                {
                    bunifuMaterialTextbox1.Text = d[0].ToString();
                }
            }
            catch (Exception EXP)
            {
                MessageBox.Show(EXP.Message);
            }
            d.Close();
        }

        private void User_Reply_Load(object sender, EventArgs e)
        {

        }
        // SEND BUTTON
        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();

            string PNAME = "SELLER_MAIL";
            //string query = "INSERT INTO [Seller_Email] (user_email,your_email,subject,email) Values ('" + this.bunifuMaterialTextbox1.Text + "','" + this.bunifuMaterialTextbox8.Text + "','" + this.bunifuMaterialTextbox2.Text + "','" + this.textBox1.Text + "') ";
            SqlCommand cmd1 = new SqlCommand(PNAME, con);
            try
            {
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@UE", SqlDbType.NVarChar).Value = bunifuMaterialTextbox1.Text;
                cmd1.Parameters.Add("@YE", SqlDbType.NVarChar).Value = bunifuMaterialTextbox8.Text;
                cmd1.Parameters.Add("@S", SqlDbType.NVarChar).Value = bunifuMaterialTextbox2.Text;
                cmd1.Parameters.Add("@E", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd1.ExecuteNonQuery();
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Email Sent ");
                bunifuMaterialTextbox1.Text = null;
                bunifuMaterialTextbox8.Text = null;
                bunifuMaterialTextbox2.Text = null;
                textBox1.Text = null;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
    }
}
