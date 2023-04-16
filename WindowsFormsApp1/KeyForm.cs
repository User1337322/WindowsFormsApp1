using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class KeyForm : Form
    {
        public string KeyWord { get; set; }
        public KeyForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(string.Empty))
            {
                MessageBox.Show("Invalid value of keyword!", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            KeyWord = textBox1.Text;
            this.Hide();
        }
    }
}
