namespace ContactsAPI.Models
{
    public class AddContactsRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
