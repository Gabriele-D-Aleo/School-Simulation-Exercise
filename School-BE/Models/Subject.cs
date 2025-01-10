using System.ComponentModel.DataAnnotations;

namespace Test_Exercises.Models
{
    public class Subject
    {
        #region Properties
        [Key,Required]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }

        public List<Classroom> Classes { get; set; }

        #endregion

    }
}
