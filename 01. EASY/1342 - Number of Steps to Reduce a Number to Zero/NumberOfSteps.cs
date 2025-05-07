using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_of_Steps_to_Reduce_a_Number_to_Zero;

    public class NumberOfStepsToReduce
{

    public int NumberOfSteps(int num)
    {
        int steps = 0;
        while (num > 0)
        {
            if ((num & 1) == 1) // verifica se num é ímpar ou par
            {
                num -= 1; // subtraí 1 devido bit menos significativo
            }
            else
            {
                num >>= 1; // divide por 2 usando deslocamento de bits
            }
            steps += 1;

        }
        return steps;
    }
}
