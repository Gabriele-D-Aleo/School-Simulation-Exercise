using Newtonsoft.Json.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Exercises.Models
{
    public class Teacher
    {
        #region Properties
        [Key, Required]
        public int TeacherId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }

        public float Salary { get; set; }

        public List<Classroom> Classes { get; set; }

        #endregion

        /*
        JSchemaGenerator generator = new JSchemaGenerator();
        Jschema schema =
        */
    }
}
