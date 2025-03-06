namespace Contains_Duplicate_II
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Bem-vindo ao programa de Sliding Window!");

            Console.Write("Digite os números separados por espaço: ");
            string? input = Console.ReadLine();
            int[] nums;

            try
            {
                nums = input.Split(' ').Select(int.Parse).ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Certifique-se de digitar apenas números.");
                return;
            }


            Console.Write("Digite o intervalo a ser buscado: ");
            if (!int.TryParse(Console.ReadLine(), out int k))
            {
                Console.WriteLine("Entrada inválida. Certifique-se de digitar um número válido.");
                return;
            }

            SlidingWindow sw = new SlidingWindow();
            bool? result = sw.ContainsNearbyDuplicate(nums, k);
            Console.WriteLine(result);

            if (result == true)
                Console.Write($"Foram encontrados repetições com distâncias iguais ou menores que {k}.");
            else
                Console.Write($"Não foram encontrados repetições com distâncias iguais ou menores que {k}.");
        }
    }
}