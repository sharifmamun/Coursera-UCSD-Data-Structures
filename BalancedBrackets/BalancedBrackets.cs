using System;
using System.Collections.Generic;

namespace BalancedBrackets
{
    public class Bracket
    {
        public char Type;
        public int Position;

        public Bracket(char type, int position)
        {
            Type = type;
            Position = position;
        }

        public bool Match(char c)
        {
            if (this.Type == '[' && c == ']')
                return true;
            if (this.Type == '{' && c == '}')
                return true;
            if (this.Type == '(' && c == ')')
                return true;

            return false;
        }
    }

    class BalancedBrackets
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<Bracket> stack = new Stack<Bracket>();
            bool isMatched = true;
            int answer = 0;
            int position;
            for (position = 0; input != null && position < input.Length && isMatched; position++)
            {
                char c = input[position];

                if (c == '(' || c == '{' || c == '[')
                {
                    Bracket b = new Bracket(c, position+1);
                    stack.Push(b);
                }

                if (c == ')' || c == '}' || c == ']')
                {                    
                    if (stack.Count > 0 && stack.Peek().Match(c))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isMatched = false;
                        answer = position + 1;
                    }
                }
            }

            if (stack.Count > 0 && isMatched)
            {
                isMatched = false;
                if (stack.Count > 0)
                {
                    Bracket b = stack.Peek();
                    answer = b.Position;
                }                
            }            

            if (isMatched)
                Console.WriteLine("Success");
            else
                Console.WriteLine(answer);
        }
    }
}
