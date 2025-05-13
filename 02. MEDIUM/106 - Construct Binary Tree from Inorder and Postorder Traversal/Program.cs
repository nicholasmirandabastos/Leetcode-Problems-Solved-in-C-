using Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal;

class Program
{
    static void Main(string[] args)
    {
        int[] inorder = null;
        int[] postorder = null;

        while (true)
        {
            try
            {
                Console.Write("Digite os elementos do percurso em ordem, separados por vírgula: ");
                inorder = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Console.Write("Digite os elementos do percurso pós-ordem, separados por vírgula: ");
                postorder = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (inorder.Length != postorder.Length)
                {
                    Console.WriteLine("Erro: As listas devem ter o mesmo tamanho.");
                    continue;
                }

                if (!inorder.OrderBy(x => x).SequenceEqual(postorder.OrderBy(x => x)))
                {
                    Console.WriteLine("Erro: As listas devem conter os mesmos elementos.");
                    continue;
                }

                break; // entrada válida
            }
            catch
            {
                Console.WriteLine("Erro ao processar entrada. Tente novamente com números inteiros separados por vírgula.");
            }
        }

        var builder = new ConstructBinaryTree();
        TreeNode root = builder.BuildTree(inorder, postorder);

        Console.WriteLine("Árvore construída com sucesso!");
        Console.Write("Percurso pré-ordem da árvore resultante: ");
        ImprimirFormatoLeetCode(root);
    }


    static void ImprimirFormatoLeetCode(TreeNode root)
    {
        if (root == null)
        {
            Console.WriteLine("[]");
            return;
        }

        var result = new List<string>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            if (node == null)
            {
                result.Add("null");
            }
            else
            {
                result.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }

        // Remove "null"s do final, que não são necessários
        for (int i = result.Count - 1; i >= 0; i--)
        {
            if (result[i] == "null")
                result.RemoveAt(i);
            else
                break;
        }

        Console.WriteLine("[" + string.Join(",", result) + "]");
    }
}
