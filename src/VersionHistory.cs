using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GoChartingPresets
{
    /// <summary>
    /// Represents a version history entry.
    /// </summary>
    public class VersionEntry
    {
        public string PresetName { get; set; } = string.Empty;
        public int Version { get; set; }
        public DateTime TimestampUtc { get; set; }
        public string ConfigJson { get; set; } = string.Empty;
    }

    /// <summary>
    /// Manages version history for presets.
    /// </summary>
    public class VersionHistory
    {
        private readonly string _historyPath;
        private readonly string _presetsFolder;
        public int RetentionCount { get; set; } = 5;

        public VersionHistory(string? historyPath = null, string? presetsFolder = null)
        {
            _historyPath = historyPath ?? Path.Combine(Directory.GetCurrentDirectory(), "data", "version_history.json");
            _presetsFolder = presetsFolder ?? Path.Combine(Directory.GetCurrentDirectory(), "data", "presets");
        }

        /// <summary>
        /// Returns the latest versions of a preset, newest first, limited by retention.
        /// </summary>
        public List<VersionEntry> GetVersions(string presetName)
        {
            var versions = new List<VersionEntry>();
            if (!File.Exists(_historyPath))
                return versions;

            var json = File.ReadAllText(_historyPath);
            var entries = JsonSerializer.Deserialize<List<VersionEntry>>(json) ?? new List<VersionEntry>();

            return entries
                .Where(entry => entry.PresetName == presetName)
                .OrderByDescending(entry => entry.TimestampUtc)
                .Take(RetentionCount)
                .ToList();
        }

        /// <summary>
        /// Records a version entry for a preset.
        /// </summary>
        public void Record(string presetName, string configJson)
        {
            var history = new List<VersionEntry>();
            if (File.Exists(_historyPath))
            {
                var json = File.ReadAllText(_historyPath);
                history = JsonSerializer.Deserialize<List<VersionEntry>>(json) ?? new List<VersionEntry>();
            }

            var version = history.Count == 0 ? 1 : history.Max(entry => entry.Version) + 1;
            history.Add(new VersionEntry { PresetName = presetName, Version = version, TimestampUtc = DateTime.UtcNow, ConfigJson = configJson });

            var trimmed = history
                .OrderByDescending(entry => entry.TimestampUtc)
                .Take(RetentionCount)
                .ToList();

            var json = JsonSerializer.Serialize(trimmed, new JsonSerializerOptions { WriteIndented = true });
            var dir = Path.GetDirectoryName(_historyPath);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllText(_historyPath, json);
        }

        /// <summary>
        /// Restores a preset to the selected version.
        /// </summary>
        public VersionEntry RestoreVersion(string presetName, int versionIndex)
        {
            var versions = GetVersions(presetName);
            if (versionIndex < 0 || versionIndex >= versions.Count)
                return null;

            var target = versions[versionIndex];
            var path = Path.Combine(_presetsFolder, presetName + ".json");
            if (!string.IsNullOrEmpty(target.ConfigJson))
                File.WriteAllText(path, target.ConfigJson);

            return target;
        }

        /// <summary>
        /// Compares two versions of a preset and returns a diff summary.
        /// </summary>
        public string CompareVersions(string presetName, int version1, int version2)
        {
            var json1 = LoadVersionConfig(presetName, version1);
            var json2 = LoadVersionConfig(presetName, version2);

            if (json1 == null && json2 == null)
                return "No versions found for preset.";

            if (json1 == null || json2 == null)
                return "One of the versions was not found.";

            if (json1 == json2)
                return "Versions are identical.";

            return "Versions differ in their stored configuration.";
        }

        private string LoadVersionConfig(string presetName, int version)
        {
            var versions = GetVersions(presetName);
            var target = versions.FirstOrDefault(entry => entry.Version == version);
            return target?.ConfigJson;
        }
    }
}
