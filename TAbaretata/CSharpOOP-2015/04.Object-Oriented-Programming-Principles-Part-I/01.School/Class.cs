namespace School
{
    using System;
    using System.Collections.Generic;

    public class Class : IComment
    {
        private string textIdentifier;
        private List<Teacher> teachersSet;

        public Class(string textIdent, params Teacher[] teachersSet)
        {
            this.TextIdentifier = textIdent;
            this.teachersSet = new List<Teacher>();
            this.teachersSet.AddRange(teachersSet);
        }

        public string TextIdentifier
        {
            get { return this.textIdentifier; }
            private set { this.textIdentifier = value; }
        }

        public List<string> Comment { get; set; }

        public void AddComment(string comment)
        {
            this.Comment.Add(comment);
        }

        public override string ToString()
        {
            return "Class " + this.TextIdentifier;
        }
    }
}
