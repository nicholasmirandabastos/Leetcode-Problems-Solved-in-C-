using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_Bits;
public class Counting_Bits
{
    public int[] CountBits(int n)
    {
        int[] ans = new int[n + 1];

        for (int i = 0; i <= n; i++)
        {
            if ((i & 1) == 1) // verifica se num é ímpar ou par
            {
                ans[i] = ans[i / 2] + 1; // para ímpares, adiciona 1 ao valor da metade
            }
            else
            {
                ans[i] = ans[i / 2]; // para números pares, herda o valor da metade
            }
        }

        return ans;
    }
}