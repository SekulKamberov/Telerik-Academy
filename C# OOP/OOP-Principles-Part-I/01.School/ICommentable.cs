namespace _01.School
{
    using System.Collections.Generic;

    public interface ICommentable
    {
        IList<string> Comments { get; set; }

        void Comment(string comment);

        void ReadComments();
    }
}
