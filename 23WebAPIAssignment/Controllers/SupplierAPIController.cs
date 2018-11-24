using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _23WebAPIAssignment.Controllers
{
    //[Authorize]
    public class SupplierAPIController : ApiController
    {
        FSEAssignmentEntities dbContext;
        public SupplierAPIController()
        {
            dbContext = new _23WebAPIAssignment.FSEAssignmentEntities();
        }
        // GET api/values
        public IEnumerable<SUPPLIER> Get()
        {
            return dbContext.SUPPLIERs.ToList();
        }

        // GET api/values/5
        public SUPPLIER Get(string id)
        {
            return dbContext.SUPPLIERs.Where(a => a.SUPLNO == id).FirstOrDefault();
        }

        // POST api/values
        public void Post([FromBody]SUPPLIER supplier)
        {
            dbContext.SUPPLIERs.Add(supplier);
            dbContext.SaveChanges();
        }

        // PUT api/values/5
        public void Put(string id, [FromBody]SUPPLIER supplier)
        {
            SUPPLIER supplierOld = dbContext.SUPPLIERs.Where(a => a.SUPLNO == id).FirstOrDefault();
            supplierOld.SUPLNAME = supplier.SUPLNAME;
            supplierOld.SUPLADDR = supplier.SUPLADDR;

            dbContext.Entry(supplierOld).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(string id)
        {
            SUPPLIER supplierOld = dbContext.SUPPLIERs.Where(a => a.SUPLNO == id).FirstOrDefault();
            dbContext.Entry(supplierOld).State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}
