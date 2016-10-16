using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfInformProtection
{
    class Frequency
    {
        private string text;
        private string alphabet;
        //private int k;

        public Frequency(string _text, string _alphabet)
        {
            text = _text;
            alphabet = _alphabet;
            //k = _k;

        }

        public Dictionary<char, double> CountFrequency()
        {
            var frequency = new Dictionary<char, double>();
            foreach (var alp in alphabet)
            {
                double count = 0;
                if (text.IndexOf(alp) == -1) continue;
                count += text.Count(t => t == alp);
                count = count / text.Length * 100;
                count = Math.Round(count, 4);
                frequency.Add(alp, count);
            }

            /*StringBuilder ans = new StringBuilder();
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (frequency.ContainsKey)
            }*/
            frequency = frequency.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            //  foreach (var item in frequency)
            //    Console.WriteLine(item.Key + " " + item.Value);

            return frequency;

        }
    }
}
