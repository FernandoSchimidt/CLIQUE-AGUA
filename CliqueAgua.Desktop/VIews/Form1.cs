using CliqueAgua.Desktop.VIews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CliqueAgua.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 5;
            if (progressBar1.Value >= 100)
            {
                frmLogin login = new frmLogin();
                this.Hide();
                login.Show();



                timer1.Enabled = true;
                progressBar1.Visible = false;
                timer1.Enabled = false;
            }
        }
    }
}
