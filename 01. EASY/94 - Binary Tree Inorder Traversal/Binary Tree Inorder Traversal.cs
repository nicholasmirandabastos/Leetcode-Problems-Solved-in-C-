using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree_Inorder_Traversal;

/* definindo o node da árvore binária*/

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Binary_Tree_Inorder_Traversal
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> result = new List<int>(); // variável para armazenar valores dos nós percorridos em ordem
        Traversal(root, result); // chama o método passando raiz e lista
        return result; // retorno do método com resultado
    }
    public void Traversal(TreeNode node, List<int> result)
    {
        if (node != null) // se a árvore terminou, retornar
        {
            Traversal(node.left, result); // chama recursivamente até acabar o lado esquerdo
            result.Add(node.val); // adiciona o valor do nó atual na lista
            Traversal(node.right, result); // chamada recursiva para percorrer o lado direito
        }
    }
}