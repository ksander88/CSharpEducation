namespace EmployeeAccounting.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public int EmployeeId { get; }

        public EmployeeNotFoundException(int employeeId)
            : base($"Сотрудник с ID {employeeId} не найден")
        {
            EmployeeId = employeeId;
        }
    }
}