using Xunit;
using StudentPhonebook;
using System.Collections.Generic;

namespace StudentPhonebook.Tests
{
    public class StudentManagerTests
    {
        [Fact]
        public void AddStudent_ShouldAddStudentSuccessfully()
        {
            // Arrange
            var manager = new StudentManager();

            // Act
            manager.AddStudent("123", "Luke", "1234567890");

            // Assert
            var students = manager.GetAllStudents();
            Assert.Single(students);
            Assert.Equal("Luke", students[0].Name);
        }

        [Fact]
        public void AddStudent_ShouldThrowErrorWhenIdNotUnique()
        {
            // Arrange
            var manager = new StudentManager();
            manager.AddStudent("123", "Luke", "1234567890");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                manager.AddStudent("123", "John", "0987654321")
            );
        }

        [Fact]
        public void LookUpStudentByName_ShouldReturnCorrectStudent()
        {
            // Arrange
            var manager = new StudentManager();
            manager.AddStudent("123", "Luke", "1234567890");
            manager.AddStudent("456", "John", "0987654321");

            // Act
            var results = manager.LookUpStudentByName("Luke");

            // Assert
            Assert.Single(results);
            Assert.Equal("Luke", results.First().Name);
        }

        [Fact]
        public void LookUpStudentByPhoneNumber_ShouldReturnCorrectStudent()
        {
            // Arrange
            var manager = new StudentManager();
            manager.AddStudent("123", "Luke", "1234567890");
            manager.AddStudent("456", "John", "0987654321");

            // Act
            var results = manager.LookUpStudentByPhoneNumber("0987654321");

            // Assert
            Assert.Single(results);
            Assert.Equal("John", results.First().Name);
        }

        [Fact]
        public void LookUpStudentById_ShouldReturnCorrectStudent()
        {
            // Arrange
            var manager = new StudentManager();
            manager.AddStudent("123", "Luke", "1234567890");
            manager.AddStudent("456", "John", "0987654321");

            // Act
            var results = manager.LookUpStudentById("123");

            // Assert
            Assert.Single(results);
            Assert.Equal("Luke", results.First().Name);
        }
    }
}
