using System;
using System.Collections;
using System.Collections.Generic;

namespace TreeOrders
{
    class TreeOrder
    {
        int n;
        int[] key, left, right;
        public void Read()
        {
            n = Convert.ToInt32(Console.ReadLine());
            key = new int[n];
            left = new int[n];
            right = new int[n];

            int[] temp = new int[3];
            for (int i = 0; i < n; i++)
            {
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    temp = Array.ConvertAll(readLine.Split(), int.Parse);
                    key[i] = temp[0];
                    left[i] = temp[1];
                    right[i] = temp[2];
                }
            }
        }

        public List<int> InOrder()
        {
            List<int> result = new List<int> { 0 };
            return result;
        }

        public List<int> PreOrder()
        {
            List<int> result = new List<int> {0};
            return result;
        }

        public List<int> PostOrder()
        {
            List<int> result = new List<int> { 0 };
            return result;
        }

        public void Print(List<int> integers)
        {
            foreach (var integer in integers)
            {
                Console.Write(integer);
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
