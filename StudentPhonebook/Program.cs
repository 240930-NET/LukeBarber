using System;

namespace StudentPhonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentManager = new StudentManager();

            // Load students from file on startup
            studentManager.LoadStudents();

            // Main menu loop
            while (true)
            {
                Console.WriteLine("\n--- Student Phonebook ---");
                Console.WriteLine("1. Add new student");
                Console.WriteLine("2. Look up student");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddStudentViaConsole(studentManager);
                        break;
                    case "2":
                        LookUpStudentViaConsole(studentManager);
                        break;
                    case "3":
                        studentManager.SaveStudents();
                        Console.WriteLine("Data saved. Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddStudentViaConsole(StudentManager manager)
        {
            string id = Validation.GetValidInput("Enter Student ID (xyz123456): ", Validation.IsValidId);
            string name = Validation.GetValidInput("Enter Student Name (non-empty): ", Validation.IsValidName);
            string phoneNumber = Validation.GetValidInput("Enter Phone Number (10 digits): ", Validation.IsValidPhoneNumber);

            manager.AddStudent(id, name, phoneNumber);
        }

        static void LookUpStudentViaConsole(StudentManager manager)
        {
            Console.WriteLine("\nLook up student by:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Phone Number");
            Console.WriteLine("3. Student ID");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            IEnumerable<Student>? results = null;

            switch (choice)
            {
                case "1":
                    string name = Validation.GetValidInput("Enter Name: ", Validation.IsValidName);
                    results = manager.LookUpStudentByName(name);
                    break;
                case "2":
                    string phoneNumber = Validation.GetValidInput("Enter Phone Number (10 digits): ", Validation.IsValidPhoneNumber);
                    results = manager.LookUpStudentByPhoneNumber(phoneNumber);
                    break;
                case "3":
                    string id = Validation.GetValidInput("Enter Student ID: ", Validation.IsValidId);
                    results = manager.LookUpStudentById(id);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            if (results != null && results.Any())
            {
                Console.WriteLine("\n--- Students Found ---");
                foreach (var student in results)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Phone: {student.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine("No students found.");
            }
        }
    }
}
