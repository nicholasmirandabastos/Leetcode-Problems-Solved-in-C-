namespace ReverseLinkedList
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Bem-vindo ao programa de Reverse Linked List!");

            Console.Write("Digite os números da lista ligados por espaço: ");
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

            ReverseLinkedList solution = new ReverseLinkedList();
            ListNode reversedHead = solution.ReverseList(head);

            Console.Write("Lista invertida: ");
            while (reversedHead != null)
            {
                Console.Write(reversedHead.val + " ");
                reversedHead = reversedHead.next;
            }

        }
    }

}