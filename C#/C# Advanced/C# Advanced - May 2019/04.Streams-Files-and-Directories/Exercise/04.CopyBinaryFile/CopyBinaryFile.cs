using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string path = "Resources";
            string fileToCopy = Path.Combine(path, "copyMe.png");
            string destinationFile = Path.Combine(path, "copied.png");

            using (var streamReadFile = new FileStream(fileToCopy, FileMode.Open))
            {
                using (var streamCreateFile = new FileStream(destinationFile, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    long lastBytesToWrite = streamReadFile.Length % buffer.Length;

                    while (true)
                    {
                        if ((streamReadFile.Read(buffer, 0, buffer.Length)) != buffer.Length)
                        {
                            streamCreateFile.Write(buffer, 0, (int)lastBytesToWrite);
                            break;
                        }

                        streamCreateFile.Write(buffer, 0, buffer.Length);
                    }


                }
            }
        }
    }
}
