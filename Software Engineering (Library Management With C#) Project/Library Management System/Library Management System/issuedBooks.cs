using MongoDB.Bson;
using System;

namespace Library_Management_System
{
    public class issuedBooks
    {
        public ObjectId Id { get; set; } // MongoDB ObjectId
        public string RollNo { get; set; } = string.Empty; // Default to empty string
        public string StudentName { get; set; } = string.Empty; // Default to empty string
        public string BookTitle { get; set; } = string.Empty; // Default to empty string
        public string Author { get; set; } = string.Empty; // Default to empty string
        public DateTime IssuedDate { get; set; } = DateTime.MinValue; // Default to MinValue
        public DateTime DueDate { get; set; } = DateTime.MinValue; // Default to MinValue
        public DateTime? ReturnDate { get; set; } = null; // Nullable for returned or not
        public int Fine { get; set; } = 0; // Default to 0
        public string PenaltyStatus { get; set; } = string.Empty;
    }
}
