using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List_Cycle
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
    public class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null) // enquanto não forem nulos, indica que a lista ainda não foi terminada
            {
                slow = slow.next; // move um nó por vez
                fast = fast.next.next; // move dois nós por vez
                if (slow == fast) // se os ponteiros se encontram, significa haver um ciclo na lsita
                {
                    return true;
                }
            }

            return false;
        }
    }
}
