using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "aab";
            bool _returnOrigin = isPalindrome(str1);
            Console.WriteLine(_returnOrigin);
            Console.ReadLine();
        }
        
        /// <summary>
        /// First Unique Character in a String 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>character index</returns>
        public static int FindFirstUniqueCharacter(String str)
        {
            /*
            Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
            Examples:
            s = "leetcode"
            return 0.

            s = "loveleetcode",
            return 2.

            Note: You may assume the string contain only lowercase letters.
            */
            int index = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.IndexOf(str[i]) == str.LastIndexOf(str[i]))
                {
                    return i;
                }
            }
            return index;
        }
        /// <summary>
        /// Reverse String
        /// </summary>
        /// <param name="str"></param>
        /// <returns>reverse string</returns>
        public static string ReverseString(String str)
        {
            string reverseStr = "";
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            reverseStr = new string(arr);
            return reverseStr;
        }
        /// <summary>
        /// Compare if two strings are Anagram. Rearranging the letters of the original word to make a new word or phrase
        /// </summary>
        /// <param name="str1">first input string</param>
        /// <param name="str2">second input string</param>
        /// <returns></returns>
        public static bool isAnagram(String str1, String str2)
        {
            var arr1 = str1.ToArray();
            var arr2 = str2.ToArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            return new string(arr1) == new string(arr2);
        }
        /// <summary>
        /// Robot Return to Origin.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ReturnOrigin(string str)
        {
            str = str.ToUpper();
            bool _isReturnOrigin = false;
            int x = 0, y = 0;
            char[] arr = str.ToCharArray();
            foreach(char m in arr)
            {
                if (m == 'U')
                    y++;
                if (m == 'D')
                    y--;
                if (m == 'L')
                    x--;
                if (m == 'R')
                    x++;
            }
            if (x == 0 && y == 0)
                _isReturnOrigin = true;

            return _isReturnOrigin;
        }
        /// <summary>
        /// Check if a string is Palindrome
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isPalindrome(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return str.ToLower() == new string(arr).ToLower();
        }
    }
}
