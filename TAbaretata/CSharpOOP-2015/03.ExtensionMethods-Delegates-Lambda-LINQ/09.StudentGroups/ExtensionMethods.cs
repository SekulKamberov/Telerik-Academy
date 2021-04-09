namespace _09.StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ExtensionMethods
    {
        //problem 10 extension method
        public static IEnumerable<Student> ExtensionSortByGroup(this IEnumerable<Student> studentsGroup)
        {
            var sorted =
                from st in studentsGroup
                where st.GroupNumber == 2
                orderby st.FirstName
                select st;

            return sorted;
        }

        //problem 14
        public static IEnumerable<Student> ExtensionSortByAtleastTwoMarks(this IEnumerable<Student> studentsGroup)
        {
            var sorted =
                from st in studentsGroup
                where st.Marks.Count == 2
                select st;

            return sorted;
        }
    }

}
