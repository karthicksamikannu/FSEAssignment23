using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _23WebAPIAssignment.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {
            List<ITEM> model = new List<ITEM>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("ItemAPI");
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<List<ITEM>>().Result;
                }
            }
            return View(model);
        }

        public ActionResult Details(string id)
        {
            ITEM model = new ITEM();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("ItemAPI/" + id);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<ITEM>().Result;
                }
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ITEM collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31766/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ITEM>("ItemAPI", collection);
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
            ITEM model = new ITEM();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:31766/api/");

                //HTTP GET
                var getTask = client.GetAsync("ItemAPI/" + id);
                getTask.Wait();

                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    model = result.Content.ReadAsAsync<ITEM>().Result;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ITEM collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31766/api/");

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<ITEM>("ItemAPI/" + collection.ITCODE, collection);
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
                var postTask = client.DeleteAsync("ItemAPI/" + id);
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
