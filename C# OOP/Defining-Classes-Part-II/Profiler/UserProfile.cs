namespace Profiler
{
    using System;
    using System.Collections.Generic;

    public class UserProfile
    {
        [Save]
        public string FirstName { get; set; }

        [Save]
        public string LastName { get; set; }

        [Save]
        public int Age { get; set; }

        [Save]
        public DateTime DateOfBirth { get; set; }

        [Save]
        public string Description { get; set; }
    }
}
