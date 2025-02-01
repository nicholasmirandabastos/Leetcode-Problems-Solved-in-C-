using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13___Roman_to_Integer
{
    internal class RomanToInteger
    {
        public int RomanToInt(string s)
        {
            Dictionary<char, int> romano = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            int numeroConvertido = 0;
            int anterior = 0;

            for (int i = s.Length - 1; i >= 0; i--) // percorer a string de trás para frente, porque em numeros romanos o número pode subtrair o anterior
            {
                int valor = romano[s[i]];

                if (valor < anterior) // verifica se o valor atual é menor que o anterior, se for, subtrairá (ex: IV = 5 - 1)
                {
                    numeroConvertido -= valor;
                }
                else
                {
                    numeroConvertido += valor; // se o valor atual for maior ou igual ao valor anterior, soma-se o valor (ex: VI = 5 + 1)
                }
                anterior = valor; // atualizará o valor para o próximo loop
            }

            return numeroConvertido;
        }
    }
}
