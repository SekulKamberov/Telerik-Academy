namespace _03.CountWordsFromTextFile.SerializableDictionary
{
    using System;
    using System.Runtime.Serialization;

    using _03.CountWordsFromTextFile.SerializableDictionary.Abstract;
    using _03.CountWordsFromTextFile.SerializableDictionary.Interfaces;

    [Serializable]
    public class LibraryItem : AbstractLibraryItem, ISerializable
    {
        public LibraryItem(string firstName, string lastName, PhoneType phoneType, string phoneNumber) 
            : base(firstName, lastName, phoneType, phoneNumber)
        {
        }

        protected LibraryItem(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // this.Id = info.GetInt32("Id");
        }

        // public override void GetObjectData(SerializationInfo info, StreamingContext context)
        // {
        // info.AddValue("Id", this.Id);
        // info.AddValue("FirstName", this.FirstName);
        // info.AddValue("LastName", this.LastName);
        // info.AddValue("PhoneType", this.PhoneType);
        // info.AddValue("PhoneNumber", this.PhoneNumber);
        // }
    }
}
