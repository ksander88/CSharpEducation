using EmployeeAccounting.Exceptions;
using EmployeeAccounting.Helpers;
using EmployeeAccounting.Models;
using EmployeeAccounting.Services;
using EmployeeAccounting.Services.Interfaces;
using System;

namespace EmployeeAccounting
{
    class Program
    {
        private static readonly IEmployeeService _employeeService = new EmployeeService();

        static void Main()
        {
            Console.WriteLine("Система учета сотрудников");

            while (true)
            {
                try
                {
                    DisplayMenu();
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": AddFullTimeEmployee(); break;
                        case "2": AddPartTimeEmployee(); break;
                        case "3": DisplayEmployee(); break;
                        case "4": UpdateEmployee(); break;
                        case "5": DeleteEmployee(); break;
                        case "6": DisplayAllEmployees(); break;
                        case "7": return;
                        default: Console.WriteLine("Неверный выбор"); break;
                    }
                }
                catch (EmployeeAlreadyExistsException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (EmployeeNotFoundException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n1. Добавить штатного сотрудника");
            Console.WriteLine("2. Добавить сотрудника с почасовой оплатой");
            Console.WriteLine("3. Найти сотрудника");
            Console.WriteLine("4. Обновить данные сотрудника");
            Console.WriteLine("5. Удалить сотрудника");
            Console.WriteLine("6. Показать всех сотрудников");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите действие: ");
        }

        static void AddFullTimeEmployee()
        {
            Console.WriteLine("\nДобавление штатного сотрудника:");
            int id = ConsoleHelper.ReadInt("ID: ");
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            DateTime hireDate = ConsoleHelper.ReadDate("Дата приема на работу");
            decimal salary = ConsoleHelper.ReadDecimal("Оклад: ");

            _employeeService.AddEmployee(new FullTimeEmployee(id, name, hireDate, salary));
            Console.WriteLine("Штатный сотрудник успешно добавлен!");
        }

        static void AddPartTimeEmployee()
        {
            Console.WriteLine("\nДобавление сотрудника с почасовой оплатой:");
            int id = ConsoleHelper.ReadInt("ID: ");
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            DateTime hireDate = ConsoleHelper.ReadDate("Дата приема на работу");
            decimal hourlyRate = ConsoleHelper.ReadDecimal("Почасовая ставка: ");
            int hoursWorked = ConsoleHelper.ReadInt("Отработанные часы: ");

            _employeeService.AddEmployee(new PartTimeEmployee(id, name, hireDate, hourlyRate, hoursWorked));
            Console.WriteLine("Сотрудник с почасовой оплатой успешно добавлен!");
        }

        static void DisplayEmployee()
        {
            int id = ConsoleHelper.ReadInt("Введите ID сотрудника: ");
            var employee = _employeeService.GetEmployee(id);
            DisplayEmployeeDetails(employee);
        }

        static void UpdateEmployee()
        {
            int id = ConsoleHelper.ReadInt("Введите ID сотрудника для обновления: ");
            var existing = _employeeService.GetEmployee(id);
            DisplayEmployeeDetails(existing);

            Console.Write("Новое имя (оставьте пустым, чтобы не изменять): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                existing.Name = newName;
            }

            Console.Write("Новая базовая зарплата (оставьте пустым, чтобы не изменять): ");
            string salaryInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(salaryInput) && decimal.TryParse(salaryInput, out decimal newSalary))
            {
                existing.BaseSalary = newSalary;
            }

            if (existing is PartTimeEmployee partTime)
            {
                Console.Write("Новые отработанные часы (оставьте пустым, чтобы не изменять): ");
                string hoursInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(hoursInput) && int.TryParse(hoursInput, out int newHours))
                {
                    partTime.HoursWorked = newHours;
                }
            }

            _employeeService.UpdateEmployee(existing);
            Console.WriteLine("Данные сотрудника успешно обновлены!");
        }

        static void DeleteEmployee()
        {
            int id = ConsoleHelper.ReadInt("Введите ID сотрудника для удаления: ");
            _employeeService.DeleteEmployee(id);
            Console.WriteLine("Сотрудник успешно удален!");
        }

        static void DisplayAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();

            if (!employees.Any())
            {
                Console.WriteLine("Сотрудники не найдены");
                return;
            }

            foreach (var emp in employees)
            {
                DisplayEmployeeDetails(emp);
                Console.WriteLine("---------------------");
            }
        }

        static void DisplayEmployeeDetails(Employee employee)
        {
            Console.WriteLine($"ID: {employee.Id}");
            Console.WriteLine($"Тип: {employee.GetEmployeeType()}");
            Console.WriteLine($"Имя: {employee.Name}");
            Console.WriteLine($"Дата приема: {employee.HireDate:dd.MM.yyyy}");
            Console.WriteLine($"Базовая ставка: {employee.BaseSalary}");

            if (employee is PartTimeEmployee partTime)
            {
                Console.WriteLine($"Отработанные часы: {partTime.HoursWorked}");
            }

            Console.WriteLine($"Зарплата: {employee.CalculateSalary()}");
        }
    }
}