namespace Test_Exercises.Models
{
    public class Student
    {
        #region Properties
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }


        /// <summary>
        /// still thinking about if these are all the
        /// </summary>
        public List<Classroom> Classes { get; set; }

        public List<Exam> Exams { get; set; }

        #endregion
    }
}
