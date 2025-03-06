using System.Collections.Generic;
using System.Reflection;

namespace Contains_Duplicate_II

{

    class SlidingWindow
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> num_dict = new Dictionary<int, int>(); // armazenar o número e índice mais recente.

            for (int i = 0; i < nums.Length; i++) 
            {
                if (num_dict.ContainsKey(nums[i]) && i - num_dict[nums[i]] <= k) // verificar se o número atual (i) está presente no dicionário e também verificar se diferença entre os indíces é menor ou igual que o valor k
                {
                    return true; // se positivo, foram encontrados dois valores de indices diferentes com a distância menor que k
                }

                num_dict[nums[i]] = i; // atualizar o índice do número atual no dicionário
            }

            return false; // nenhum par encontrado conforme as condições, números iguais e com distância igual ou menor que k
        }

    }
}