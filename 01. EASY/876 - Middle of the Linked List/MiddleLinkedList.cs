using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middle_of_the_Linked_List
{
    public class ListNode
    {
        public int val; // valor do nó na linked list
        public ListNode next; // referência para o próximo nó da lista

        // construtor da classe ListNode que inicializa o valor e a referência para o próximo nó
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class MiddleLinkedList
    {
        public ListNode MiddleNode(ListNode head)
        {
            ListNode ahead = head; // inicializar ponteiro

            while (ahead != null && ahead.next != null)
            {
                ahead = ahead.next.next; // ahead move-se duas posições à frente
                head = head.next; // head move uma posição à frente
            }
            return head; // quando ahead chega ao final da lista indica que head estará no meio
        }
    }
}