using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection ole;
        private void button1_Click(object sender, EventArgs e)
        {
            ole = new OleDbConnection();
            ole.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\Project Csharp\Library Management\Library Management\Access\Library.mdb'";
            OleDbCommand command = new OleDbCommand();
            ole.Open();
            command.CommandText = "Insert into Admin (FirstName,LastName,Email,Pasword,Images) Values (@firstnam,@lastnam,@email,@pasword,@image)";
            command.Parameters.AddWithValue("@firstnam", txtfirstname.Text);
            command.Parameters.AddWithValue("@lastnam", txtlastname.Text);
            command.Parameters.AddWithValue("@email", txtemail.Text);
            command.Parameters.AddWithValue("@pasword", txtpassword.Text);
            command.Parameters.AddWithValue("@image", pictureBox1.Image);
            command.Connection = ole;
            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            //if (txtrepassword.Text == txtpassword.Text)
            //{
                command.ExecuteNonQuery();
                MessageBox.Show("Malumot Saqlandi:", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////}
            //else
            //{
            //    MessageBox.Show("parol xato");
            //}
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            ole.Close();
        }
        string filenam = "";
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(ofd.FileName);
                pictureBox1.Image = bmp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
