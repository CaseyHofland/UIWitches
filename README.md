# UI Witches
> Cast a 💫spell on your UI!

Easily separate UI code into their own scripts (spells) and select them with a generalized component (witch). This package will make your UI manipulation code reusable and make it easy for designers to experiment with and add logic to their UI.

## Installing

You can install this package via Unity's package manager. Simply copy the repository and paste it under "add git package".

The package assumes you have Unity UI installed. If you don't have Unity UI installed, the package won't compile as a safeguard.
UI Witches also has Text Mesh Pro support where the same safeguard applies, though Text Mesh Pro is optional.

## Developing

Once the package is installed, starting with UI Witches is as easy as flying a broom!
1. Create a Toggle and add a Toggle Witch component to it.
2. Create a new script like this:
```csharp
using System;
using UIWitches;

[Serializable]
public class MyToggleSpell : IToggleSpell {}
```
3. Implement the interface. This will provide you with functions to manipulate the UI. For now, let's return to the editor.
4. The Toggle Witch can now select the MyToggleSpell spell.

And that's it! You've learned how to write spells: you're a true witch.

> Note that if you want to write spells for Text Mesh Pro Dropdowns and InputFields you must inherit for example ITMP_DropdownSpell, NOT IDropdownSpell (or you can just inherit both).

## Features

* Separate UI code into reuseable scritps.
* Text Mesh Pro support.

## Contributing

If you'd like to contribute, please fork the repository and use a feature branch. Use the same styling as Unity, meaning:
* Use camelCase for fields and properties.
* Use the [C# General Naming Conventions](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions) for everything else.
* When extending Text Mesh Pro, try to follow their naming conventions as close as possible, even though they break every rule in the aformentioned Naming Conventions. For example, write `public TMP_Dropdown tmp_Dropdown; // Normally wrong`, instead of `public TMP_Dropdown tmpDropdown; // Normally right`.

## Links

- Repository: https://github.com/Casey-Hofland/UIWitches
- Issue Tracker: https://github.com/Casey-Hofland/UIWitches/issues
- Documentation: https://github.com/Casey-Hofland/UIWitches/wiki

## Licensing

The code in this project is licensed under the MIT license.
