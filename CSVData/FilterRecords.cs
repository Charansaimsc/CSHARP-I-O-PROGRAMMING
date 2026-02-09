using System;
using System.IO;
public class FilterRecords
{
    private static readonly string folderpath = "datafields";
    private static readonly string filepath = "datafields/Students.csv";
    public static void Run()
    {
        try
        {
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            if (!File.Exists(filepath))
            {
                File.Create(filepath);
            }
            using(StreamReader sr = new StreamReader(filepath))
            {
                string line;
                bool isHeader = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (isHeader)
                    {
                        isHeader = false;
                        continue;
                    }
                     string[] values = line.Split(',');

                    int id = int.Parse(values[0]);
                    string name = values[1];
                    int age = int.Parse(values[2]);
                    int marks = int.Parse(values[3]);
                    if (marks > 80)
                    {
                        PrintStudent(id,name,age,marks);
                    }
                }
            }
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
        private static void PrintStudent(int id , string name,int age,int marks)
    {
        Console.WriteLine("StudentRecord");
         Console.WriteLine("ID    : " + id);
        Console.WriteLine("Name  : " + name);
        Console.WriteLine("Age   : " + age);
        Console.WriteLine("Marks : " + marks);
    }
    }
