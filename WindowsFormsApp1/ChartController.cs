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
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.Algorithms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class ChartController : UserControl
    {
        List<TextProperties> textProperties;
        System.Windows.Forms.ToolTip tooltip;
        public ChartController()
        {
            InitializeComponent();
            tooltip = new System.Windows.Forms.ToolTip();
            richTextBox1.Text = "ключ";
          
        }
        private void SetData()
        {
            string[] keys = richTextBox2.Text.Split(';');
            string textToEncrypt = richTextBox1.Text;
            ViginereCipher cipher = new ViginereCipher();
            textProperties = new List<TextProperties>();
            foreach (var key in keys)
            {
                string encryptedText = cipher.Encrypt(textToEncrypt, key);
                double indexForOpenText = new CorrespondenceIndex(textToEncrypt).FindIndex();
                double indexForEcryptedText = new CorrespondenceIndex(encryptedText).FindIndex();
                textProperties.Add(new TextProperties
                {
                    OpenText = textToEncrypt,
                    Key = key,
                    EncryptedText = encryptedText,
                    OpenTextCorresponceIndex = indexForOpenText,
                    EncryptedTextCorresponceIndex = indexForEcryptedText
                });
            }
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            foreach (var point in textProperties)
            {
                chart1.Series[1].Points.AddXY(point.Key.Length, point.EncryptedTextCorresponceIndex);
                chart1.Series[0].Points.AddXY(point.Key.Length, point.OpenTextCorresponceIndex);
            }
        }
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                  ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

                    int correctXValue = (int)Math.Ceiling(xVal);
                    tooltip.Show("X=" + correctXValue + ", Y=" + yVal,
                                 this.chart1, e.Location.X, e.Location.Y - 15);
                }
            }
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
            SetData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
           

        }
    }
}
