using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Создать программу, которая будет проверять корректность ввода логина.Корректным логином будет строка от 2 до 10 символов, 
//    содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
//а) без использования регулярных выражений;
//б) ** с использованием регулярных выражений.

namespace Lesson51
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка корректности ввода без использования регулярных выражений");
            Console.WriteLine("Введите логин от 2 до 10 символов, первый символ не должен быть цифрой:");
            string Login = string.Empty;
            while(true)
            {
                Login = Console.ReadLine();
                int count = Login.Length;
                char sym = Login.ElementAt(0);
                if (count >= 2 && count <= 10 && Char.IsDigit(sym)) break;
                else Console.WriteLine("Повторите ввод: несоответствие шаблону!");
            }
            Console.WriteLine("Логин соответствует шаблону!\n");

            Console.WriteLine("Проверка корректности ввода без использования регулярных выражений");
            Console.WriteLine("Введите логин от 2 до 10 символов, первый символ не должен быть цифрой:");
            string patternNumber = @"^\d[\d|\w]{1,9}$";
            Regex RegexString = new Regex(patternNumber,RegexOptions.IgnoreCase);
            Login = string.Empty;
            while (true)
            {
                Login = Console.ReadLine();
                if (RegexString.IsMatch(Login)) break;
                else Console.WriteLine("Повторите ввод: несоответствие шаблону!");
            }
            Console.WriteLine("Логин соответствует шаблону!");
            Console.ReadKey();
        }
    }
}
