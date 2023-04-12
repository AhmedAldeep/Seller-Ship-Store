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
    public partial class Admin_Form : MetroFramework.Forms.MetroForm
    {
        public Admin_Form()
        {
            InitializeComponent();
        }

        private void Admin_Form_Load(object sender, EventArgs e)
        {

        }
        // Users Button
        private void MetroTile1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new Users_Admin());
            panel2.BackColor = Color.CornflowerBlue;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;

        }
        // Sign Out
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

        private void MetroTile9_Click(object sender, EventArgs e)
        {

        }
        // Cars Button
        private void MetroTile2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new ADMIN_CARS());
            panel1.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
        }
        // Spare Part Button
        private void MetroTile3_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new Parts_Admin());
            panel3.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
        }
        // Sales
        private void MetroTile5_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new admin_sales());
            panel5.BackColor = Color.CornflowerBlue;
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
        }
    }
}
