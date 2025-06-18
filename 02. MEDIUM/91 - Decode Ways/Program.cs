using System;
using System.Text.RegularExpressions;
using Decode_Ways;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite uma string numérica para decodificar (ex: 12, 226): ");
        string input = Console.ReadLine();

        // Validação da entrada: deve conter apenas dígitos
        if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^\d+$"))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira apenas números positivos (0-9).");
            return;
        }

        DecodeWays decoder = new DecodeWays();
        int result = decoder.NumDecodings(input);

        Console.WriteLine($"Número de formas possíveis de decodificar \"{input}\": {result}");
    }
}

