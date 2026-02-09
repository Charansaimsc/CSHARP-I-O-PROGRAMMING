using System;
using System.IO;

public class StudentDataService
{
    private static readonly string filePath = "student.dat";

    public static void Run()
    {
        try
        {
            WriteStudentData();
            Console.WriteLine("Student data saved.\n");

            ReadStudentData();
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }

    private static void WriteStudentData()
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter GPA: ");
            double gpa = double.Parse(Console.ReadLine());

            
            writer.Write(roll);
            writer.Write(name);
            writer.Write(gpa);
        }
    }

    private static void ReadStudentData()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No student data found.");
            return;
        }

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            int roll = reader.ReadInt32();
            string name = reader.ReadString();
            double gpa = reader.ReadDouble();

            Console.WriteLine("Student Details");
            
            Console.WriteLine("Roll Number : " + roll);
            Console.WriteLine("Name        : " + name);
            Console.WriteLine("GPA         : " + gpa);
        }
    }
}
