using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GoChartingPresets
{
    /// <summary>
    /// Main window for GoCharting Footprint Presets.
    /// Shows saved presets with apply and export actions plus settings.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PresetManager _presetManager;
        private readonly VersionHistory _versionHistory;
        private readonly Settings _settings;

        private string _activeConfigJson = string.Empty;

        public MainWindow()
        {
            _settings = Settings.Load();
            _presetManager = new PresetManager(_settings.PresetFolderPath);
            _versionHistory = new VersionHistory(null, _settings.PresetFolderPath);

            InitializeComponent();
            RefreshPresets();
            UpdateStatus("Ready");
        }

        private void BtnApplyPreset_Click(object sender, RoutedEventArgs e)
        {
            if (lstPresets.SelectedItem is not FootprintPreset selected) { UpdateStatus("Select a preset"); return; }

            var configJson = _presetManager.LoadPreset(selected.Name);
            _activeConfigJson = configJson;

            var appliedFolder = Path.Combine(Directory.GetCurrentDirectory(), "data", "applied");
            if (!Directory.Exists(appliedFolder)) Directory.CreateDirectory(appliedFolder);
            File.WriteAllText(Path.Combine(appliedFolder, selected.Name + ".json"), configJson);

            UpdateStatus("Preset applied");
        }

        private void BtnExportPreset_Click(object sender, RoutedEventArgs e)
        {
            if (lstPresets.SelectedItem is not FootprintPreset selected) { UpdateStatus("Select a preset"); return; }

            var configJson = _presetManager.LoadPreset(selected.Name);
            var exportFolder = Path.Combine(Directory.GetCurrentDirectory(), "data", "exports");
            if (!Directory.Exists(exportFolder)) Directory.CreateDirectory(exportFolder);
            File.WriteAllText(Path.Combine(exportFolder, selected.Name + ".json"), configJson);

            UpdateStatus("Preset exported");
        }

        private void BtnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            _settings.PresetFolderPath = txtPresetFolder.Text.Trim();
            if (int.TryParse(txtRetention.Text, out var retention))
                _settings.RetentionCount = retention;

            _settings.Save();
            _presetManager = new PresetManager(_settings.PresetFolderPath);
            _versionHistory = new VersionHistory(null, _settings.PresetFolderPath);
            RefreshPresets();
            UpdateStatus("Settings saved");
        }

        private void RefreshPresets()
        {
            lstPresets.ItemsSource = _presetManager.GetPresets();
        }

        private void UpdateStatus(string message)
        {
            txtStatus.Text = message;
        }
    }
}
