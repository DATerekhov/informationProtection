using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfInformProtection
{
    class Casis
    {
        public class Pair//класс пары, нужен для подсчета в конце
        {
            public int Index { get; set; }//индекс элемента в массиве
            public int Value { get; set; }//значение элемента в массиве
        }

        public static int digramLength = 3;//количество символов, которое должно совпадать
        public static int gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return gcd(b, a % b);
            }
        }

        public string Do(string inputText)
        {
            //string text = File.ReadAllText("text.txt", Encoding.GetEncoding(1251));//считываем текст
            string text = inputText;
            List<int> repeatCount = new List<int>();//массив, который содержит все длины
            //заполняем этот массив, ища расстояние между одинаковыми триграммами

            for (int i = 0; i < text.Length - digramLength + 1; i++)
            {
                string temp = text.Substring(i, digramLength);
                for (int j = i + 1; j < text.Length - digramLength + 1; j++)
                {
                    string temp2 = text.Substring(j, digramLength);
                    if (temp.Equals(temp2))
                    {
                        repeatCount.Add(j - i);
                    }
                }
            }

            int[] nods = new int[5000];//массив для подсчета количества НОД
            //В случае если НОД двух расстояний равен q, то увеличваем nods[q] на 1
            for (int i = 0; i < repeatCount.Count; ++i)
                for (int j = i + 1; j < repeatCount.Count; ++j)
                    nods[gcd(repeatCount[i], repeatCount[j])]++;
            nods[0] = 0;

            //загоняем все в новый массив, чтобы удобно отсортировать
            List<Pair> ans = new List<Pair>();
            for (int i = 2; i < 500; ++i)
            {
                ans.Add(new Pair()
                {
                    Index = i,
                    Value = nods[i]
                });
            }
            IEnumerable<Pair> anss = ans.OrderByDescending(p => p.Value).Take(10);//сортируем и берем первые 10 результатов
            string stringAns = "";
            //выводим ответ
            foreach (var s in anss)
            {
                if (s.Value > 0)
                {
                    stringAns += s.Index + " ";
                }
            }
            return stringAns;
            //File.WriteAllText("ans.txt", stringAns);
        }
    }
}
