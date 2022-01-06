using System;
using System.Linq;
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
            int [] array = FillAndCreateArray(GetInfo("Введите длину массивa: "));
            
            // int maxValue = array.Max();
            // array = DeleteOnArray(array, array.ToList().IndexOf(maxValue));
            
            // int [] newArray = Sdvig(array);
            
            // var firstMinus = array.FirstOrDefault(i => i < 0);
            bubbleSort(array);
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
            
            return value;
        }

        public static int[] FillAndCreateArray(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
               array[i] = GetInfo($"Введите значение {i + 1}?: ");
            }
            return array;
        }

        public static int[] DeleteOnArray(int[] array, int indexToDelete)
        {
            return array.Where((val, idx) => idx != indexToDelete).ToArray();
        }

        public static int[] Sdvig(int[] array)
        {
            int size = array.Length;
            int i, j, temp; 
            int m = 2; // количество позиций на которые сдвигаем
 
            for (i = 0; i < m; ++i) 
            { 
                temp = array[size-1]; 
                for ( j = size - 1; j > 0; j--) 
                    array[j] = array[j-1]; 
                array[0] = temp;
            }
 
            for ( i = 0; i < size; ++i) 
                Console.WriteLine($"{array[i]}");

            return array;
        }

        public static int[] bubbleSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            foreach (var VARIABLE in array)
            {
                Console.WriteLine(VARIABLE);
            }
            return array;
        }
        
        
        
    }
}
  