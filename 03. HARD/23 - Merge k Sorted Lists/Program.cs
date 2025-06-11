using Merge_k_Sorted_Lists;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Merge_k_Sorted_Lists
{
    public class Program
    {
        public static void Main()
        {
            var mergeLists = new MergeLists();
            ListNode[] lists = null;

            while (true)
            {
                Console.Write("Digite as listas no formato [1,4,5],[1,3,4],[2,6]: ");
                string input = Console.ReadLine();

                try
                {
                    lists = ParseInputToListNodes(input);
                    break;
                }
                catch
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }
            }

            var merged = mergeLists.MergeKLists(lists);
            PrintList(merged);
        }

        public static ListNode[] ParseInputToListNodes(string input)
        {
            var match = Regex.Matches(input, @"\[(.*?)\]");
            var list = new List<ListNode>();

            foreach (Match m in match)
            {
                var numbers = m.Groups[1].Value.Split(',', StringSplitOptions.RemoveEmptyEntries);
                ListNode head = null, current = null;

                foreach (var numStr in numbers)
                {
                    if (int.TryParse(numStr.Trim(), out int num))
                    {
                        var newNode = new ListNode(num);
                        if (head == null)
                        {
                            head = newNode;
                            current = head;
                        }
                        else
                        {
                            current.next = newNode;
                            current = current.next;
                        }
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }

                list.Add(head);
            }

            return list.ToArray();
        }

        public static void PrintList(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val);
                if (node.next != null)
                    Console.Write(" -> ");
                node = node.next;
            }
            Console.WriteLine();
        }
    }
}
