using System;

namespace DynamicArrays { 
    public class DynamicArray<T>
    {
        private T[] internalArray;
        private int actualSize;
        private int allocatedCapacity;

        public DynamicArray(int initialCapacity)
        {
            this.allocatedCapacity = initialCapacity;
            this.internalArray = new T[initialCapacity];
            this.actualSize = 0;
        }

        public void Add(int index, T item)
        {
            if (index < 0 || index > actualSize)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the bounds of the array.");
            }

            if (index >= allocatedCapacity)
            {
                Resize(index);
            }

            if (index < actualSize)
            {
                Array.Copy(internalArray, index, internalArray, index + 1, actualSize - index);
            }

            internalArray[index] = item;
            actualSize++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= actualSize)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return internalArray[index];
            }
            set
            {
                if (index < 0 || index >= actualSize)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                internalArray[index] = value;
            }
        }

        public int Count
        {
            get { return actualSize; }
        }

        private void Resize(int requiredIndex)
        {
            int newCapacity = Math.Max(allocatedCapacity * 2, requiredIndex + 1);
            T[] newArray = new T[newCapacity];
            Array.Copy(internalArray, newArray, allocatedCapacity);
            internalArray = newArray;
            allocatedCapacity = newCapacity;
        }
    }
}
