using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson55
{
    struct Question
    {
        public string quenstion;
        public string answer;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Отвечайте 'Да' или 'Нет'!");
            List<Question> list = new List<Question>();
            StreamReader qReader = new StreamReader(Directory.GetCurrentDirectory() + "//question.txt");
            string reader = string.Empty;
            do
            {
                reader = qReader.ReadLine();
                string[] item = reader.Split(new string[] { "," },StringSplitOptions.None);
                list.Add(new Question { quenstion = item[0], answer = item[1]});
            } while (!qReader.EndOfStream);
            qReader.Close();

            Random random = new Random();
            int[] perm = Enumerable.Range(0, list.Count).ToArray();
            for (int j = list.Count-1; j >= 1; j--)
            {
                int k = random.Next(j + 1);
                int temp = perm[k];
                perm[k] = perm[j];
                perm[j] = temp;
            }
            string rd = string.Empty;
            string a = string.Empty;
            for(int i=0; i < 5; i++)
            {
                Console.Write($"{i+1}. {list.ElementAt(perm[i]).quenstion} ");
                rd = Console.ReadLine();
                a = list.ElementAt(perm[i]).answer;
                if (a == rd) Console.WriteLine("Правильный ответ!");
                else Console.WriteLine("Неправильный ответ!");
            }
            Console.WriteLine("Тест окончен!");
            Console.ReadKey();
        }
    }
}
