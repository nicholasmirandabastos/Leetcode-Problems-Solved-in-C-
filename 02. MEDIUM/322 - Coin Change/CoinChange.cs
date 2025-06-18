using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Change
{
    public class CoinChangeCalc
    {
        public int CoinChange(int[] coins, int amount)
        {
            // Cria um array 'dp' com tamanho amount + 1 e inicializa todos os valores com int.MaxValue
            // Esse array armazenará o menor número de moedas necessário para cada valor de 0 até amount
            int[] dp = new int[amount + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }

            // O número mínimo de moedas para obter valor 0 é 0
            dp[0] = 0;

            // Para cada moeda disponível
            foreach (int coin in coins)
            {
                // Para cada valor de coin até amount
                for (int i = coin; i <= amount; i++)
                {
                    // Se já sabemos o menor número de moedas para formar o valor (i - coin),
                    // então podemos formar o valor i usando essa solução mais uma moeda a mais (coin).
                    // Atualizamos dp[i] com o menor número possível de moedas entre o valor atual e essa nova possibilidade.
                    if (dp[i - coin] != int.MaxValue)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                    }
                }
            }

            // Se não foi possível formar o valor 'amount', retorna -1
            return dp[amount] == int.MaxValue ? -1 : dp[amount];
        }
    }

}
