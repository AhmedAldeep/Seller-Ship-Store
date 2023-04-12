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
    public partial class Seller_Form : MetroFramework.Forms.MetroForm
    {
        private Seller_Login U;

        public Seller_Form(string y)
        {
            InitializeComponent();
            label1.Text = y;
        }

        private void Seller_Form_Load(object sender, EventArgs e)
        {

        }
        // Sign Out Button
        private void MetroTile7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            ((Form)this.TopLevelControl).Hide();
            f.ShowDialog();
            ((Form)this.TopLevelControl).Close();
        }
        // Exit Button  
        private void MetroTile4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Add Cars for Sale button
        private void MetroTile1_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new add_car_for_sale(TSU));
            panel2.BackColor = Color.CornflowerBlue;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
        }
        // Your Cars Button
        private void MetroTile2_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new Your_Cars(TSU));
            panel1.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
        }
        // Add Spare Part
        private void MetroTile3_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new Add_Spare(TSU));
            panel3.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
        }

        private void MetroTile6_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new your_spare(TSU));
            panel6.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
        }
        // INBOX BUTTON
        private void MetroTile5_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new Seller_Inbox(TSU));
            panel5.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
        }
        // your sales
        private void MetroTile8_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new YOUR_SALES(TSU));
            panel8.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
        }
    }
}
