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
    public partial class User_Login : UserControl
    {
        private string user__name;
        public string u
        {
            get { return user__name; }
            set { user__name = value; }
        }
        public User_Login()
        {
            InitializeComponent();
        }
        public string user_name
        {
            get
            {
                return bunifuMaterialTextbox1.Text;
            }
            set
            {
                string US = bunifuMaterialTextbox1.Text;

            }
        }
        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            SqlCommand cod = new SqlCommand("Select * from [User] where username='" + this.bunifuMaterialTextbox1.Text + "' and password ='" + this.bunifuMaterialTextbox2.Text + "';", con);
            try
            {
                SqlDataReader myreader;
                myreader = cod.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tWelcome \t" + this.bunifuMaterialTextbox1.Text);
                    string US = bunifuMaterialTextbox1.Text;



                    User_Form f = new User_Form(US);
                    ((Form)this.TopLevelControl).Hide();
                    f.ShowDialog();
                    ((Form)this.TopLevelControl).Close();
                }
                else if (count > 1)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tDuplicate Username and Password ... Access Denied");
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tUsername and Password Is not Correct ... Try Again");
                }

            }
            catch(Exception EXP)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t"+EXP.Message);
            }


        }
    }
}
