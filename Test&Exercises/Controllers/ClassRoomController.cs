using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Test_Exercises.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class ClassRoomController : ControllerBase
    {
        [HttpPatch]
        public ActionResult EnterClassroon(int id)
        {

            return Ok();
        }
    }
}
