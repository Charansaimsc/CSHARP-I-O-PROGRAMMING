/*. Buffered Streams - Efficient File Copy
Problem Statement: Create a C# program that copies a large file
(e.g., 100MB) from one location to another using Buffered Streams
(BufferedStream). Compare the performance with normal file streams.
Requirements: Read and write in chunks of 4 KB (4096 bytes). Use
Stopwatch to measure execution time. Compare execution time with
unbuffered streams.
*/

using System;
using System.IO;

public class FileCopier
{
    private const int BufferSize = 4096; 
    public static void CopyWithoutBuffer(string source, string destination)
    {
        using (FileStream fsRead = new FileStream(source, FileMode.Open, FileAccess.Read))
        using (FileStream fsWrite = new FileStream(destination, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[BufferSize];
            int bytesRead;

            while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsWrite.Write(buffer, 0, bytesRead);
            }
        }
    }
    public static void CopyWithBuffer(string source, string destination)
    {
        using (FileStream fsRead = new FileStream(source, FileMode.Open, FileAccess.Read))
        using (BufferedStream bsRead = new BufferedStream(fsRead, BufferSize))
        using (FileStream fsWrite = new FileStream(destination, FileMode.Create, FileAccess.Write))
        using (BufferedStream bsWrite = new BufferedStream(fsWrite, BufferSize))
        {
            byte[] buffer = new byte[BufferSize];
            int bytesRead;

            while ((bytesRead = bsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                bsWrite.Write(buffer, 0, bytesRead);
            }
        }
    }
}
