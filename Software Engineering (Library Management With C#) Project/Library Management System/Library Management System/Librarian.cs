using MongoDB.Bson;

namespace Library_Management_System
{
    public class Librarian
    {
        public ObjectId Id { get; set; } // Unique Identifier
        public string LibrarianName { get; set; } = string.Empty; // Student's full name
        public string LibrarianID { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty; // Gender
        public string Username { get; set; } = string.Empty; // Username for system access
        public string Password { get; set; } = string.Empty; // Password
        public string Mobile { get; set; } = string.Empty; // Mobile number
        public string Address { get; set; } = string.Empty; // Address
    }
}
