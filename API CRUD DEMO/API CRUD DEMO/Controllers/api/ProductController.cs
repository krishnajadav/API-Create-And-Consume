using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_CRUD_DEMO.Data_Access;

namespace API_CRUD_DEMO.Controllers
{
    public class ProductController : ApiController
    {
        
        public IHttpActionResult GetAllProduct()
        {
            IList<product> pro = null;

            using (var ctx = new TestMVCEntities())
            {
                pro = ctx.products.ToList();
                            
           
            }

            if (pro.Count == 0)
            {
                return NotFound();
            }

            return Ok(pro);
        }

        public IHttpActionResult PostNewProduct(product pro)
        {

            using (var ctx = new TestMVCEntities())
            {

                ctx.InUPProduct(pro.pid,pro.pname,pro.pprice);

                ctx.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult PutOldProduct(product pro)
        {

            using (var ctx = new TestMVCEntities())
            {

                product c = (from x in ctx.products
                              where x.pid == pro.pid
                              select x).First();
            
                if (c != null)
                {
                    c.pname = pro.pname;
                    c.pprice = pro.pprice;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            
            using (var ctx = new TestMVCEntities())
            {
                var pro = ctx.products
                    .Where(s => s.pid == id)
                    .FirstOrDefault();

                ctx.Entry(pro).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
