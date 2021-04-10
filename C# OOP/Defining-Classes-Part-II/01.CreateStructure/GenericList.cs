namespace _01.CreateStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericList<D> where D : IComparable
    {
        private const int DefaultSize = 32;
        private D[] genericArray;

        public GenericList()
        {
            this.genericArray = new D[DefaultSize];
        }

        public GenericList(int size)
        {
            if (size >= 0)
            {
                this.genericArray = new D[size];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Negative index " + size);
            }
        }

        public uint Count { get; private set; }

        public D this[int index]
        {
            get
            {
                if (index < 0 || this.Count <= index)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return this.genericArray[index];
                }
            }

            set
            {
                if (index < 0 || this.Count <= index)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    this.genericArray[index] = value;
                }
            }
        }

        public void AddElement(D element)
        {
            if (this.Count == this.genericArray.Count())
            {
                this.ExpandArray();
            }

            this.genericArray[this.Count] = element;
            this.Count++;
        }

        public void RemoveElement(int index)
        {
            try
            {
                if (0 <= index && index <= this.Count)
                {
                    D[] tempArr = new D[this.genericArray.Count() - 1];
                    int tempIndex = 0;

                    for (int i = 0; i < this.genericArray.Count(); i++)
                    {
                        if (i != index)
                        {
                            tempArr[tempIndex] = this.genericArray[i];
                            tempIndex++;
                        }
                    }

                    this.Count--;
                    this.genericArray = tempArr;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index - {0}, is not accesible - index out of range", index);
            }
        }

        public int FindElementIndex(D value)
        {
            for (int i = 0; i < this.genericArray.Count(); i++)
            {
                if (this.Compare(value, this.genericArray[i]))
                {
                    return i;
                }                
            }

            return -1;
        }

        public void InsertElement(int index, D element)
        {
            try
            {
                if (0 <= index && index <= this.Count)
                {
                    if (this.Count == this.genericArray.Count())
                    {
                        this.ExpandArray();
                    }

                    D[] tempArr = new D[this.genericArray.Count() + 1];
                    int tempIndex = 0;

                    for (int i = 0; i < tempArr.Count(); i++)
                    {
                        if (i == index)
                        {
                            tempArr[i] = element;
                        }
                        else
                        {
                            tempArr[i] = this.genericArray[tempIndex];
                            tempIndex++;
                        }
                    }

                    this.Count++;
                    this.genericArray = tempArr;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index - {0}, is not accesible - index out of range", index);
            }
        }

        public void Clear()
        {
            this.genericArray = new D[DefaultSize];
            this.Count = 0;
        }

        public override string ToString()
        {
            D[] temp = new D[this.Count];
            Array.Copy(this.genericArray, temp, this.Count);

            return string.Join(", ", temp);
        }
   
        public D Min()
        {
            if (this.Count == 0)
            {
                throw new Exception("There is no Min value in empty list");
            }
            else if (this.Count == 1)
            {
                return this.genericArray[0];
            }
            else
            {
                D min = this.genericArray[0];

                for (int i = 0; i < this.Count; i++)
                {
                    if (min.CompareTo(this.genericArray[i]) > 0)
                    {
                        min = this.genericArray[i];
                    }
                }

                return min;
            }
        }

        public D Max()
        {
            if (this.Count == 0)
            {
                throw new Exception("There is no Max value in empty list");
            }
            else if (this.Count == 1)
            {
                return this.genericArray[0];
            }
            else
            {
                D max = this.genericArray[0];

                for (int i = 0; i < this.Count; i++)
                {
                    if (max.CompareTo(this.genericArray[i]) < 0)
                    {
                        max = this.genericArray[i];
                    }
                }

                return max;
            }
        }

        private void ExpandArray()
        {
            D[] tempArr = new D[this.Count * 2];
            Array.Copy(this.genericArray, tempArr, this.Count);
            this.genericArray = tempArr;
        }

        private bool Compare<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }
}