using System;

namespace Counting_Bits;

class Program
{
    public static void Main()
    {
        int input;
        while (true)
        {
            Console.Write("Digite um número inteiro positivo: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out input) && input >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        Counting_Bits cb = new Counting_Bits();
        int[] result = cb.CountBits(input);

        Console.WriteLine("Quantidade de bits 1 para cada número até " + input + ":");
        for (int i = 0; i <= input; i++)
        {
            Console.WriteLine($"Número {i} => {result[i]} bits 1");
        }
    }
}