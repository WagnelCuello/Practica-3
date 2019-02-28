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
    public class ClientesController : Controller
    {
        private CatalogoDataModel db = new CatalogoDataModel();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file)
        {
            // FILE
            string ImageName = System.IO.Path.GetFileName(file.FileName);
            string physicalPath = Server.MapPath("~/images/" + ImageName);
            file.SaveAs(physicalPath);
            
            // CLIENTE
            Cliente cliente = new Cliente();
            cliente.Nombres = Request.Form["Nombres"];
            cliente.Apellidos = Request.Form["Apellidos"];
            cliente.Direccion = Request.Form["Direccion"];
            cliente.Movil = Request.Form["Movil"];
            cliente.Telefono = Request.Form["Telefono"];
            cliente.Email = Request.Form["Email"];
            cliente.ImageUrl = ImageName;

            // ENTITY
            db.Cliente.Add(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IdCliente,Nombres,Apellidos,Direccion,Email,Telefono,Movil,ImageUrl")] Cliente cliente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cliente).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(cliente);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file)
        {
            Cliente cliente = new Cliente();

            if (ModelState.IsValid)
            {
                // FILE
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/" + ImageName);
                file.SaveAs(physicalPath);

                // CLIENTE
                cliente.IdCliente = int.Parse(Request.Form["Id"]);
                cliente.Nombres = Request.Form["Nombres"];
                cliente.Apellidos = Request.Form["Apellidos"];
                cliente.Direccion = Request.Form["Direccion"];
                cliente.Movil = Request.Form["Movil"];
                cliente.Telefono = Request.Form["Telefono"];
                cliente.Email = Request.Form["Email"];
                cliente.ImageUrl = ImageName;

                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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
