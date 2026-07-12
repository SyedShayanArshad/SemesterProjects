using MongoDB.Bson;

namespace Library_Management_System
{
    public class Book
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; } = string.Empty; // Default to empty string
        public string Author { get; set; } = string.Empty; // Default to empty string
        public decimal Price { get; set; } = 0; // Default to 0
        public int Quantity { get; set; } = 0; // Default to 0
        public int Available { get; set; } = 0; // Default to 0
        public int Issued { get; set; } = 0; // Default to 0
        public string Edition { get; set; } = string.Empty; // Default to empty string
        public string Description { get; set; } = string.Empty; // Default to empty string
        public string Image { get; set; } = string.Empty; // Default to empty string
    }
}
