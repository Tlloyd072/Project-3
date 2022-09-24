using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        public bool DeleteDevice(int id)
        {
            bool result = false;
            var dev = _context.Device.Find(id);
            _context.Device.Remove(dev);
            _context.SaveChanges();

            result = true;

            return result;
            
            
        }

        public Device GetMostRecentService()
        {
            return _context.Device.OrderByDescending(Device => Device.DateCreated).FirstOrDefault();
        }

        public bool SaveDevice(Device device)
        {
            bool outcome = false;
            _context.Device.Add(device);
            _context.SaveChanges();
            outcome = true;


            return outcome;
        }

        public bool UpdateDevice(Device device)
        {
            bool outcome = false;
            _context.Device.Update(device);
            _context.SaveChanges();
            outcome = true;


            return outcome;
        }
    }
    
    
}
