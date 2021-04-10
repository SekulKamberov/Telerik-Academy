namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public abstract class Person : ICommentable
    {
        private string name;
        private IList<string> comments;

        public Person(string name)
        {
            this.Name = name;
            this.Comments = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name is empty!");
                }

                this.name = value;
            }
        }

        public IList<string> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Comments has null value!");
                }

                this.comments = value;
            }
        }

        public void Comment(string comment)
        {
            if (string.IsNullOrEmpty(comment))
            {
                throw new ArgumentException("Comment is empty!");
            }

            this.comments.Add(comment);
        }

        public void ReadComments()
        {
            foreach (var comment in this.comments)
            {
                Console.WriteLine("Comment: {0}", comment);
            }
        }
    }
}
