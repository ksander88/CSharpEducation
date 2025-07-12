namespace EmployeeAccounting.Exceptions
{
    public class EmployeeAlreadyExistsException : Exception
    {
        public int EmployeeId { get; }

        public EmployeeAlreadyExistsException(int employeeId)
            : base($"Сотрудник с ID {employeeId} уже существует")
        {
            EmployeeId = employeeId;
        }
    }
}