using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Algorithms
{
    public class CorrespondenceIndex
    {
        public string Text { get; set; }
        public Dictionary<char, int> correspondence { get; set; } 
        public CorrespondenceIndex(string text)
        {
            this.Text = text;
            correspondence = GetSymbolCount(text);

        }
        public double FindIndex()
        {
            double index = 0;
            foreach (var pair in correspondence)
            {
                double charCount = pair.Value;
                double rowSum = (charCount - 1) * charCount;
                double sum = rowSum / (Text.Length * (Text.Length - 1));
                index += sum;
            }
            return index;
        }
        public Dictionary<char, int> GetSymbolCount(string text)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount.Add(c, 1);
            }
            return charCount;
        }
    }
}
