namespace _02.Articles
{
    using System;

    public class Article : IComparable<Article>
    {
        public Article(string barcode, string vendor, string title, int price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0} / {1} / {2} / {3}", this.Barcode, this.Vendor, this.Title, this.Price);
        }

        public override int GetHashCode()
        {
            return this.Barcode.GetHashCode() << 3 ^ 
                this.Price >> 5 ^ 
                this.Title.GetHashCode() << 7 ^ 
                this.Vendor.GetHashCode() >> 13;
        }

        public int CompareTo(Article other)
        {
            var comparePrice = this.Price.CompareTo(other.Price);
            if (comparePrice != 0)
            {
                return comparePrice;
            }

            var compareBarcode = this.Barcode.CompareTo(other.Barcode);
            if (compareBarcode != 0)
            {
                return compareBarcode;
            }

            var compareVendor = this.Vendor.CompareTo(other.Vendor);
            if (compareVendor != 0)
            {
                return compareVendor;
            }

            var compareTitle = this.Title.CompareTo(other.Title);
            if (compareTitle != 0)
            {
                return compareTitle;
            } 

            return 0;
        }
    }
}
