namespace Reverse_Words_in_a_String_III;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma frase: ");
        string input = Console.ReadLine();

        RevertWords rw = new RevertWords(); 
        string resultado = rw.ReverseWords(input);

        Console.WriteLine("Resultado: " + resultado);
    }
}