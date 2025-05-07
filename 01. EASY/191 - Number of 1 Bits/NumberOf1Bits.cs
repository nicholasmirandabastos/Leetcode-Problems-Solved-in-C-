namespace Number_of_1_Bits
{
    public class NumberOf1Bits
    {
        public int HammingWeight(int n)
        {
            int count = 0;
            while (n > 0)
            {
                if ((n & 1) == 1) // verifica se é ímpar
                {
                    count += 1; // adiciona no contador
                    n >>= 1; // divide por 2 usando deslocamento de bits
                }
                else
                {
                    n >>= 1; // divide por 2 usando deslocamento de bits
                }
            }
            return count;

        }
    }
}