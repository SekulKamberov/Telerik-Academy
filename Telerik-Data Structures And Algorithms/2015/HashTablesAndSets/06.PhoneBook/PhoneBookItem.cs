namespace _06.PhoneBook
{
    public class PhoneBookItem
    {
        public PhoneBookItem(string name, string town, string phoneNumber)
        {
            this.Name = name;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }
    }
}
