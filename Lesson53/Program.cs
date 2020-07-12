using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Например:
badc являются перестановкой abcd.
*/
namespace Lesson53
{
    class Program
    {
        static List<char> GetList(string str)
        {
            List<char> list = new List<char>();
            foreach (char ch in str)
            {
                list.Add(ch);
            }
            return list;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку:");
            string firstString = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string secondString = Console.ReadLine();
            List<char> firstList = GetList(firstString);
            firstList.Sort();
            List<char> secondList = GetList(firstString);
            secondList.Sort();
            bool Not = true;
            if (firstList.Count != secondList.Count) Not = false;
            else
            {
                for (int i = 0; i < firstList.Count;i++){
                    if (firstList.ElementAt(i) != secondList.ElementAt(i)) Not = false;
                }
            }
            Console.WriteLine($"Массивы {(!Not ? "не " : "")}являются анаграммами!");
            Console.ReadKey();
        }
    }
}
