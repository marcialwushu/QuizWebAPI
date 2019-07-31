using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ParticipantController : ApiController
    {
        [HttpPost]
        [Route("api/InsertParticipant")]
        public Participant Insert(Participant model)
        {
            using (DBModel db = new DBModel())
            {
                db.Participant.Add(model);
                db.SaveChanges();
                return model;
            }

        }
        
        [HttpPost]
        [Route("api/UpdateOutput")]        
        public void UpdateOutput(Participant model)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(model).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                
            }

        }

        private Participant[] participants = new Participant[]
        {
            new Participant {  }
        };

        [HttpGet]
        [Route("api/Participants")]
        [ResponseType(typeof(IEnumerable<Participant>))]
        public IEnumerable<Participant> Get()
        {
            return participants;
        }

        [HttpGet]
        [Route("api/Participants/{id}")]
        public IHttpActionResult Get(int id)
        {
            var product = participants.FirstOrDefault((p) => p.ParticipantID == id);
            if (product == null)
            {
                return NotFound();

            }
            return Ok(product);
            
        }
    }
}
