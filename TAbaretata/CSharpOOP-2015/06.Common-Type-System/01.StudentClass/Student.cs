namespace _01.StudentClass
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string address;
        private string mobilePhone;
        private string email;
        private string course;

        public Student(string firstName, string middleName, string lastName, string ssn, string address,
            string mobilePhone, string email, string course, Speciality speciality, University uni, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Speciality = speciality;
            this.University = uni;
            this.Faculty = faculty;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name input cannot be null or empty");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Middle name input cannot be null or empty");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name input cannot be null or empty");
                }

                this.lastName = value;
            }
        }

        public string SSN
        {
            get { return this.ssn; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("SSN cannot be null or empty");
                }

                this.ssn = value;
            }
        }

        public string Address
        {
            get { return this.address; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address input cannot be null or empty");
                }

                this.address = value;
            }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Mobile phone input cannot be null or empty");
                }

                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email cannot be null or empty");
                }

                this.email = value;
            }
        }

        public string Course
        {
            get { return this.course; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course cannot be null or empty");
                }

                this.course = value;
            }
        }

        public Speciality Speciality { get; private set; }

        public University University { get; private set; }

        public Faculty Faculty { get; private set; }

        public override bool Equals(object obj)
        {
            var student = obj as Student;

            if (student == null)
            {
                return false;
            }

            if (this.SSN == student.SSN)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            sb.AppendLine("SSN: " + this.SSN);
            sb.AppendLine("Address: " + this.Address);
            sb.AppendLine("Mobile Phone: " + this.MobilePhone);
            sb.AppendLine("Email: " + this.Email);
            sb.AppendLine("Course: " + this.Course);
            sb.AppendLine("Speciality: " + this.Speciality);
            sb.AppendLine("University: " + this.University);
            sb.AppendLine("Faculty: " + this.Faculty);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return this.SSN.GetHashCode() ^ this.MobilePhone.GetHashCode();
        }

        public static bool operator ==(Student first, Student second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !(first.Equals(second));
        }

        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.MobilePhone,
                this.Email, this.Course, this.Speciality, this.University, this.Faculty);
        }

        public int CompareTo(Student other)
        {
            var nameOfStudent = this.FirstName + this.MiddleName + this.LastName;
            var nameOfOther = other.FirstName + other.MiddleName + other.LastName;

            if (nameOfStudent == nameOfOther)
            {
                return this.SSN.CompareTo(other.SSN);
            }

            return nameOfStudent.CompareTo(nameOfOther);
        }
    }
}
