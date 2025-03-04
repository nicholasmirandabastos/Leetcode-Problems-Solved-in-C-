using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search
{
    public class BinarySearch
    {
        public static int BSearch(int[] nums, int target)
        {
            int lenArr = nums.Count();

            int lowPos = 0;
            int highPos = lenArr - 1; // garantir que o máximo é dentro do array

            while (lowPos < highPos)
            {
                int middle = (int)((lowPos + highPos) / 2); // pegar o meio

                // se o elemento do meio for o alvo, retorna sua posição
                if (nums[middle] == target)
                    return middle;

                // se o elemento do meio for menor que o alvo, descarta essa metade e ajusta o limite
                if (nums[middle] < target)
                    lowPos = middle + 1;
                else
                    // caso o elemento do meio for maior que o alvo, já descarta a metade e ajusta o limite
                    highPos = middle;
            }

            // retorna -1 se o alvo não for encontrado
            return -1;
        }
    }

}
