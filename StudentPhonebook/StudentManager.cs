using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace StudentPhonebook
{
    public class StudentManager
    {
        private readonly string filePath = "students.json";
        private List<Student> students;

        public StudentManager()
        {
            students = new List<Student>();
        }

        public void AddStudent(string id, string name, string phoneNumber)
        {
            if (students.Any(s => s.Id == id))
            {
                throw new InvalidOperationException("Student ID must be unique.");
            }

            students.Add(new Student { Id = id, Name = name, PhoneNumber = phoneNumber });
        }

        public IEnumerable<Student> LookUpStudentByName(string name)
        {
            return students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Student> LookUpStudentByPhoneNumber(string phoneNumber)
        {
            return students.Where(s => s.PhoneNumber == phoneNumber);
        }

        public IEnumerable<Student> LookUpStudentById(string id)
        {
            return students.Where(s => s.Id == id);
        }

        public void SaveStudents()
        {
            var json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void LoadStudents()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                students = JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
            }
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
