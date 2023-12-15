using System.Diagnostics;
using System.Reflection;
using System.Text;

Console.WriteLine("Analysing images with ARCore");
Console.WriteLine("________________\n");

// get directory of this app
var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

if (directory == null)
{
    Console.WriteLine("Directory not found");
    Console.ReadKey(true);
    return;
}

// get all files with .png and .jpeg extensions from this folder and subfolders
var files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories)
    .Where(s =>
    {
        var temp =s.ToLower();
         return temp.EndsWith(".png") || temp.EndsWith(".jpeg") || temp.EndsWith(".jpg");
    });

var results = new StringBuilder();

foreach (var file in files)
{
    var proc = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "arcoreimg.exe",
            Arguments = $"eval-img --input_image_path=\"{file}\"",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = false
        }
    };

    proc.Start();

    while (!proc.StandardOutput.EndOfStream)
    {
        var line = proc.StandardOutput.ReadLine();
        Console.WriteLine(Path.GetFileName(file) + ": " + line);
        results.AppendLine(Path.GetFileName(file) + "," + line);
    }
    await proc.WaitForExitAsync();
    var exitCode = proc.ExitCode;
    proc.Close();
}

// create CSV file and write results
File.WriteAllText("results.csv", results.ToString());

Console.ReadKey();