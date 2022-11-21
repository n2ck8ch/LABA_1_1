using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

using System.Text.RegularExpressions;

namespace LABA1
{
    internal class Task:chisla
    {
        public Task()
        {

        }

        static void Main(string[] args)
        {

            while (true)
            {
                // очистка буфера, чтобы исключить нажатия на клавиатуру тогда, когда не ждём ввода
                while (Console.KeyAvailable) { Console.ReadKey(true); }

                Console.Clear();
                Console.WriteLine("[0] Exit");
                Console.WriteLine("[1] Hello World!");
                Console.WriteLine("[2] Calc: <(X+sqrt(Y))/Z>");
                Console.WriteLine("[3] Recursion date");
                Console.WriteLine("[4] Strings");

                ConsoleKey Key = GetButton();
                Console.Clear();

                if (Key == ConsoleKey.D0)
                {
                    break;
                }
                else if (Key == ConsoleKey.D1)
                {
                    Hello a = new Hello();
                    a.Hello1();
                }
                else if (Key == ConsoleKey.D2)
                {
                    Calc b = new Calc();
                    b.Calc1();
                }
                else if (Key == ConsoleKey.D3)
                {
                    Date c = new Date();
                    c.Date1();
                }
                else if (Key == ConsoleKey.D4)
                {
                    STR d = new STR();
                    d.STR1();
                }
                else
                {
                    Console.WriteLine("Не туда тыкаешь приятель.");
                    Thread.Sleep(1000);
                }
            }
        }

        public static ConsoleKey GetButton()
        {
            var but = Console.ReadKey(true).Key;


            return but;
        }
    }

    public class Hello
    {
        public void Hello1()
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
            Console.ReadLine();
        }
    }


    public class chisla
    {
        public double X, Y, Z;

        public void inputC()
        {

            do
            {
                Console.Write("Введите X: ");
                string input_X = Console.ReadLine();
                if (!double.TryParse(input_X, out X))
                {
                    Console.WriteLine("Ввел не то, давай заново");
                    Thread.Sleep(3000);
                    Console.Clear();
                    continue;

                }
                else X = Convert.ToDouble(input_X);

                break;
            }
            while (true);

            do
            {
                Console.Write("Введите Y: ");
                string input_Y = Console.ReadLine();
                if (!double.TryParse(input_Y, out Y))
                {
                    Console.WriteLine("Ввел не то, давай заново");
                    Thread.Sleep(3000);
                    Console.Clear();
                    continue;
                }

                if (Y < 0)
                {
                    Console.WriteLine("Переменная Y должна быть больше, либо равна 0. Вводи заново.");
                    Thread.Sleep(5000);
                    Console.Clear();
                    continue;
                }
                else Y = Convert.ToDouble(input_Y);

                break;
            }
            while (true);

            do
            {
                Console.Write("Введите Z: ");
                string input_Z = Console.ReadLine();
                if (!double.TryParse(input_Z, out Z))
                {
                    Console.WriteLine("Ввел не то, давай заново");
                    Thread.Sleep(3000);
                    Console.Clear();
                    continue;

                }

                if (Z == 0)
                {
                    Console.WriteLine("Переменная Z не должна быть равна 0. Давай заново.");
                    Thread.Sleep(5000);
                    Console.Clear();
                    continue;
                }
                else Z = Convert.ToDouble(input_Z);

                break;
            }
            while (true);

            Console.WriteLine(X);
            Console.WriteLine(Y);
            Console.WriteLine(Z);
        }
    }

    public class Calc:chisla
    {
        public void Calc1()
        {

            chisla n = new chisla();
            n.inputC();

            Console.WriteLine(X);
            Console.WriteLine(Y);
            Console.WriteLine(Z);

            double result;
            Console.Write($"({X}+sqrt({Y})) / {Z} = ");
            result = (X + Math.Sqrt(Y)) / Z;
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

    public class Date
    {
        public void Date1()
        {
            Console.WriteLine("Пока в работе! Но я обязательно сдам вторую лабу)");
            Console.ReadKey();
        }
    }

    public class STR
    {
        // функция для удаления дублирующих проблелов. Приватная, т.к. используется
        // локальными функциями и нет смысла в её использовании из вне
        private string deleteDoubleSpaces(string str) {
            bool isDone = false;
            while(!isDone) {
                str = str.Replace("  ", " ");
                if(!str.Contains("  ")) {
                    isDone = true;
                }
            }
            return str;
        }

        private bool isSameLoweredTrimedWithoutDoubleSpaces(string str1, string str2) {
            str1 = str1.ToLower().Trim(' ');
            str1 = deleteDoubleSpaces(str1);
            
            str2 = str2.ToLower().Trim(' ');
            str2 = deleteDoubleSpaces(str2);

            return str1 == str2;
        }

         private bool isPerevertysh(string str1, string str2) {
            if(str1.Length != str2.Length) {
                return false;
            }

            for (int i = 0, lenght = str1.Length; i < lenght/2; i++)
            {   
                if(str1[i] != str2[lenght-1-i]) {
                    return false;
                }
            }
            return true;
        }

        public void STR1()
        {
            string str1, str2;

            Console.WriteLine("Введите первую строку: ");
            str1 = Console.ReadLine();

            Console.WriteLine("Введите вторую строку: ");
            str2 = Console.ReadLine();
            
            Console.WriteLine("\n");

            // если строки не равны - возвращаем ошибку
            Console.WriteLine($"Совпадают ли они посимвольно: {str1 == str2}");

            Console.WriteLine($"Совпадают ли в приведённом виде: {isSameLoweredTrimedWithoutDoubleSpaces(str1,str2)}");

            Console.WriteLine($"Являются ли перевёртышами друг друга: {isPerevertysh(str1, str2)}");

            Regex validateEmailRegex = new Regex("[^@ \t\r\n]+@[^@ \t\r\n]+\\.[^@ \t\r\n]+");
            Regex validatePhoneRegex = new Regex("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$");
            Regex validateIPRegex = new Regex("(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}");

            Console.WriteLine($"Являются ли e-mail:\tпервая строка - {validateEmailRegex.IsMatch(str1)}\tвторая строка - {validateEmailRegex.IsMatch(str2)}");
            Console.WriteLine($"Являются ли telephone:\tпервая строка - {validatePhoneRegex.IsMatch(str1)}\tвторая строка - {validatePhoneRegex.IsMatch(str2)}");
            Console.WriteLine($"Являются ли IP: \tпервая строка - {validateIPRegex.IsMatch(str1)}\tвторая строка - {validateIPRegex.IsMatch(str2)}");

            Console.ReadKey();


        }
    }
}