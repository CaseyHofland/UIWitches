# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.1.0-pre] - 2021-05-15
### Added
- UI Witch components. Every component inheriting from Selectable now have a Witch (e.g. Dropdown Witch). A witch can select a spell to cast on your UI.
- UI Spell interfaces. If a class is serializable and inherits from an IUISpell (e.g. IDropdownSpell) that class becomes a spell for the Dropdown Witch to select. The spell manipulates the UI.
- Text Mesh Pro integration.
- Icons for light & dark mode.
