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
    public partial class admin_sales : UserControl
    {
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        SqlDataAdapter sa;
        SqlCommandBuilder sb;
        DataSet ds;
        public admin_sales()
        {
            InitializeComponent();
            string q = "SELECT * FROM [Sells]";
            sa = new SqlDataAdapter(q, MYCON);
            ds = new DataSet();
            sa.Fill(ds);
            metroGrid1.DataSource = ds.Tables[0];
        }

        private void Admin_sales_Load(object sender, EventArgs e)
        {

        }
    }
}
