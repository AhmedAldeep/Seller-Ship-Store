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
    public partial class User_Inbox : UserControl
    {
        string USER_Us;
        string USER_Ema;
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        SqlDataAdapter sa;
        SqlCommandBuilder sb;
        BindingSource bsource;
        DataTable da;
        DataSet ds;
        public User_Inbox(string U)
        {
            InitializeComponent();
            USER_Us = U;
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            SqlCommand cod = new SqlCommand("Select email from [User] where username='" + USER_Us + "' ;", con);
            SqlDataReader d = cod.ExecuteReader();
            try
            {
                if (d.Read())
                {
                    USER_Ema = d[0].ToString();
                }
            }
            catch (Exception EXP)
            {
                MessageBox.Show(EXP.ToString());
            }
            string q = "SELECT * FROM [User_Email] where Your_Email='" + USER_Ema + "'";
            sa = new SqlDataAdapter(q, MYCON);
            ds = new DataSet();
            sa.Fill(ds);
            metroGrid1.DataSource = ds.Tables[0];
        }
        // Reply button
        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            User_Reply SR = new User_Reply(USER_Us);
            SR.Show();
        }
    }
}
