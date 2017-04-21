using System;

namespace TreeHeight
{
    internal class TreeHeight
    {
        public int n;        
        public int[] Parents;
        public int[] Children;

        public void Read()
        {
            n = Convert.ToInt32(Console.ReadLine());
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                Parents = Array.ConvertAll(readLine.Split(), int.Parse);
            }

            Children = new int[n];
            for (var i = 0; i < n; i++)
            {
                Children[i] = 0;
            }
        }

        public int ComputeHeight(int nodeId)
        {
            var temp = Parents[nodeId];

            if (temp == -1)
                return 1;
            if (Children[nodeId] != 0)
                return Children[nodeId];

            Children[nodeId] = 1 + ComputeHeight(Parents[nodeId]);

            return Children[nodeId];
        }
    }

    internal class Solution
    {
        public static void Main(string[] args)
        {
            var treeHeight = new TreeHeight();
            treeHeight.Read();
            var maxHeight = 0;
            for (var i = 0; i < treeHeight.n; i++)
            {
                maxHeight = Math.Max(maxHeight, treeHeight.ComputeHeight(i));
            }
            Console.WriteLine(maxHeight);
        }
    }
}