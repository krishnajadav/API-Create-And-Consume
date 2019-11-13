using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using MVC_Product.Models;
namespace MVC_Product.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProductsData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44350/api/");
                //HTTP GET
                var responseTask = client.GetAsync("product");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<product>>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    var rsproduct = from x in alldata
                                 select new[]
                                 {
                                 Convert.ToString(x.pid),
                                 Convert.ToString(x.pname),
                                 Convert.ToString(x.pprice),
                                 Convert.ToString(x.pimage),
                                 Convert.ToString(x.pisdemand),
                                 Convert.ToString(x.pcname),
                                 Convert.ToString(x.psupply)

                          };

                    return Json(new
                    {
                        aaData = rsproduct
                    },
        JsonRequestBehavior.AllowGet);


                }
                else //web api sent error response 
                {
                    //log response status here..

                   var pro = Enumerable.Empty<product>();


                    return Json(new
                    {
                        aaData = pro
                    },
        JsonRequestBehavior.AllowGet);

             
                }
            }
        }

        public JsonResult InupProduct(string id,string pname, string pprice)
        {
            try
            {



                product obj = new product
                {
                    pid = Convert.ToInt32(id),
                    pname = pname,
                    pprice = Convert.ToDecimal(pprice)
                };



                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:44350/api/product");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<product>("product", obj);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return Json(1, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(0, JsonRequestBehavior.AllowGet);
                    }
                }


                /*context.InUPProduct(Convert.ToInt32(id),pname,Convert.ToDecimal(pprice));

                return Json(1, JsonRequestBehavior.AllowGet);*/
            }
            catch (Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult deleteRecord(int ID)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:44350/api/product");

                    //HTTP DELETE
                    var deleteTask = client.DeleteAsync("product/" + ID);
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return Json(1, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(0, JsonRequestBehavior.AllowGet);
                    }
                }



               /* var data = context.products.Where(x => x.pid == ID).FirstOrDefault();
                context.products.Remove(data);
                context.SaveChanges();
                return Json(1, JsonRequestBehavior.AllowGet);*/
            }
            catch (Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

    }
}