using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public sealed class Phonebook
{
    private static readonly Phonebook _instance = new Phonebook();
    private readonly string _filePath = "phonebook.txt";
    private List<Abonent> _abonents;
    private Phonebook()
    {
        _abonents = new List<Abonent>();
        LoadFromFile();
    }
    public static Phonebook Instance => _instance;
    public void AddAbonent(string phoneNumber, string name)
    {
        if (_abonents.Any(a => a.PhoneNumber == phoneNumber || a.Name == name))
        {
            Console.WriteLine("Ошибка: абонент с таким номером или именем уже существует!");
            return;
        }

        _abonents.Add(new Abonent(phoneNumber, name));
        SaveToFile();
        Console.WriteLine("Абонент добавлен!");
    }
    public List<Abonent> GetAllAbonents() => _abonents;
    public Abonent GetAbonentByPhone(string phoneNumber) =>
        _abonents.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
    public Abonent GetAbonentByName(string name) =>
        _abonents.FirstOrDefault(a => a.Name == name);
    public void DeleteAbonent(string phoneNumber)
    {
        var abonent = GetAbonentByPhone(phoneNumber);
        if (abonent == null)
        {
            Console.WriteLine("Ошибка: абонент не найден!");
            return;
        }

        _abonents.Remove(abonent);
        SaveToFile();
        Console.WriteLine("Абонент удалён!");
    }
    private void LoadFromFile()
    {
        if (!File.Exists(_filePath)) return;

        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length == 2)
            {
                _abonents.Add(new Abonent(parts[0], parts[1]));
            }
        }
    }
    private void SaveToFile()
    {
        var lines = _abonents.Select(a => $"{a.PhoneNumber}|{a.Name}");
        File.WriteAllLines(_filePath, lines);
    }
}