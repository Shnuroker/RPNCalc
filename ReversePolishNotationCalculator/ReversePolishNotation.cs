﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ReversePolishNotationCalculator
{
    class ReversePolishNotation
    {
        // Calculate - главный метод класса, ему передается значение в виде строки (записанной в обратной польской записи). Метод возвращает итоговый результат вычислений.
        static public double Calculate(string input)
        {
            double result = Counting(input); //Решаем выражение
            return result; //Возвращаем результат
        }


        // Counting - метод, которому метод Calculate передает выражение. Метод вычисляет и возвращает результат этого выражения.
        static private double Counting(string input)
        {
            double result = 0; //Результат
            Stack<double> temp = new Stack<double>(); //Временный стек для решения

            for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                    {
                        a += input[i]; //Добавляем
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a)); //Записываем в стек
                    i--;
                }
                else if (IsOperator(input[i])) //Если символ - оператор
                {
                    //Проверка на наличие в стеке хотя бы 2 значений
                    if (temp.Count < 2)
                    {
                        throw new FormatException("Отсутствует значение для выполнения операции");
                    }
                    //Берем два последних значения из стека
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i]) //И производим над ними действие, согласно оператору
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
                //Проверка на обнаружения ошибок в введенной строке
                else if (IsDelimeter(input[i])!=true)
                    {
                       throw new FormatException("На месте " + i + " обнаружен символ \"" + input[i] + "\" не являющийся цифрой или оператором");
                    }  
            }
            //Проверка на наличие в стеке последнего итогового значения
           if (temp.Count!=1)
            {
                throw new FormatException("Неверный формат входной строки");
            }
            
            return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }


        //Метод возвращает true, если проверяемый символ - пробел
        static private bool IsDelimeter(char c)
        {
            if ((" ".IndexOf(c) != -1))
                return true;
            return false;
        }


        //Метод возвращает true, если проверяемый символ - оператор
        static private bool IsOperator(char с)
        {
            if (("+-/*^".IndexOf(с) != -1))
                return true;
            return false;
        }
    }
}
