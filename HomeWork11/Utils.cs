using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11
{
    internal class Utils
    {
        public static string GetBasePath()
        {
            var basePath = "";
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                basePath = @"c:\Otus";
            }
            else
            {
                basePath = "/Otus";
            }
            return basePath;
        }

        public static bool CanWriteToFile(string filePath)
        {
            try
            {
                using (FileStream fs = File.OpenWrite(filePath))
                {
                    return true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
