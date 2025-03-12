using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
{
    public class ListNode
    {
        public int val; // valor do nó na linked list
        public ListNode next; // referência para o próximo nó da lista

        // construtor da classe ListNode que inicializa o valor e a referência para o próximo nó
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val; // define o valor do nó
            this.next = next; // define a referência para o próximo nó
        }
    }
    public class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode newList = null; // inicializa a nova lista invertida como nula

            while (head != null) // percorre a lista original até que head seja nulo
            {
                ListNode nextNode = head.next; // armazena a referência para o próximo nó da lista original
                head.next = newList; // faz o nó atual apontar para a nova lista (invertendo a ligação)
                newList = head; // move o nó atual para ser o primeiro da nova lista
                head = nextNode; // avança para o próximo nó na lista original
            }

            return newList; 
        }
    }
}
