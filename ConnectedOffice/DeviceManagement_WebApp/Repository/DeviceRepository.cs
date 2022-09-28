using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {

        }
        // the methods below is the implementation of what they should do to get data from the database
        public void AddDevice(Device device)
        {
            _context.Device.Add(device);
        }

        public Device DeleteDevice(int id)
        {
            return _context.Device.Find(id); ;
        }

        public Device GetMostRecentService()
        {
            return _context.Device.OrderByDescending(Device => Device.DateCreated).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateDevice(Device device)
        {
            _context.Entry(device).State = EntityState.Modified;
        }

        void IDeviceRepository.DeleteDevice(int id)
        {
            _context.Device.Find(id);
            _context.Remove(id);

        }

        /**
    public bool DeleteDevice(int id)
    {
       bool result = false;
       var dev = _context.Device.Find(id);
       _context.Device.Remove(dev);
       _context.SaveChanges();

       result = true;

       return result;


    }

    public bool SaveDevice(Device device)
    {
       bool outcome = false;
       try
       {
           _context.Device.Add(device);
           _context.SaveChanges();
           outcome = true;
       }
       catch {
       }
   


       return outcome;
    }



    public bool UpdateDevice(Device device)
    {
       bool outcome = false;
       _context.Device.Update(device);
       _context.SaveChanges();
       outcome = true;


       return outcome;
    }**/
    }
    
    
}
