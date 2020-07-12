using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
 * В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>, где
<Фамилия> — строка, состоящая не более чем из 20 символов, 
<Имя> — строка, состоящая не более чем из 15 символов, 
<оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
<Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом. Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран 
фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
*/
namespace Lesson54
{
    struct Student
    {
        public string firstName;
        public string secondName;
        public int one;
        public int two;
        public int three;
        public double sum;
    }

    class StudentComparer : IComparer<Student>
    {
        public int Compare(Student p1, Student p2)
        {
            if (p1.sum > p2.sum)
                return 1;
            else if (p1.sum < p2.sum)
                return -1;
            else
                return 0;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Student> listStudents = new List<Student>();
            int number = random.Next(10, 100);
            Console.WriteLine($"Введите информацию об {number} учениках по шаблону <Фамилия до 20 символов> <Имя до 15 символов> <оценки - 3 через пробел>:");
            string pattern = @"^[а-яА-Я]{1,20}\s[а-яА-Я]{1,15}\s[1-5]\s[1-5]\s[1-5]$";
            Regex regex = new Regex(pattern);
            int i = 0;
            while (i < number)
            {
                string InfoStudent = Console.ReadLine();
                if (regex.IsMatch(InfoStudent))
                {
                    string[] Item = InfoStudent.Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
                    listStudents.Add(new Student
                    {
                        firstName = Item.ElementAt(0),
                        secondName = Item.ElementAt(1),
                        one = Convert.ToInt32(Item.ElementAt(2)),
                        two = Convert.ToInt32(Item.ElementAt(3)),
                        three = Convert.ToInt32(Item.ElementAt(4)),
                        sum = Convert.ToInt32(Item.ElementAt(2)) + Convert.ToInt32(Item.ElementAt(3)) + Convert.ToInt32(Item.ElementAt(4))
                    }
                    );
                    i++;
                }
                else
                {
                    Console.WriteLine("Ввод не соответствует шаблону!");
                }
            }
            listStudents.Sort(new StudentComparer());

            Console.WriteLine("Вывод результатов трех худших учеников:");
            for (int j = 0; j < 3; j++)
            {
                Student st = listStudents.ElementAt(j);
                Console.WriteLine($"{st.firstName} {st.secondName} {(double)st.sum / 3}");
            }

            int k = 1;
            while (true)
            {
                if (listStudents.ElementAt(3).sum == listStudents.ElementAt(3 + k).sum)
                {
                    Student st = listStudents.ElementAt(3 + k);
                    Console.WriteLine($"{st.firstName} {st.secondName} {(double)st.sum / 3}");
                }
                else break;
            }
            Console.ReadKey();
        }
    }
}
