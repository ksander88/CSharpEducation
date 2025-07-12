namespace EmployeeAccounting.Models
{
    public abstract class Employee
    {
        public int Id { get; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public decimal BaseSalary { get; set; }

        protected Employee(int id, string name, DateTime hireDate, decimal baseSalary)
        {
            Id = id;
            Name = name;
            HireDate = hireDate;
            BaseSalary = baseSalary;
        }

        public abstract decimal CalculateSalary();
        public abstract string GetEmployeeType();
    }
}