namespace Binary_Search;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao programa de Busca Binária!");

        Console.Write("Digite os números ordenados separados por espaço: ");
        string? input = Console.ReadLine();
        int[] numbers;

        try
        {
            numbers = input.Split(' ').Select(int.Parse).OrderBy(n => n).ToArray();
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida. Certifique-se de digitar apenas números.");
            return;
        }

        Console.Write("Digite o número a ser buscado: ");
        if (!int.TryParse(Console.ReadLine(), out int target))
        {
            Console.WriteLine("Entrada inválida. Certifique-se de digitar um número válido.");
            return;
        }

        int? result = BinarySearch.BSearch(numbers, target);

        if (result != -1)
            Console.Write($"Elemento {target} encontrado no índice {result}.");
        else
            Console.Write($"Elemento {target} não encontrado.");
    }
}
