using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumScoreFromRemovingSubstring
{
    class Program
    {
        public static int MaximumGain(string s, int x, int y)
        {
            int point = 0;
            Stack<char> stack = new Stack<char>();
            // Find out whether to call ab or ba first
            if (x>y)
            {
                foreach (char ch in s)
                {
                    if (stack.Count > 0 && stack.Peek() == 'a' && ch == 'b')
                    {
                        stack.Pop();
                        point += x;
                    }
                    else
                    {
                        stack.Push(ch);
                    }
                }

                // Collect remaining characters
                char[] remainingChars = stack.ToArray();
                Array.Reverse(remainingChars);
                stack.Clear();

                foreach (char ch in remainingChars)
                {
                    if (stack.Count > 0 && stack.Peek() == 'b' && ch == 'a')
                    {
                        stack.Pop();
                        point += y;
                    }
                    else
                    {
                        stack.Push(ch);
                    }
                }
            }
            else
            {
                foreach (char ch in s)
                {
                    if (stack.Count > 0 && stack.Peek() == 'b' && ch == 'a')
                    {
                        stack.Pop();
                        point += y;
                    }
                    else
                    {
                        stack.Push(ch);
                    }
                }

                // Collect remaining characters
                char[] remainingChars = stack.ToArray();
                Array.Reverse(remainingChars);
                stack.Clear();

                foreach (char ch in remainingChars)
                {
                    if (stack.Count > 0 && stack.Peek() == 'a' && ch == 'b')
                    {
                        stack.Pop();
                        point += x;
                    }
                    else
                    {
                        stack.Push(ch);
                    }
                }
            }

            return point;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(MaximumGain("aabbaaxybbaabb", 5, 4));
            Console.ReadLine();

        }
    }
}
