namespace Clone_Graph;
public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null) return null; //se vier nulo, retorna null

        // fila usadada para percorrer o grafo (Breadth First Search - BFS)
        Queue<Node> queue = new Queue<Node>();
        // adiocna o primeiro nó na fila
        queue.Enqueue(node);

        // dicionarário para mapear o nó original e seu clone
        Dictionary<int, Node> clones = new Dictionary<int, Node>();

        // armazenar o clone do nó inicial
        clones[node.val] = new Node(node.val, new List<Node>());

        // enquanto existir a queue, ela será processada
        while (queue.Count > 0)
        {
            // remover o próximo nó da fila para processar os vizinhos
            Node curr = queue.Dequeue();

            // obter o clone do nó atual
            Node currClone = clones[curr.val];

            // percorrer por cada vizinho do nó atual para garantir que ele tenha um clone para fazer a ligação com o nó atual
            foreach (Node neighbor in curr.neighbors)
            {

                // verificar se não foi clonado
                if (!clones.ContainsKey(neighbor.val))
                {
                    // criar o clone do vizinho e adicionar ao dicionário
                    clones[neighbor.val] = new Node(neighbor.val, new List<Node>());

                    // adiciona o vizinho original à fila para processar os seus vizinhos
                    queue.Enqueue(neighbor);
                }

                // adiciona o clone do vizinho à lista de vizinhos
                currClone.neighbors.Add(clones[neighbor.val]);
            }
        }

        // retorna o clone ao nó inicial
        return clones[node.val];
    }
}
