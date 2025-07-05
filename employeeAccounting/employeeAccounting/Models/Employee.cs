namespace EmployeeAccounting.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int HoursWorked { get; set; }

        public Employee(int id, string name, string position, decimal salary, int hours = 0)
        {
            Id = id;
            Name = name;
            Position = position;
            Salary = salary;
            HoursWorked = hours;
        }
    }
}