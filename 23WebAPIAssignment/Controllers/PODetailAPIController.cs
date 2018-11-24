using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _23WebAPIAssignment.Controllers
{
    public class PODetailAPIController : ApiController
    {
        FSEAssignmentEntities dbContext;
        public PODetailAPIController()
        {
            dbContext = new _23WebAPIAssignment.FSEAssignmentEntities();
        }

        // GET api/<controller>
        public IEnumerable<PODETAIL> Get()
        {
            return dbContext.PODETAILs.ToList();
        }

        // GET api/<controller>/5
        public PODETAIL Get(string id)
        {
            return dbContext.PODETAILs.Where(a => a.PONO == id).FirstOrDefault();
        }

        // POST api/<controller>
        public void Post([FromBody]PODETAIL poDetail)
        {
            dbContext.PODETAILs.Add(poDetail);
            dbContext.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]PODETAIL poDetail)
        {
            PODETAIL poDetailOld = dbContext.PODETAILs.Where(a => a.PONO == id).FirstOrDefault();
            poDetailOld.ITCODE = poDetail.ITCODE;
            poDetailOld.QTY = poDetail.QTY;

            dbContext.Entry(poDetailOld).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();

        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            PODETAIL poDetailOld = dbContext.PODETAILs.Where(a => a.PONO == id).FirstOrDefault();
            dbContext.Entry(poDetailOld).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}