/*⃣Read a CSV File and Print Data
● Read a CSV file containing student details (ID, Name, Age, Marks).
● Print each record in a structured format.
*/

using System;
using System.IO;
public class Student
{
    private static readonly string folderpath= "datafields";
    private static readonly string filepath= "datafields/Students.csv";
    public static void ReadPrint()
    {
        try
        {
            if (!Directory.Exists(folderpath))
            {
                Console.WriteLine("no folder exists");
                return;
            }
            if (!File.Exists(filepath))
            {
                Console.WriteLine("File not exists");
                return ;
            }
            using(StreamReader sr = new StreamReader(filepath))
            {
                string line;
                bool isHeader = true;
                while((line=sr.ReadLine())!= null)
                {
                    if(isHeader == true)
                    {
                        isHeader = false;
                        continue;
                    }
                    string[] values = line.Split(',');
                    var id = int.Parse(values[0]);
                    var name = (values[1]);
                    var age = int.Parse(values[2]);
                    var marks = int.Parse(values[3]);
                    PrintStudent(id,name,age,marks);
                }
            }
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
        private static void PrintStudent(int id,string name,int age ,int marks)
    {
        Console.WriteLine("StudentRecord\n"+"ID: "+id);
        Console.WriteLine("Name  : " + name);
        Console.WriteLine("Age   : " + age);
        Console.WriteLine("Marks : " + marks);
    }
    
}
