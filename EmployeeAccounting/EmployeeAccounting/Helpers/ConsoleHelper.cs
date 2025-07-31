using System;

namespace EmployeeAccounting.Helpers
{
    public static class ConsoleHelper
    {
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите целое число.");
            }
        }

        public static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите число.");
            }
        }

        public static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите дату в формате дд.мм.гггг.");
            }
        }
    }
}