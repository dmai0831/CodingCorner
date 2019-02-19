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
            string str1 = "https://leetcode.com/problems/design-tinyurl";
            Codec.Base64 base64 = new Codec.Base64();
            string encodeURL = base64.Encode(str1);
            Console.WriteLine(encodeURL);
            Console.WriteLine(base64.Decode(encodeURL));

            Codec.NewGuid newGuid = new Codec.NewGuid();
            string encodeURL1 = newGuid.Encode(str1);
            Console.WriteLine(encodeURL);
            Console.WriteLine(newGuid.Decode(encodeURL1));
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
