using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Words_in_a_String_III
{
    class RevertWords
    {
        public string ReverseWords(string s)
        {
            string res = ""; // variável que armazenará o resultado final
            int l = 0, r = 0; // ponteiros para o início e o fim das palavras

            while (r < s.Length) // percorrer toda a string
            {
                if (s[r] != ' ') // se o caractere atual não for um espaço, move r para a direita
                {
                    r++;
                }
                else // se encontramos um espaço, invertemos a palavra atual
                {
                    res += ReverseSubstring(s, l, r) + " "; // inverte e adiciona ao resultado
                    r++; // move r para o próximo caractere após o espaço
                    l = r; // atualiza l para o início da próxima palavra
                }
            }

            // adiciona a última palavra invertida (sem espaço extra no final)
            res += ReverseSubstring(s, l, r);

            return res; // retorna a string
        }

        private string ReverseSubstring(string s, int start, int end)
        {
            char[] charArray = s.Substring(start, end - start).ToCharArray(); // extrai a palavra e converte para array de caracteres
            Array.Reverse(charArray); // inverte os caracteres da palavra
            return new string(charArray); // retorna a palavra invertida como string
        }
    }
}
