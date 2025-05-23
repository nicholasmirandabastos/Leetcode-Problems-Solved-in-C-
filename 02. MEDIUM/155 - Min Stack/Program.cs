using System;


namespace MinStack;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao programa de MinStack!");
        // Instancia a MinStack
        MinStack minStack = new MinStack();

        // Executa as operações
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Console.WriteLine(minStack.GetMin()); // Deve imprimir -3
        minStack.Pop();
        Console.WriteLine(minStack.Top());    // Deve imprimir 0
        Console.WriteLine(minStack.GetMin()); // Deve imprimir -2
    }
}
