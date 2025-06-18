using System;
using System.Linq;
using Coin_Change;

class Program
{
    static void Main()
    {
        int[] coins = null;
        int amount = -1;

        // Loop para garantir que o usuário insira moedas válidas
        while (coins == null)
        {
            Console.Write("Digite as moedas disponíveis (separadas por vírgula, ex: 1,2,5): ");
            string input = Console.ReadLine();

            try
            {
                coins = input.Split(',')
                             .Select(x => int.Parse(x.Trim()))
                             .Where(x => x > 0)
                             .ToArray();

                if (coins.Length == 0)
                {
                    Console.WriteLine("Por favor, insira pelo menos uma moeda válida.");
                    coins = null;
                }
            }
            catch
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
            }
        }

        // Loop para garantir que o valor desejado seja um inteiro positivo
        while (amount < 0)
        {
            Console.Write("Digite o valor desejado: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out amount) || amount < 0)
            {
                Console.WriteLine("Valor inválido. Digite um número inteiro positivo.");
                amount = -1;
            }
        }

        // Calcula a menor quantidade de moedas usando a classe CoinChangeCalc
        CoinChangeCalc calc = new CoinChangeCalc();
        int resultado = calc.CoinChange(coins, amount);

        // Exibe o resultado
        if (resultado == -1)
        {
            Console.WriteLine($"Não é possível formar o valor {amount} com as moedas fornecidas.");
        }
        else
        {
            Console.WriteLine($"Menor número de moedas para formar {amount}: {resultado}");
        }
    }
}
