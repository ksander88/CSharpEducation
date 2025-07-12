namespace EmployeeAccounting.Models
{
    public class PartTimeEmployee : Employee
    {
        public int HoursWorked { get; set; }

        public PartTimeEmployee(int id, string name, DateTime hireDate, decimal hourlyRate, int hoursWorked)
            : base(id, name, hireDate, hourlyRate)
        {
            HoursWorked = hoursWorked;
        }

        public override decimal CalculateSalary()
        {
            return BaseSalary * HoursWorked;
        }

        public override string GetEmployeeType()
        {
            return "Сотрудник с почасовой оплатой";
        }
    }
}