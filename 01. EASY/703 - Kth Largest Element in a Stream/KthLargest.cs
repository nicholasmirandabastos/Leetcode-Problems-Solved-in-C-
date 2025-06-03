namespace Kth_Largest_Element_in_a_Stream
{
    public class KthLargest
    {
        private PriorityQueue<int, int> minHeap; 
        private int k; 

        public KthLargest(int k, IList<int> nums)
        {
            this.k = k;

            // cria o heap mínimo com os elementos existentes
            minHeap = new PriorityQueue<int, int>();
            foreach (var num in nums)
            {
                Add(num);
            }
        }

        public int Add(int val)
        {
            minHeap.Enqueue(val, val);

            // Se a heap tiver mais de k elementos, remove o menor (topo da heap)
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }

            return minHeap.Peek();
        }
    }

}
