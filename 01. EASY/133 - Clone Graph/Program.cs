using System;
using System.Collections.Generic;
using System.Text.Json;
using Clone_Graph;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Digite a lista de adjacência no formato [[2,4],[1,3]]: ");
            string input = Console.ReadLine();

            try
            {
                var adjList = JsonSerializer.Deserialize<List<List<int>>>(input);

                if (adjList == null)
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                Node startNode = null;

                // Caso especial: [] → grafo nulo
                if (adjList.Count == 0)
                {
                    startNode = null;
                }
                // Caso especial: [[]] → grafo com um nó sem vizinhos
                else if (adjList.Count == 1 && adjList[0].Count == 0)
                {
                    startNode = new Node(1);
                }
                // Grafo normal
                else
                {
                    Dictionary<int, Node> nodes = new Dictionary<int, Node>();
                    for (int i = 1; i <= adjList.Count; i++)
                        nodes[i] = new Node(i);

                    for (int i = 0; i < adjList.Count; i++)
                    {
                        foreach (int neighborVal in adjList[i])
                        {
                            if (neighborVal < 1 || neighborVal > adjList.Count)
                                throw new Exception($"Nó {neighborVal} inválido.");
                            nodes[i + 1].neighbors.Add(nodes[neighborVal]);
                        }
                    }

                    startNode = nodes[1];
                }

                // Clona usando CloneGraph (sempre)
                Node clonedGraph = new Solution().CloneGraph(startNode);

                // Constrói e exibe a lista de adjacência do grafo clonado
                List<List<int>> clonedAdjList = BuildAdjacencyList(clonedGraph);
                Console.Write("Resultado: " + JsonSerializer.Serialize(clonedAdjList));
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Entrada inválida: {ex.Message}");
            }
        }
    }

    static List<List<int>> BuildAdjacencyList(Node node)
    {
        if (node == null)
            return new List<List<int>>(); // caso CloneGraph(null)

        Dictionary<int, List<int>> adjMap = new Dictionary<int, List<int>>();
        HashSet<int> visited = new HashSet<int>();
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);
        visited.Add(node.val);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            if (!adjMap.ContainsKey(current.val))
                adjMap[current.val] = new List<int>();

            foreach (var neighbor in current.neighbors)
            {
                adjMap[current.val].Add(neighbor.val);

                if (!visited.Contains(neighbor.val))
                {
                    visited.Add(neighbor.val);
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Preenche a lista na ordem crescente dos nós
        int maxIndex = adjMap.Count > 0 ? Math.Max(adjMap.Keys.Max(), adjMap.Values.SelectMany(v => v).DefaultIfEmpty().Max()) : 0;
        List<List<int>> result = new List<List<int>>();
        for (int i = 1; i <= maxIndex; i++)
        {
            result.Add(adjMap.ContainsKey(i) ? adjMap[i] : new List<int>());
        }

        return result;
    }
}
