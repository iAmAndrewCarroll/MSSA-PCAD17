using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MSSA_Project.Utility;

namespace MSSA_Project.Utility
{
    public static class PerformanceStorage
    {
        private static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "performanceLog.json");

        public static string GetFilePath() => FilePath;

        public static async Task SaveAsync(Dictionary<string, CardPerformance> data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                await File.WriteAllTextAsync(FilePath, json);
                DebugLogger.Log("Performance log saved.");
            }
            catch (Exception ex)
            {
                DebugLogger.Log($"Error saving performance log: {ex.Message}");
            }
        }

        public static async Task<Dictionary<string, CardPerformance>> LoadAsync()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    DebugLogger.Log("No performance log found. Starting fresh.");
                    return new Dictionary<string, CardPerformance>();
                }

                var json = await File.ReadAllTextAsync(FilePath);
                var data = JsonSerializer.Deserialize<Dictionary<string, CardPerformance>>(json);
                DebugLogger.Log("Performance log loaded.");
                return data ?? new Dictionary<string, CardPerformance>();
            }
            catch (Exception ex)
            {
                DebugLogger.Log($"Error loading performance log: {ex.Message}");
                return new Dictionary<string, CardPerformance>();
            }
        }
    }
}
