# UI Witches
> Cast a 💫spell on your UI!

Easily separate UI code into their own scripts (spells) and select them with a generalized component (witch). This package will make your UI manipulation code reusable and make it easy for designers to experiment with and add logic to their UI.

Check the [Wiki](https://github.com/Casey-Hofland/UIWitches/wiki) for the documentation.

## Installation

Follow the [Installing from a Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html) instructions in the Unity Manual.

### Dependencies

* UI Witches is using [Unity UI 1.0.0](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/index.html).
* UI Witches has optional [Text Mesh Pro >= 1.0.0](https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0/manual/index.html) support.

## Developing

Once the package is installed, starting with UI Witches is as easy as flying a broom!
1. Create a new script:
```csharp
[Serializable] // Don’t forget this!
public class MyToggleSpell : IToggleSpell 
{
    // Returns the value for the UI to display. This is called every LateUpdate by the UI Witch.
    public bool GetValue() => default;
    
    // When the toggle is changed via e.g. user input, this method is called containing the new value.
    public void OnValueChanged(bool isOn) {}
    
    // This is a convenience method for instantly resetting the UI.
    public void ResetUI(Toggle toggle) {}
}
```
2. Create a Toggle and add a Toggle Witch Component to it.
3. Select My Toggle Spell in the Toggle Witch.

And that's it! You've learned how to write spells: you're a true witch!

But why use spells? Well, they enable you to write reusable UI scripts, not only for your game, but across projects, especially when working with ScriptableObjects. Take this script for example:
```csharp
[Serializable]
public class AudioParameterSpell : ISliderSpell
{
    public AudioMixer audioMixer;
    public string parameterName;
    public float valueMargin = 80;

    public float GetValue()
    {
        audioMixer.GetFloat(parameterName, out float value);
        return value + valueMargin;
    }

    public void OnValueChanged(float sliderValue)
    {
        audioMixer.SetFloat(parameterName, sliderValue - valueMargin);
    }

    public void ResetUI(Slider slider)
    {
        slider.minValue = -80 + valueMargin;
        slider.maxValue = 20 + valueMargin;
    }
}
```

This can set any parameter on any audio mixer and would be great for a slider that sets the music volume as well as one that sets the effects volume.

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
