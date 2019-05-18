using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main()
        {
            using (var streamReadFile = new FileStream(@"Resources\copyMe.png", FileMode.Open))
            {
                using (var streamCreateFile = new FileStream(@"Resources\moved.png", FileMode.Create))
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
