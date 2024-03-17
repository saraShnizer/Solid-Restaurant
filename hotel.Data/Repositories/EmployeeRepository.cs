using Restaurant.Core.Models;
using Restaurant.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        Employee IEmployeeRepository.AddEmployee(Employee employee)
        {
            _context.Employees.Add(new Employee
            {
                EmployeeId=employee.EmployeeId,
                Name=employee.Name,
                PhoneNumber=employee.PhoneNumber,
                Orders=employee.Orders, 
            });
            _context.SaveChanges();
            return employee; 

        }
        void IEmployeeRepository.DeleteEmployee(int id)
        {
            var temp = _context.Employees.Find(id);
            _context.Employees.Remove(temp);
            _context.SaveChanges();
        }
        IEnumerable<Employee> IEmployeeRepository.GetEmployees()
        {
            return _context.Employees;
        }
        Employee IEmployeeRepository.GetById(int id)
        {
            return _context.Employees.Find(id);

        }
        Employee IEmployeeRepository.UpdateEmployee(int id, Employee employee)
        {
            var temp = _context.Employees.Find(id);
            temp.Name=employee.Name;
            temp.PhoneNumber=employee.PhoneNumber;
            temp.EmployeeId=id;
            temp.Orders = employee.Orders;
            _context.SaveChanges();
            return temp;
        }
    }
}
