# UI Witches
> Cast a 💫spell on your UI!

Easily separate UI code into their own scripts (spells) and select them with a generalized component (witch). This package will make your UI manipulation code reusable and make it easy for designers to experiment with and add logic to their UI.

## Installation

Follow the instructions in the [Unity Manual](https://docs.unity3d.com/Manual/upm-ui-giturl.html).

UI Witches is using [Unity UI 1.0.0](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/index.html).

UI Witches also has optional [Text Mesh Pro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0/manual/index.html) support.

## Developing

Once the package is installed, starting with UI Witches is as easy as flying a broom!
1. Create a Toggle and add a Toggle Witch component to it.
2. Create a new script like this:
```csharp
using System;
using UIWitches;
using UnityEngine.UI;

[Serializable]
public class MyToggleSpell : IToggleSpell {}
```
3. Implement the interface. This will provide you with functions to manipulate the UI. For now, let's return to the editor.
4. The Toggle Witch can now select the MyToggleSpell spell.

Awesome! Of course, this doesn't work yet, since we still need to fill out those interface functions. Let's go 1 by 1.

5. The GetValue method couples a value back to the UI. Basically, whatever we return here, the UI will show. For example:
```csharp
public float f;
public bool GetValue()
{
    return f > 0;
}
// Our spell now has a value f. If we set it to more than 0, we can see our toggle turn on, and off again when we set our value to 0 or lower.
```

6. ValueChanged is the other way around: this couples a change in our UI back to our value. For example:
```csharp
public void ValueChanged(bool isOn)
{
    f = isOn ? 1 : 0;
}
// If we press play and click our toggle, we can see f change to 0 and 1 for off and on respectively.
```

7. ResetUI lets you instantly apply modifications to the UI. This is called when the Reset UI button is pressed in the bottom of a UI Witch. For example:
```csharp
public void ResetUI(Toggle toggle)
{
    toggle.toggleTransition = Toggle.ToggleTransition.None;
}
// If we click our Reset UI button, we can see that it will set the Toggle Transition on our Toggle to None.
```

And that's it! You've learned how to write spells: you're a true witch.

> Note that if you want to write spells for Text Mesh Pro Dropdowns and InputFields you must inherit for example ITMP_DropdownSpell, NOT IDropdownSpell (or you can just inherit both).

## Features

Briefly, this is why you need UI Witches:
* Separate UI code into reuseable scripts.
* Text Mesh Pro support.

## Contributing

If you'd like to contribute, please fork the repository and use a feature branch. For styling:
* Use the [C# General Naming Conventions](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions).
* Use camelCase for properties, like Unity does.
* Follow established naming conventions as close as possible, even if these break the aformentioned rules. For example: write `public TMP_Dropdown tmp_Dropdown; // Normally wrong` instead of `public TMP_Dropdown tmpDropdown; // Normally right`. This rule will likely only come up if you are extending something for Text Mesh Pro.

## Links

- Repository: https://github.com/Casey-Hofland/UIWitches
- Issue Tracker: https://github.com/Casey-Hofland/UIWitches/issues
- Documentation: https://github.com/Casey-Hofland/UIWitches/wiki
- Changelog: https://github.com/Casey-Hofland/UIWitches/blob/master/CHANGELOG.md

In case of business inquiries or partnerships, you may contact me at hofland.casey@gmail.com.

## Licensing

The code in this project is licensed under the MIT license.
