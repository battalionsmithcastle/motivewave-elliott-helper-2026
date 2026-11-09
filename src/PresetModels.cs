using System;
using System.Collections.Generic;

namespace GoChartingPresets
{
    /// <summary>
    /// Represents a footprint preset for a single market.
    /// </summary>
    public class FootprintPreset
    {
        public string Name { get; set; } = string.Empty;
        public string Market { get; set; } = string.Empty;
        public string CandleType { get; set; } = string.Empty;
        public List<string> Columns { get; set; } = new List<string>();
        public double ImbalanceThreshold { get; set; }
        public bool IgnoreZeroes { get; set; }

        public string Type { get; set; } = "Footprint";
        public DateTime DateModified { get; set; }
        public int Version { get; set; }
    }

    /// <summary>
    /// Represents a profile preset for a single market.
    /// </summary>
    public class ProfilePreset
    {
        public string Name { get; set; } = string.Empty;
        public string Market { get; set; } = string.Empty;
        public string SessionSplit { get; set; } = string.Empty;
        public double ValueArea { get; set; }
        public List<string> ExtendedLevels { get; set; } = new List<string>();
    }
}
