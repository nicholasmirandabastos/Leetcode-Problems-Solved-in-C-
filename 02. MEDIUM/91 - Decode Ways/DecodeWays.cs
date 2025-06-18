using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decode_Ways
{
public class DecodeWays {
    public int NumDecodings(string s) {
        // Se a string for vazia ou começar com '0', não pode ser decodificada
        if (string.IsNullOrEmpty(s) || s[0] == '0') {
            return 0;
        }

        int n = s.Length;
        int prev = 1; // Número de formas de decodificar até i - 2
        int curr = 1; // Número de formas de decodificar até i - 1

        for (int i = 1; i < n; i++) {
            int temp = 0;

            // Se o caractere atual não for '0', ele pode ser decodificado sozinho
            if (s[i] != '0') {
                temp += curr;
            }

            // Verifica se os dois dígitos formam um número válido entre 10 e 26 (alfabeto)
            int twoDigit = int.Parse(s.Substring(i - 1, 2));
            if (twoDigit >= 10 && twoDigit <= 26) {
                temp += prev;
            }

            // Atualiza os contadores
            prev = curr;
            curr = temp;

            // Se curr virar 0, significa que não há nenhuma forma válida de continuar
            if (curr == 0) {
                return 0;
            }
        }

        return curr;
    }
}

}
