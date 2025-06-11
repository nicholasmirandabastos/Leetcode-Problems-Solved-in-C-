using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_k_Sorted_Lists
{
    public class MergeLists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            // cria uma priority queue com chave de ordenação (valor do nó, contador)
            var heap = new PriorityQueue<ListNode, (int, int)>();
            int counter = 0; // contador usado para desempate quando valores forem iguais

            // função auxiliar para adicionar nós na heap
            void PushNode(ListNode node)
            {
                if (node != null)
                {
                    // enfileira o nó usando como chave (valor do nó, ordem de inserção)
                    heap.Enqueue(node, (node.val, counter++));
                }
            }

            // adiciona o primeiro nó de cada lista ao heap
            foreach (var node in lists)
            {
                PushNode(node);
            }

            // Nó inicial para facilitar a construção da nova lista encadeada
            var dummy = new ListNode();
            var current = dummy; // ponteiro que será usado para montar a nova lista

            // enquanto ainda houver nós na heap
            while (heap.Count > 0)
            {
                // remove o nó com menor valor da heap
                var node = heap.Dequeue();

                // adiciona o nó à nova lista encadeada
                current.next = node;
                current = current.next; // move o ponteiro

                // se o nó removido tiver um próximo, adiciona ele ao heap
                if (node.next != null)
                {
                    PushNode(node.next);
                }
            }

            // retorna a cabeça da nova lista, ignorando o nó dummy
            return dummy.next;
        }
    }
}
