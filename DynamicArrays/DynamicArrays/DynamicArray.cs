using System;

public class DynamicArray<T>
{
    private T[] array;
    private int count;

    public DynamicArray(int initialCapacity = 4)
    {
        array = new T[initialCapacity];
        count = 0;
    }

    public void Add(int index, T item)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative");
        }

        EnsureCapacity(index + 1);
        array[index] = item;
        count = Math.Max(count, index + 1);
    }

    public T this[int index]
    {
        get
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            return array[index];
        }
        set
        {
            Add(index, value);
        }
    }

    public int Count
    {
        get { return count; }
    }

    private void EnsureCapacity(int min)
    {
        if (min > array.Length)
        {
            int newCapacity = array.Length == 0 ? 4 : array.Length * 2;
            newCapacity = Math.Max(newCapacity, min);
            Resize(newCapacity);
        }
    }

    private void Resize(int newSize)
    {
        T[] newArray = new T[newSize];
        Array.Copy(array, newArray, array.Length);
        array = newArray;
    }
}
