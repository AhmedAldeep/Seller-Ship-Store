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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // ADMIN LOGIN BUTTON
        private void Admin_Login_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new AdminLogin());
            panel2.BackColor = Color.CornflowerBlue;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
        }
        // Exit Button
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // User Login Button
        private void User_Login_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new User_Login());
            panel1.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
        }
        // SELLER LOGIN BUTTON
        private void Seller_Login_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new Seller_Login());
            panel5.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
        }
        // USER REGISTER BUTTON
        private void User_Register_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new User_Register());
            panel3.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
        }
        // SELLER REGISTER BUTTON
        private void Seller_Register_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new Seller_Register());
            panel6.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
        }
    }
}
