using System;
using System.IO;

public class ImageByteArrayService
{
    public static void Run()
    {
        string sourceImage = @"input.png";   
        string outputImage = @"output2.png";  

        try
        {
            byte[] imageBytes = ImageToByteArray(sourceImage);

            ByteArrayToImage(outputImage, imageBytes);

            bool identical = AreFilesIdentical(sourceImage, outputImage);

            Console.WriteLine(identical ? "Images are IDENTICAL." : "Images are NOT identical.");
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

  

    private static byte[] ImageToByteArray(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Source image not found.");

        byte[] fileBytes = File.ReadAllBytes(path);

        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(fileBytes, 0, fileBytes.Length);
            return ms.ToArray();
        }
    }


    private static void ByteArrayToImage(string path, byte[] data)
    {
        using (MemoryStream ms = new MemoryStream(data))
        {
            File.WriteAllBytes(path, ms.ToArray());
        }
    }

    private static bool AreFilesIdentical(string file1, string file2)
    {
        byte[] bytes1 = File.ReadAllBytes(file1);
        byte[] bytes2 = File.ReadAllBytes(file2);

        if (bytes1.Length != bytes2.Length)
            return false;

        for (int i = 0; i < bytes1.Length; i++)
        {
            if (bytes1[i] != bytes2[i])
                return false;
        }

        return true;
    }
}
