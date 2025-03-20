namespace Linked_List_Cycle
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Bem-vindo ao programa de Linked List Cycle!");

            Console.Write("Digite os números da lista separados por espaço: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Entrada inválida!");
                return;
            }

            string[] values = input.Split(' ');
            List<ListNode> nodes = new List<ListNode>();
            ListNode head = null, current = null;

            foreach (string value in values)
            {
                if (int.TryParse(value, out int num))
                {
                    ListNode newNode = new ListNode(num);
                    nodes.Add(newNode);

                    if (head == null)
                    {
                        head = newNode;
                        current = head;
                    }
                    else
                    {
                        current.next = newNode;
                        current = newNode;
                    }
                }
                else
                {
                    Console.WriteLine($"Valor inválido ignorado: {value}");
                }
            }

            if (head == null)
            {
                Console.WriteLine("Nenhum número válido foi inserido!");
                return;
            }

            Console.Write("Digite a posição do nó para criar um ciclo: ");
            string posInput = Console.ReadLine();

            if (int.TryParse(posInput, out int pos) && pos >= 0 && pos < nodes.Count)
            {
                current.next = nodes[pos];
                Console.WriteLine($"Ciclo criado conectando o último nó ao nó na posição {pos}.");
            }

            LinkedListCycle cycleChecker = new LinkedListCycle();
            bool hasCycle = cycleChecker.HasCycle(head);

            Console.WriteLine(hasCycle ? "A lista contém ciclo!" : "A lista não contém ciclo.");
        }
    }

}