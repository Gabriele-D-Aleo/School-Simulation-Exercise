using Castle.Core.Logging;
using FileLogger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Cryptography.Xml;
using Test_Exercises.Controllers;
using Test_Exercises.Models;

namespace UnitTestNExercises
{
    public class StudentsTests
    {

        public  IFileLoggerC _fileLogger = new FileLoggerC();


        [Fact]
        public void TestGetStudent()
        {
            //Arr
            int id = 0;
            var controller = new StudentsController(_fileLogger);

            // Act
           

            //Assert
            // fondamentale fare sempre questo tipo di cast explicito altrimenti . Value è vuoto
            Assert.True((controller.GetStudent(id).Result as OkObjectResult).Value != null);
        }
    }
}