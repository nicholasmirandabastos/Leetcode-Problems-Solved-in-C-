using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Length_Substring
{
    class SlidingWindow
    {
        public int MaximumLengthSubstring(string s)
        {
            int left = 0, right = 0; // ponteiros para os limites da sliding window
            int maxLength = 1; // armazena o tamanho máximo da substring válida
            Dictionary<char, int> counter = new Dictionary<char, int>(); // dicionário para contar a frequência dos caracteres

            counter[s[0]] = 1; // Inicializa a contagem com o primeiro caractere

            while (right < s.Length - 1)
            {
                right++; // move o ponteiro direito
                if (counter.ContainsKey(s[right]))
                    counter[s[right]]++; // Incrementa a contagem do caractere atual
                else
                    counter[s[right]] = 1; // adiciona o caractere ao dicionário

                while (counter[s[right]] == 3) // se um caractere aparecer 3 vezes, reduz a janela
                {
                    counter[s[left]]--; // diminui a contagem do caractere na posição esquerda
                    left++; // move o ponteiro esquerdo para frente
                }
                maxLength = Math.Max(maxLength, right - left + 1); // atualiza o tamanho máximo da substring válida
            }

            return maxLength;
        }
    }
}