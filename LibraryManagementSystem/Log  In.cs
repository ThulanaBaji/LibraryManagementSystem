using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace Library_management_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usrnam = textBox2.Text;
            string pswd = textBox1.Text;

            if ((usrnam == "admin") && (pswd == "1234"))
            {
                MetroMessageBox.Show(this ,"\nLogin Success !", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Hide();
                Loading obj = new Loading();
                obj.ShowDialog();
                obj.Shown += obj_Shown;
                this.Close();
               
            }
            else 
            {
                MetroMessageBox.Show(this ,"\nLogin not Success !", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox2.Select();
            }
        }

        private void obj_Shown(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroMessageBox.Show(this ,"\nDo you really want to exit ?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox1.Select();                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MetroMessageBox.Show(this ,"\nDo you really want to exit ?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void textBox1_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox2.Text != "")
                {
                    loginbtn.Select();
                }
            }
        }
    }
}

