namespace Test_Exercises.Models
{
    public class Teacher
    {
        #region Properties
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public float Salary { get; set; }

        public List<Classroom> Classes { get; set; }

        #endregion
    }
}
