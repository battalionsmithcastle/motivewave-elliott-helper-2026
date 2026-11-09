using System;
using System.IO;
using System.Text.Json;

namespace GoChartingPresets
{
    /// <summary>
    /// Application settings for GoCharting Footprint Presets.
    /// </summary>
    public class Settings
    {
        public string PresetFolderPath { get; set; } = string.Empty;
        public int RetentionCount { get; set; } = 5;

        private static readonly string StoragePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "settings.json");

        /// <summary>
        /// Loads settings from local JSON storage.
        /// </summary>
        public static Settings Load()
        {
            var settings = new Settings();
            try
            {
                if (!File.Exists(StoragePath))
                    return settings;

                var json = File.ReadAllText(StoragePath);
                using var document = JsonDocument.Parse(json);
                var root = document.RootElement;
                if (root.ValueKind == JsonValueKind.Object)
                {
                    if (root.TryGetProperty("presetFolderPath", out var folder) && folder.ValueKind == JsonValueKind.String)
                        settings.PresetFolderPath = folder.GetString() ?? string.Empty;

                    if (root.TryGetProperty("retentionCount", out var retention) && retention.ValueKind == JsonValueKind.Number)
                        settings.RetentionCount = retention.GetInt32();
                }
            }
            catch
            {
                // Return default settings on failure.
            }

            return settings;
        }

        /// <summary>
        /// Saves settings to local JSON storage.
        /// </summary>
        public void Save()
        {
            try
            {
                var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                var dir = Path.GetDirectoryName(StoragePath);
                if (!string.IsNullOrEmpty(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllText(StoragePath, json);
            }
            catch
            {
                // Ignore save failures.
            }
        }
    }
}
