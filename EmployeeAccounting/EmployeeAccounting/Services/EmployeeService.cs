using EmployeeAccounting.Exceptions;
using EmployeeAccounting.Models;
using EmployeeAccounting.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAccounting.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            if (_employees.Any(e => e.Id == employee.Id))
            {
                throw new EmployeeAlreadyExistsException(employee.Id);
            }
            _employees.Add(employee);
        }

        public Employee GetEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            var existing = GetEmployee(employee.Id);
            _employees.Remove(existing);
            _employees.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployee(id);
            _employees.Remove(employee);
        }
    }
}