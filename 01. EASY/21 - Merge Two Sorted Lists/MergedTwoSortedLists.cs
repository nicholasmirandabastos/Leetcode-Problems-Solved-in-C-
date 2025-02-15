using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Two_Sorted_Lists
{
    internal class MergedTwoSortedLists
    {

        public class ListNode
        {
            //código disponibilizado pelo exercício do leetcode
            public int val; // valor guardado no nó
            public ListNode next; // referência para o próximo nó da lista
            public ListNode(int val = 0, ListNode next = null) // construtor
            {
                this.val = val; // atribui valor ao nó
                this.next = next; // define a referência para o próximo nó
            }


        }
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 is null) // se a primeira lista for nula, devolve a segunda já ordenada
            {
                return l2;
            }

            if (l2 is null) //se a segunda lista for nula, devolve a primeira já ordenada
            {
                return l1;
            }
            if (l1.val > l2.val) // se o valor do primeiro nó de l1 for maior que l2, define o próximo nó de l2 como a fusão de l1
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
            else // caso contrário, define o próximo nó de l1 como a fusão de l2
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }

        }
        public static void PrintList(ListNode node) // imprimir resultado no programa principal
        {
            while (node != null)
            {
                Console.Write(node.val);
                if (node.next != null)
                    Console.Write(" -> "); // Formato de saída visual
                node = node.next;
            }
            Console.WriteLine(); // Nova linha no final
        }


    }
}