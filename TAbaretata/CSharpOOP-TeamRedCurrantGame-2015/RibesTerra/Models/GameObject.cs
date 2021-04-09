namespace Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Models.CustomExceptions;

    public abstract class GameObject : IEnumerable<GameObject>
    {
        private string name;
        private List<GameObject> listOfObjects;

        public GameObject(string name)
        {
            this.Name = name;
            this.listOfObjects = new List<GameObject>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new InvalidRangeException<int>("Name cannot be less than 4 characters or empty!");
                }

                this.name = value;
            }
        }

        public GameObject this[int index]
        {
            get { return listOfObjects[index]; }
            set { listOfObjects.Insert(index, value); }
        } 

        public IEnumerator<GameObject> GetEnumerator()
        {
            for (int i = 0; i < listOfObjects.Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
