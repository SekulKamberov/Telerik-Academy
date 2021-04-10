namespace _03.CountWordsFromTextFile.SerializableDictionary.Abstract
{
    using System;
    using System.Runtime.Serialization;
    using _03.CountWordsFromTextFile.SerializableDictionary.Interfaces;

    [Serializable]
    public abstract class AbstractLibraryItem : ILibraryItem, ISerializable
    {
        public AbstractLibraryItem(string firstName, string lastName, PhoneType phoneType, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneType = phoneType;
            this.PhoneNumber = phoneNumber;
        }

        protected AbstractLibraryItem(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            this.FirstName = info.GetString("FirstName");
            this.LastName = info.GetString("LastName");
            this.PhoneType = (PhoneType)info.GetInt16("PhoneType");
            this.PhoneNumber = info.GetString("PhoneNumber");
        }

        // public T Id { get; protected set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PhoneType PhoneType { get; set; }

        public string PhoneNumber { get; set; }

        // public virtual void Accept(IVisitor<T> visitor)
        // {
        // visitor.Visit(this);
        // }
        public override string ToString()
        {
            return string.Format("Name: {0} {1} ({2}){3}", this.FirstName, this.LastName, this.PhoneType, this.PhoneNumber);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", this.FirstName);
            info.AddValue("LastName", this.LastName);
            info.AddValue("PhoneType", this.PhoneType);
            info.AddValue("PhoneNumber", this.PhoneNumber);
        }
    }
}
