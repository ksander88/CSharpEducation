using EmployeeAccounting.Models;
using System.Collections.Generic;

namespace EmployeeAccounting.Services.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}