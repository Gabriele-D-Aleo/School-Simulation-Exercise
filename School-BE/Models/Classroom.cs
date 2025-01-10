using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Exercises.Models
{
    public class Classroom
    {
        #region Properties

        [Key, Required]
        public int ClassId { get; set; }

        [Key, Required]
        public int SubjectId { get; set; }

        [Key, Required]
        public int TeacherId { get; set; }

        public List<Student> Students { get; set; }

        #endregion
    }
}
