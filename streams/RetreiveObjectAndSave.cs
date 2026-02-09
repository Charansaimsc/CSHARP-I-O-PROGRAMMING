using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}


public class EmployeeService
{
    private static readonly string filePath = "input.txt";

    public static void Run()
    {
        try
        {
            // 1️⃣ Load existing employees (if file exists)
            List<Employee> employees = DeserializeEmployees();

            // 2️⃣ Read new employees from user
            List<Employee> newEmployees = ReadEmployeeFromUser();

            // 3️⃣ Merge old + new
            employees.AddRange(newEmployees);

            // 4️⃣ Serialize full list back to file
            SerializeEmployees(employees);

            Console.WriteLine("\nEmployees saved successfully.\n");

            // 5️⃣ Display all employees
            DisplayEmployees(employees);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // ---------------- READ FROM USER ----------------

    private static List<Employee> ReadEmployeeFromUser()
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("How many employees? ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEmployee {i + 1}");

            Employee emp = new Employee();

            Console.Write("Id: ");
            emp.Id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());

            employees.Add(emp);
        }

        return employees;
    }

    // ---------------- SERIALIZATION ----------------

    private static void SerializeEmployees(List<Employee> employees)
    {
        string json = JsonSerializer.Serialize(
            employees,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(filePath, json);
    }

    // ---------------- DESERIALIZATION ----------------

    private static List<Employee> DeserializeEmployees()
    {
        if (!File.Exists(filePath))
            return new List<Employee>();

        string json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<Employee>>(json)
               ?? new List<Employee>();
    }

    // ---------------- DISPLAY ----------------

    private static void DisplayEmployees(List<Employee> employees)
    {
        Console.WriteLine("📋 Employee List");
        Console.WriteLine("----------------");

        foreach (var emp in employees)
        {
            Console.WriteLine(
                $"Id: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.Salary}"
            );
        }
    }
}

