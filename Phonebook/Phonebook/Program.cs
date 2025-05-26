using System;

class Program
{
    static void Main()
    {
        var phonebook = Phonebook.Instance;

        while (true)
        {
            Console.WriteLine("\n=== Телефонная книга ===");
            Console.WriteLine("1. Добавить абонента");
            Console.WriteLine("2. Удалить абонента");
            Console.WriteLine("3. Найти по номеру");
            Console.WriteLine("4. Найти по имени");
            Console.WriteLine("5. Показать всех");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите номер: ");
                    var phone = Console.ReadLine();
                    Console.Write("Введите имя: ");
                    var name = Console.ReadLine();
                    phonebook.AddAbonent(phone, name);
                    break;

                case "2":
                    Console.Write("Введите номер для удаления: ");
                    phone = Console.ReadLine();
                    phonebook.DeleteAbonent(phone);
                    break;

                case "3":
                    Console.Write("Введите номер для поиска: ");
                    phone = Console.ReadLine();
                    var abonentByPhone = phonebook.GetAbonentByPhone(phone);
                    Console.WriteLine(abonentByPhone != null
                        ? $"Найдено: {abonentByPhone.Name}"
                        : "Не найдено!");
                    break;

                case "4":
                    Console.Write("Введите имя для поиска: ");
                    name = Console.ReadLine();
                    var abonentByName = phonebook.GetAbonentByName(name);
                    Console.WriteLine(abonentByName != null
                        ? $"Найдено: {abonentByName.PhoneNumber}"
                        : "Не найдено!");
                    break;

                case "5":
                    Console.WriteLine("\nСписок абонентов:");
                    foreach (var abonent in phonebook.GetAllAbonents())
                    {
                        Console.WriteLine($"{abonent.Name}: {abonent.PhoneNumber}");
                    }
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Ошибка: неверный ввод!");
                    break;
            }
        }
    }
}