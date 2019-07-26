using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class QuizController : ApiController
    {
        [HttpGet]
        [Route("api/Question")]
        public HttpResponseMessage GetQuestions()
        {
            using(DBModel db = new DBModel())
            {
                var Qns = db.Question
                    .Select(x => new { QnID = x.QnID, Qn = x.Qn, ImageName = x.ImageName, x.Option1, x.Option2, x.Option3, x.Option4 })
                    .OrderBy(y => Guid.NewGuid())
                    .Take(10)
                    .ToArray();
                var updated = Qns.AsEnumerable()
                    .Select(x => new
                    {
                        QnID = x.QnID,
                        Qn = x.Qn,
                        ImageName = x.ImageName,
                        Options = new String[] { x.Option1, x.Option2, x.Option3, x.Option4 }
                    }).ToList();
                return this.Request.CreateResponse(HttpStatusCode.OK, updated);
            }
        }
        [HttpPost]
        [Route("api/Answer")]
        public HttpResponseMessage GetAnswers(int[] qIDs)
        {
            using(DBModel db = new DBModel())
            {
                var result = db.Question
                    .AsEnumerable()
                    .Where(y => qIDs.Contains(y.QnID))
                    .OrderBy(x => { return Array.IndexOf(qIDs, x.QnID); })
                    .Select(z => z.Answer)
                    .ToArray();
                return this.Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }
    }
}
