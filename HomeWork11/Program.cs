using System.Text;

namespace HomeWork11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var basePath = Utils.GetBasePath();
            string[] directoryNames = { "TestDir1", "TestDir2" };
            foreach (var dirName in directoryNames)
            {
                var dirPath = Path.Combine(basePath, dirName);
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (!dir.Exists)
                {
                    dir.Create();
                }

                for (int i = 0; i < 10; i++)
                {
                    var fileName = "File" + (i + 1);
                    var filePath = Path.Combine(dirPath, fileName);
                    if (!File.Exists(filePath))
                    {
                        using (var fs = File.Create(filePath))
                        {
                            fs.Write(Encoding.UTF8.GetBytes(fileName+" "));
                        }
                        if (Utils.CanWriteToFile(filePath))
                        {
                            File.AppendAllTextAsync(filePath, DateTime.Now.ToString());
                        }
                    }

                }
            }

            foreach (var dirName in directoryNames)
            {
                var dirPath = Path.Combine(basePath, dirName);
                for (int i = 0; i < 10; i++)
                {
                    var fileName = "File" + (i + 1);
                    var filePath = Path.Combine(dirPath, fileName);
                    if (File.Exists(filePath))
                    {
                        var Text = File.ReadAllText(filePath);
                        Console.WriteLine(Text);
                    }
                }
            }
        }
    }
}
