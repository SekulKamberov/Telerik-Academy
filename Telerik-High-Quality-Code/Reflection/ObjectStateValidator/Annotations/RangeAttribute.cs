namespace ObjectStateValidator.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class RangeAttribute : ValidationAttribute
    {
        private int min;
        private int max;

        public RangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
            this.ErrorMessage = "{0} should be between " + min + " and " + max + ".";
        }

        public override bool Validate(object obj)
        {
            if (obj is int)
            {
                var objAsInt = (int)obj;
                if (objAsInt < this.min || this.max < objAsInt)
                {
                    return false;
                }

                return true;
            }
            
            return false;
        }
    }
}
