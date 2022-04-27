/*Задание 1. 
Написать программу, которая вычисляет среднее арифметическое элементов массива без учета минимального и 
максимального элементов массива. Элементы массива рандомно в диапазоне [-20; 20] (размер массива вводит пользователь )

Задание 2. 
Написать программу, которая находит сумму четных и сумму нечетных элементов массива. 
(Данные можно взять из первого массива)

Задание 3. 
Написать программу, которая находит в массиве значения, повторяющиеся два и более раз, и показывает их на экран.
(Данные можно взять из первого массива)

Задание 4. 
Написать программу, которая находит в массиве самое маленькое нечетное число и показывает его на экран.
(Данные можно взять из первого массива)

Задание 5. 
Написать программу, которая определяет количество учеников в классе, чей рост превышает средний. 
Рост каждого ученика  рандомно в диапазоне [150, 190], количество учеников задает пользователь. 
Вывести количество и рост каждого ученика  превышающего средний.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            int[] arr;
            int[] arrClass;
            while (true)
            {
                WriteLine("Задайте размер массива/количество учеников в классе: ");
                size = Convert.ToInt32(ReadLine());
                if (size < 0)
                {
                    WriteLine("Размер массива не может быть меньше 0");
                    continue;
                }
                else
                    arr = new int[size];
                arrClass = new int[size];
                Random_Array(arr);

                while (true)
                {
                    WriteLine("Выберете действие, которое хотите произвести:\n " +
                        "1. Вычислить среднее арифметическое элементов массива; \n " +
                        "2. Найти сумму четных и сумму нечетных элементов массива; \n " +
                        "3. Найти в массиве значения, повторяющиеся два и более раз; \n " +
                        "4. Найти в массиве самое маленькое нечетное число; \n " +
                        "5. Определить количество учеников в классе, чей рост превышает средний; \n " +
                        "6. Задать новый размер массива/класса; \n " +
                        "7. Выйти из программы.");
                    WriteLine();

                    int posnum = Convert.ToInt32(ReadLine());

                    switch (posnum)
                    {
                        case 1:
                            {
                                Print_Array("********Ваш массив**********************", arr);
                                WriteLine($"Среднее арифметическое элементов массива (Enumerable.Average) = " +
                                    $" { Enumerable.Average(arr)}");
                                WriteLine($"Среднее арифметическое элементов массива (самодельная функция) = " +
                                    $" { Find_Sum(arr) / arr.Length}");
                                WriteLine();
                            }
                            break;

                        case 2:
                            {
                                Print_Array("********Ваш массив**********************", arr);
                                WriteLine($"Сумма четных элементов массива = { Find_Even_Sum(arr)}");
                                WriteLine($"Сумма нечетных элементов массива = { Find_notEven_Sum(arr)}");
                                WriteLine();
                            }
                            break;

                        case 3:
                            {
                                Print_Array("********Ваш массив**********************", arr);
                                WriteLine("Повторяющиеся элементы массива:");
                                Duplicate_Elements(arr);
                                WriteLine();
                            }
                            break;

                        case 4:
                            {
                                Print_Array("********Ваш массив**********************", arr);
                                WriteLine($"Минимальный нечетный элемент массива = {Min_notEven(arr)}\n");
                                WriteLine();
                            }
                            break;

                        case 5:
                            {
                                Random_Class(arrClass);
                                Print_Array("********Рост учеников класса**********************", arrClass);
                                WriteLine($"Средний рост в классе {Enumerable.Average(arrClass)}");
                                int count = 0;
                                for (int i = 0; i < arrClass.Length; i++)
                                    if (arrClass[i] > Enumerable.Average(arrClass))
                                    {
                                        Write($"{arrClass[i]} ");
                                        count++;
                                    }
                                WriteLine();
                                WriteLine($"Количество учеников в классе с ростом выше среднего: {count}\n");
                            }
                            break;

                        case 6:
                            {
                                WriteLine("Задайте размер массива/количество учеников в классе: ");
                                size = Convert.ToInt32(ReadLine());
                                if (size < 0)
                                {
                                    WriteLine("Размер массива не может быть меньше 0");
                                    continue;
                                }
                                else
                                    arr = new int[size];
                                Random_Array(arr);
                                arrClass = new int[size];
                            }
                            break;
                            
                        case 7:
                            return;

                        default:
                            WriteLine("Вы выбрали несуществующий пункт меню. Выберите снова.");
                            continue;
                    }
                }
            }
        }

        static void Print_Array(string _str, int[] _ar)
        {
            WriteLine(_str);
            foreach (var item in _ar)
            {
                Write($"{item} ");
            }
            WriteLine();
        }

        static void Random_Array(int[] _ar)
        {
            Random rn = new Random();
            for (int i = 0; i < _ar.Length; i++)
            {
                _ar[i] = rn.Next(-20, 20);
            }
        }

        static float Find_Sum(int[] _ar)
        {
            float sum = 0;
            for (int i = 0; i < _ar.Length; i++)
            {
                sum += _ar[i];
            }
            return sum;
        }

        static int Find_Even_Sum(int[] _ar)
        {
            int even_sum = 0;
            for (int i = 0; i < _ar.Length; i++)
            {
                if (_ar[i] % 2 == 0)
                    even_sum += _ar[i];
            }
            return even_sum;
        }

        static int Find_notEven_Sum(int[] _ar)
        {
            int noteven_sum = 0;
            for (int i = 0; i < _ar.Length; i++)
            {
                if (_ar[i] % 2 != 0)
                    noteven_sum += _ar[i];
            }
            return noteven_sum;
        }

        static void Duplicate_Elements(int[] _ar)
        {
            for (int i = 0; i < _ar.Length; i++)
                for (int j = 0; j < _ar.Length; j++)
                {
                    if (i != j && _ar[i] == _ar[j])

                        Write($"{_ar[i]} ");
                }
        }

        static int Min_notEven(int[] _ar)
        {
            int min = 20;
            for (int i = 0; i < _ar.Length; i++)
            {
                if ((_ar[i] % 2) != 0 && _ar[i] < min)
                    min = _ar[i];
            }
            return min;
        }

        static void Random_Class(int[] _ar)
        {
            Random rn = new Random();
            for (int i = 0; i < _ar.Length; i++)
            {
                _ar[i] = rn.Next(150, 190);
            }
        }

    }
}