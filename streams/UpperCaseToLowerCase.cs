/*Filter Streams - Convert Uppercase to Lowercase
📌 Problem Statement: Create a program that reads a text file and
writes its contents into another file, converting all uppercase letters to
lowercase.
Requirements: Use StreamReader and StreamWriter. Use
BufferedStream for efficiency. Handle character encoding issues.
*/
using System;
using System.IO;
using System.Text;
using System.Xml;
public class Text
{
    public static void Run()
    {
        string SourceFile = "input.txt";
        string DEstination = "output.txt";
        try
        {
            if (!File.Exists(SourceFile))
            {
                Console.WriteLine("file not present");
                return;
            }
            using (FileStream reader = new FileStream(SourceFile, FileMode.Open, FileAccess.Read))
            using (BufferedStream bs = new BufferedStream(reader))
            using (StreamReader reads = new StreamReader(bs, Encoding.UTF8))
            using (FileStream writer = new FileStream(DEstination, FileMode.Append, FileAccess.Write))
            using (BufferedStream bswrite = new BufferedStream(writer))
            using (StreamWriter writes = new StreamWriter(bswrite, Encoding.UTF8))
            {
                string line;
                while ((line = reads.ReadLine()) != null)
                {
                        writes.WriteLine(line.ToLower());
                }

            }
            Console.WriteLine("created");


        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}