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
    public partial class VigenereCipherAttack : UserControl
    {
        public VigenereCipherAttack()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Step = 1;
            progressBar1.Maximum = 100000;
            progressBar1.Minimum = 0;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            FindPossibleKeyLength(richTextBox1.Text);
        }
        public void FindPossibleKeyLength(string text)
        {
            int[] lengths = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 };
            int num_lengths = lengths.Length;

            int max_matches = 0;
            int max_length = 0;


            for (int i = 0; i < num_lengths; i++)
            {
                int length = lengths[i];
                int num_substrings = text.Length / length;
                int matches = 0;

                for (int j = 0; j < num_substrings; j++)
                {
                    string substring = text.Substring(j * length, length);
                    Console.WriteLine(substring);
                    richTextBox1.Text += substring + "\n";

                    if (j > 0)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            if (substring[k] == text[(j - 1) * length + k])
                            {
                                matches++;
                            }
                        }
                    }
                }

                int remaining_length = text.Length % length;
                if (remaining_length > 0)
                {
                    string last_substring = text.Substring(num_substrings * length, remaining_length);
                    Console.WriteLine(last_substring);
                    richTextBox1.Text += last_substring + "\n";


                    if (num_substrings > 0)
                    {
                        for (int k = 0; k < remaining_length; k++)
                        {
                            if (last_substring[k] == text[num_substrings * length - remaining_length + k])
                            {
                                matches++;
                            }
                        }
                    }
                }


                Console.WriteLine("Matches for length " + length + ": " + matches);


                if (matches > max_matches)
                {
                    max_matches = matches;
                    max_length = length;
                }
                progressBar1.Maximum = 40;
                progressBar1.Value = i;
            }


            Console.WriteLine("Max matches: " + max_matches + " for length " + max_length);
            label2.Text += " " + max_length;
            MessageBox.Show(max_length.ToString());

            
        }
    }
}
