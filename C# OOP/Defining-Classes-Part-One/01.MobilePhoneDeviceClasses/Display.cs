namespace _01.MobilePhoneDeviceClasses
{
    using System;

    public class Display
    {
        private int size;
        private int numberOfColors;

        public Display()
            : this(0, 0)
        {
        }

        public Display(int displaySize, int numberOfColors)
        {
            this.Size = displaySize;
            this.NumberOfColors = numberOfColors;
        }

        public int Size 
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Display size is out of range!");
                }

                this.size = value;
            }
        }

        public int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Display size is out of range!");
                }

                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            return string.Format("===Display===\nSize: {0}\nNumber of colors: {1}", this.Size, this.NumberOfColors);
        }
    }
}
