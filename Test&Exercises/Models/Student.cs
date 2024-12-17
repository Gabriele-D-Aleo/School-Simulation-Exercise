namespace Test_Exercises.Models
{
    public class Student
    {
        #region Properties
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public List<Classroom> Classes { get; set; }

        public List<Exam> Exams { get; set; }

        #endregion
    }
}
