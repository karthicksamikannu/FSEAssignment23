using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _23WebAPIAssignment.Controllers
{
    public class POMasterAPIController : ApiController
    {
        FSEAssignmentEntities dbContext;
        public POMasterAPIController()
        {
            dbContext = new _23WebAPIAssignment.FSEAssignmentEntities();
        }
        // GET api/<controller>
        public IEnumerable<POMASTER> Get()
        {
            return dbContext.POMASTERs.ToList();
        }

        // GET api/<controller>/5
        public POMASTER Get(string id)
        {
            return dbContext.POMASTERs.Where(a => a.PONO == id).FirstOrDefault();
        }

        // POST api/<controller>
        public void Post([FromBody]POMASTER pomaster)
        {
            dbContext.POMASTERs.Add(pomaster);
            dbContext.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]POMASTER pomaster)
        {
            POMASTER pomasterOld = dbContext.POMASTERs.Where(a => a.PONO == id).FirstOrDefault();
            pomasterOld.PODATE = pomaster.PODATE;
            pomasterOld.SUPLNO = pomaster.SUPLNO;

            dbContext.Entry(pomasterOld).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();

        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            POMASTER poMasterOld = dbContext.POMASTERs.Where(a => a.PONO == id).FirstOrDefault();
            dbContext.Entry(poMasterOld).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}