using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using ConsoleApp.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class MainLogic
    {
        private readonly AppContext _dbcontext;

        public MainLogic()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            _dbcontext = new AppContext(optionsBuilder.Options);
        }

        public List<Employee> getEmployee()
        {
            return _dbcontext.employees.ToList();
        }

        public List<Employee> getEmployeeFiltered()
        {
            var res = from c in _dbcontext.employees
                      where c.name.Contains("h")
                      select c;
            return res.ToList();
        }

        public List<GroupDTO> getRentGroupByRoom()
        {
            var res = from c in _dbcontext.rent
                      group c by c.room.numOfRoom into grp
                      select new GroupDTO { name = grp.Key, count = grp.Count() };
            return res.ToList();
        }

        public List<Rent> getRentWithOrg()
        {
            return _dbcontext.rent.Include(u => u.room).Include(u => u.organization).ToList();
        }

        public List<Rent> getRentWithOrgFiltered()
        {
            var res = from c in _dbcontext.rent
                      join u in _dbcontext.organizations on c.organizationID equals u.id
                      join d in _dbcontext.rooms on c.roomID equals d.id
                      where u.email.Contains("h")
                      select c;
            return res.ToList();
        }

        public async Task<Employee> addEmployee(string name, string surname)
        {
            var add = new Employee { name = name, surname = surname };
            _dbcontext.employees.Add(add);
            await _dbcontext.SaveChangesAsync();
            return add;
        }

        public async Task<Rent> addRent()
        {
            var rent = new Rent { roomID = 590, organizationID = 12, entryDate = new DateTime(2024, 12, 10), exitDate = new DateTime(2025, 01, 10) };
            _dbcontext.rent.Add(rent);
            await _dbcontext.SaveChangesAsync();
            return rent;
        }

        public async Task<Employee> deleteEmployee(int id)
        {
            var emp = _dbcontext.employees.FirstOrDefault(u => u.id == id);
            _dbcontext.employees.Remove(emp);
            await _dbcontext.SaveChangesAsync();
            return emp;
        }

        public async Task<Rent> deleteRent(int id)
        {
            var rec = _dbcontext.rent.FirstOrDefault(u => u.id == id);
            _dbcontext.rent.Remove(rec);
            await _dbcontext.SaveChangesAsync();
            return rec;
        }

        public async Task<List<Organization>> updateAll()
        {
            var res = from c in _dbcontext.organizations
                      where c.email.Contains("h")
                      select c;
            foreach(var r in res)
            {
                r.email = r.email.Replace("h", "H");
            }
            await _dbcontext.SaveChangesAsync();
            return res.ToList();
        }
    }
}
