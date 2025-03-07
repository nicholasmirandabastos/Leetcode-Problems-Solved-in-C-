namespace Maximum_Length_Substring
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Bem-vindo ao programa de Sliding Window!");

            Console.Write("Digite a string: ");
            string? s = Console.ReadLine();


            SlidingWindow sw = new SlidingWindow();
            int? result = sw.MaximumLengthSubstring(s);
            Console.WriteLine(result);

            Console.WriteLine($"O maior comprimento de uma substring em que cada caractere aparece no máximo duas vezes é {result}.");


        }
    }
}