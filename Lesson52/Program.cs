using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения,  которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) *** Создать метод, который производит частотный анализ текста.В качестве параметра в него передается массив слов и текст, 
в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.Здесь требуется использовать класс Dictionary.
*/
namespace Lesson52
{
    static public class Message
    {
        static public void PrintStringMoreNumber(string str, int number)
        {
            List<string> list = GetListStringSplit(str);
            Console.WriteLine($"Вывод слов с количетсвом символов не более {number}:");
            foreach (string item in list)
            {
                if(item.Length <=number) Console.Write($"{item}\n");
            }
            Console.Write("\n");
        }

        static public void PrintStringDeleteLastSymbol(string str, char[] ch)
        {
            List<string> ListWordNumber = new List<string>();
            string[] ListWord = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ListWord.Count(); i++)
            {
                string strWord = ListWord.ElementAt(i);
                if (Char.IsPunctuation(strWord.ElementAt(strWord.Length - 1)))
                {
                    //strWord = strWord.Remove(strWord.Length - 1);
                    if(strWord.Length < 2)
                    {
                        ListWordNumber.Add(strWord); continue;
                    } 
                    if (strWord.ElementAt(strWord.Length - 2).CompareTo(ch.ElementAt(0)) != 0) ListWordNumber.Add(strWord);
                }
                else if(strWord.ElementAt(strWord.Length - 1).CompareTo(ch.ElementAt(0)) != 0) ListWordNumber.Add(strWord);
            }
            Console.WriteLine($"Вывод слов, которые не заканчиваются на {ch.ElementAt(0)}:");
            foreach (string item in ListWordNumber) Console.Write($"{item} ");
            Console.Write("\n");
        }

        static public string GetLongWord(string str)
        {
            string LongString = string.Empty;
            List<string> list = GetListStringSplit(str);
            foreach(string item in list)
            {
                if (item.Length >= LongString.Length) LongString = item;
            }
            return LongString;
        }

        static internal List<string> GetListStringSplit(string str)
        {
            List<string> ListWordNumber = new List<string>();
            string[] ListWord = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ListWord.Count(); i++)
            {
                string strWord = ListWord.ElementAt(i);
                if (Char.IsPunctuation(strWord.ElementAt(strWord.Length - 1)))
                {
                    ListWordNumber.Add(strWord.Remove(strWord.Length - 1));
                }
                else ListWordNumber.Add(strWord);
            }
            return ListWordNumber;
        }

        static public StringBuilder BuilderString(string str, int number)
        {
            StringBuilder output = new StringBuilder();
            List<string> list = GetListStringSplit(str);
            foreach (string item in list)
            {
                if (item.Length >= number) output.Append($"{item} ");
            }
            return output;
        }

        static public void PrintAnalizeString(string str)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            List<string> list = GetListStringSplit(str);
            foreach(string item in list)
            {
                if (!dict.ContainsKey(item)) dict.Add(item, 1);
                else dict[item] += 1; 
            }
            foreach(KeyValuePair<string,int> pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} раз;");
            }
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сообщение");
            string StringMessage = Console.ReadLine();
            Message.PrintStringMoreNumber(StringMessage, 10);
            Message.PrintStringDeleteLastSymbol(StringMessage, "е".ToArray());
            Console.WriteLine($"Самое длинное слово в сообщении: {Message.GetLongWord(StringMessage)} - {Message.GetLongWord(StringMessage).Length} букв.");
            Console.WriteLine($"Сформированное предложение из самый длинных слов:\n{Message.BuilderString(StringMessage,6)}");
            Console.WriteLine("Вывод частоты повторения слов:");
            Message.PrintAnalizeString(StringMessage);
            Console.ReadKey();
        }
    }
}
