using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Test_Exercises.Models;

namespace Test_Exercises.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class TeachersController : ControllerBase
    {
        public string teacherFilePath = "C:\\Users\\gabriele.daleo\\source\\repos\\Test&Exercises\\Test&Exercises\\StorageTemp\\Db.json";

        #region Gets

        #endregion

        #region Posts

        [HttpPost]
        [Route("InsertTeachers")]
        public ActionResult InsertTeachersF(IFormFile file)
        {
            JsonNode jsDoc;

            Teacher t = new Teacher();
            var properties = t.GetType().GetProperties();

            foreach ( PropertyInfo p in properties)
            {
                System.Console.WriteLine(p.Name);
                var attributes = p.GetCustomAttributes();
                foreach (Attribute a in attributes)
                {
                    System.Console.WriteLine(a.ToString());
                }
            }

            var fileDb = System.IO.File.ReadAllText(teacherFilePath);
            // Parse the file to Json Node Json DOM easily accessible and modifiable
            JsonNode dbNode = JsonNode.Parse(fileDb);

            using (StreamReader stream = new StreamReader(file.OpenReadStream()))
            {
               jsDoc = JsonNode.Parse(stream.ReadToEnd());

            }

            var teachersList = dbNode["Teachers"].Deserialize<List<Teacher>>();

            if (jsDoc != null)
            {
                var tempNewTList = jsDoc.Deserialize<List<Teacher>>();
            
                if (tempNewTList.Count != 0 || tempNewTList != null)
                {
                    teachersList.AddRange(tempNewTList);

                    var options = new JsonSerializerOptions { WriteIndented = true };

                    dbNode["Teachers"] = JsonNode.Parse(JsonSerializer.Serialize(teachersList));

                    System.IO.File.WriteAllText(teacherFilePath, dbNode.ToJsonString(options));
                }
                else
                    return BadRequest(jsDoc.ToJsonString);
            }
            else
                return BadRequest();

            return Ok();
        }

        #endregion

    }
}
