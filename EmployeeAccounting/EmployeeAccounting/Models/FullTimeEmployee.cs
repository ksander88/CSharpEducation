namespace EmployeeAccounting.Models
{
    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(int id, string name, DateTime hireDate, decimal salary)
            : base(id, name, hireDate, salary) { }

        public override decimal CalculateSalary()
        {
            // Фиксированная зарплата + бонусы
            return BaseSalary;
        }

        public override string GetEmployeeType()
        {
            return "Штатный сотрудник";
        }
    }
}