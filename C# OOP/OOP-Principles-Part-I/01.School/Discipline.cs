namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Discipline : ICommentable
    {
        private string name;
        private int lectures;
        private int exersizes;
        private IList<string> comments;

        public Discipline(string name, int lectures, int exersizes)
        {
            this.Name = name;
            this.Lectures = lectures;
            this.Exersizes = exersizes;
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

        public int Lectures
        {
            get
            {
                return this.lectures;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect number of lectures!");
                }

                this.lectures = value;
            }
        }

        public int Exersizes 
        {
            get
            {
                return this.exersizes;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect number of exercises!");
                }

                this.exersizes = value;
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
                    throw new ArgumentNullException("Comments are null!");
                }

                this.comments = value;
            }
        }

        public void Comment(string comment)
        {
            if (string.IsNullOrEmpty(comment))
            {
                throw new ArgumentException("Comment is empty.");
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
