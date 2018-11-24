using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _23WebAPIAssignment.Controllers
{
    public class ItemAPIController : ApiController
    {
        FSEAssignmentEntities dbContext;
        public ItemAPIController()
        {
            dbContext = new _23WebAPIAssignment.FSEAssignmentEntities();
        }
        // GET api/<controller>
        public IEnumerable<ITEM> Get()
        {
            return dbContext.ITEMs.ToList();
        }

        // GET api/<controller>/5
        public ITEM Get(string id)
        {
            return dbContext.ITEMs.Where(a => a.ITCODE == id).FirstOrDefault(); 
        }

        // POST api/<controller>
        public void Post([FromBody]ITEM value)
        {
            dbContext.ITEMs.Add(value);
            dbContext.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]ITEM value)
        {
            ITEM item = dbContext.ITEMs.Where(a => a.ITCODE == id).FirstOrDefault();
            item.ITDESC = value.ITDESC;
            item.ITRATE = value.ITRATE;

            dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            ITEM item = dbContext.ITEMs.Where(a => a.ITCODE == id).FirstOrDefault();
            dbContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}