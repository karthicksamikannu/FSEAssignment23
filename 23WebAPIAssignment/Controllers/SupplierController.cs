using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _23WebAPIAssignment.Controllers
{
    public class SupplierController : Controller
    {
        public ActionResult Index()
        {
            List<SUPPLIER> model = new List<SUPPLIER>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("Supplierapi");
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<List<SUPPLIER>>().Result;
                }
            }
            return View(model);
        }

        public ActionResult Details(string id)
        {
            SUPPLIER model = new SUPPLIER();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("Supplierapi/" + id);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<SUPPLIER>().Result;
                }
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SUPPLIER collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31766/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<SUPPLIER>("Supplierapi", collection);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            SUPPLIER model = new SUPPLIER();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("Supplierapi/" + id);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<SUPPLIER>().Result;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SUPPLIER collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31766/api/");

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<SUPPLIER>("Supplierapi/" + collection.SUPLNO, collection);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP POST
                var postTask = client.DeleteAsync("Supplierapi/" + id);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


    }
}
