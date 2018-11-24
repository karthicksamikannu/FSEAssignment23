using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _23WebAPIAssignment.Controllers
{
    public class PoDetailController : Controller
    {
        // GET: PoDetail
        public ActionResult Index()
        {
            List<PODETAIL> model = new List<PODETAIL>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("PODetailAPI");
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<List<PODETAIL>>().Result;
                }
            }
            return View(model);
        }

        public ActionResult Details(string id)
        {
            PODETAIL model = new PODETAIL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("PODetailAPI/" + id);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<PODETAIL>().Result;
                }
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PODETAIL collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31766/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<PODETAIL>("PODetailAPI", collection);
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
            PODETAIL model = new PODETAIL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("PODetailAPI/" + id);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<PODETAIL>().Result;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PODETAIL collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31766/api/");

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<PODETAIL>("PODetailAPI/" + collection.PONO, collection);
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
                var postTask = client.DeleteAsync("PODetailAPI/" + id);
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
