namespace Palindrome_Number
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao problema de Números Palíndromos!");

            int x = ObterInteiroValido();

            PalindromeNumber palindromo = new PalindromeNumber();
            bool resultado = palindromo.IsPalindrome(x);
            Console.WriteLine(resultado);

            static int ObterInteiroValido()
            {
                while (true) // loop para validar entrada
                {
                    Console.Write("Digite um número inteiro para verificar se é um palíndromo: ");
                    if (int.TryParse(Console.ReadLine(), out int x))
                    {
                        return x; // caso valide, a variável será retornada
                    }
                    else // se não conseguir, apontará erro na conversão
                    {
                        Console.WriteLine("Inválido. Digite um número inteiro.");
                    }
                }
            }
        }
    }
}