using System;
namespace _02.Articles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Article : IComparable<Article>
    {
        public Article(string title, int barcode, string vendor)
        {
            this.Title = title;
            this.Barcode = barcode;
            this.Vendor = vendor;
        }

        public string Title { get; set; }

        public int Barcode { get; set; }

        public string Vendor { get; set; }

        public override string ToString()
        {
            return " Title: " + this.Title + " Barcode: " + this.Barcode + " Vendor: " + this.Vendor;
        }

        public int CompareTo(Article obj)
        {

            if (this.Title.CompareTo(obj.Title) != 0)
            {
                return this.Title.CompareTo(obj.Title);
            }
            else if (this.Barcode.CompareTo(obj.Barcode) != 0)
            {
                return this.Barcode.CompareTo(obj.Barcode);
            }
            else if (this.Vendor.CompareTo(obj.Vendor) != 0)
            {
                return this.Vendor.CompareTo(obj.Vendor);
            }
            return 0;
        }
    }
}
