using System;
using System.IO;
public class StudentDataAdd
{
    private static readonly string folderpath = "datafields";
    private static readonly string filepath = "datafields/Employees.csv";
    public static void WriteData()
    {
        try
        {
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                sw.WriteLine("ID,NAME,DEPARTMENT,SALARY");
                sw.WriteLine("1,sai,cs,1234");
                sw.WriteLine("2,charan,cse,23456");
                sw.WriteLine("3,muchakarla,csed,34567");
                sw.WriteLine("4,saicharan,ece,45678");
                sw.WriteLine("5,saicharanmuchakarla,eee,67890");
            }
            Console.WriteLine("Added Successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}