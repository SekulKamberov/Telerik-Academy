namespace ObjectStateValidator.Annotations
{
    public class MandatoryAttribute : ValidationAttribute
    {
        public MandatoryAttribute()
        {
            this.ErrorMessage = "{0} cannot be null because it is required!";
        }

        public override bool Validate(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return true;
        }
    }
}
