using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IEmployeeService
    {
        void DeleteEmployee(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        private EmployeeContext _db;
        public EmployeeService(EmployeeContext db)
        {
            _db = db;
        }
        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee == null) return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
