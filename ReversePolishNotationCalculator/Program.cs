using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReversePolishNotationCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) //Бесконечный цикл
            {
                Console.Write("Введите выражение: "); //Предлагаем ввести выражение
                try
                {
                    Console.WriteLine(ReversePolishNotation.Calculate(Console.ReadLine())); //Считываем, и выводим результат
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message); // Выводим сообщение о соответствующем исключении
                }
            }
        }
    }
}
