using Serilog;

namespace Learning.Api
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class test
    {
        public static void ListFilesInDirectory(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Log.Information($"directory found: {directoryPath}");




                    // Get all files in the directory
                    string[] files = Directory.GetFiles(directoryPath);

                    Log.Information($"Files in directory: {directoryPath}");
                    foreach (string file in files)
                    {
                        Log.Information($"- {file}"); // Or Path.GetFileName(file) for just the filename
                    }

                    // Get all subdirectories in the directory
                    string[] subdirectories = Directory.GetDirectories(directoryPath);

                    Log.Information($"\nSubdirectories in directory: {directoryPath}");
                    foreach (string subdirectory in subdirectories)
                    {
                        Log.Information($"- {subdirectory}"); // Or Path.GetFileName(subdirectory)
                                                              // If you want to recursively list contents of subdirectories:
                        ListFilesInDirectory(subdirectory); // Uncomment to recurse
                    }
                }
                else
                {
                    Log.Information($"directory not found: {directoryPath}");
                }
            }
            catch (DirectoryNotFoundException)
            {
                Log.Information($"Error: Directory not found: {directoryPath}");
            }
            catch (UnauthorizedAccessException)
            {
                Log.Information($"Error: Unauthorized access to directory: {directoryPath}");
            }
            catch (Exception ex)
            {
                Log.Information($"An error occurred: {ex.Message}");
            }
        }
    }
}
