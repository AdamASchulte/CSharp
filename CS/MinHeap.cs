
using System;
namespace CS
{
    class MinHeap
    {

        public int[] heapArray { get; set; }

        public int capacity { get; set; }

        public int current_heap_size { get; set; }

        public MinHeap(int n)
        {
            capacity = n;
            heapArray = new int[capacity];
            current_heap_size = 0;
        }

        // Swapping using reference
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        // Get the Parent index for the given index
        public int Parent(int key)
        {
            return (key - 1) / 2;
        }

        // Get the Left Child index for the given index
        public int Left(int key)
        {
            return 2 * key + 1;
        }

        // Get the Right Child index for the given index
        public int Right(int key)
        {
            return 2 * key + 2;
        }

        // Inserts a new key
        public bool insertKey(int key)
        {
            if (current_heap_size == capacity)
            {
                return false;
            }

            int i = current_heap_size;
            heapArray[i] = key;
            current_heap_size++;

            while (i != 0 && heapArray[i] <
                             heapArray[Parent(i)])
            {
                Swap(ref heapArray[i],
                     ref heapArray[Parent(i)]);
                i = Parent(i);
            }
            return true;
        }

        // Decreases value of given key to new_val.
        // It is assumed that new_val is smaller
        // than heapArray[key].
        public void decreaseKey(int key, int new_val)
        {
            heapArray[key] = new_val;

            while (key != 0 && heapArray[key] <
                               heapArray[Parent(key)])
            {
                Swap(ref heapArray[key],
                     ref heapArray[Parent(key)]);
                key = Parent(key);
            }
        }

        // Returns the minimum key (key at
        // root) from min heap
        public int getMin()
        {
            return heapArray[0];
        }

        // Method to remove minimum element
        // (or root) from min heap
        public int extractMin()
        {
            if (current_heap_size <= 0)
            {
                return int.MaxValue;
            }

            if (current_heap_size == 1)
            {
                current_heap_size--;
                return heapArray[0];
            }

            int root = heapArray[0];

            heapArray[0] = heapArray[current_heap_size - 1];
            current_heap_size--;
            heapArray[current_heap_size] = 0;
            MinHeapify(0);

            return root;
        }

        // This function deletes key at the
        // given index. It first reduced value
        // to minus infinite, then calls extractMin()
        public void deleteKey(int key)
        {
            decreaseKey(key, int.MinValue);
            extractMin();
        }

        // A recursive method to heapify a subtree
        // with the root at given index
        // This method assumes that the subtrees
        // are already heapified
        public void MinHeapify(int key)
        {
            int l = Left(key);
            int r = Right(key);

            int smallest = key;
            if (l < current_heap_size &&
                heapArray[l] < heapArray[smallest])
            {
                smallest = l;
            }
            if (r < current_heap_size &&
                heapArray[r] < heapArray[smallest])
            {
                smallest = r;
            }

            if (smallest != key)
            {
                Swap(ref heapArray[key],
                     ref heapArray[smallest]);
                MinHeapify(smallest);
            }
        }

        // Increases value of given key to new_val.
        // It is assumed that new_val is greater
        // than heapArray[key].
        // Heapify from the given key
        public void increaseKey(int key, int new_val)
        {
            heapArray[key] = new_val;
            MinHeapify(key);
        }

        // Changes value on a key
        public void changeValueOnAKey(int key, int new_val)
        {
            if (heapArray[key] == new_val)
            {
                return;
            }
            if (heapArray[key] < new_val)
            {
                increaseKey(key, new_val);
            }
            else
            {
                decreaseKey(key, new_val);
            }
        }
        public void printHeap()
        {
            for (int i = 0; i < heapArray.Length; i++)
            {
                Console.Write(heapArray[i] + " ");
            }
            Console.Write(" \n");
        }
    }

    static class MinHeapTest
    {

        public static void Main(string[] args)
        {
            Console.Write("Enter size of heap (<= 5) \n");
            int size = Convert.ToInt32(Console.ReadLine());
            MinHeap h = new MinHeap(size);

            Console.Write("Enter an integer to add to the heap\n");
            int temp = Convert.ToInt32(Console.ReadLine());
            h.insertKey(temp);

            Console.Write("Enter an integer to add to the heap\n");
            temp = Convert.ToInt32(Console.ReadLine());
            h.insertKey(temp);

            Console.Write("Enter an integer to add to the heap\n");
            temp = Convert.ToInt32(Console.ReadLine());
            h.insertKey(temp);

            Console.Write("Enter an integer to add to the heap\n");
            temp = Convert.ToInt32(Console.ReadLine());
            h.insertKey(temp);

            Console.Write("Enter an integer to add to the heap\n");
            temp = Convert.ToInt32(Console.ReadLine());
            h.insertKey(temp);

            h.printHeap();

            Console.Write("Enter a valid index to delete\n");
            temp = Convert.ToInt32(Console.ReadLine());
            h.deleteKey(temp);

            h.printHeap();
            
            Console.Write("Extracting min: " + h.extractMin() + "\n");

            h.printHeap();

            Console.Write("Extracting min: " + h.extractMin() + "\n");

            h.printHeap();

            
            // h.insertKey(3);
            // h.insertKey(2);
            // h.deleteKey(1);
            // h.insertKey(15);
            // h.insertKey(5);
            // h.insertKey(4);
            // h.insertKey(45);

            // h.printHeap();
            // Console.Write(h.extractMin() + " \n");
            // h.printHeap();
            // Console.Write(h.getMin() + " \n");

            // h.printHeap();
            // h.decreaseKey(2, 1);
            // Console.Write(h.getMin() + " \n");
            // h.printHeap();
        }
    }
}