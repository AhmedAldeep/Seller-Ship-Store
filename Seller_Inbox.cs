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
    public partial class Seller_Inbox : UserControl
    {
        string Seller_Us;
        string Seller_Ema;
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        SqlDataAdapter sa;
        SqlCommandBuilder sb;
        BindingSource bsource;
        DataTable da;
        DataSet ds;
        public Seller_Inbox(string U)
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            Seller_Us = U;
            SqlCommand cod = new SqlCommand("Select EMAIL from [SELLER] where username='" + Seller_Us + "' ;", con);
            SqlDataReader d = cod.ExecuteReader();
            try
            {
                if (d.Read())
                {
                    Seller_Ema = d[0].ToString();
                }
            }
            catch (Exception EXP)
            {
                MessageBox.Show(EXP.ToString());
            }
            string q = "SELECT * FROM [Seller_Email] where your_email='"+Seller_Ema+"'";
            sa = new SqlDataAdapter(q, MYCON);
            ds = new DataSet();
            sa.Fill(ds);
            metroGrid1.DataSource = ds.Tables[0];

        }

        private void Seller_Inbox_Load(object sender, EventArgs e)
        {

        }

        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            SELLER_REPLY SR = new SELLER_REPLY(Seller_Us);
            SR.Show();
        }
    }
}
