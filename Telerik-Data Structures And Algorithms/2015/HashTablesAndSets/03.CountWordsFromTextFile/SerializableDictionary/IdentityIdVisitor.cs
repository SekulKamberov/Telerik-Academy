namespace _03.CountWordsFromTextFile.SerializableDictionary
{
    using System;
    using System.Runtime.Serialization;
    using _03.CountWordsFromTextFile.SerializableDictionary.Interfaces;

    [Serializable]
    public class IdentityIdVisitor : AbstractIdVisitor<int>, ISerializable
    {
        private static int counter;

        public IdentityIdVisitor()
        {
        }

        protected IdentityIdVisitor(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("IdVisitor");
            }

            counter = info.GetInt32("counter");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("counter", counter);
        }

        public override void Visit(ILibraryItem libraryItem)
        {
            // if (libraryItem.Id == 0)
            // {
            // libraryItem.Id = this.GenerateId();
            // }
        }

        protected override int GenerateId()
        {
            counter++;
            return counter;
        }
    }
}
