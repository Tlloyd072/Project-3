using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRrepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRrepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Device GetMostRecentService()
        {
            return _context.Device.OrderByDescending(device => device.DateCreated).FirstOrDefault();
        }
        // GET ALL: Device
        public IEnumerable<Device> GetAll()
        {
            return _context.Device.ToList();
        }
        //GetByID retreives devices by the given id
        public Device GetById(int id)
        {
            return _context.Device.Find(id);
        }
        //Creat a new category: creates a new record of device
        public void CreatNewCategory(Device device)
        {
            _context.Device.Add(device);
        }
        //Update category: updates the exisitng record in the database
        public void EditCategory(Device device)
        {
            _context.Entry(device).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        //Delete category: deletes a device records using the id parsed through
        public void DeleteProduct(int id)
        {
            Device device = _context.Device.Find(id);
            _context.Device.Remove(device);
        }
        // Update: Edits the exisiting record in the device table with the new data
        public void UpdateProduct(Device device)
        {
            _context.Entry(device).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }






    }

}
