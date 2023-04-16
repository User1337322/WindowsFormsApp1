using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Algorithms
{
    public class Filter
    {
        public static string GetFilterText(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if ((c >= '0' && c <= '9') || (c.Equals('ё') || (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я')))
                {
                    if (c.Equals('ё'))
                    {
                        sb.Append('e');
                        continue;
                    }
                    sb.Append(c);
                }
            }
            string outputString = sb.ToString().ToLower();
            return outputString;
        }
    }
}
