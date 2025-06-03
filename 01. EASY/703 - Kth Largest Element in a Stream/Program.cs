using System;
using System.Collections.Generic;

namespace Kth_Largest_Element_in_a_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o valor de k: ");
            int k = int.Parse(Console.ReadLine());

            Console.Write("Digite os números iniciais separados por espaço: ");
            var entradaInicial = Console.ReadLine().Split(' ');
            var numerosIniciais = new List<int>();
            foreach (var item in entradaInicial)
            {
                if (int.TryParse(item, out int num))
                {
                    numerosIniciais.Add(num);
                }
            }

            var kth = new KthLargest(k, numerosIniciais);
            var resultados = new List<string>();
            resultados.Add("null");

            Console.WriteLine("Digite os valores para adicionar (um por vez). Digite 'sair' para encerrar:");

            while (true)
            {
                Console.Write("Adicionar: ");
                var entrada = Console.ReadLine();

                if (entrada.ToLower() == "sair") break;

                if (int.TryParse(entrada, out int valor))
                {
                    int resultado = kth.Add(valor);
                    resultados.Add(resultado.ToString());
                }
                else
                {
                    Console.WriteLine("Valor inválido.");
                }
            }

            Console.WriteLine($"Saída: [{string.Join(", ", resultados)}]");
        }
    }
}
