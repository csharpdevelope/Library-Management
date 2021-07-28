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
using System.IO;

namespace Library_Management
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oled.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\Project Csharp\Library Management\Library Management\Access\Library.mdb'";
        }
        OleDbConnection oled = new OleDbConnection();
        OleDbDataReader reader = null;
        DataTable dt;

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView.RowTemplate.Height = 120;
            oled.Open();
            string select = "select * from Admin";
            OleDbCommand command = new OleDbCommand(select, oled);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //oled.Open();
            //string select = "SELECT * FROM Admin";
            //OleDbCommand command = new OleDbCommand(select, oled);
            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            //DataTable data = new DataTable();
            //dataAdapter.Fill(data);
            //dataGridView.DataSource = data;
        }
        Form4 frm4;
        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];
            string firstname = row.Cells[1].Value.ToString();
            string lastname = row.Cells[2].Value.ToString();
            string email = row.Cells[3].Value.ToString();
            string password = row.Cells[4].Value.ToString();
            byte[] bts = (byte[])row.Cells[5].Value;
            MemoryStream st = new MemoryStream();
            frm4.pictureBox1.Image = Image.FromStream(st);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("LastName like '%{0}%'", textBox1.Text);
            dataGridView.DataSource = dv.ToTable();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("LastName like '%{0}%'", textBox1.Text);
                dataGridView.DataSource = dv.ToTable();
            }
        }
    }
}
