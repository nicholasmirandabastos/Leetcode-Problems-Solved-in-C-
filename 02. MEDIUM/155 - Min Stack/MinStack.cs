using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStack
{
    public class MinStack
    {
        // Pilha principal que armazena todos os valores
        private Stack<int> stack;
        // Pilha auxiliar que mantém o menor valor a cada operação de push
        private Stack<int> minStack;

        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val); // Adiciona o valor à pilha principal

            // Se a pilha de mínimos não estiver vazia, comparamos o novo valor com o menor atual
            if (minStack.Count > 0)
            {
                val = System.Math.Min(minStack.Peek(), val); // Pegamos o menor entre o valor atual e o do topo da minStack
            }

            minStack.Push(val); // Armazena o novo menor valor na pilha de mínimos
        }

        // Remove o valor do topo da pilha
        public void Pop()
        {
            if (stack.Count > 0) // Verifica se há elementos na pilha antes de remover
            {
                stack.Pop();     // Remove o topo da pilha principal
                minStack.Pop();  // Remove o topo da pilha de mínimos (que acompanha a principal)
            }
        }

        // Retorna o valor do topo da pilha
        public int Top()
        {
            return stack.Peek(); // Retorna o último valor inserido na pilha
        }

        // Retorna o menor valor da pilha
        public int GetMin()
        {
            return minStack.Peek(); // Retorna o topo da pilha de mínimos
        }
    }
}
