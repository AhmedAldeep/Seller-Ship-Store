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
    public partial class USER_SENT_EMAIL : MetroFramework.Forms.MetroForm
    {
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        string Seller_U;
        string User_U;
        public USER_SENT_EMAIL(string U,string U2)
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            Seller_U = U;
            User_U = U2;
            SqlCommand cod = new SqlCommand("Select email from [User] where username='" + User_U + "' ;", con);
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
                MessageBox.Show(EXP.ToString());
            }
            d.Close();
            SqlCommand cod2 = new SqlCommand("Select EMAIL from [Seller] where username='" + Seller_U + "' ;", con);
            SqlDataReader d2 = cod2.ExecuteReader();
            try
            {
                if (d2.Read())
                {
                    bunifuMaterialTextbox8.Text = d2[0].ToString();
                }
            }
            catch (Exception EXP)
            {
                MessageBox.Show(EXP.Message);
            }
            con.Close();
        }

        private void USER_SENT_EMAIL_Load(object sender, EventArgs e)
        {

        }
        // Send Button
        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            string query = "INSERT INTO [Seller_Email] (user_email,your_email,subject,email) Values ('" + this.bunifuMaterialTextbox1.Text + "','" + this.bunifuMaterialTextbox8.Text + "','" + this.bunifuMaterialTextbox2.Text + "','" + this.textBox1.Text + "') ";
            SqlCommand cmd1 = new SqlCommand(query, con);
            try
            {

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
