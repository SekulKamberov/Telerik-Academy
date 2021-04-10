namespace ObjectStateValidator.Annotations
{
    using System;

    public abstract class ValidationAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        public abstract bool Validate(object obj);
    }
}
