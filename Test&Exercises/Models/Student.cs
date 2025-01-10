using System.ComponentModel.DataAnnotations;

namespace Test_Exercises.Models
{
    public class Student
    {
        #region Properties
        [Key,Required]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        /// <summary>
        /// still thinking about if these are all the
        /// </summary>
        public List<Classroom> Classes { get; set; }

        public List<Exam> Exams { get; set; }

        #endregion
    }
}
