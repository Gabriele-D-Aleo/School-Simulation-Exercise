namespace Test_Exercises.Models
{
    public class Subject
    {
        #region Properties
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public List<Classroom> Classes { get; set; }

        #endregion

    }
}
