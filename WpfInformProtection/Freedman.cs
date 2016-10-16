using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfInformProtection
{
    class Freedman
    {
        private readonly string _text;
        public Freedman(string text)
        {
            _text = text;
        }

        public List<KeyValuePair<int, float>> CalculateKeyLength(int maxKeyLength)
        {
            var coincidenceIndexes = new List<KeyValuePair<int, float>>();
            var strings = new string[maxKeyLength];
            for (var i = 1; i <= maxKeyLength; i++)
            {
                var stringBuilder = new StringBuilder();
                var partOne = _text.Substring(i, _text.Length - i);
                var partTwo = _text.Substring(0, i);
                stringBuilder.Append(partOne);
                stringBuilder.Append(partTwo);
                strings[i - 1] = stringBuilder.ToString();
            }


            for (var i = 0; i < strings.Length; i++)
            {
                var repeats = 0;
                for (var j = 0; j < _text.Length; j++)
                {
                    if (strings[i][j] == _text[j])
                    {
                        repeats++;
                    }
                }
                var coincidenceIndex = (float)repeats / _text.Length;
                coincidenceIndexes.Add(new KeyValuePair<int, float>(i + 1, coincidenceIndex));
            }

            var results = coincidenceIndexes.OrderByDescending(c => c.Value).ToList();
            return results;
        }
    }
}