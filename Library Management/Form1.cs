using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Library_Management
{
    public partial class Form1 : Form
    {
        OleDbConnection ole = new OleDbConnection();
        OleDbDataReader read = null;
        public Form1()
        {
            InitializeComponent();
            ole.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\Project Csharp\Library Management\Library Management\Access\Library.mdb'";
        }
    
        private  void btnLogin_Click(object sender, EventArgs e)
        {
            bool user = !string.IsNullOrEmpty(txtUsername.Text);
            bool pass = !string.IsNullOrEmpty(txtPassword.Text);
            ole.Open();
            OleDbCommand command = new OleDbCommand();
            command.CommandText = "Select * from Admin where LastName='" + txtUsername.Text+"' and Pasword='"+txtPassword.Text+"'";
            command.Connection = ole;
            read = command.ExecuteReader();
            int i = 0;
            while (read.Read())
            {
                i++;
            }
            if (i>=1)
            {
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.Show();
            }
            else
            {
                MessageBox.Show("False");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ole.Close();
        }
    }
}
