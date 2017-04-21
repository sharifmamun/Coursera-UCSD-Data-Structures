using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Node
    {
        public int data;
        public Node parent;        
        public List<Node> children;

        public Node()
        {
            children = new List<Node>();
        }

        public Node(int d)
        {
            data = d;
            children = new List<Node>();
        }

        public void addChild(int child)
        {            
            Node childNode = new Node(child);
            //childNode.setParent(this);
            children.Add(childNode);            
        }

        public void setParent(Node parent)
        {
            this.parent = parent;
        }
    }

    class TreeHeight
    {
        public int n;
        public Node root;
        public Node[] nodes;

        public void Read()
        {
            n = Convert.ToInt32(Console.ReadLine());
            nodes = new Node[n];
            var readLine = Console.ReadLine();
            int[] c =new int[n];
            if (readLine != null)
            {
                c = Array.ConvertAll(readLine.Split(), int.Parse);
            }

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node();
            }

            for (int i = 0; i < n; i++)
            {
                int parentIndex = c[i];
                if (parentIndex == -1)
                    root = new Node(i);
                else
                {
                    nodes[parentIndex] = new Node(i);
                    nodes[parentIndex].addChild(i);
                }
                    
            }
        }

        public int ComputeHeight()
        {
            TreeHeight tH = this;
            Stack<Node> s = new Stack<Node>();
            s.Push(root);            
            int maxHeight = 0;
            
            while (s.Count > 0)
            {
                Node v = s.Pop();
                if (v.children != null && v.children.Count > 0)
                {
                    foreach (Node child in v.children)
                    {
                        s.Push(child);
                    }
                    maxHeight++;
                }
            }

            /*for (int vertex = 0; vertex < n; vertex++)
            {
                int height = 0;
                for (int i = vertex; i != -1; i = nodes[i])
                {
                    height++;
                }
                maxHeight = Math.Max(maxHeight, height);
            }*/
            return maxHeight;
        }
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            /*           
            int n = Convert.ToInt32(Console.ReadLine());
            int[] parent = new int[n];
            List<Node> nodes = new List<Node>();         
            var readLine = Console.ReadLine();
            int[] c = new int[n];
            if (readLine != null)
            {
                c = Array.ConvertAll(readLine.Split(), int.Parse);
            }

            for (int i = 0; i < n; i++)
            {
                nodes.Add(new Node(i));
            }

            for (int i = 0; i < n; i++)
            {
                int parentIndex = Convert.ToInt32(c[i]);
                if (parentIndex == -1)
                {
                    nodes[i].setParent(new Node(i));
                    Tree tree = new Tree(new Node(i));                    
                }                    
                else
                {
                    nodes[i].setParent(new Node(parentIndex));
                    nodes[parentIndex].addChild(i);
                }                    
            }

            Console.WriteLine(DepthOfTree(nodes));
            */
            TreeHeight treeHeight = new TreeHeight();
            treeHeight.Read();
            Console.WriteLine(treeHeight.ComputeHeight());
            //Console.WriteLine(DepthOfTree(treeHeight));
        }

        /*public static int DepthOfTree(TreeHeight tH)
        {
            if (tH.root == null || tH.nodes.Length == 0)
                return 0;

            int height = 0;
            foreach (Node child in tH.nodes)
            {
                height = Math.Max(height, DepthOfTree(child.children));
            }

            return height + 1;
        }*/
    }
}
