using Binary_Tree_Inorder_Traversal;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Binary_Tree_Inorder_Traversal;

public class Program
{
    static void Main(string[] args)
    {
        string input;
        bool isValid = false;

        Console.WriteLine("Bem-vindo ao desafio de Travessia em ordem em árvore binária.");
        do
        {
            Console.Write("Digite a árvore no formato [1,null,2,3]: ");
            input = Console.ReadLine()?.Trim(); // lê a entrada do usuário e remove espaços extras

            if (IsValidTreeInput(input))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }
        while (!isValid); 

        TreeNode root = BuildTreeFromInput(input);

        Binary_Tree_Inorder_Traversal solver = new Binary_Tree_Inorder_Traversal();
        IList<int> result = solver.InorderTraversal(root);

        Console.Write("Resultado do In-OrderTraversal: ");
        if (result.Count == 0)
        {
            Console.WriteLine("[]");
        }
        else
        {
            Console.WriteLine("[" + string.Join(", ", result) + "]");
        }
    }

    static bool IsValidTreeInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        input = input.Trim();
        // expressão regular para validar o formato [1,null,2,3]
        var regex = new Regex(@"^\[\s*(\d+|null)?\s*(,\s*(\d+|null)\s*)*\]$");

        return regex.IsMatch(input);
    }

    // constrói a árvore binária a partir da string de entrada
    static TreeNode BuildTreeFromInput(string input)
    {
        input = input.Trim('[', ']', ' ');
        if (string.IsNullOrEmpty(input)) return null;

        string[] parts = input.Split(','); // divide os valores por vírgula
        Queue<TreeNode> queue = new Queue<TreeNode>(); // fila para construir a árvore nível por nível

        TreeNode root = CreateNode(parts[0]); // cria o nó raiz
        queue.Enqueue(root);

        int i = 1;
        while (i < parts.Length)
        {
            TreeNode current = queue.Dequeue(); // pega o nó atual da fila

            // adiciona filho à esquerda, se houver
            if (i < parts.Length)
            {
                TreeNode left = CreateNode(parts[i++]);
                current.left = left;
                if (left != null) queue.Enqueue(left);
            }

            // adiciona filho à direita, se houver
            if (i < parts.Length)
            {
                TreeNode right = CreateNode(parts[i++]);
                current.right = right;
                if (right != null) queue.Enqueue(right);
            }
        }

        return root; // retorna a raiz da árvore construída
    }

    // cria um nó da árvore a partir de um valor string
    static TreeNode CreateNode(string value)
    {
        value = value.Trim();
        if (value == "null") return null; // "null" representa ausência de nó
        return new TreeNode(int.Parse(value)); // converte string para inteiro e cria nó
    }
}