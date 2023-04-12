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
    public partial class Shopping_Cart : UserControl
    {
        String MYCON = "Data Source=.;Initial Catalog=Car_Database_2020;Integrated Security=True";
        SqlDataAdapter sa;
        SqlCommandBuilder sb;
        DataSet ds;
        string UU;
        int AA;
        int A;
        List<string> PA = new List<string>();
        List<int> AMM = new List<int>();
        List<int> PRI = new List<int>();
        List<DateTime> DTT = new List<DateTime>();
        List<string> SUU = new List<string>();





        List<int> FA = new List<int>();

        public Shopping_Cart(string U)
        {
            InitializeComponent();
            UU = U;
            string q = "SELECT * FROM [Shopping_Cart]";
            sa = new SqlDataAdapter(q, MYCON);
            ds = new DataSet();
            sa.Fill(ds);
            metroGrid1.DataSource = ds.Tables[0];
        }
        // UPDATE SHOPPING CART
        private void MetroButton2_Click(object sender, EventArgs e)
        {
            sb = new SqlCommandBuilder(sa);
            sa.Update(ds.Tables[0]);
            MetroFramework.MetroMessageBox.Show(this, "\n\n\t UPDATED");
            metroButton1.Visible = true;
        }
        // TOTAL COST
        private void MetroButton1_Click(object sender, EventArgs e)
        {
            int TOTAL = 0;
            int A1 = 0;
            int P = 0;

            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            SqlCommand cod = new SqlCommand("Select ammount,price from [Shopping_Cart] where user_username='" + UU + "'", con);
            try
            {

                SqlDataReader myreader;
                myreader = cod.ExecuteReader();
                while (myreader.Read())
                {
                    A1= Int32.Parse(myreader[0].ToString());
                    P= Int32.Parse(myreader[1].ToString());
                    TOTAL = TOTAL + (A1*P);
                }
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t TOTAL COST = "+TOTAL);
                myreader.Close();
                con.Close();
                metroButton3.Visible = true;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        // BUY BUTTON
        private void MetroButton3_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(MYCON);
            con.Open();
            SqlCommand cod = new SqlCommand("Select Product_Code,ammount,price,seller_us from [Shopping_Cart] where user_username='" + UU + "'", con);
            SqlDataReader myreader33;
            myreader33 = cod.ExecuteReader();
            int c = 0;
            try
            {
                while (myreader33.Read())
                {
                    string PC = (myreader33[0].ToString());
                    A = Int32.Parse(myreader33[1].ToString());
                    int P = Int32.Parse(myreader33[2].ToString());
                    string SU = (myreader33[3].ToString());
                    DateTime DT;
                    DT = DateTime.Now;
                    PA.Add(PC);
                    AMM.Add(A);
                    PRI.Add(P);
                    DTT.Add(DT);
                    SUU.Add(SU);
                    
                }
                myreader33.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            for (int i = 0; i < PA.Count; i++)
            {
                string query = "INSERT INTO [Sells] (Product_Code,ammount,price,seller_username,date,user_username) Values ('" + PA[i] + "','" + AMM[i] + "','" + PRI[i] + "','" + SUU[i] + "','" + DTT[i] + "','" + UU + "') ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                cmd1.ExecuteNonQuery();
            }

                for (int i = 0; i<PA.Count;i++)
            { 
                string ppp = PA[i].ToString();
                string query23 = "select ammount from [Car_Part] where Product_Code ='" + ppp + "' ;";
                SqlCommand cmd123 = new SqlCommand(query23, con);
                SqlDataReader reader3;
                reader3 = cmd123.ExecuteReader();
                try
                {
                    while (reader3.Read())
                    {
                        AA = Int32.Parse(reader3[0].ToString());
                        FA.Add(AA);
                    }
                    reader3.Close();
                }
                catch (Exception ex)
                { MetroFramework.MetroMessageBox.Show(this, ex.Message); }
            }
            for (int i = 0; i < PA.Count; i++)
            {
                int NA = FA[i] - A;
                string query2 = "update [Car_Part] set ammount='" + NA + "' where Product_Code ='" + PA[i] + "' ;";
                SqlCommand cmd12 = new SqlCommand(query2, con);
                SqlDataReader reader;
                try
                {
                    reader = cmd12.ExecuteReader();
                    reader.Close();
                }
                catch (Exception ex)
                { MetroFramework.MetroMessageBox.Show(this, ex.Message); }
            }

                MetroFramework.MetroMessageBox.Show(this, "\n\n\t THANK YOU" );
                metroButton3.Visible = true;
                con.Close();
            

            try
            {
                con.Open();
                string query = "Delete from [Shopping_Cart]";
                SqlCommand cmd1 = new SqlCommand(query, con);
                cmd1.CommandText = query;
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
    }
}
