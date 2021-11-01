using LibraryManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_management_system
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = panel1.Width;
            panel2.Width += 2;

            if (panel2.Width >= x)
            {
                timer1.Stop();
                this.Hide();

                Home obj = new Home();
                obj.ShowDialog();
            }
            if (panel2.Width >= x / 4)
            {
                this.BackgroundImage = Resources._2; //Image.FromFile("E:/Programming/C#/Projects/LibraryManagementSystem/Resources/2.jpg");
            }
            if (panel2.Width >= (x / 4) * 2)
            {
                this.BackgroundImage = Resources._3; //Image.FromFile("E:/Programming/C#/Projects/LibraryManagementSystem/Resources/3.jpg");
            }
            if (panel2.Width >= (x / 4) * 3)
            {
                this.BackgroundImage = Resources._4; // Image.FromFile("E:/Programming/C#/Projects/LibraryManagementSystem/Resources/4.jpg");
            }
        }
    }
}
