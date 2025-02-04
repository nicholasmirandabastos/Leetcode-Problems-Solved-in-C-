using System;
using System.Text.RegularExpressions;

namespace _14___Longest_Common_Prefix;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao problema de Maior Prefixo Comum!");
        Console.Write("Digite palavras separadas por vírgula: ");
        string input = Console.ReadLine();

        string[] x = input.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray(); // separar palavras por vírgulas e remover espaços em branco

        LongestCommonPrx longestCommonPrx = new LongestCommonPrx();

        string result = longestCommonPrx.LongestCommonPrefix(x);

        Console.WriteLine(result);

    }
}
