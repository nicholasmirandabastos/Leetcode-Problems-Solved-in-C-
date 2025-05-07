using System;

namespace Number_of_Steps_to_Reduce_a_Number_to_Zero;

class Program
{
    static void Main(string[] args)
    {
        int number;

        while (true)
        {
            Console.Write("Digite um número inteiro não negativo: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number) && number >= 0)
            {
                break;
            }

            Console.WriteLine("Entrada inválida. Tente novamente.");
        }

        NumberOfStepsToReduce calculator = new NumberOfStepsToReduce();
        int steps = calculator.NumberOfSteps(number);

        Console.WriteLine($"Número de passos para reduzir {number} a zero: {steps}");
    }
}
