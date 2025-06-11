using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing_Stairs
{
    class ClimbingStairs
    {
        public int ClimbStairs(int n)
        {
            if (n == 1) // se nf or igual a 1, já retorna 1
            {
                return 1;
            }

            int prev = 1, curr = 1; // inicializa os dois primeiros valores

            for (int i = 2; i <= n; i++) // loop do índice 2 até o n2
            {
                int temp = curr; // salva o valor atual de curr em temp
                curr = prev + curr; // calcula o próximo da sequência
                prev = temp; // atualiza o prev com o valor anterior de curr, na próxima iteração prev será F(n-1)
            }

            return curr;
        }
    }

}
