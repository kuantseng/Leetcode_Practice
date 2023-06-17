using System;

namespace _394._Decode_String
{
    class Program
    {
        public static string Encode_Str = "3[a]2[bc[2bc2[bc]]]";
        public static string Result;
        static void Main(string[] args)
        {
            Console.WriteLine(Str_Decode(Encode_Str));
            Console.ReadKey();
        }
        public static string Str_Decode(string input)
        {
            Result = input;
            while (Result.IndexOf("[") > 0)
            {
                int coefficient = 0;   // coefficient
                int temp_coeff = 0;  
                int pre_char_count = 1;
                string temp_result_str = "";
                int start_symbol = Result.LastIndexOf("[");
                string temp_str = Result.Substring(start_symbol, Result.Length - start_symbol);
                int end_symbol = Result.IndexOf("]", start_symbol);
                temp_str = Result.Substring(start_symbol+1, end_symbol-start_symbol-1);
                try
                {
                    while ((int.TryParse(Result.Substring(start_symbol - pre_char_count, pre_char_count), out temp_coeff)))
                    {
                        pre_char_count++;
                        coefficient = temp_coeff;
                    }
                }
                catch
                {

                }

                for (int i = 0; i < coefficient; i++)
                {
                    temp_result_str = temp_result_str + temp_str;
                }

                Result = Result.Substring(0,start_symbol - (pre_char_count-1)) + temp_result_str + Result.Substring(end_symbol+1);
            }
            return Result;
        }
    }
}
