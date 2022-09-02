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
    public class DeviceManagerController : Controller
    {
        IRepository<Device> context;
        public DeviceManagerController(IRepository<Device> context)
        {
            this.context = context;
        }
        // GET: DeviceManager
        public ActionResult Index()
        {
            List<Device> device = context.Collection().ToList();
            return View(device);
        }
        public ActionResult BrowseDevices()
        {
            List<Device> devices;

            devices = context.Collection().ToList();

            DeviceViewModel model = new DeviceViewModel();
            model.Devices = devices;

            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Device device = context.Find(Id);
            if (device == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(device);
            }
        }

        public ActionResult Create()
        {
            Device device = new Device();
            return View(device);
        }
        [HttpPost]
        public ActionResult Create(Device device, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(device);
            }
            else
            {
                if (file != null)
                {
                    device.Image = device.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//DeviceImages//") + device.Image);
                }
                context.Insert(device);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Device device = context.Find(Id);
            if (device == null)
            {
                return HttpNotFound();
            }
            else
            {
                DeviceViewModel viewModel = new DeviceViewModel();
                viewModel.Device = device;
                return View(device);
            }
        }
        [HttpPost]
        public ActionResult Edit(Device device, string Id,HttpPostedFileBase file)
        {
            Device deviceToEdit = context.Find(Id);
            if (deviceToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(device);
                }
                if (file != null)
                {
                    deviceToEdit.Image = device.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//DeviceImages//") + deviceToEdit.Image);
                }

                deviceToEdit.Name = device.Name;
                deviceToEdit.Price = device.Price;
                deviceToEdit.Memory = device.Memory;
                deviceToEdit.OperatingSystem = device.OperatingSystem;
                deviceToEdit.ProcessorType = device.ProcessorType;
                deviceToEdit.HardDrive = device.HardDrive;
                deviceToEdit.GraphicsCard = device.GraphicsCard;
                deviceToEdit.VirusProtect = device.VirusProtect;
                deviceToEdit.YearsOfWarranty = device.YearsOfWarranty;



                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Device deviceToDelete = context.Find(Id);

            if (deviceToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(deviceToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Device deviceToDelete = context.Find(Id);

            if (deviceToDelete == null)
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