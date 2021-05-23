# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.2.0-pre] - 2021-05-23

- The new and improved UI Witches do things completely different! Methods like GetValue and OnValueChanged where too limiting a restriction on the spells. If you would like to change the color of e.g. a health bar based on the amount of health, this was unviable with spells. For the solution, it was opted to give spells a suite of methods like OnEnable and LateUpdate with a parameter of the UIBehaviour. This way, the spell had full control over how to influence the UI. Since this new implementation is also generic, you can hook spells up to any UIBehaviour.
Also, the decision was made to use UIBehaviours instead of Selectables to allow for more elements to be used by witches (e.g. Text is now UI Witch compatible).

### Added
- UISpell<T> where T : UIBehaviour added. This can be inherited with the proper UIBehaviour, instead of the old method using interfaces.
- TextWitch for manipulating Text Elements.
- TMP_TextWitch for manipulating TMP_Text Elements.

### Removed
- All Spell interfaces.

### Changed
- UIWitch<> is now only expecting a UIBehaviour.

## [0.1.1-pre.2] - 2021-05-21
### Fixed
- Settings weren't correctly drawn in Unity 2021.1.

## [0.1.1-pre] - 2021-05-19
### Added
- OnClick callback for IButtonSpells.

### Changed
- Made Unity UI 1.0.0 a dependency of this package.
- Changed ValueChanged method of spells to OnValueChanged.
- Changed the Component Menu name of "Input Field Witch - TextMeshPro" to TextMeshPro - Input Field Witch" and "Dropdown Witch - TextMeshPro" to "Dropdown - TextMeshPro Witch". If this naming seems odd to you, take it up with the Text Mesh Pro team.

## [0.1.0-pre.2] - 2021-05-18
### Added
- IUISpellDrawer draws the spell without the redundant spell dropdown, for a smoother editor experience.
- Spells in a UI Witches spell picker now have spaces before every capital letter. e.g. FloatSettingSpell will now be displayed as Float Setting Spell.
- xml Documentation for witches and spells.
- Package links for the documentation, changelog and license.

### Changed
- Significantly improved the README in accordance with best practices and provided useful information and a clear getting started section.
- Changed the package description based on the README text.

## [0.1.0-pre] - 2021-05-15
### Added
- UI Witch components. Every component inheriting from Selectable now have a Witch (e.g. Dropdown Witch). A witch can select a spell to cast on your UI.
- UI Spell interfaces. If a class is serializable and inherits from an IUISpell (e.g. IDropdownSpell) that class becomes a spell for the Dropdown Witch to select. The spell manipulates the UI.
- Text Mesh Pro integration.
- Icons for light & dark mode.
