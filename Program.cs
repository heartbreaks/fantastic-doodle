using System;
using System.Drawing;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;

namespace project_c_sharp
{
    class Program
    {
        static void Main()
        {
            // // Задание №1
            // Console.WriteLine("-----------------Задание №1------------------------");
            // IcantInterpretateIt();
            //
            // // Задание №2
            // Console.WriteLine("-------------------- Задание №2 -----------------");
            // float coordX = GetUserCoord('X'), coordY = GetUserCoord('Y');
            // Coordinates coordinates = new Coordinates(coordX, coordY);
            // Console.WriteLine(coordinates.GetCoordinates() ? "Входит" : "Не входит");
            //
            // // Задание №3
            // Console.WriteLine("-------------------- Задание №3 -----------------");
            // MathCalculate();
            
            
            // -----------------------------------------------------
            SecondLab.Start();
        }

        static float GetUserCoord(char Coordinate)
        {
            float value;
            Console.Write($"Введите значение по {Coordinate}:");
            
            if (!float.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Потребуется снова ввести значение, мы такое не терпим");
                return GetUserCoord(Coordinate);
            }
            return value;
        }

        // Задание 3 
        static void MathCalculate()
        {
            const double variableA = 100;
            const double variableB = 0.001;
            
            var first = Math.Pow((variableA + variableB), 3);
            
            var result = (first - (Math.Pow(variableA, 3) + (3 * (Math.Pow(variableA, 2) * variableB)))) /
                (3 * (variableA * Math.Pow(variableB, 2))) + Math.Pow(variableB, 3);      

            // VALUES WITH FLOAT TYPE
            const float a = 100;
            const float b = (float)0.001;
            
            var result2 = (((a + b) * (a + b) * (a + b)) - ((a * a * a) + 3 * ((a * a) * b))) / 3 * (a * (b * b)) + (b * b * b);
            Console.WriteLine($"Math calculate result of double type: {result}. And result 2 is of float type: {result2}");
        }

        static void IcantInterpretateIt()
        {
            int n = 1;
            int m = 2;
            // Console.WriteLine(m / --n++); // Ошибка, нельзя делать до и после инкремент \ декремент. К тому же это бесполезно
            Console.WriteLine("Ошибка, нельзя делать до и после инкремент / декремент. К тому же это бесполезно");
            Console.WriteLine(m / n < n--); // Булево значение (оператор сравнения). При текущих обстоятельствах false
            Console.WriteLine(m + n++ > n + m ); // Всегда ложно, n прибавит саму себя и в правой стороне будет то же самое. Бесполезно
            
            double x = GetUserCoord('X');
            var result = Math.Pow(x, 5) * Math.Sqrt(Math.Abs(x - 1)) + (Math.Abs(25 - Math.Pow(x, 5)));
            
            Console.WriteLine($"Result of expression: {result}");
        }
        
    }

    // Задание №2:
    public class Coordinates
    {
        private int GraphX { get; }
        private int GraphY { get; } 
        private double UserTargetX { get; }
        private double UserTargetY { get; }

        public Coordinates(double userTargetX, double userTargetY)
        {
            GraphX = -7;
            GraphY = -1;
            UserTargetX = userTargetX;
            UserTargetY = userTargetY;
        }
    
        public bool GetCoordinates()
        {
            return UserTargetY + UserTargetX / 7 >= GraphY && UserTargetY < 0 && UserTargetX < 0;
        }
    }


    public class SecondLab
    {
        public static void Start()
        {
            Console.WriteLine("---------------- Лаба 2 ----------------");
            Console.WriteLine("---------------- Задание 1 -------------");
            MinAndMaxValues();
            
            Console.WriteLine("---------------- Задание 2 -------------");
            GetMaxValue();
            
            Console.WriteLine("---------------- Задание 3 -------------");
            Console.WriteLine(isPowerOfThree() ? "Является степенью 3" : "Не является степенью 3");
            
        }


        private static void MinAndMaxValues()
        {
            Console.Write("Длина массива: ");
            int length = 0;
            int.TryParse( Console.ReadLine(), out length);

            if (length > 0)
            {
                int[] values = new int[length];
                for (int i = 0; i < length; i++)
                {
                    Console.Write("Введите целое число: ");
                    int userValue;
                    if (int.TryParse(Console.ReadLine(), out userValue))
                    {
                        values[i] = userValue;
                    }
                    else
                    {
                        Console.WriteLine("Число не целое, либо вообще не число");
                        i -= 1;
                    }
                }
                getMaxAndLowValues(values);
            }
            else
            {
                Console.WriteLine("Данные неккоректны, давай по новой");
                MinAndMaxValues();
            }
        }

        public static void getMaxAndLowValues(int[] array)
        {
            int maxValue = 0;
            int minValue = 999999999;
            foreach (var number in array)
            {
                Console.WriteLine(number);
                maxValue = maxValue > number ? maxValue : number;
                minValue = minValue < number ? minValue : number;
            }
            
            Console.WriteLine($"Min val: {minValue}, then max value: {maxValue}");
        }

        public static void GetMaxValue()
        {
            int minValue = 999999999;
            int maxValueIndex = 0;
            int index = 0;
            
            int userValue = 999999999;
            Console.WriteLine("Если надо выйти из перебора, введите 0");
            Console.WriteLine("Если вы допустите ошибку, мы закончим перебор.");
            while (userValue != 0)
            {
                Console.Write("Введите число: ");
                int.TryParse(Console.ReadLine(), out userValue);
                
                if (userValue < minValue && userValue != 0)
                {
                    minValue = userValue;
                    maxValueIndex = index;
                }

                index += userValue != 0 ? 1 : 0;
            }
            
            Console.WriteLine($"Index of min value: {maxValueIndex} (or human number {maxValueIndex + 1}), him value is: {minValue}");
        }
        
        public static bool isPowerOfThree()
        {
            Console.Write("Введите число K: ");
            int valueK = int.Parse(Console.ReadLine());
            Console.Write("Введите число N: ");
            int valueN = int.Parse(Console.ReadLine());
            if (valueK == Math.Pow(3, valueN))
            {
                return true;
            }
            return false;
        }
    }
}
