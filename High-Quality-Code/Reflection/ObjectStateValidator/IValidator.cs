namespace ObjectStateValidator
{
    using System.Collections.Generic;

    public interface IValidator
    {
        bool IsValid { get; }

        IDictionary<string, IList<string>> Errors { get; }

        void Validate();
    }
}
