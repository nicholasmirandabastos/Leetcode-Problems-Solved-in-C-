using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal
{
    public class ConstructBinaryTree
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || inorder.Length == 0 || postorder == null || postorder.Length == 0) // se algo estiver nulo, nada a ser feito
            {
                return null;
            }

            int rootVal = postorder[postorder.Length - 1]; // o último node do postorder é a raiz da arvore
            TreeNode root = new TreeNode(rootVal); // cria o node com o valor da raiz
            int idx = Array.IndexOf(inorder, rootVal); // localiza a posição da raiz e divide em duas arvores menores

            int[] leftInorder = inorder.Take(idx).ToArray(); // elementos da esquerda para a arvore da esquerda
            int[] rightInorder = inorder.Skip(idx + 1).ToArray(); // elementos da direita para a arvore da direita

            List<int> postList = postorder.ToList(); // convert o postorder em uma lista
            postList.RemoveAt(postList.Count - 1); // remove o último elento que já foi usado para raiz

            int[] leftPostorder = postList.Take(leftInorder.Length).ToArray(); // pega os elementos à esquerda da raiz
            int[] rightPostorder = postList.Skip(leftInorder.Length).ToArray(); // pega os elementos restantes que estão à direita da raiz

            root.left = BuildTree(leftInorder, leftPostorder); // pega os elementos da esquerda e monta uma subarvore
            root.right = BuildTree(rightInorder, rightPostorder); // pega os elementos da direita e monta uma subarvore

            return root;
        }
    }
}
