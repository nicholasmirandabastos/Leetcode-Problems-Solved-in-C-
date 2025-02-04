using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _14___Longest_Common_Prefix
{
    internal class LongestCommonPrx
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) // nulo ou vazio, retorna vazio
                return "";

            if (strs.Length == 1) // se possuir apenas um elemento, retorna ele através do índice 
                return strs[0];

            return CommomPrefix(strs, 0, strs.Length-1 ); // função recursiva em que o array será divido
        }

        private string CommomPrefix(string[] strs, int left, int right)
        {
            if (left == right) // se a direita e esquerda forem iguais, retorna o próprio elemento
                return strs[left];

            int middlePart = (left + right) / 2; // encontra o meio do array para dividir

            var leftSide = CommomPrefix(strs, left, middlePart); // chama a função recursiva para encontrar o prefixo comum da esquerda
            var rightSide = CommomPrefix(strs, middlePart + 1, right);// chama a função recursiva para encontrar o prefixo comum da direita

            return ConquerPrefix(leftSide, rightSide); // combina os prefixos encontrados
        }

        private string ConquerPrefix(string leftSide, string rightSide)
        { 
            int currentSmallest = Math.Min(leftSide.Length, rightSide.Length); // compara o tamanho dos prefixos, uma vez que o prefixo não pode ser maior que nenhuma das palavras

            for (int currentIndex = 0; currentIndex < currentSmallest; currentIndex++) // laço for para percorrer até o tamanho da menor palavra
            {
                if (leftSide[currentIndex] != rightSide[currentIndex]) // se os caracteres forem diferentes no mesmo índice, retorna o prefixo até o índice atual
                    return leftSide.Substring(0, currentIndex);
            }

            return leftSide.Substring(0, currentSmallest); // se não houver diferença, retorna o prefixo até o tamanho da menor palavra
        }
    }
}
