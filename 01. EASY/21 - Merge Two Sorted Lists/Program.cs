using static Merge_Two_Sorted_Lists.MergedTwoSortedLists;

namespace Merge_Two_Sorted_Lists;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite a primeira lista ordenada (valores separados por vírgula): ");
        ListNode list1 = CreateListFromInput(Console.ReadLine());

        Console.Write("Digite a segunda lista ordenada (valores separados por vírgula): ");
        ListNode list2 = CreateListFromInput(Console.ReadLine());

        MergedTwoSortedLists mergedTwoSortedLists = new MergedTwoSortedLists();
        ListNode result = mergedTwoSortedLists.MergeTwoLists(list1, list2);

        Console.WriteLine("Merged Sorted List:");
        MergedTwoSortedLists.PrintList(result);
    }

    static ListNode CreateListFromInput(string input)
    {
        // se a entrada for vazia ou nula, retorna null
        if (string.IsNullOrWhiteSpace(input)) return null;

        // separa a entrada em um array de strings usando a vírgula como separador
        string[] values = input.Split(",");

        // cria um nó dummy para servir de cabeça da lista, para não precisarmos tratar o primeiro nó de forma diferente, no final, este será ignorado

        ListNode dummy = new ListNode();
        ListNode current = dummy;

        // percorrer os valores fornecedor pelo usuário
        foreach (string value in values)
        {
            // tenta converter o valor para um número inteiro
            if (int.TryParse(value.Trim(), out int num))
            {
                // cria um novo nó com o valor convertido
                current.next = new ListNode(num);
                current = current.next;
            }
        }

        // retorna a lista a partir do segundo nó, ignorando o dummy
        return dummy.next;
    }
}