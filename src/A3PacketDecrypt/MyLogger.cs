using System;
using System.IO;

namespace A3PacketDecrypt
{
    public static class MyLogger
    {
        /// <summary>
        /// Writes specified string into log file
        /// </summary>
        public static void WriteLog(string log)
        {
            try
            {
                using (var sw = new StreamWriter("A3PacketDecrypt.log", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt") + " : " + log);
                }
            }
            catch { }
        }

        public static bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                // Open file for reading
                var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                fileStream.Write(byteArray, 0, byteArray.Length);
                // close file stream
                fileStream.Close();
                return true;
            }
            catch (Exception exception)
            {
                WriteLog(exception.Message);
            }
            // error occured, return false
            return false;
        }
    }
}
