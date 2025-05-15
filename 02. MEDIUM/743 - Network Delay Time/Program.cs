using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Network_Delay_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] times = null;
            int n = 0, k = 0;

            Console.WriteLine("Bem-vindo ao programa Calculadora de Tempo de Atraso na Rede!\n");
            Console.WriteLine("Este programa calcula o tempo mínimo necessário para que um sinal enviado a partir de um nó específico alcance todos os nós de uma rede.\n");

            // Entrada e validação dos tempos
            while (true)
            {
                try
                {
                    Console.WriteLine("Entrada 1 - Tempos de transmissão:");
                    Console.WriteLine("Informe as conexões da rede no formato de lista de listas.");
                    Console.WriteLine("Cada sublista deve conter 3 números: [nó de origem, nó de destino, tempo de transmissão].");
                    Console.WriteLine("Exemplo: [[2,1,1],[2,3,1],[3,4,1]]");
                    Console.Write("Digite os tempos de transmissão entre os nós: ");
                    string timesInput = Console.ReadLine();

                    var timesMatch = Regex.Match(timesInput, @"\[\[(.*?)\]\]");
                    if (!timesMatch.Success)
                        throw new Exception("Formato inválido. Use o formato [[u1,v1,w1],[u2,v2,w2],...].");

                    string[] triplets = timesMatch.Groups[1].Value.Split("],[");
                    times = new int[triplets.Length][];

                    for (int i = 0; i < triplets.Length; i++)
                    {
                        string[] parts = triplets[i].Split(',');
                        if (parts.Length != 3)
                            throw new Exception("Cada sublista deve conter exatamente 3 números.");

                        times[i] = new int[]
                        {
                            int.Parse(parts[0]),
                            int.Parse(parts[1]),
                            int.Parse(parts[2])
                        };
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Erro: {ex.Message}");
                    Console.WriteLine("Tente novamente.\n");
                }
            }

            // Entrada e validação de n
            while (true)
            {
                try
                {
                    Console.WriteLine("\nEntrada 2 - Quantidade de nós:");
                    Console.WriteLine("Digite o número total de nós da rede (n). Deve ser um número inteiro positivo.");
                    Console.Write("Digite o valor de n: ");
                    string nInput = Console.ReadLine();

                    if (!int.TryParse(nInput, out n) || n <= 0)
                        throw new Exception("O valor de 'n' deve ser um número inteiro positivo maior que zero.");

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    Console.WriteLine("Tente novamente.\n");
                }
            }

            // Entrada e validação de k
            while (true)
            {
                try
                {
                    Console.WriteLine("\nEntrada 3 - Nó de origem:");
                    Console.WriteLine("Digite o número do nó de onde o sinal será enviado (k). Deve estar entre 1 e n.");
                    Console.Write("Digite o valor de k: ");
                    string kInput = Console.ReadLine();

                    if (!int.TryParse(kInput, out k) || k <= 0 || k > n)
                        throw new Exception("O valor de 'k' deve ser um número inteiro entre 1 e n.");

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    Console.WriteLine("Tente novamente.\n");
                }
            }

            var solution = new Network_Delay_Time();
            int resultado = solution.NetworkDelayTime(times, n, k);
            Console.Write($"\nResultado: {resultado}");
        }
    }
}
