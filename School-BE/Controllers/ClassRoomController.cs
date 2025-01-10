using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Test_Exercises.Models;

namespace Test_Exercises.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class ClassRoomController : ControllerBase
    {
        [HttpPatch]
        [Route("IntoClassroom")]
        public ActionResult EnterClassroon(object person)
        {
            // The idea here is that a class has a lifetime of a small thread,lesson starts only when teacher enters class and ends 
            // think how to handle each class if it makes sense to store data in json db or something like a cache
            // pensare ad un task async che gestisca la vita della classe con determinati orari 
            // classe può avere 1 solo insegnante , tot studenti, un certo orario d'entrata ed uno d'uscita per tutti
            // gestire entrata in ritardo

            // piattaforma grafica con classi attive e non attive, aule occupate e non
            if (person.GetType() == typeof(Teacher))
                Teach();

            return Ok();
        }


        private async Task Teach()
        {

        }

        // metodi crud per le classi, vanno inserite inizialmente, va capito come gestire il numero di lezioni,
        //  magari funzione random che determina il numero e poi immagazzina valore in variabile 
    }
}
