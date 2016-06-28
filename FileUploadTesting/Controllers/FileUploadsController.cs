using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FileUploadTesting.Models;
using System.IO;

namespace FileUploadTesting.Controllers
{
    public class FileUploadsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: FileUploads
        public ActionResult Index()
        {
            return View(db.FileUploads.ToList());
        }
        //[HttpPost]
        //public ActionResult Index(FileUpload upload, HttpPostedFileBase file)
        //{
        //    if (file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var guid = Guid.NewGuid().ToString();
        //        var path = Path.Combine(Server.MapPath("~/uploads"), guid + fileName);
        //        file.SaveAs(path);
        //        string fl = path.Substring(path.LastIndexOf("\\"));
        //        string[] split = fl.Split('\\');
        //        string newpath = split[1];
        //        string imagepath = "~/uploads/" + newpath;
        //        upload.length = imagepath;
        //        db.FileUploads.Add(upload);
        //        db.SaveChanges();
        //    }
        //    TempData["Success"] = "Upload successful";
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Index(FileUpload upload, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                //var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/uploads"),fileName);
                file.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = "~/uploads/" + newpath;
                upload.Path = imagepath;
                upload.FileName = fileName;
                db.FileUploads.Add(upload);
                db.SaveChanges();
            }
            //ViewBag.Success = "Upload Successful";
            TempData["Success"] = "Upload successful";
            return RedirectToAction("Index");
        }


        // GET: FileUploads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUpload fileUpload = db.FileUploads.Find(id);
            if (fileUpload == null)
            {
                return HttpNotFound();
            }
            return View(fileUpload);
        }

        // GET: FileUploads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileUploads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,length")] FileUpload fileUpload)
        {
            if (ModelState.IsValid)
            {
                db.FileUploads.Add(fileUpload);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fileUpload);
        }

        // GET: FileUploads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUpload fileUpload = db.FileUploads.Find(id);
            if (fileUpload == null)
            {
                return HttpNotFound();
            }
            return View(fileUpload);
        }

        // POST: FileUploads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,length")] FileUpload fileUpload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileUpload).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fileUpload);
        }

        // GET: FileUploads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUpload fileUpload = db.FileUploads.Find(id);
            if (fileUpload == null)
            {
                return HttpNotFound();
            }
            return View(fileUpload);
        }

        // POST: FileUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileUpload fileUpload = db.FileUploads.Find(id);
            db.FileUploads.Remove(fileUpload);
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
