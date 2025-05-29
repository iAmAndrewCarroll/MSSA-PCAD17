using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MSSA_Project.Utility
{
    public static class JsonLoader
    {
        public static async Task<T?> LoadJsonAsync<T>(string filename)
        {
            try
            {
                using Stream stream = await FileSystem.OpenAppPackageFileAsync(filename);
                using StreamReader reader = new StreamReader(stream);
                string json = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<T>(json);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading {filename}: {ex.Message}");
                return default;
            }

            Console.WriteLine($"[JsonLoader] Attempting to open: {filename}");
        }
    }
}
