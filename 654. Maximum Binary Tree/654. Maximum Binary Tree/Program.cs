using System;
using System.Collections.Generic;
using System.Linq;

namespace _654._Maximum_Binary_Tree
{
    class Program
    {
        public static int[] input;
        public static List<string> Output = new List<string>();
        public static bool GetResult = false;
        public static int[] Left_New_List;
        public static int[] Right_New_List;
        public static int Min_Val;
        static void Main(string[] args)
        {
            input = new int[] { 3, 2, 1, 6, 0, 5 };
            Min_Val = input.Min();
            Method1_FindMax(new List<int[]> { input });  //Method1
            Output.ForEach(val => Console.WriteLine(val));
            //nums = Output.Select(int.Parse).ToArray();
            Console.ReadLine();

        }

        static void Method1_FindMax(List<int[]> array_list)    //Start from the Max Value
        {
            GetResult = true;   //Set true for every loop, if array not null, turn false
            int Temp_Max_Idx;
            List<int[]> temp_array = new List<int[]>();
            //int Temp_Max_Val;
            //int[] Temp_Array;
            foreach (int[] array in array_list)
            {
                if (array.Length != 0)
                {
                    Temp_Max_Idx = Array.IndexOf(array, array.Max());    // Find Max Value and it's Addr in array
                    try // Find left right value and add to output
                    {
                        Output.Add(array.Max().ToString()); //Add the max to output
                        Left_New_List = array.Where(val => Array.IndexOf(array, val) < Temp_Max_Idx).ToArray(); // 3, 2, 1, 6, 0, 5 
                        Right_New_List = array.Where(val => Array.IndexOf(array, val) > Temp_Max_Idx).ToArray();

                        if (Left_New_List.Length != 0 || Right_New_List.Length != 0)
                        {
                            temp_array.Add(Left_New_List);
                            temp_array.Add(Right_New_List);
                        }


                    }
                    catch   //if catch, means there is no element in 
                    {
                        //No need
                    }
                    GetResult = false;
                    //if (array.Max() == Min_Val) return;
                }
                else
                {
                        Output.Add("Null");
                }

            }
            if (GetResult == true) return;
            Method1_FindMax(temp_array);     //Left,Right Recursion
        }
    }
}
