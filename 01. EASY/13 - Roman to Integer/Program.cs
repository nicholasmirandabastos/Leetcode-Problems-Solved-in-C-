using System;
using System.Text.RegularExpressions;

namespace _13___Roman_to_Integer;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao problema de Números Romanos para Inteiro!");

        // Chama o validador e obtém o número romano válido
        string x = ValidarNumeroRomano();

        // Instancia a classe RomanToInteger para conversão
        RomanToInteger romano = new RomanToInteger();

        // Converte o número romano para inteiro e exibe o resultado
        int resultado = romano.RomanToInt(x);
        Console.WriteLine($"O número romano {x} convertido para inteiro é: {resultado}");
    }

    // Função para validar a entrada do número romano
    static string ValidarNumeroRomano()
    {
        while (true) // loop para validar entrada
        {
            Console.Write("Digite um número romano para converter para inteiro: ");
            string x = Console.ReadLine().ToUpper(); // Lê a entrada e converte para maiúsculo

            // Regex para validar números romanos válidos
            string padrao = @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            /*
            Este regex valida números romanos de 1 a 3999, seguindo as regras tradicionais:
            - 0 a 4 "M"s para as unidades de milhar (1000).
            - Combinações válidas de "C", "D" e "M" para as centenas (100-900).
            - Combinações válidas de "X", "L" e "C" para as dezenas (10-90).
            - Combinações válidas de "I", "V" e "X" para as unidades (1-9).
            Ele garante que o número romano esteja corretamente formatado sem exceder 3999.
            */

            Regex regex = new Regex(padrao);

            // Verifica se o número romano é válido
            if (regex.IsMatch(x))
            {
                return x; // Se válido, retorna o número romano
            }
            else
            {
                Console.WriteLine($"{x} não é um número romano válido.");
            }
        }
    }
}