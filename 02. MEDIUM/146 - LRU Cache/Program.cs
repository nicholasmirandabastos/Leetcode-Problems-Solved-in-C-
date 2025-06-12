using LRU_Cache;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo ao programa de LRU Cache!");
        string[] commands = new string[]
        {
            "LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"
        };

        int[][] arguments = new int[][]
        {
            new int[] { 2 },
            new int[] { 1, 1 },
            new int[] { 2, 2 },
            new int[] { 1 },
            new int[] { 3, 3 },
            new int[] { 2 },
            new int[] { 4, 4 },
            new int[] { 1 },
            new int[] { 3 },
            new int[] { 4 }
        };

        LRUCache cache = null!;
        List<int> outputs = new List<int>();

        for (int i = 0; i < commands.Length; i++)
        {
            string cmd = commands[i];
            int[] args = arguments[i];

            if (cmd == "LRUCache")
            {
                cache = new LRUCache(args[0]);
                outputs.Add(-1); // criação não retorna nada, pode usar -1 para indicar "void"
            }
            else if (cmd == "put")
            {
                cache.Put(args[0], args[1]);
                outputs.Add(-1); // put não retorna valor
            }
            else if (cmd == "get")
            {
                int res = cache.Get(args[0]);
                outputs.Add(res);
            }
        }

        // Imprime os resultados (com -1 para void)
        Console.Write("Output: ");
        Console.WriteLine("[{0}]", string.Join(", ", outputs));
    }
}
