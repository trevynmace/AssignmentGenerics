using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssignmentGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            FindDuplicateWordsInSentence("The optimist thinks this is the best of all possible worlds; the pessimist fears it is true.");
            Console.WriteLine();
            ModifyList();
        }

        public static void FindDuplicateWordsInSentence(string userInput)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            string inputLower = userInput.ToLower();
            Regex reg = new Regex("[^a-zA-Z0-9 -]");
            string returnString = reg.Replace(inputLower, " ");
            string[] split = returnString.Split(' ');

            int shortestWordLength = 0;

            foreach (string word in split)
            {
                if (!word.Equals(""))
                {
                    if (shortestWordLength == 0)
                    {
                        shortestWordLength = word.Length;
                    }
                    else
                    {
                        if (word.Length < shortestWordLength)
                        {
                            shortestWordLength = word.Length;
                        }
                    }

                    if (map.ContainsKey(word))
                    {
                        map[word] += 1;
                    }
                    else
                    {
                        map.Add(word, 1);
                    }
                }
            }
            
            List<string> shortestWords = new List<string>();

            foreach (KeyValuePair<string,int> pair in map)
            {
                if (pair.Key.Count() == shortestWordLength)
                {
                    shortestWords.Add(pair.Key);
                }

                Console.WriteLine("{0} {1}", pair.Key, pair.Value);
            }

            if(shortestWords.Count > 0)
            {
                StringBuilder sb = new StringBuilder("Shortest word(s): ");

                foreach (string word in shortestWords)
                {
                    sb.Append(word);
                    sb.Append(", ");
                }
                sb.Length = sb.Length - 2;

                Console.WriteLine(sb.ToString());
            }
        }

        public static void ModifyList()
        {
            List<int> list = new List<int>();
            Random random = new Random(17);

            for (int i = 0; i < 25; i++)
            {
                list.Add(random.Next(20, 80));
            }

            StringBuilder sb = new StringBuilder();
            foreach (int integer in list)
            {
                sb.Append(integer);
                sb.Append(", ");
            }
            if(sb.Length > 2)
            {
                sb.Length = sb.Length - 2;
            }
            Console.WriteLine(sb);

            list.Sort();

            int sumOfList = 0;
            int count = 0;
            int key = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (int element in list)
            {
                sumOfList += element;

                if (count == 0)
                {
                    key = element;
                    count++;
                }
                else
                {
                    if(key == element)
                    {
                        count++;
                    }
                    else
                    {
                        map.Add(key, count);
                        key = element;
                        count = 1;
                    }
                }
            }

            List<int> modes = new List<int>();
            int highValue = 0;
            StringBuilder modesString = new StringBuilder();

            foreach (KeyValuePair<int,int> pair in map)
            {
                if (highValue == 0)
                {
                    highValue = pair.Value;
                }
                else if (pair.Value > highValue)
                {
                    highValue = pair.Value;
                }
            }

            foreach (KeyValuePair<int,int> pair in map)
            {
                if (pair.Value == highValue)
                {
                    modesString.Append(pair.Key);
                    modesString.Append(", ");
                }
            }

            if(modesString.Length > 2)
            {
                modesString.Length = modesString.Length - 2;
            }

            double average = sumOfList / list.Count();

            int median = list[(list.Count + 1) / 2];
            int range = list.Max() - list.Min();

            Console.WriteLine("Mean: {0}", average);
            Console.WriteLine("Mode: {0}", modesString);
            Console.WriteLine("Median: {0}", median);
            Console.WriteLine("Range: {0}", range);
            Console.WriteLine();
        }
    }
}
