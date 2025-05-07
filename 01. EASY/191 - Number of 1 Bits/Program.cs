using System;

namespace Number_of_1_Bits;

class Program
{
    static void Main(string[] args)
    {
        int number = 0;
        bool isValid = false;

        do
        {
            Console.Write("Digite um número inteiro positivo: ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out number) && number >= 0)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número inteiro.");
            }
        } while (!isValid);

        NumberOf1Bits calculator = new NumberOf1Bits();
        int bitCount = calculator.HammingWeight(number);
        Console.WriteLine($"O número de bits 1 em {number} é: {bitCount}");
    }
}