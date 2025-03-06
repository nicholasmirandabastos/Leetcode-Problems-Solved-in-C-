using System.Collections.Generic;
using System.Reflection;

namespace Contains_Duplicate_II

{

    class SlidingWindow
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> num_dict = new Dictionary<int, int>(); // armazenar o n�mero e �ndice mais recente.

            for (int i = 0; i < nums.Length; i++) 
            {
                if (num_dict.ContainsKey(nums[i]) && i - num_dict[nums[i]] <= k) // verificar se o n�mero atual (i) est� presente no dicion�rio e tamb�m verificar se diferen�a entre os ind�ces � menor ou igual que o valor k
                {
                    return true; // se positivo, foram encontrados dois valores de indices diferentes com a dist�ncia menor que k
                }

                num_dict[nums[i]] = i; // atualizar o �ndice do n�mero atual no dicion�rio
            }

            return false; // nenhum par encontrado conforme as condi��es, n�meros iguais e com dist�ncia igual ou menor que k
        }

    }
}