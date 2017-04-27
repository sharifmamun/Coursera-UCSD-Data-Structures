using System;
using System.Collections.Generic;

namespace TreeOrders
{
    /*
        Input:
        5
        4  1  2
        2  3  4
        5 -1 -1
        1 -1 -1
        3 -1 -1

           4
          / \
         2   5
        / \
       1   3

        Output:
        1 2 3 4 5
        4 2 1 3 5
        1 3 2 5 4
    */

    internal class TreeOrder
    {
        private int n;
        private int[] _key;
        private int[] _left;
        private int[] _right;

        public void Read()
        {
            n = Convert.ToInt32(Console.ReadLine());
            _key = new int[n];
            _left = new int[n];
            _right = new int[n];

            var temp = new int[3];
            for (var i = 0; i < n; i++)
            {
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    temp = Array.ConvertAll(readLine.Split(), int.Parse);
                    _key[i] = temp[0];
                    _left[i] = temp[1];
                    _right[i] = temp[2];
                }
            }
        }

        public List<int> InOrder()
        {
            int index = 0;
            List<int> result = new List<int>();
            Stack<int> stack = new Stack<int>();

            while (true)
            {
                if (index != -1)
                {
                    stack.Push(index);
                    index = _left[index];
                }
                else if(stack.Count > 0)
                {
                    index = stack.Pop();
                    result.Add(_key[index]);
                    index = _right[index];
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        public List<int> PreOrder()
        {
            int index = 0;
            List<int> result = new List<int>();
            Stack<int> stack = new Stack<int>();

            while (true)
            {
                if (index != -1)
                {
                    result.Add(_key[index]);
                    stack.Push(index);
                    index = _left[index];
                }
                else if (stack.Count > 0)
                {
                    index = stack.Pop();                    
                    index = _right[index];
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        /*
         * PostOrder is a bit different than the rest traversals          
         */
        public List<int> PostOrder()
        {
            // Using two stacks            
            List<int> result = new List<int>();
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();            

            stack1.Push(0);

            while (stack1.Count > 0)
            {
                int index = stack1.Pop();
                stack2.Push(_key[index]);

                int leftIndex = _left[index];
                int rightIndex = _right[index];

                if (leftIndex != -1)
                    stack1.Push(leftIndex);
                if (rightIndex != -1)
                    stack1.Push(rightIndex);
            }

            while (stack2.Count > 0)
                result.Add(stack2.Pop());
            return result;
        }

        public void Print(List<int> integers)
        {
            foreach (var integer in integers)
            {
                Console.Write(integer + " ");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            var treeOrder = new TreeOrder();
            treeOrder.Read();

            treeOrder.Print(treeOrder.InOrder());
            treeOrder.Print(treeOrder.PreOrder());
            treeOrder.Print(treeOrder.PostOrder());
        }
    }
}