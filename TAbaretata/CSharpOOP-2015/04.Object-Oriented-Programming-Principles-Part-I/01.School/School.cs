namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private List<Class> classes;

        public School(params Class[] classes)
        {
            this.Classes = new List<Class>();
            this.Classes.AddRange(classes);
        }

        public List<Class> Classes
        {
            get { return this.classes; }
            private set { this.classes = value; }
        }

        public void AddClass(Class newClass)
        {
            this.classes.Add(newClass);
        }

        public void Remove(Class oldClass)
        {
            this.classes.Remove(oldClass);
        }
    }
}
