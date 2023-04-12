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
    public partial class YOUR_SALES : UserControl
    {
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        SqlDataAdapter sa;
        SqlCommandBuilder sb;
        DataSet ds;
        string SU;
        public YOUR_SALES(string U)
        {
            InitializeComponent();
            SU = U;
            string q = "SELECT * FROM [Sells] where seller_username='"+SU+"'";
            sa = new SqlDataAdapter(q, MYCON);
            ds = new DataSet();
            sa.Fill(ds);
            metroGrid1.DataSource = ds.Tables[0];
        }

        private void YOUR_SALES_Load(object sender, EventArgs e)
        {

        }
    }
}
