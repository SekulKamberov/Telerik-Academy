/*
 * Task 5: Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
         Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
         Implement methods for adding element, accessing element by index, removing element by index, inserting element
         at given position, clearing the list, finding element by its value and ToString(). Check all input parameters to 
         avoid accessing elements at invalid positions.
 * Task 6: Implement auto-grow functionality: when the internal array is full, create a new array of double size
        and move all elements to it.

 */

namespace _05.GenericList
{
    using System;
    using System.Text;

    class GenericList<T> where T: IComparable<T>
    {
        private T[] List { get; set; }
        public int Capacity { get; private set; }
        public int Length{get;private set;}

        public GenericList(int capacity = 0)
        {
            this.Capacity = capacity;
            this.List = new T[Capacity];
            this.Length = 0;
        }

        public void Add(T element)
        {
            if (Capacity == 0)
            {
                AutoGrow();
                this.List[0] = element;
                this.Length--;
            }

            else if (Length >= Capacity)
            {
                AutoGrow();
                this.List[Length] = element;
            }

            else if (Capacity != 0)
            {
                this.List[Length] = element;
                this.Length++;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                return this.List[index];
            }
            set
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                this.List[index] = value;
            }
        }

        public void Remove(int index)
        {
            for (int i = index - 1; i < this.Length - 1; i++)
            {
                this.List[i] = this.List[i + 1];
            }
            this.Length--;
        }

        public void Insert(T element, int position)
        {
            if (position < 0 || position >= this.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            this.Length++;

            T[] clonedArr = new T[this.Length];
            for (int i = 0; i < position-1; i++)
            {
                clonedArr[i] = this.List[i];
            }
            clonedArr[position - 1] = element;

            for (int i = position; i < clonedArr.Length; i++)
            {
                clonedArr[i] = this.List[i - 1];
            }
            this.List = new T[clonedArr.Length];

            for (int i = 0; i < this.List.Length; i++)
            {
                this.List[i] = clonedArr[i];
            }
        }

        public void Clear()
        {
            //nclone
            this.Length = 0;
            this.Capacity = 0;
        }

        public int ElementByValue(T element)
        {
            int result = 0;
            for (int i = 0; i < this.Length; i++)
            {
                if (this.List[i].CompareTo(element) == 0)
                {
                    result = i;
                }
            }
            return result;
        }

        //task 6
        private void AutoGrow()
        {
            if (this.Capacity == 0)
            {
                this.Capacity = 4;
                this.Length = this.Capacity / 2;
            }
            T[] cloneArr = new T[Length * 2];

            for (int i = 0; i < this.List.Length; i++)
            {
                cloneArr[i] = this.List[i];
            }
            this.List = new T[Length * 2];

            for (int i = 0; i < this.List.Length; i++)
            {
                this.List[i] = cloneArr[i];
            }
            this.Capacity = this.List.Length;
        }


        //task 7
        public dynamic Min<T>()
        {
            dynamic min = List[0];
            for (int i = 0; i < Length; i++)
            {
                if (min.CompareTo(List[i]) > 0)
                {
                    min = List[i];
                }
            }
            return min;
        }

        public dynamic Max<T>()
        {
            dynamic max = List[0];
            for (int i = 0; i < Length; i++)
            {
                if (max.CompareTo(List[i]) < 0)
                {
                    max = List[i];
                }
            }
            return max;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Length; i++)
            {
                sb.AppendFormat("Position[{0}]: Element value = {1}", i, List[i]).AppendLine();
            }
            return sb.ToString();
        }
    }
}
