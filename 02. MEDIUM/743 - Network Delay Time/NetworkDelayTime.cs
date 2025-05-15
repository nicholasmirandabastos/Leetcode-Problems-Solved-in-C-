using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Delay_Time
{
    public class Network_Delay_Time
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            // cria um dicionário para armazenar as conexões entre os nós e os tempos
            var table = new Dictionary<int, Dictionary<int, int>>();

            // preenche a tabela com os tempos das conexões
            foreach (var t in times)
            {
                if (!table.ContainsKey(t[0]))
                {
                    table[t[0]] = new Dictionary<int, int> { { t[1], t[2] } };
                }
                else
                {
                    table[t[0]][t[1]] = t[2];
                }
            }

            // dicionário que armazena a distância mínima de cada nó a partir do nó k
            var distances = new Dictionary<int, int> { { k, 0 } };

            // fila de prioridade (min-heap) para processar os nós pela distância mínima
            var minHeap = new List<Tuple<int, int>> { Tuple.Create(0, k) };

            // processa os nós na ordem de distância mínima
            while (minHeap.Count > 0)
            {
                // ordena a lista para pegar o nó com a menor distância
                minHeap.Sort((a, b) => a.Item1.CompareTo(b.Item1));
                var dist = minHeap[0].Item1;  // distância mínima
                var node = minHeap[0].Item2; // nó correspondente à distância mínima
                minHeap.RemoveAt(0);  // remove o nó processado da fila

                // verifica as conexões do nó atual
                if (table.ContainsKey(node))
                {
                    foreach (var entry in table[node])
                    {
                        var key = entry.Key; // nó vizinho
                        var v = entry.Value; // tempo para o nó vizinho

                        // calcula a nova distância para o nó vizinho.
                        var tableDist = distances.ContainsKey(key) ? distances[key] : int.MaxValue;

                        // se a nova distância for menor, atualiza a distância e adiciona na fila
                        if (dist + v < tableDist)
                        {
                            distances[key] = dist + v;
                            minHeap.Add(Tuple.Create(dist + v, key));
                        }
                    }
                }
            }

            // verifica o tempo máximo para que todos os nós recebam a mensagem
            int _max = -1;
            if (distances.Count < n)
            {
                return _max;  // se não forem alcançados todos os nós, retorna -1
            }

            // encontra o maior tempo de envio
            foreach (var kvp in distances)
            {
                _max = Math.Max(_max, kvp.Value);
            }

            // se o maior tempo for 0, significa que não há tempo de transmissão, então retorna -1
            if (_max == 0)
            {
                return -1;
            }

            // retorna o maior tempo de transmissão
            return _max;
        }
    }
}
