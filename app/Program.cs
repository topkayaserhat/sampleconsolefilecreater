using System;
using System.IO;
using System.Text;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App is started!");
           
            try
            {
                
                var dir = $"{AppDomain.CurrentDomain.BaseDirectory}files";
                if (Directory.Exists(dir))
                {
                    Console.WriteLine($"{dir} folder is exist.");
                }
                else
                {
                    Directory.CreateDirectory(dir);
                    Console.WriteLine($"{dir} folder has created.");
                }

                var fileName =  Guid.NewGuid().ToString();
                var path = $"{dir}/{fileName}.txt";

                
                // Create the file, or overwrite if the file exists.
                using (var fs = File.Create(path))
                {
                    var info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                    Console.WriteLine($"{path} has created.");
                }
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
