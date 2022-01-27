using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace project_c_sharp
{
    class Program
    {
        static void Main()
        {
            // Zadanie 1, 10 Var
            // int[] integersArray = FillArray(GetInfo("Введите длину массивa: "));
            // PrintArray(integersArray);
            // PrintArray(DeleteFromArray(integersArray));
            
            
            // Zadanie 2, 10 Var

            Int32[,] m2x2 = new int[2, 2];
            var matrix = "";
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    m2x2[row, col] = GetInfo($"Введите значение для адреса {row} {col}: ");
                    matrix += $"{m2x2[row, col].ToString()} ";
                }
                matrix += '\n';
            }
            Console.WriteLine(matrix);
            AddColumns(m2x2, GetInfo("Сколько столбцов добавить?: "));

        }

        public static int[,] AddColumns(int[,] currentMatrix, int columns)
        {
            int[,] matrix = new int[2, columns + 2];
            var textMatrix = "";
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < columns + 2; col++)
                {
                    if (col < columns)
                    {
                        matrix[row, col] = 0;
                        
                        textMatrix += $"{matrix[row, col].ToString()} ";
                        continue;
                    }
                    
                    matrix[row, col] = currentMatrix[row, col - columns];
                    textMatrix += $"{matrix[row, col].ToString()} ";
                }
                textMatrix += '\n';
            }
            Console.WriteLine(textMatrix);
            return matrix;
        }


        public static void PrintArray(int[] array)
        {
            foreach (var VARIABLE in array)
            {
                Console.Write($"{VARIABLE} ");
            }

            Console.WriteLine("");
            // Console.ReadKey();
        }

        public static int[] FillArray(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = GetInfo($"Введите значение {i + 1}?: ");
            }
            return array;
        }
        
        public static int GetInfo(string text)
        {
            int value;
            Console.Write(text);
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Попробуй снова");
                return GetInfo(text);
            }

            Console.WriteLine();
            return value;
        }

        public static int[] DeleteFromArray(int[] fullArray)
        {
            return fullArray.Where((num, index) => index % 2 == 0 && index != 0).ToArray();
        }
    }
}