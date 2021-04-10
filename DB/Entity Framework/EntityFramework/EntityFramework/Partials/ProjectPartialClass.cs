namespace EntityFramework
{
    using System;

    public partial class Project
    {
        public TimeSpan TimeSinceBeginning()
        {
            return DateTime.Now - this.StartDate;
        }
    }
}
