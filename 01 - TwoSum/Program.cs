namespace TwoSum
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao TwoSum Problem!");

            int[] nums = ObterNumerosValidos();
            int target = ObterAlvoValido();


            // instanciar a classe TwoSum e chamar o método
            TwoSum solver = new TwoSum();
            int[] result = solver.FindTwoSum(nums, target);

            // Exibir o resultado
            if (result.Length == 0)
            {
                Console.WriteLine("Não há par para o alvo definido.");
            }
            else
            {
                Console.WriteLine($"Par encontrado, os índices são: {result[0]}, {result[1]}");
            }
        }

        static int[] ObterNumerosValidos()
        {
            while (true)
            {
                Console.Write("Digite números inteiros separados por vírgulas: ");
                string input = Console.ReadLine();

                string[] valores = input.Split(',');
                int[] numeros = new int[valores.Length];
                bool entradaValida = true;

                for (int i = 0; i < valores.Length; i++)
                {
                    if (!int.TryParse(valores[i].Trim(), out numeros[i])) // tenta converter e remover espaços
                    {
                        Console.WriteLine($"Entrada inválida: '{valores[i].Trim()}'. Digite apenas números inteiros separados por vírgula.");
                        entradaValida = false;
                        break; // sai do loop se houver erro
                    }
                }

                if (entradaValida)
                    return numeros; // Retorna apenas se toda a entrada for válida
            }
        }


        static int ObterAlvoValido()
        {
            while (true) // loop para validar entrada
            {
                Console.Write("Digite o número alvo: ");
                if (int.TryParse(Console.ReadLine(), out int target))
                {
                    return target; // caso valide, o alvo será retornado
                }
                else // se não conseguir, apontará erro na conversão
                {
                    Console.WriteLine("Inválido. Digite um número inteiro.");
                }
            }
        }
    }
}