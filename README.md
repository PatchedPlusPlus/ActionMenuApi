

[![MIT License][license-shield]][license-url]
<!--
![Downloads][downloads-shield] -->


<br />
<p align="center">

  <h3 align="center">ActionMenuApi</h3>

  <p align="center">
    <br />
    <a href="https://github.com/gompocp/ActionMenuApi/issues">Request Feature</a>
  </p>




<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
      <a href="#info">Info</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#building">Building</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>




## Info
<a href="https://github.com/gompocp/ActionMenuApi">
    <img src="Assets/preview.gif" alt="Preview" width="700" height="400">
</a> 

This mod doesn't do anything on it's own.

It provides an easy way for modders to add integration with the action menu.

It supports the use of the

* Radial Puppet
* Four Axis Puppet
* Button
* Toggle Button
* Sub Menus

Additionally allows mods to add their menus to a dedicated section on the action menu to prevent clutter.

## Getting Started

To use simply add ActionMenuApi to your mods folder and reference it in your project same way as with UIX

### Building 

1. Clone the repo
   ```sh
   git clone https://github.com/gompocp/ActionMenuApi.git
   ```
2. Copy the .dlls from your MelonLoader\Managed folder to the Libs folder
3. Build Solution


## Usage

```cs
using ActionMenuApi.Api;
using ActionMenuApi.Pedals;
/*

Code

*/

//Call in OnApplicationStart()
//To add a button to the main page of the action menu
//                          Page to add to          Action for onClick                    Text       Texture     locked     
VRCActionMenuPage.AddButton(ActionMenuPage.Main, () => MelonLogger.Msg("Pressed Button") , "Button", buttonIcon, true);

//To add a toggle to the main page of the action menu
VRCActionMenuPage.AddToggle(ActionMenuPage.Main, testBool, b => testBool = b, "Toggle", toggleIcon);

//To add a radial pedal to the main page of the action menu
VRCActionMenuPage.AddRadialPuppet(ActionMenuPageType.Main, f => testFloatValue = f, "Radial", testFloatValue, radialIcon);

//To add a submenu to the main page of the action menu and add a toggle and button to it
VRCActionMenuPage.AddSubMenu(ActionMenuPageType.Main, 
    delegate {
        MelonLogger.Msg("Sub Menu Opened");
        AMAPI.AddButtonPedalToSubMenu(() => MelonLogger.Msg("Pressed Button In Sub Menu"), "Sub Menu Button", buttonIcon);
        AMAPI.AddTogglePedalToSubMenu(b => testBool2 = b, testBool2, "Sub Menu Toggle", toggleIcon);
    },
    "Sub Menu", 
    subMenuIcon
);
```

When you lock/update a pedal in anyway, you must call either `AMUtils.ResetMenu()` or `AMUtils.RefreshMenu()` so that these changes will be visible. If you are after locking a submenu its advised that you call `AMUtils.ResetMenu()` so that in case the user is already in the submenu it'll pushed them out of it. If you are just locking a button pedal or something, you can just call `AMUtils.RefreshMenu()` to rebuild the current action menu submenu. 

> NOTE FOR PEOPLE USING THE LOCKING FUNCTIONALITY FOR RISKY FUNCTIONS: It is advised that in the case that my reflection to reset/refresh the action menu fails you have a boolean check in the pedal trigger event so that the action can't run anyway if it fails


_For a mod example check out the test mod [here](https://github.com/gompocp/ActionMenuApi/tree/main/ActionMenuTestMod)_



## License

Distributed under the GPL-3.0 License. See `LICENSE` for more information.



Project Link: [https://github.com/gompocp/ActionMenuApi](https://github.com/gompocp/ActionMenuApi)


## Acknowledgements

* XRef method from [BenjaminZehowlt](https://github.com/BenjaminZehowlt/DynamicBonesSafety/blob/master/DynamicBonesSafetyMod.cs)
* [Knah](https://github.com/knah/VRCMods/) assetbundle loading example and his solution structure


[license-shield]: https://img.shields.io/github/license/gompocp/ActionMenuApi.svg?style=for-the-badge
[license-url]: https://github.com/gompocp/ActionMenuApi/blob/main/LICENSE
[downloads-shield]: https://img.shields.io/github/downloads/gompocp/ActionMenuApi/total?style=for-the-badge
