using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_PROJECT_20
{
    public partial class User_Form : MetroFramework.Forms.MetroForm
    {
        private User_Login U;

        public User_Form(string y)
        {
            InitializeComponent();
            label1.Text = y;
        }

        private void User_Form_Load(object sender, EventArgs e)
        {

        }
        // Exit Button
        private void MetroTile4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Sign Out
        private void MetroTile7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            ((Form)this.TopLevelControl).Hide();
            f.ShowDialog();
            ((Form)this.TopLevelControl).Close();
        }
        // Car Button
        private void MetroTile1_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new User_Car(TSU));
            panel2.BackColor = Color.CornflowerBlue;
            panel1.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel9.BackColor = Color.DimGray;


        }
        // INBOX BUTTON
        private void MetroTile8_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new User_Inbox(TSU));
            panel3.BackColor = Color.CornflowerBlue;
            panel1.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel2.BackColor = Color.DimGray;
            panel9.BackColor = Color.DimGray;


        }
        // Car Search
        private void MetroTile2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new CAR_SEARCH());
            panel1.BackColor = Color.CornflowerBlue;
            panel3.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel2.BackColor = Color.DimGray;
            panel9.BackColor = Color.DimGray;

        }
        // search spare part
        private void MetroTile3_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new User_spare_Search());
            panel8.BackColor = Color.CornflowerBlue;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel2.BackColor = Color.DimGray;
            panel9.BackColor = Color.DimGray;

        }
        // SHOPPING CART
        private void MetroTile9_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new Shopping_Cart(TSU));
            panel9.BackColor = Color.CornflowerBlue;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel2.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
        }
        // CAR PART 
        private void MetroTile6_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new user_spare_part(TSU));
            panel6.BackColor = Color.CornflowerBlue;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel9.BackColor = Color.DimGray;
            panel2.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
        }
    }
}
