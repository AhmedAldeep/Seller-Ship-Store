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
    public partial class Users_Admin : UserControl
    {
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        SqlDataAdapter sa;
        SqlCommandBuilder sb;
        BindingSource bsource;
        DataTable da;
        DataSet ds;
        public Users_Admin()
        {
            InitializeComponent();
            string q = "SELECT * FROM [User]";
            sa = new SqlDataAdapter(q, MYCON);
            ds = new DataSet();
            sa.Fill(ds);
            metroGrid1.DataSource = ds.Tables[0];
        }

        private void MetroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            sb = new SqlCommandBuilder(sa);
            sa.Update(ds.Tables[0]);
            MetroFramework.MetroMessageBox.Show(this, "\n\n\t Saved");
        }

        private void Users_Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
