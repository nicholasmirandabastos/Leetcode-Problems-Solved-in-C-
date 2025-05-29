using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTemperatures;

public class DailyTemp
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int n = temperatures.Length; // Armazena o tamanho do array de temperaturas
        int[] results = new int[n];  // Inicializa o array de resultados com zeros (mesmo tamanho que a entrada Temperatures)
        Stack<int> stack = new Stack<int>(); // Pilha para armazenar os índices das temperaturas ainda não resolvidas

        // Loop por cada temperatura no array
        for (int i = 0; i < n; i++)
        {
            // Enquanto a pilha não estiver vazia e a temperatura atual for maior do que a temperatura no topo da pilha
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                int index = stack.Pop(); // Remove o índice do topo da pilha
                results[index] = i - index; // Calcula o intervalo até encontrar uma temperatura maior
            }

            stack.Push(i); // Adiciona o índice atual à pilha
        }

        return results; // Retorna o array com os resultados
    }
}