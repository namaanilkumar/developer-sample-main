
using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        //public static int GetFactorial(int n) => throw new NotImplementedException();

        //public static string FormatSeparators(params string[] items) => throw new NotImplementedException(); 

        public static int GetFactorial(int n) => CallFactorial(n);

        public static int CallFactorial(int n)
        {
            int result = 1;
            for (int i = n; i >= 1; i--)
            {
                result = result * i;
            }
            return result;
        }

        public static string FormatSeparators(params string[] items) => CallFormatSeparators(items);

        private static string CallFormatSeparators(string[] items)
        {
            string strResult = "";
            for (int i = 0; i < items.Length - 1; i++)
            {

                strResult = strResult + items[i] + ", ";
            }
            int index = strResult.LastIndexOf(',');
            strResult = strResult.Remove(index, 1);
            strResult = strResult + "and " + items[items.Length - 1];
            return strResult;
        }
    }
}