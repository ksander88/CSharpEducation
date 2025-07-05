using EmployeeAccounting.Models;
using EmployeeAccounting.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeAccounting.Services
{
    public class EmployeeService
    {
        private readonly string _filePath = "employees.txt";
        private List<Employee> _employees;

        public EmployeeService()
        {
            _employees = LoadEmployees();
        }

        // Загрузка из файла
        private List<Employee> LoadEmployees()
        {
            if (!File.Exists(_filePath))
                return new List<Employee>();

            return File.ReadAllLines(_filePath)
                .Select(line => line.Split('|'))
                .Where(parts => parts.Length >= 4)
                .Select(parts => new Employee(
                    int.Parse(parts[0]),
                    parts[1],
                    parts[2],
                    decimal.Parse(parts[3]),
                    parts.Length > 4 ? int.Parse(parts[4]) : 0
                )).ToList();
        }

        // Сохранение в файл
        private void SaveEmployees()
        {
            var lines = _employees.Select(e => $"{e.Id}|{e.Name}|{e.Position}|{e.Salary}|{e.HoursWorked}");
            File.WriteAllLines(_filePath, lines);
        }

        // Добавление сотрудника
        public void AddEmployee(Employee employee)
        {
            if (_employees.Any(e => e.Id == employee.Id))
                throw new ArgumentException("Сотрудник с таким ID уже существует!");

            _employees.Add(employee);
            SaveEmployees();
        }

        // Удаление сотрудника по имени (с исключением)
        public void DeleteEmployee(string name)
        {
            var employee = _employees.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (employee == null)
                throw new EmployeeNotFoundException($"Сотрудник с именем '{name}' не найден!");

            _employees.Remove(employee);
            SaveEmployees();
        }

        // Обновление данных
        public void UpdateEmployee(int id, Action<Employee> updateAction)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                throw new EmployeeNotFoundException($"Сотрудник с ID {id} не найден!");

            updateAction(employee);
            SaveEmployees();
        }

        // Получение всех сотрудников
        public List<Employee> GetAllEmployees() => _employees;

        // Расчёт зарплаты
        public decimal CalculateSalary(int employeeId)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee == null)
                throw new EmployeeNotFoundException($"Сотрудник с ID {employeeId} не найден!");

            return employee.Position.ToLower().Contains("временный")
                ? employee.Salary * employee.HoursWorked
                : employee.Salary;
        }
    }
}