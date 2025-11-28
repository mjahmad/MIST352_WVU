using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Students_Application
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents a student with ID, name, date of birth, email, and addresses.
    /// Demonstrates data encapsulation, property validation, constructors, and methods.
    /// </summary>
    public class Student
    {
        // ---------------------------------------------------------------------
        // PRIVATE FIELDS
        // ---------------------------------------------------------------------

        private string _strId;                 // Student ID
        private string _strName;               // Student full name
        private DateTime _dtmDob;              // Date of birth
        private string _strEmail;              // Email address
        private string _strPhysicalAddress;    // Home address
        private string _strMailingAddress;     // Mailing address

        // ---------------------------------------------------------------------
        // PUBLIC PROPERTIES (VALIDATED)
        // ---------------------------------------------------------------------

        /// <summary>
        /// Unique student ID (read-only). Assigned only through constructor.
        /// </summary>
        public string StrId
        {
            get => _strId;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Student ID cannot be empty.");
                _strId = value.Trim();
            }
        }

        /// <summary>
        /// Student full name. Cannot be empty or whitespace.
        /// </summary>
        public string StrName
        {
            get => _strName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                _strName = value.Trim();
            }
        }

        /// <summary>
        /// Student’s date of birth. Must make them at least 16 years old.
        /// </summary>
        public DateTime DtmDob
        {
            get => _dtmDob;
            set
            {
                int intAge = CalculateAgeFrom(value);
                if (intAge < 16)
                    throw new ArgumentException("Student must be at least 16 years old.");
                _dtmDob = value;
            }
        }

        /// <summary>
        /// Student’s email address. Must be a valid email format.
        /// </summary>
        public string StrEmail
        {
            get => _strEmail;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email cannot be empty.");

                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(value, pattern))
                    throw new ArgumentException("Invalid email format.");

                _strEmail = value.Trim();
            }
        }

        /// <summary>
        /// Physical (residential) address.
        /// </summary>
        public string StrPhysicalAddress
        {
            get => _strPhysicalAddress;
            set => _strPhysicalAddress = value?.Trim() ?? "";
        }

        /// <summary>
        /// Mailing address.
        /// </summary>
        public string StrMailingAddress
        {
            get => _strMailingAddress;
            set => _strMailingAddress = value?.Trim() ?? "";
        }

        // ---------------------------------------------------------------------
        // CONSTRUCTORS
        // ---------------------------------------------------------------------

        /// <summary>
        /// Constructor #1 — creates a student using only an ID.
        /// Other information can be set later using properties.
        /// </summary>
        public Student(string strId)
        {
            StrId = strId;
            StrName = "Unknown";
            StrEmail = "NotSet@example.com";
            StrPhysicalAddress = "Not Provided";
            StrMailingAddress = "Not Provided";
            _dtmDob = DateTime.MinValue;
        }

        /// <summary>
        /// Constructor #2 — creates a student with ID, Name, and DOB.
        /// Validation occurs automatically through property setters.
        /// </summary>
        public Student(string strId, string strName, DateTime dtmDob)
        {
            StrId = strId;
            StrName = strName;
            DtmDob = dtmDob;
        }

        // ---------------------------------------------------------------------
        // METHODS
        // ---------------------------------------------------------------------

        /// <summary>
        /// Displays all student details in a readable format.
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"ID: {StrId}");
            Console.WriteLine($"Name: {StrName}");

            if (_dtmDob != DateTime.MinValue)
                Console.WriteLine($"DOB: {DtmDob:yyyy-MM-dd} (Age: {CalculateAge()} years)");
            else
                Console.WriteLine("DOB: Not Provided");

            Console.WriteLine($"Email: {StrEmail}");
            Console.WriteLine($"Physical Address: {StrPhysicalAddress}");
            Console.WriteLine($"Mailing Address: {StrMailingAddress}");
            Console.WriteLine("-------------------------------------------------\n");
        }

        /// <summary>
        /// Calculates the student's current age in years.
        /// </summary>
        public int CalculateAge()
        {
            if (_dtmDob == DateTime.MinValue)
                return 0;

            DateTime today = DateTime.Today;
            int age = today.Year - _dtmDob.Year;
            if (_dtmDob.Date > today.AddYears(-age))
                age--;
            return age;
        }

        /// <summary>
        /// Private helper used to validate DOB before assigning.
        /// </summary>
        private int CalculateAgeFrom(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age))
                age--;
            return age;
        }

        /// <summary>
        /// Returns a personalized greeting message based on age.
        /// Demonstrates a method taking a parameter with simple branching logic.
        /// </summary>
        public string GetGreeting(string strPrefix)
        {
            int age = CalculateAge();

            if (age == 0)
                return $"{strPrefix}, age unknown.";
            else if (age < 18)
                return $"{strPrefix}, you are still a young learner!";
            else if (age < 25)
                return $"{strPrefix}, you’re in the prime of your student years.";
            else
                return $"{strPrefix}, your experience adds value to the class!";
        }

        /// <summary>
        /// Returns the student's preferred contact information
        /// based on a simple keyword parameter.
        /// </summary>
        public string GetContact(string contactType)
        {
            if (contactType.ToLower() == "email")
                return StrEmail;

            if (contactType.ToLower() == "mailing")
                return StrMailingAddress;

            if (contactType.ToLower() == "physical")
                return StrPhysicalAddress;

            return "Invalid contact type.";
        }
    }

}
