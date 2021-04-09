namespace School
{
    using System;
    using System.Collections.Generic;

    public class Discipline : IComment
    {
        private string name;
        private int exerciseNumber;
        private int lectureNumber;

        public Discipline(string name, int exerciseNumber, int lectureNumber)
        {
            this.Name = name;
            this.ExerciseNumber = exerciseNumber;
            this.LectureNumber = lectureNumber;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Discipline name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int ExerciseNumber
        {
            get { return this.exerciseNumber; }
            private set
            {
                if (this.exerciseNumber < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of exercise cannot be negative number");
                }

                this.exerciseNumber = value;
            }
        }

        public int LectureNumber
        {
            get { return this.lectureNumber; }
            private set
            {
                if (this.lectureNumber < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of exercise cannot be negative number");
                }

                this.lectureNumber = value;
            }
        }

        public List<string> Comment { get; set; }

        public void AddComment(string comment)
        {
            this.Comment.Add(comment);
        }

        public override string ToString()
        {
            return "Discipline: " + this.Name;
        }
    }
}
