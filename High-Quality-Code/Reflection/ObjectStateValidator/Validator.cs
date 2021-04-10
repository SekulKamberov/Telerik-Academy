namespace ObjectStateValidator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using ObjectStateValidator.Annotations;

    public class Validator : IValidator
    {
        private object validatableObject;
        private bool? isObjectValidated;
        private IDictionary<string, IList<string>> errors;

        public Validator(object validatableObject)
        {
            if (validatableObject == null)
            {
                throw new ArgumentNullException("Object cannot be null.");
            }

            this.validatableObject = validatableObject;
            this.errors = new Dictionary<string, IList<string>>();
        }

        public bool IsValid
        {
            get 
            {
                if (!this.isObjectValidated.HasValue)
                {
                    throw new InvalidOperationException("You must invoke the validate method first!");
                }

                return this.errors.Count == 0; 
            }
        }

        public IDictionary<string, System.Collections.Generic.IList<string>> Errors
        {
            get { return this.errors; }
        }

        public void Validate()
        {
            this.isObjectValidated = true;
            this.Validate(this.validatableObject, string.Empty);
        }

        private void Validate(object obj, string name)
        {
            if (obj == null)
            {
                return;
            }

            var type = obj.GetType();
            foreach (var property in type.GetProperties())
            {
                var propertyName = property.Name;
                var nestedPropertyName = (name == string.Empty ? name : (name + ".")) + propertyName;
                var valueToValidate = property.GetValue(obj);
                var validationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);
                foreach (var validationAttribute in validationAttributes)
                {
                    var attrAsValidationAttr = (ValidationAttribute)validationAttribute;
                    var validationResult = attrAsValidationAttr.Validate(valueToValidate);
                    if (!validationResult)
                    {
                        var errorMessage = attrAsValidationAttr.ErrorMessage;
                        this.AddError(nestedPropertyName, string.Format(errorMessage, nestedPropertyName));
                    }
                }

                // recursion
                if (valueToValidate != null &&
                    !(valueToValidate is ICollection) && 
                    !(valueToValidate is string) &&
                    !property.PropertyType.IsPrimitive)
                {
                    this.Validate(valueToValidate, nestedPropertyName);
                }
            }
        }

        private void AddError(string name, string error)
        {
            if (!this.errors.ContainsKey(name))
            {
                this.errors.Add(name, new List<string>());
            }

            this.errors[name].Add(error);
        }
    }
}
