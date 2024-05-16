using System;
using System.Collections.Generic;
using Algorithm_assignment;
namespace PQ
{
    public class MinHeap
    {

        private List<HuffmanNode> heap = new List<HuffmanNode>();
        public int Count => heap.Count;
        public MinHeap(List<HuffmanNode> arr = null)
        {
            if (arr != null)
            {
                heap.AddRange(arr);
                for (int i = (heap.Count - 1) / 2; i >= 0; i--)
                {
                    SiftDown(i);
                }
            }
        }

        private void SiftUp(int i)
        {
            int parent = (i - 1) / 2;
            while (i != 0 && heap[i].Frequency < heap[parent].Frequency)
            {
                Swap(i, parent);
                i = parent;
                parent = (i - 1) / 2;
            }
        }

        private void SiftDown(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            while ((left < heap.Count && heap[i].Frequency > heap[left].Frequency) || (right < heap.Count && heap[i].Frequency > heap[right].Frequency))
            {
                int smallest = left;
                if (right < heap.Count && heap[right].Frequency < heap[smallest].Frequency)
                {
                    smallest = right;
                }
                Swap(i, smallest);
                i = smallest;
                left = 2 * i + 1;
                right = 2 * i + 2;
            }
        }

        public void Insert(HuffmanNode element)
        {
            heap.Add(element);
            SiftUp(heap.Count - 1);
        }

        public HuffmanNode GetMin()
        {
            return heap.Count > 0 ? heap[0] : null; // Return null if the heap is empty
        }

        public HuffmanNode ExtractMin()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty");
            HuffmanNode minVal = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            SiftDown(0);
            return minVal;
        }

        private void Swap(int i, int j)
        {
            HuffmanNode temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }

    public class MaxHeap
    {
        private List<HuffmanNode> heap = new List<HuffmanNode>();

        public MaxHeap(List<HuffmanNode> arr = null)
        {
            if (arr != null)
            {
                heap.AddRange(arr);
                for (int i = (heap.Count - 1) / 2; i >= 0; i--)
                {
                    SiftDown(i);
                }
            }
        }

        private void SiftUp(int i)
        {
            int parent = (i - 1) / 2;
            while (i != 0 && heap[i].Frequency > heap[parent].Frequency)
            {
                Swap(i, parent);
                i = parent;
                parent = (i - 1) / 2;
            }
        }

        private void SiftDown(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            while ((left < heap.Count && heap[i].Frequency < heap[left].Frequency) || (right < heap.Count && heap[i].Frequency < heap[right].Frequency))
            {
                int biggest = left;
                if (right < heap.Count && heap[right].Frequency > heap[biggest].Frequency)
                {
                    biggest = right;
                }
                Swap(i, biggest);
                i = biggest;
                left = 2 * i + 1;
                right = 2 * i + 2;
            }
        }

        public void Insert(HuffmanNode element)
        {
            heap.Add(element);
            SiftUp(heap.Count - 1);
        }

        public HuffmanNode GetMax()
        {
            return heap.Count > 0 ? heap[0] : null; // Return null if the heap is empty
        }

        public HuffmanNode ExtractMax()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty");
            HuffmanNode maxVal = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            SiftDown(0);
            return maxVal;
        }

        private void Swap(int i, int j)
        {
            HuffmanNode temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }

    public class PriorityQueue
    {
        private MaxHeap queue = new MaxHeap();

        public void Enqueue(HuffmanNode element)
        {
            queue.Insert(element);
        }

        public HuffmanNode Peek()
        {
            return queue.GetMax();
        }

        public HuffmanNode Dequeue()
        {
            return queue.ExtractMax();
        }

        public bool IsEmpty()
        {
            return queue.GetMax() == null;
        }

        public void ChangePriorityByIndex(int i, HuffmanNode newPriority)
        {
            // Not implemented in this version, you may need to implement it yourself
            throw new NotImplementedException();
        }

        public void ChangePriority(HuffmanNode oldPriority, HuffmanNode newPriority)
        {
            // Not implemented in this version, you may need to implement it yourself
            throw new NotImplementedException();
        }
    }



}