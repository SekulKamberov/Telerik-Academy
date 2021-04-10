namespace ObjectStateValidator.Annotations
{
    using System.Collections;

    public class ElementsAttribute : ValidationAttribute
    {
        private int maxCount;

        public ElementsAttribute(int maxCount)
        {
            this.maxCount = maxCount;
            this.ErrorMessage = "{0} should have maximum of " + maxCount + " elements.";
        }

        public int MinCount { get; set; }

        public override bool Validate(object obj)
        {
            if (obj is string)
            {
                var objAsString = (string)obj;
                if (this.MinCount <= objAsString.Length && objAsString.Length <= this.maxCount)
                {
                    return true;
                }

                return false;
            }

            if (obj is ICollection)
            {
                var objAsCollection = (ICollection)obj;
                if (this.MinCount <= objAsCollection.Count && objAsCollection.Count <= this.maxCount)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
