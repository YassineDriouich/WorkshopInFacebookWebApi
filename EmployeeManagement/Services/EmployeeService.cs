using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeManagementDbContext _employeeManagementDbContext;
        public EmployeeService(EmployeeManagementDbContext employeeManagementDbContext)
        {
            _employeeManagementDbContext=employeeManagementDbContext;
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                _employeeManagementDbContext.employees.Add(employee);
                _employeeManagementDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Employee DeleteEmployee(int id)
        {
            var employee = GetById(id);
            _employeeManagementDbContext.employees.Remove(employee);
            _employeeManagementDbContext.SaveChanges();
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeManagementDbContext.employees.ToList();
        }

        public Employee GetById(int id)
        {
           return _employeeManagementDbContext.employees.Find(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeManagementDbContext.Entry(employee).State=EntityState.Modified;
            _employeeManagementDbContext.SaveChanges();
        }
    }
}
