using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Practica_5._3.Controllers
{
    public class ProductosController : Controller
    {
        private CatalogoDataModel db = new CatalogoDataModel();

        // GET: Productos
        public ActionResult Index()
        {
            return View(db.Producto.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.

        //public ActionResult Create([Bind(Include = "IdProducto,Producto1,Descripcion,Precio,CantExistencia,ImageUrl")] Producto producto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Producto.Add(producto);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(producto);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file)
        {
            // FILE
            string ImageName = System.IO.Path.GetFileName(file.FileName);
            string physicalPath = Server.MapPath("~/images/" + ImageName);
            file.SaveAs(physicalPath);

            // PRODUCTO
            Producto pro = new Producto();
            pro.Producto1 = Request.Form["Producto1"];
            pro.Descripcion = Request.Form["Descripcion"];
            pro.Precio = float.Parse(Request.Form["Precio"]);
            pro.CantExistencia = int.Parse(Request.Form["CantExistencia"]);
            pro.ImageUrl = ImageName;
            
            // ENTITY
            db.Producto.Add(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file)
        {
            Producto pro = new Producto();

            if (ModelState.IsValid)
            {
                // FILE
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/" + ImageName);
                file.SaveAs(physicalPath);

                // PRODUCTO
                pro.IdProducto = int.Parse(Request.Form["Id"]);
                pro.Producto1 = Request.Form["Producto1"];
                pro.Descripcion = Request.Form["Descripcion"];
                pro.Precio = float.Parse(Request.Form["Precio"]);
                pro.CantExistencia = int.Parse(Request.Form["CantExistencia"]);
                pro.ImageUrl = ImageName;

                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(pro);
        }

        //// POST: Productos/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IdProducto,Producto1,Descripcion,Precio,CantExistencia,ImageUrl")] Producto producto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(producto).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(producto);
        //}

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
