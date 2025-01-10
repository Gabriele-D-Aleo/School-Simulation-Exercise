using FileLogger;
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
        public string studFilePath = "C:\\Users\\gabriele.daleo\\source\\repos\\Test&Exercises\\Test&Exercises\\StorageTemp\\Db.json";

        // logger funziona senza nessuna aggiunta nel file Program perchè questo service
        // è già aggiunto di default

        public readonly IFileLoggerC _fileLogger;


        public StudentsController(IFileLoggerC fileLogger)
        {
            _fileLogger = fileLogger;
        }

        #region Gets

        [HttpGet]
        [Route("GetStudent/{id:int}")]
        public ActionResult<Student> GetStudent(int id) 
        {
            Student st = new Student();


            string fileDb = System.IO.File.ReadAllText(studFilePath);

            JsonNode jsonNode= JsonNode.Parse(fileDb);

            // A lot of instructions put togheter it's a lo simpler than it looks, first of all in the JsonNode Doc we find the Students, after that we retrieve a List
            st= jsonNode["Students"].Deserialize<List<Student>>().Find(x => x.StudentId == id);
            // logging into file our operations


            if (st == null)
            {
                _fileLogger.Log("Student not found");
                return BadRequest();
            }
            else
                _fileLogger.Log("succesful retrieval");

            return new OkObjectResult(st); 
        }

        [HttpGet]
        [Route("GetStudents")]
        public ActionResult<List<Student>> GetStudents() 
        {
            List<Student> listSt = new List<Student>();


            string fileDb = System.IO.File.ReadAllText(studFilePath);

            JsonNode jsonNode = JsonNode.Parse(fileDb);

            // A lot of instructions put togheter it's a lo simpler than it looks, first of all in the JsonNode Doc we find the Students, after that we retrieve a List
            listSt = jsonNode["Students"].Deserialize<List<Student>>();

            if (listSt == null)
            {
                _fileLogger.Log("Student not found");
                return BadRequest();
            }
            _fileLogger.Log("succesful retrieval");

            return new OkObjectResult(listSt);
        }

        [HttpGet]
        [Route("GetStudents/{classId:int}")]
        public ActionResult<List<Student>> GetStudents(int classId) 
        {
            return new List<Student>(); 
        }

        [HttpGet]
        [Route("GetStudentsAB")]
        public ActionResult<List<Student>> GetStudentsAlphaBetOrder()
        {
            // Read the file
            string fileDb = System.IO.File.ReadAllText(studFilePath);
            // Parse the file to Json Node Json DOM easily accessible and modifiable
            JsonNode dbNode = JsonNode.Parse(fileDb);

            // we deserialize only the list of Students taken from the document Node
            var tempstudList = dbNode["Students"].Deserialize<List<Student>>();
            // to the deserialized list we add the new students
            List<Student> AlphabOrderedStudents = new List<Student>();
            Student lastStud = new Student();
            /*for ( int i= 0; i<tempstudList.Count ;i++)
            { 
                foreach (Student sti in tempstudList)
                    if(st != sti)
                        lastStud = (int)st.StudentName[0] > (int)sti.StudentName[0] ? st : sti;
                // 
                AlphabOrderedStudents.Add(lastStud);
                //tempstudList.r
            }*/

            // 1 gestire ordinamento studenti utilizzando puntatori su liste per ottimizzazione dei tempi

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
            fileDb = System.IO.File.ReadAllText(studFilePath);
            // Parse the file to Json Node Json DOM easily accessible and modifiable
            JsonNode dbNode = JsonNode.Parse(fileDb);

            // we deserialize only the list of Students taken from the document Node
            var tempStudList = dbNode["Students"].Deserialize<List<Student>>();
            // to the deserialized list we add the new students
            Student lastStudent = tempStudList.Last<Student>();

            foreach(Student studentn in students)
            {
                if (students.First<Student>() == studentn && lastStudent != null)
                    studentn.StudentId = lastStudent.StudentId++;
                else if (students.First<Student>() != studentn)
                    studentn.StudentId = students[students.IndexOf(studentn) - 1].StudentId++;
                else
                    studentn.StudentId = 1;
             
            }

            // potrebbe essere ridondante

            tempStudList.AddRange(students);
            // this is to write the new students indented so with \n
            var options = new JsonSerializerOptions { WriteIndented = true };
            // we parse the new list of students and we change the old with the new one
            dbNode["Students"] = JsonNode.Parse(JsonSerializer.Serialize(tempStudList));
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
