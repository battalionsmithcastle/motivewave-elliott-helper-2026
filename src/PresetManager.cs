using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GoChartingPresets
{
    /// <summary>
    /// Manages footprint and profile presets stored as JSON files.
    /// </summary>
    public class PresetManager
    {
        private readonly string _presetsFolder;

        public PresetManager(string? presetsFolder = null)
        {
            _presetsFolder = presetsFolder ?? Path.Combine(Directory.GetCurrentDirectory(), "data", "presets");
        }

        /// <summary>
        /// Returns the saved presets from the preset folder.
        /// </summary>
        public List<FootprintPreset> GetPresets()
        {
            var presets = new List<FootprintPreset>();
            if (!Directory.Exists(_presetsFolder))
                return presets;

            foreach (var file in Directory.GetFiles(_presetsFolder, "*.json"))
            {
                var preset = new FootprintPreset
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    Market = "BTC",
                    Type = "Footprint",
                    DateModified = File.GetLastWriteTimeUtc(file),
                    Version = 1
                };

                try
                {
                    var json = File.ReadAllText(file);
                    using var document = JsonDocument.Parse(json);
                    preset.Market = "BTC";
                    preset.CandleType = "Time";
                    preset.Columns = new List<string>();
                    preset.ImbalanceThreshold = 0;
                    preset.IgnoreZeroes = false;
                }
                catch
                {
                    // Invalid JSON preset is skipped.
                }

                presets.Add(preset);
            }

            presets.Sort((a, b) => b.DateModified.CompareTo(a.DateModified));
            return presets;
        }

        /// <summary>
        /// Saves a preset with the provided JSON configuration.
        /// </summary>
        public void SavePreset(string name, string configJson)
        {
            if (!Directory.Exists(_presetsFolder))
                Directory.CreateDirectory(_presetsFolder);

            var destination = Path.Combine(_presetsFolder, name + ".json");
            File.WriteAllText(destination, configJson);
        }

        /// <summary>
        /// Loads a preset JSON by name.
        /// </summary>
        public string LoadPreset(string name)
        {
            var path = Path.Combine(_presetsFolder, name + ".json");
            if (!File.Exists(path))
                throw new FileNotFoundException("Preset not found: " + name);

            return File.ReadAllText(path);
        }

        /// <summary>
        /// Deletes a preset by name.
        /// </summary>
        public void DeletePreset(string name)
        {
            var path = Path.Combine(_presetsFolder, name + ".json");
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
