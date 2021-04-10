namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private IList<Clas> classes;

        public School()
        {
            this.Classes = new List<Clas>();
        }

        public School(IList<Clas> classes)
        {
            this.Classes = classes;
        }

        public IList<Clas> Classes 
        {
            get
            {
                return this.classes;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Classes has null value!");
                }

                this.classes = value;
            }
        }
    }
}
