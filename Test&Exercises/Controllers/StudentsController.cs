using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using Test_Exercises.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Test_Exercises.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class StudentsController : ControllerBase
    {
        public string studFilePath = "../StorageTemp";

        #region Gets

        [HttpGet]
        [Route("GetStudent/{id:int}")]
        public ActionResult<Student> GetStudent(int id) 
        {
            Student st = new Student();
            studFilePath = studFilePath+"/Students.json";
            
            
            using (FileStream f = new FileStream(studFilePath, FileMode.Create))
            {
      
                JsonDocument json= JsonDocument.Parse(f);
                if (json.ToString().Length!=0)
                st= json.Deserialize<Student>();

            }

            if (st.StudentId!= null)
            return BadRequest(st);

            return new OkObjectResult(st); 
        }

        [HttpGet]
        [Route("GetStudents")]
        public ActionResult<List<Student>> GetStudents() 
        {
            return new List<Student>(); 
        }

        [HttpGet]
        [Route("GetStudents/{classId:int}")]
        public ActionResult<List<Student>> GetStudents(int classId) 
        {
            return new List<Student>(); 
        }


        #endregion

        #region Posts


        // enter in body object of single student
        [HttpPost]
        [Route("CreateStudent")]
        public ActionResult CreateStudent() 
        {
            return Ok(); 
        }

        // enter in body list of students
        [HttpPost]
        [Route("CreateStudents")]
        public ActionResult CreateStudents(List<Student> students) 
        {
            var fileDb = "";
            List<Student> tempStud = new List<Student>();
            
            // Read the file
            fileDb = System.IO.File.ReadAllText("..\\Test&Exercises\\StorageTemp\\Db.json");
            // Parse the file to Json Node Json DOM easily accessible and modifiable
            JsonNode dbNode = JsonNode.Parse(fileDb);

            // we deserialize only the list of Students taken from the document Node
            var tempstudNode = dbNode["Students"].Deserialize<List<Student>>();
            // to the deserialized list we add the new students
            tempstudNode.AddRange(students);
            // this is to write the new students indented so with \n
            var options = new JsonSerializerOptions { WriteIndented = true };
            // we parse the new list of students and we change the old with the new one
            dbNode["Students"] = JsonNode.Parse(JsonSerializer.Serialize(tempstudNode));
            // then with the Json Node DOM we parse it to string and overwrite the one that we have locally
            System.IO.File.WriteAllText("..\\Test&Exercises\\StorageTemp\\Db.json",dbNode.ToJsonString(options));

            // se abbiamo file json con db unico e varie liste nominate in teoria preso il root element/ i root element possiamo navigare tra questi
            // parsandolo viene già un array non serve conversione sotto, sopra dobbiamo solo recuperare quello che ci interessa e via, lesgoski lesgo ;)
            // non so perchè cercassi di leggere il body tramite stream, stavo cristonando da due ore bastav solo aggiungere il parametro


            return Ok(); 
        }
        /*
        // send files list of students
        [HttpPost]
        [Route("CreateStudents")]
        public ActionResult CreateStudentsWithFile() 
        {
            return Ok(); 
        }

        */

        #endregion

    }
}
