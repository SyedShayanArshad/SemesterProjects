using MongoDB.Bson;
using MongoDB.Driver;
using System;
namespace Library_Management_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("LibraryManagementSystem");
                Console.WriteLine("MongoDB attached to Server Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Application.Run(new LoginPage());
        }
    }
}
