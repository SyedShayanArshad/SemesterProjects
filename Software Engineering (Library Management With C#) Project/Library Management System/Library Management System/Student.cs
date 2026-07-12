using MongoDB.Bson;

namespace Library_Management_System
{
    public class Student
    {
        public ObjectId Id { get; set; } // Unique Identifier
        public string StudentName { get; set; } = string.Empty; // Student's full name
        public string RollNo { get; set; } = string.Empty; // Roll Number
        public string Gender { get; set; } = string.Empty; // Gender
        public string Username { get; set; } = string.Empty; // Username for system access
        public string Password { get; set; } = string.Empty; // Password
        public string Department { get; set; } = string.Empty; // Department
        public string Mobile { get; set; } = string.Empty; // Mobile number
        public string Address { get; set; } = string.Empty; // Address
    }
}
