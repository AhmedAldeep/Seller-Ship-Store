﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace IS_PROJECT_20
{
    public partial class AdminLogin : UserControl
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        // SIGN IN BUTTON
        private void Ad_sign_in_Click(object sender, EventArgs e)
        {
            String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            SqlCommand cod = new SqlCommand("Select * from Admin where username='" + this.bunifuMaterialTextbox1.Text + "' and password ='" + this.bunifuMaterialTextbox2.Text + "';", con);
            SqlDataReader myreader;
            try
            {
                myreader = cod.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tWelcome \t" + this.bunifuMaterialTextbox1.Text);
                    Admin_Form f = new Admin_Form();
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
            catch (Exception EXP)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t"+EXP.Message);
            }


        }

  
    }
}
