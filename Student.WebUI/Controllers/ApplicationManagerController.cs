using Student.Core.Contracts;
using Student.Core.Models;
using Student.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class ApplicationManagerController : Controller
    {
        IRepository<Application> context;
        public ApplicationManagerController(IRepository<Application> context)
        {
            this.context = context;
        }
        // GET: JobManager
        public ActionResult Index()
        {
            List<Application> application = context.Collection().Where(p => p.Status == null).OrderByDescending(p => p.CreatedAt).ToList();
            return View(application);
        }
        public ActionResult ApplicationStatuses()
        {
            List<Application> application = context.Collection().Where(p => p.Status != "").OrderByDescending(p => p.CreatedAt).ToList();
            return View(application);
        }

        public ActionResult Create()
        {
            Application application = new Application();
            return View(application);
        }
        [HttpPost]
        public ActionResult Create(Application application, HttpPostedFileBase file1, HttpPostedFileBase file2)
        {
            if (!ModelState.IsValid)
            {
                return View(application);
            }
            else
            {
                if (file1 != null)
                {
                    application.Image = application.Id + Path.GetExtension(file1.FileName);
                    file1.SaveAs(Server.MapPath("//Content//ApplicantImages//") + application.Image);
                }
                if (file2 != null)
                {
                    application.CV = application.Id + Path.GetExtension(file2.FileName);
                    file2.SaveAs(Server.MapPath("//Content//ApplicationImages//") + application.CV);
                }
                context.Insert(application);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Application application = context.Find(Id);
            if (application == null)
            {
                return HttpNotFound();
            }
            else
            {
                ApplicationViewModel viewModel = new ApplicationViewModel();
                viewModel.Application = application;
                return View(application);
            }
        }
        [HttpPost]
        public ActionResult Edit(Application application, string Id, HttpPostedFileBase file1, HttpPostedFileBase file2)
        {
            Application applicationToEdit = context.Find(Id);
            if (applicationToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(application);
                }
                
                if (file1 != null)
                {
                    applicationToEdit.Image = application.Id + Path.GetExtension(file1.FileName);
                    file1.SaveAs(Server.MapPath("//Content//ApplicantImages//") + applicationToEdit.Image);
                }
                if (file2 != null)
                {
                    applicationToEdit.CV = application.Id + Path.GetExtension(file2.FileName);
                    file2.SaveAs(Server.MapPath("//Content//ApplicationImages//") + applicationToEdit.CV);
                }
                applicationToEdit.JobId = application.JobId;
                applicationToEdit.JobPosition = application.JobPosition;
                applicationToEdit.Business = application.Business;
                applicationToEdit.StudentName = application.StudentName;
                applicationToEdit.University = application.University;
                applicationToEdit.Qualification = application.Qualification;
                applicationToEdit.Email = application.Email;
                applicationToEdit.Cell = application.Cell;



                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Application applicationToDelete = context.Find(Id);

            if (applicationToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(applicationToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Application applicationToDelete = context.Find(Id);

            if (applicationToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }


    }
}