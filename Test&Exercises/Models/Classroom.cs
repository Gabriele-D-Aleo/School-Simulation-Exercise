using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Exercises.Models
{
    public class Classroom
    {
        #region Properties

        [Key]
        public int ClassId { get; set; }
        
        [Key]
        public int SubjectId { get; set; }

        [Key]
        public int TeacherId { get; set; }

        public List<Student> Students { get; set; }

        #endregion
    }
}
