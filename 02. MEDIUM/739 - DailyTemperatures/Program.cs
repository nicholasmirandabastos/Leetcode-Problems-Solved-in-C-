namespace DailyTemperatures;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao programa de Variação de Temperaturas Diárias!");
        int[] temperatures;

        while (true)
        {
            Console.Write("Digite as temperaturas separadas por vírgula (ex: 30,40,50,60): ");
            string input = Console.ReadLine();
            string[] parts = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

            List<int> tempList = new List<int>();
            bool allValid = true;

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int temp))
                {
                    tempList.Add(temp);
                }
                else
                {
                    allValid = false;
                    Console.WriteLine($"Valor inválido detectado: '{part}'. Tente novamente.");
                    break;
                }
            }

            if (allValid && tempList.Count > 0)
            {
                temperatures = tempList.ToArray();
                break;
            }
            else if (tempList.Count == 0)
            {
                Console.WriteLine("Nenhuma temperatura válida foi inserida. Tente novamente.");
            }
        }

        DailyTemp dailyTemperature = new DailyTemp();
        int[] results = dailyTemperature.DailyTemperatures(temperatures);

        Console.WriteLine("Resultado (dias até uma temperatura mais alta):");
        Console.WriteLine(string.Join(" ", results));
    }
}