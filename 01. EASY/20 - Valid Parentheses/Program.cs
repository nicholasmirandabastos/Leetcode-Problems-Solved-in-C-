using System.Text.RegularExpressions;

namespace _20___Valid_Parentheses
{
    public class Program
    {
        static void Main(string[] args)
        {
            string x = ValidarEntrada();

            ValidParentheses validarParenteses = new ValidParentheses();

            bool result = validarParenteses.IsValid(x);
            Console.WriteLine($"O resultado para a entrada dos símbolos é: {result}");


            static string ValidarEntrada()
            {
                while (true) // Loop para validar a entrada
                {
                    Console.Write("Digite apenas parênteses, colchetes ou chaves: ");
                    string entrada = Console.ReadLine(); // Lê a entrada do usuário

                    // Regex para validar a entrada (apenas caracteres de parênteses, colchetes e chaves)
                    string padrao = @"^[\(\)\[\]\{\}]+$";  // Permite apenas '(', ')', '[', ']', '{', '}'

                    Regex regex = new Regex(padrao);

                    // Verifica se a entrada contém apenas caracteres válidos
                    if (regex.IsMatch(entrada))
                    {
                        return entrada; // Se válido, retorna a entrada
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida! Apenas parênteses, colchetes e chaves são permitidos.");
                    }
                }
            }
        }
    }
}