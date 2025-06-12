using System;
using Climbing_Stairs;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao programa Calculadora de Formas de Subir a escada!");
        
        int steps;

        // Loop até o usuário inserir um número inteiro válido
        while (true)
        {
            Console.Write("Digite o número de degraus (inteiro): ");
            string input = Console.ReadLine();

            // Tenta converter o valor para inteiro
            if (int.TryParse(input, out steps))
            {
                break; // Sai do loop se a conversão for bem-sucedida
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
            }
        }

        ClimbingStairs solver = new ClimbingStairs();

        int result = solver.ClimbStairs(steps);

        Console.WriteLine($"Número de formas de subir {steps} degraus: {result}");
    }
}
