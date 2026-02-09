using System;
using System.IO;
public class ReadAndCountRows
{
    private static readonly string folderpath = "datafields";
    private static readonly string filepath = "datafields/Employees.csv";
    public static void WorkOn()
    {
        try
        {
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            int count = 0;
            bool isHeader = true;
            using (StreamReader sr = new StreamReader(filepath))
            {

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (isHeader == true)
                    {
                        isHeader = false;
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        count++;
                    }
                }
                Console.WriteLine("Count: " + count);
            }
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}