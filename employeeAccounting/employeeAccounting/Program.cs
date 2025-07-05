using EmployeeAccounting.Models;
using EmployeeAccounting.Services;
using EmployeeAccounting.Exceptions;
using System;

namespace EmployeeAccounting
{
    class Program
    {
        static void Main()
        {
            var employeeService = new EmployeeService();

            while (true)
            {
                Console.WriteLine("\n1. Добавить сотрудника");
                Console.WriteLine("2. Удалить сотрудника");
                Console.WriteLine("3. Обновить данные");
                Console.WriteLine("4. Список сотрудников");
                Console.WriteLine("5. Рассчитать зарплату");
                Console.WriteLine("6. Выход");

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddEmployee(employeeService);
                            break;
                        case "2":
                            DeleteEmployee(employeeService);
                            break;
                        case "3":
                            UpdateEmployee(employeeService);
                            break;
                        case "4":
                            ListEmployees(employeeService);
                            break;
                        case "5":
                            CalculateSalary(employeeService);
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Неверный ввод!");
                            break;
                    }
                }
                catch (EmployeeNotFoundException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        static void AddEmployee(EmployeeService service)
        {
            Console.Write("Введите ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Console.Write("Должность: ");
            string position = Console.ReadLine();

            Console.Write("Оклад: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Console.Write("Часы работы (если временный): ");
            int hours = int.Parse(Console.ReadLine() ?? "0");

            service.AddEmployee(new Employee(id, name, position, salary, hours));
            Console.WriteLine("Сотрудник добавлен!");
        }

        static void DeleteEmployee(EmployeeService service)
        {
            Console.Write("Введите имя сотрудника для удаления: ");
            string name = Console.ReadLine();
            service.DeleteEmployee(name);
            Console.WriteLine("Сотрудник удалён!");
        }

        static void UpdateEmployee(EmployeeService service)
        {
            Console.Write("Введите ID сотрудника: ");
            int id = int.Parse(Console.ReadLine());

            service.UpdateEmployee(id, emp =>
            {
                Console.Write("Новое имя: ");
                emp.Name = Console.ReadLine();

                Console.Write("Новая должность: ");
                emp.Position = Console.ReadLine();

                Console.Write("Новый оклад: ");
                emp.Salary = decimal.Parse(Console.ReadLine());
            });

            Console.WriteLine("Данные обновлены!");
        }

        static void ListEmployees(EmployeeService service)
        {
            var employees = service.GetAllEmployees();
            if (employees.Count == 0)
            {
                Console.WriteLine("Список пуст!");
                return;
            }

            foreach (var emp in employees)
                Console.WriteLine($"ID: {emp.Id}, Имя: {emp.Name}, Должность: {emp.Position}, Оклад: {emp.Salary}");
        }

        static void CalculateSalary(EmployeeService service)
        {
            Console.Write("Введите ID сотрудника: ");
            int id = int.Parse(Console.ReadLine());
            decimal salary = service.CalculateSalary(id);
            Console.WriteLine($"Зарплата: {salary} руб.");
        }
    }
}