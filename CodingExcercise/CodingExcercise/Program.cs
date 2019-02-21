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

            bool isValid = IsValidParentheses("[{]}");

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
        /// <summary>
        /// 200. Number of Islands
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int NumberIslands(char[,] grid)
        {
            /*
            Given a 2d grid map of '1's(land) and '0's(water), count the number of islands.An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
            Example 1:

            Input:
            11110
            11010
            11000
            00000

            Output: 1
            Example 2:

            Input:
            11000
            11000
            00100
            00011

            Output: 3
            */
            int numberIslands = 0;

            if (grid == null)
                return numberIslands;

            for(int i=0; i <= grid.GetUpperBound(0); i++)
            {
                for(int j=0; j <= grid.GetUpperBound(1); j++)
                {
                    if(grid[i,j] == '1')
                    {
                        numberIslands++;
                        //set current position and all neightbor to 0
                        SetLandToWater(grid, i, j);
                    }
                }
            }
            return numberIslands;
        }
        private static void SetLandToWater(char[,] grid, int i, int j)
        {
            //1. If row is less than 0
            //2. If row is greater than grid.length(row length)
            //3. If column is less than 0
            //4. If column is greater than grid.length(column lenghth)
            //5. If the current position is 0
            if (i < 0 || i > grid.GetUpperBound(0) || j < 0 || j > grid.GetUpperBound(1) || grid[i, j] == '0')
                return;

            //set current position is 0
            grid[i, j] = '0';
            SetLandToWater(grid, i + 1, j);
            SetLandToWater(grid, i - 1, j);
            SetLandToWater(grid, i, j + 1);
            SetLandToWater(grid, i, j - 1);
        }
        /// <summary>
        /// 20. Valid Parentheses
        /// </summary>
        public static bool IsValidParentheses(string str)
        {
            
            if (str.Length % 2 != 0)
                return false;

            Stack<char> stack = new Stack<char>();
            foreach(char s in str.ToCharArray())
            {
                if (s == '{' || s == '[' || s == '(')
                {
                    stack.Push(s);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        if (isPair(stack.Peek(), s))
                            stack.Pop();
                    }
                }
            }
            if (stack.Count == 0)
                return true;
            return false;
        }
        private static bool isPair(char open, char close)
        {
            return open == '(' && close == ')' || open == '[' && close == ']' || open == '{' && close == '}';    
        }

    }
    //Encode and Decode tinyURL
    public class Codec
    {
        private static Dictionary<string, string> dty = new Dictionary<string, string>();
        public class Base64
        {
            /// <summary>
            /// Encode using Base64String
            /// </summary>
            /// <param name="longURL"></param>
            /// <returns></returns>
            public string Encode(string longURL)
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(longURL));
            }
            /// <summary>
            /// Decode using Base64String
            /// </summary>
            /// <param name="shortURL"></param>
            /// <returns></returns>
            public string Decode(string shortURL)
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(shortURL));
            }
        }
        public class NewGuid
        {
            /// <summary>
            /// Encode using NewGuid
            /// </summary>
            /// <param name="longURL"></param>
            /// <returns></returns>
            public string Encode(string longURL)
            {
                string guid = Guid.NewGuid().ToString();
                dty.Add(guid, longURL);

                return guid;
            }
            /// <summary>
            /// Decode using NewGuid
            /// </summary>
            /// <param name="shortURL"></param>
            /// <returns></returns>
            public string Decode(string shortURL)
            {
                string url = String.Empty;
                return dty.TryGetValue(shortURL, out url)?url:null;
            }
        }
    }
}
