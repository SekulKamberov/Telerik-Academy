namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Clas : ICommentable
    {
        private IList<Student> students;
        private IList<Teacher> teachers;
        private IList<string> comments;
        private Guid id;

        public Clas()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
            this.Comments = new List<string>();
            this.id = new Guid();
        }

        public IList<Student> Students 
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Students has null value!");
                }

                this.students = value;
            } 
        }

        public IList<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Teachers has null value!");
                }

                this.teachers = value;
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

        public Guid Id 
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.id = value;
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
