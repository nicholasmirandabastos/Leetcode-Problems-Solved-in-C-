using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20___Valid_Parentheses
{
    internal class ValidParentheses
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>(); // pilha para armazenar os os caracteres de abertura
            var matchingBrackets = new Dictionary<char, char> { // dicionário para armazenar os caracteres pares de abertura e fechamento
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
            };

            foreach (char ch in s) // percorer a string
            {
                if (matchingBrackets.ContainsValue(ch)) // verifica se é um caractere de abertura (valor)
                {
                    stack.Push(ch); // caso positivo, adicionará na pilha
                }
                else if (matchingBrackets.ContainsKey(ch)) // verifica se é um caractere de fechamento (chave)
                {
                    if (stack.Count == 0 || stack.Pop() != matchingBrackets[ch]) // verifica se a pilha está vazia ou se o caractere de fechamento não é igual ao caractere de abertura
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0; // se a pilha não possuir elementos, retorna true, ou seja, está balanceada
        }
    }
}
