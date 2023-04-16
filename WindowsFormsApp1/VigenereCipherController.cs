using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Algorithms;

namespace WindowsFormsApp1
{
    public partial class VigenereCipherController : UserControl
    {
        public VigenereCipherController()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.Text.Equals(string.Empty))
            {
                richTextBox2.Text = string.Empty;
                KeyForm kf = new KeyForm();
                kf.ShowDialog();
                string keyWord = kf.KeyWord;
                if (keyWord != string.Empty)
                {
                    ViginereCipher viginereCipher = new ViginereCipher();
                    string enrtyptedText = viginereCipher.Encrypt(richTextBox1.Text, keyWord);
                    richTextBox2.Text = enrtyptedText;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != string.Empty)
            {
                richTextBox2.Text = string.Empty;
                KeyForm kf = new KeyForm();
                kf.ShowDialog();
                string keyWord = kf.KeyWord;
                if (keyWord != string.Empty)
                {
                    ViginereCipher viginereCipher = new ViginereCipher();
                    string decryptedText = viginereCipher.Decrypt(richTextBox1.Text, keyWord);
                    richTextBox2.Text = decryptedText;
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "(*.txt)|*.txt";
            if (f.ShowDialog() == DialogResult.OK)
            {
                string text = File.ReadAllText(f.FileName);
                string filteredText = Filter.GetFilterText(text);
                richTextBox1.Text = filteredText;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "(*.txt)|*.txt";
            if (f.ShowDialog() == DialogResult.OK)
            {
                string text = richTextBox2.Text;
                TextWriter txt = new StreamWriter(f.FileName);
                txt.Write(text);
                txt.Close();
            }
        }
    }
}
