namespace _09.StudentGroups
{
    using System;

    public class Group
    {
        private int groupNumber;
        private string groupName;

        public Group()
        {
        }

        public Group(int groupNumber, string groupName)
            : this()
        {
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Group number cannot be negative");
                }
                this.groupNumber = value;
            }
        }

        public string GroupName
        {
            get { return groupName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Group name cannot be null or empty");
                }

                this.groupName = value;
            }
        }
    }
}
