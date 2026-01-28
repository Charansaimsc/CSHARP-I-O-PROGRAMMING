using System;
using System.IO;

public class ReadAndWrite
{
    public static void CopyFile(string sourceFile, string destinationFile)
    {
        if (!File.Exists(sourceFile))
        {
            using (FileStream fs = File.Create(sourceFile))
            {

                byte[] content = System.Text.Encoding.UTF8.GetBytes(
                    "ABCD EFGH IJKL MNOP QRST WXYZ /n"
                );
                fs.Write(content, 0, content.Length);
            }

            Console.WriteLine("Source file created. .");
            return;
        }

        try
        {
            using (FileStream fsRead = new FileStream( sourceFile,FileMode.Open,FileAccess.Read))
            {
                using (FileStream fsWrite = new FileStream(destinationFile,FileMode.Create,FileAccess.Write))
                {
                    int byteData;
                    while ((byteData = fsRead.ReadByte()) != -1)
                    {
                        fsWrite.WriteByte((byte)byteData);
                    }
                }
            }

            Console.WriteLine("File copied successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O Error: " + ex.Message);
        }
    }
}
