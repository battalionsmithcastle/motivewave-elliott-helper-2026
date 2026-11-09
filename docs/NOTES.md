# Developer Notes

## Overview

GoCharting Footprint Presets is a local preset manager for the GoCharting orderflow trading platform. It stores JSON configuration files for market profiles and does not modify the platform. It is strictly read-only with respect to trading execution.

## Configuration Storage

The manager keeps preset files in a local folder. Each preset stores market data such as BTC, ETH, SOL, ES, NQ.

## Applying Presets

The apply action writes a selected preset configuration for the user. Because GoCharting is a web platform, live application is not possible from a local process.

## Updating the Data

If GoCharting changes its configuration format, update the parsing logic in the PresetManager and the model classes.

## Known Limitations

- GoCharting is a web platform, so live application is not possible.
- Accuracy depends on the quality of stored configurations.
