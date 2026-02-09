/*Read User Input from Console
Problem Statement: Write a program that asks the user for their
name, age, and favorite programming language, then saves this
information into a file.
Requirements: Use StreamReader for console input. Use StreamWriter
to write the data into a file. Handle exceptions properly.*/


using System;
using System.Formats.Asn1;
using System.IO;
public class User
{
    public static void ReadAndSave()
    {
        string filepath = "input.txt";
        try
        {
            using(StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                Console.WriteLine("Name");
                string name =reader.ReadLine();

                 Console.WriteLine("Age");
               string age = reader.ReadLine();

                 Console.WriteLine("Subject **");
                string favourateSubject =reader.ReadLine();
                using(StreamWriter writer = new StreamWriter(filepath,true))
                {
                    writer.WriteLine("name :"+ name);
                    writer.WriteLine("age:"+ age);
                    writer.WriteLine("subject:"+favourateSubject);
                }

            }
            Console.WriteLine("sAVED");
        }
        catch(IOException e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
}