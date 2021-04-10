namespace _01.StudentSystem
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string mobilePhone;
        private string email;
        private int course;
        private string address;
        private University university;
        private Faculty faculty;
        private Specialty specialty;

        public Student(string firstName, string middleName, string lastName, string ssn, string mobilePhone, string email, int course, string address, University university, Faculty faculty, Specialty specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Address = address;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        public string Address
        {
            get 
            {
                return this.address; 
            }

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address is null ot empty.");
                }

                this.address = value; 
            }
        }

        public Specialty Specialty
        {
            get
            {
                return this.specialty;
            }

            set
            {
                this.specialty = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }

            set
            {
                this.faculty = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }

            set
            {
                this.university = value;
            }
        }

        public int Course
        {
            get
            {
                return this.course;
            }

            set
            {
                if (value < 1 || 5 < value)
                {
                    throw new ArgumentOutOfRangeException("Course is out of range.");
                }

                this.course = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email is null or empty.");
                }

                if (value.Length < 10)
                {
                    throw new ArgumentOutOfRangeException("Invalid email.");
                }

                this.email = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Mobile Phone is null or empty.");
                }

                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("Mobile Phone has exactly 10 digits.");
                }

                this.mobilePhone = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.ssn;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("SSN is null or empty.");
                }

                if (value.Length != 8)
                {
                    throw new ArgumentOutOfRangeException("SSN has exactly 8 symbols.");
                }

                this.ssn = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last Name is null or empty.");
                }

                this.lastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Middle Name is null or empty.");
                }

                this.middleName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Name is null or empty.");
                }

                this.firstName = value;
            }
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Equals(secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !firstStudent.Equals(secondStudent);
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\nSSN: {3}\nAddress: {4}\tEmail: {5}\nPhone: {6}\tUni: {7}\tFaculty: {8}\tSpciality: {9}\tCourse: {10}", this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.Email, this.MobilePhone, this.University, this.Faculty, this.Specialty, this.Course);
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }

            return this.SSN == student.SSN && this.FirstName == student.FirstName && this.LastName == student.LastName;
        }
                
        public override int GetHashCode()
        {
            return (this.FirstName.GetHashCode() << 3) + (this.MiddleName.GetHashCode() << 5) + (this.LastName.GetHashCode() << 7) + (this.SSN.GetHashCode() << 13);
        }

        public object Clone()
        {
            Student currentStudent = this;

            Student studentCopy = new Student(currentStudent.FirstName, currentStudent.MiddleName, currentStudent.LastName, currentStudent.SSN, currentStudent.MobilePhone, currentStudent.Email, currentStudent.Course, currentStudent.Address, currentStudent.University, currentStudent.Faculty, currentStudent.Specialty);

            return studentCopy;
        }

        public int CompareTo(Student other)
        {
            int comparedByFirstName = this.FirstName.CompareTo(other.FirstName);

            if (comparedByFirstName != 0)
            {
                return comparedByFirstName;
            }

            int comparedByMiddleName = this.MiddleName.CompareTo(other.MiddleName);

            if (comparedByMiddleName != 0)
            {
                return comparedByMiddleName;
            }

            int comparedByLastName = this.LastName.CompareTo(other.LastName);

            if (comparedByLastName != 0)
            {
                return comparedByLastName;
            }

            int compareSSN = this.SSN.CompareTo(other.SSN);

            return compareSSN;
        }
    }
}
