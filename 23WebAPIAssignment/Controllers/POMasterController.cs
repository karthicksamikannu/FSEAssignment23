using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _23WebAPIAssignment.Controllers
{
    public class POMasterController : Controller
    {
        public ActionResult Index()
        {
            List<POMASTER> model = new List<POMASTER>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("POMasterAPI");
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<List<POMASTER>>().Result;
                }
            }
            return View(model);
        }

        public ActionResult Details(string id)
        {
            POMASTER model = new POMASTER();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("POMasterAPI/" + id);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<POMASTER>().Result;
                }
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(POMASTER collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31766/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<POMASTER>("POMasterAPI", collection);
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
            POMASTER model = new POMASTER();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("POMasterAPI/" + id);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<POMASTER>().Result;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(POMASTER collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31766/api/");

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<POMASTER>("POMasterAPI/" + collection.PONO, collection);
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
                var postTask = client.DeleteAsync("POMasterAPI/" + id);
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
