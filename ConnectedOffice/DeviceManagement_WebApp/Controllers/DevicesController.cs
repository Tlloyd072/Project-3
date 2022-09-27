using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DeviceManagement_WebApp.Controllers
{
    
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;
        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            return View(_deviceRepository.GetAll());
        }
        // GET: Devices/Create
        public IActionResult Create()
        {
            return View(new Device());
        }
        [HttpPost]
        public ActionResult Create(Device device)
        {
            _deviceRepository.AddDevice(device);
            _deviceRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            return View(_deviceRepository.GetById(id));
        }
        [HttpPost]
        public ActionResult Update(Device device)
        {
            _deviceRepository.UpdateDevice(device);
            _deviceRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _deviceRepository.DeleteDevice(id);
            _deviceRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        /**
       // GET: Devices/Details/5
       public IActionResult Details(int? id)
       {
           if (id == null)
           {
               return NotFound();
           }

           var device = _deviceRepository.GetById(id);
           if (device == null)
           {
               return NotFound();
           }

           return View(device);
       }

       
       /**
       [HttpGet]
       public IActionResult SaveDevice()
       {
           return View(new Device()); 

       }
       [HttpPost]
       public IActionResult SaveDevice(Device device)
       {
          var result =  _deviceRepository.(device);
           if(result)
               return RedirectToAction("Index");
           return View(result);

       }
       [HttpGet]
       public IActionResult UpdateDevice(int id)
       {
           var device = _deviceRepository.GetById(id);
           return View(device);

       }
       [HttpPost]
       public IActionResult UpdateDevice(Device device)
       {
           var result = _deviceRepository.UpdateDevice(device);
           if (result)
               return RedirectToAction("Index");
           return View(result);

       }

       [HttpGet]
       public IActionResult DeleteDevice(int id)
       {
           var device = _deviceRepository.GetById(id);
           return View(device);

       }
       [HttpPost]
       public IActionResult DeleteDevice(int id,Device device)
       {
           var result = _deviceRepository.DeleteDevice(id);
           if (result)
               return RedirectToAction("Index");
           return View(device);

       }
       // To protect from overposting attacks, enable the specific properties you want to bind to, for 
       // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
       {
           if (id != device.DeviceId)
           {
               return NotFound();
           }
           try
           {
               _deviceRepository.UpdateDevice(device);
               await _deviceRepository.SaveDevice();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!DeviceExists(device.DeviceId))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }
           return RedirectToAction(nameof(Index));

       }
       /**
       
       // POST: Devices/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to, for 
       // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
       {
           device.DeviceId = Guid.NewGuid();
           _deviceRepository.Add(device);
           await _deviceRepository.SaveDevice();
           return RedirectToAction(nameof(Index));


       }

       //GET: Devices/Edit/5
       
       public IActionResult Edit(int id)
       {
           if (id == null)
           {
               return NotFound();
           }
           var device = _deviceRepository.GetById((int)id);

           if (device == null)
           {
               return NotFound();
           }
           ViewData["CategoryId"] = new SelectList(_deviceRepository.Category, "CategoryId", "CategoryName", device.CategoryId);
           ViewData["ZoneId"] = new SelectList(_deviceRepository.Zone, "ZoneId", "ZoneName", device.ZoneId);
           return View(device);
       }
       /**

       // POST: Devices/Edit/5
       // To protect from overposting attacks, enable the specific properties you want to bind to, for 
       // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
       {
           if (id != device.DeviceId)
           {
               return NotFound();
           }
           try
           {
               _deviceRepository.Update(device);
               await _deviceRepository.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!DeviceExists(device.DeviceId))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }
           return RedirectToAction(nameof(Index));

       }

      //  GET: Devices/Delete/5
       public async Task<IActionResult> Delete(Guid? id)
       {
           if (id == null)
           {
               return NotFound();
           }

           var device = await _deviceRepository.GetById(id);
               
           if (device == null)
           {
               return NotFound();
           }

           return View(device);
       }

      // POST: Devices/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(Guid id)
       {
           var device = await _deviceRepository.GetById(id);
           _deviceRepository.Remove(device);
            _deviceRepository.SaveDevice();
           return RedirectToAction(nameof(Index));
       }
       

       private bool DeviceExists(Guid id)
       {
           return _context.Device.Any(e => e.DeviceId == id);
       }**/

    }
}
