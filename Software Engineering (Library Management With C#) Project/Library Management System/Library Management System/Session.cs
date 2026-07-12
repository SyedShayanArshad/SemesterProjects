using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Session
    {
        private static Session _instance;
        public Student LoggedInStudent { get; private set; }
        public Librarian LoggedInLibrarian { get; private set; }
        private Session() { }
        public static Session Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Session();
                return _instance;
            }
        }
        public void SetLoggedInStudent(Student student)
        {
            LoggedInStudent = student;
            LoggedInLibrarian = null;
        }
        public void SetLoggedInLibrarian(Librarian librarian)
        {
            LoggedInLibrarian = librarian;
            LoggedInStudent = null;
        }
        public void ClearSession()
        {
            LoggedInStudent = null;
            LoggedInLibrarian = null;
        }
    }
}
