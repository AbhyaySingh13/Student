using Student.Core.Contracts;
using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class StudentsManagerController : Controller
    {
        // GET: StudentsManager
        IRepository<Students> context;
        public StudentsManagerController(IRepository<Students> context)
        {
            this.context = context;
        }
        // GET: ListingManager
        public ActionResult Index()
        {
            List<Students> students = context.Collection().ToList();
            return View(students);
        }

        public ActionResult Create()
        {
            Students students = new Students();
            return View(students);
        }
        [HttpPost]
        public ActionResult Create(Students students)
        {
            if (!ModelState.IsValid)
            {
                return View(students);
            }
            else
            {
                context.Insert(students);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Students students = context.Find(Id);
            if (students == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(students);
            }
        }
        [HttpPost]
        public ActionResult Edit(Students students, string Id)
        {
            Students studentsToEdit = context.Find(Id);
            if (studentsToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(students);
                }

                studentsToEdit.FirstName = students.FirstName;
                studentsToEdit.LastName = students.LastName;
                studentsToEdit.Email = students.Email;
                studentsToEdit.CellNumber = students.CellNumber;
                studentsToEdit.University = students.University;
                studentsToEdit.Faculty = students.Faculty;
                studentsToEdit.Qualification = students.Qualification;
                studentsToEdit.Vaccinated = students.Vaccinated;
                studentsToEdit.NumYears = students.NumYears;
                studentsToEdit.Bursary = students.Bursary;
                studentsToEdit.EmergencyFirstName = students.EmergencyFirstName;
                studentsToEdit.Relation = students.Relation;
                studentsToEdit.EmergencyCellNum = students.EmergencyCellNum;


                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Students studentsToDelete = context.Find(Id);

            if (studentsToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(studentsToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Students studentsToDelete = context.Find(Id);

            if (studentsToDelete == null)
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