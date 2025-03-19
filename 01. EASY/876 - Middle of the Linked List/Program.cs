namespace Middle_of_the_Linked_List
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Bem-vindo ao programa de Middle of the Linked List!");

            Console.Write("Digite os números da lista separados por espaço: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) // valida entrada vazia ou nula
            {
                Console.WriteLine("Entrada inválida!");
                return;
            }

            string[] values = input.Split(' ');
            ListNode head = null, current = null;

            foreach (string value in values)
            {
                if (int.TryParse(value, out int num)) // valida se é um número inteiro
                {
                    ListNode newNode = new ListNode(num);
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

            MiddleLinkedList MiddleNode = new MiddleLinkedList();
            ListNode middleList = MiddleNode.MiddleNode(head);

            Console.Write("Meio da Lista: ");
            while (middleList != null)
            {
                Console.Write(middleList.val + " ");
                middleList = middleList.next;
            }

        }
    }

}