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
    public class ListingManagerController : Controller
    {
        IRepository<Listing> context;
        public ListingManagerController(IRepository<Listing> context)
        {
            this.context = context;
        }
        // GET: ListingManager
        public ActionResult Index()
        {
            List<Listing> listing = context.Collection().ToList();
            return View(listing);
        }

        public ActionResult Anything()
        {
            return View();
        }

        public ActionResult Details(string Id)
        {
            Listing listing = context.Find(Id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(listing);
            }
        }

        public ActionResult BrowseListings()
        {
            List<Listing> listings;

            listings = context.Collection().ToList();

            ListingViewModel model = new ListingViewModel();
            model.Listings = listings;

            return View(model);
        }

        public ActionResult Create()
        {
            Listing listing = new Listing();
            return View(listing);
        }
        [HttpPost]
        public ActionResult Create(Listing listing, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(listing);
            }
            else
            {
                if (file != null)
                {
                    listing.Image = listing.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ListingImages//") + listing.Image);
                }
                context.Insert(listing);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Listing listing = context.Find(Id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            else
            {
                ListingViewModel viewModel = new ListingViewModel();
                viewModel.Listing = listing;
                return View(listing);
            }
        }
        [HttpPost]
        public ActionResult Edit(Listing listing, string Id,HttpPostedFileBase file)
        {
            Listing listingToEdit = context.Find(Id);
            if (listingToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(listing);
                }
                if (file != null)
                {
                    listingToEdit.Image = listing.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ListingImages//") + listingToEdit.Image);
                }

                listingToEdit.Area = listing.Area;
                listingToEdit.Address = listing.Address;
                listingToEdit.Price = listing.Price;
                listingToEdit.Description = listing.Description;
                listingToEdit.NumBedrooms = listing.NumBedrooms;
                listingToEdit.NumBathrooms = listing.NumBathrooms;
                listingToEdit.NumGarages = listing.NumGarages;
                listingToEdit.Alarm = listing.Alarm;
                listingToEdit.Fencing = listing.Fencing;
                listingToEdit.Wifi = listing.Wifi;
                listingToEdit.OwnerName = listing.OwnerName;
                listingToEdit.NumOwner = listing.NumOwner;



                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Listing listingToDelete = context.Find(Id);

            if (listingToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(listingToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Listing listingToDelete = context.Find(Id);

            if (listingToDelete == null)
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