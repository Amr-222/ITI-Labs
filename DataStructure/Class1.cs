namespace DataStructure
{

   

    public class DynamicArray<T>
    {
        int FixedSize = 1;

        T[] arr;

        public DynamicArray()
        {
             arr = new T[FixedSize];

        }

        public int Count { get; private set; } = 0;
        public int PrefixSum { get; private set; } = 0;

        public void Add(T value)
        {
            if (Count == FixedSize)
            {
                Resize();
            }
            arr[Count++]= value;

            if (typeof(T) == typeof(int))
                PrefixSum += (int)(object)value;

        }


        private void Resize()
        {
            FixedSize *= 2;
            T[] new_arr = new T[FixedSize];

            for (int i = 0; i < Count; i++)
            {
                new_arr[i] = arr[i];
            }

            arr = new_arr;
        }


        public void PrintAll()
        {
            Console.WriteLine("\nArray Values:");
            for (int i = 0; i < Count; i++)
            {
                Console.Write(arr[i] + "   ");
            }

            Console.WriteLine("");
        }

        public double Average() => Count == 0 || typeof(T) != typeof(int) ? 0 : (double)PrefixSum / Count;
        




    }


    public class MyStack<T>
    {

        int FixedSize = 1;

        T[] mystack;

        public int Count { get; private set; } = 0;

        public MyStack()
        {
            mystack = new T[FixedSize];

        }

        public bool isFull() => (Count == FixedSize);
        public bool isEmpty() => (Count == 0);

        public void Push(T item) {

            if (isFull())
            {
                Resize();
            }


            mystack[Count++] = item;
        }


        private void Resize()
        {
            FixedSize *= 2;

            T[] new_arr = new T[FixedSize];

            for (int i = 0; i < Count; i++)
            {
                new_arr[i] = mystack[i];
            }

            mystack = new_arr;

        }


        public T Pop() {

            if (!isEmpty())
            {
                T[] new_arr = new T[FixedSize];

                for (int i = 0; i < Count-1; i++)
                {
                    new_arr[i] = mystack[i];
                }
                T temp = mystack[Count-1];
                mystack = new_arr;
                Count--;
                return temp;


            }
            return default(T);
        }

        public T Peek() => mystack[Count - 1];


    }

}
