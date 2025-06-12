using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU_Cache
{
    public class LRUCache
    {
        private class Node
        {
            public int Key;
            public int Value;
            public Node Prev;
            public Node Next;

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly int _capacity;
        private readonly Dictionary<int, Node> _cache;
        private readonly Node _left;  // Dummy para ser o head
        private readonly Node _right; // Dummy para ser o tail

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, Node>();

            _left = new Node(0, 0); // cria o nó de início (head)
            _right = new Node(0, 0); // cria o nó de fim (tail)
            
            // apontar os nós
            _left.Next = _right; 
            _right.Prev = _left;
        }

        private void Remove(Node node)
        {
            Node prev = node.Prev; // pegar o nó anterior do nó que será removido
            Node next = node.Next; // pegar o próximo nó do nó que será removido
            
            // conectar os nós
            prev.Next = next;
            next.Prev = prev;
        }

        private void Insert(Node node)
        {
            Node prev = _left; // primeiro nó (dummy)
            Node next = _left.Next; // valor será inserido logo após o dummy

            // Insere o novo nó entre os nós 'prev' (_left) e 'next'
            prev.Next = node; 
            node.Prev = prev;
            node.Next = next;
            next.Prev = node;
        }

        public int Get(int key)
        {
            if (_cache.ContainsKey(key)) // verifica se a chave já está armazenada e caso esteja, já remove para adicionar ao início, pois ela será a de uso mais recente
            {
                Node node = _cache[key];
                Remove(node);
                Insert(node);
                return node.Value;
            }
            return -1; // retorna -1 se a chave não estiver no cache
        }

        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key)) // Se já existir a chave, este será removido do nó antigo
            {
                Remove(_cache[key]);
            }

            Node newNode = new Node(key, value); // cria um novo nó
            _cache[key] = newNode; // adiciona ao dicionário
            Insert(newNode); // insere no ínicio da lista

            if (_cache.Count > _capacity) // verificar se excedeu a capacidade, caso positivo, o nó menos recente será removido
            {
                Node lru = _right.Prev;
                Remove(lru);
                _cache.Remove(lru.Key);
            }
        }
    }

}
