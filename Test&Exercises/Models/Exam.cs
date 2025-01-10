using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Exercises.Models
{
    public class Exam
    {
        #region Properties
        [Key, Required]
        public int StudentId { get; set; }
        [Key, Required]
        public int ClassId { get; set; }
        [Key,Required]
        public int ExamId { get; set; }
        [Range(0,30)]
        public int Mark { get; set; }

        #endregion
    }
}
