namespace TwoSum
{
    internal class TwoSum
    {
        public int[] FindTwoSum(int[] nums, int target)
        {
            // Esta solução é eficiente em termos de performance, pois percorre a lista apenas uma vez.
            // O dicionário é usado para armazenar os complementos necessários para alcançar o target.
            // A cada adição no FOR, é checado se o complemento já foi encontrado. Se sim, o par foi encontrado.

            // Criar um dicionário para armazenar os números e seus índices
            Dictionary<int, int> hashNum = new Dictionary<int, int>();

            // Percorrer a lista
            for (int index = 0; index < nums.Length; index++)
            {
                int num = nums[index];

                // Verificar se o número já existe no dicionário como complemento
                if (hashNum.ContainsKey(num))
                {
                    // Caso o número já tenha seu complemento armazenado, retorne os índices do par encontrado
                    return new int[] { hashNum[num], index };
                }

                // Adicionar o número e seu índice ao dicionário
                hashNum[target - num] = index;
            }

            // Retorna um array vazio se não encontrar nenhuma combinação
            return new int[] { };
        }
    }
}
