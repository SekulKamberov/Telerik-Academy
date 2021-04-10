namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Person
    {
        private IList<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public Teacher(string name, IList<Discipline> disciplines)
            : base(name)
        {
            this.Disciplines = disciplines;
        }

        public IList<Discipline> Disciplines 
        {
            get
            {
                return this.disciplines;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Disciolines are null!");
                }

                this.disciplines = value;
            }
        }
    }
}
