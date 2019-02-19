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
        
    }
}
