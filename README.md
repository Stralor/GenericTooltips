#Pat Scott's Utility Scripts



A collection of C# scripts for use in Unity games and apps that you might find useful.

Let's go over the folders and their contents

###Convenience

Basically a bunch of shit I find super useful to reduce reinventing the wheel. My generics that I really should just put in a library.

**CoroutineUtil** has a couple of nice shorthand coroutines.

`DoAfter()` is great for basically everything. It's a shorthand Coroutine-based Invoke-alike (no reflection) that can call any action(s) after a number of seconds (realtime or sim) or after a give condition.

######Example: `Coroutine myCoroutine = StartCoroutine(CoroutineUtil.DoAfter(() => Foo(), () => myBoolCondition);` will execute Foo() after myBoolCondition is true, and saves this call as myCoroutine for easy reference later.

Around 5.4 or so, `WaitForRealSeconds()` became no longer necessary, as Unity now has `WaitForSecondsRealtime()`. It's still in the class for 4.x and 5.early projects.

**Utility** currently contains just `GetRandomEnum<T>()`. Straightforward: get a random value from a given enum type. I didn't write this one.

###Layout

Contains just **CenterGroup** which adjusts all the rigidbodies childed to the GameObject it's on so they're averaged around zero (`UpdateGroupPosition()`, which also returns a Vector2 so you can match other objects' children to it `MoveChildrenRigidbodies`). I use it to keep player-built objects around a unified center point in my camera. For use in 2D.

###Misc

These are maybe useful, but not quite **Convenience** level.

**ColorPalette** will require some variable customization based on your game's palette, but provides a reference to your game's colors that's easily accessible to scripts. More importantly, it has a couple static convenience methods:

`ColorToHex()` takes in a Color and spits out the hex string equivalent, in case you're scripting text with different colors, for example. Or use...

`ColorText()` takes in a color and a string and inserts the markdown to change that string's color. Break up the monotony of your game text!

**ToggleSetting** is used to make "on or off" PlayerPrefs (like, game settings) more accessible as buttons. Put it on a button, fill in the two fields in the inspector, and it does the rest.

######Requires ColorPalette's red4 and blue4 if used as is.

###Placements

Makes in-game mouse clicks pick objects up and put them down wherever they don't block each other, basically. _Lots_ more functionality and versatility here, though. This is all 2D stuff.

**Connection** informs another GameObject with a Placement on it (usually a sibling, while the parent actually moves) if this is a valid location. Combo with Collider2Ds to detect when you're in valid triggers (like lining up pieces in a puzzle or something).

**Placement** the key piece of the puzzle. Put it on GameObjects you want to be interactable with the mouse (ideally wherever the main sprite is). Changes the sprite colors based on validity of possible placements. Obviously, Collider2D and Rigidbody2d are necessary. Tons of options to play with on this.

######Calls to ColorPalette's colors. Change as you will.

**PlacementManager** receives events from individual Placements and then invokes all its various Actions and Funcs based on what the input was. Lets you combo all kinds of other calls in your code whenever objects get placed/ blocked/ picked up/ .... Aaaand that's about it, other than some audio calls you need to replace.

######Note: this class makes calls to a script I haven't yet included in this collection (AudioClipOrganizer). Please replace those lines with your own SFX calls.

**SnapBase** and its extensions are useful if you want objects to snap into place. Provided options are "grid" (world transform increments) or "nodes" (transforms).

######Note: you'll have to define a list of valid nodes and edit the code to reference it, if you include SnapToNodes in your assets.

###Tooltips

_Requires Unity 5.5+_

This folder contains an adaptable tooltip script (+pool and prefab).

######Please note: this has not been thoroughly tested since being adapted from my personal project. Let me know if you encounter any issues.

####Usage:

Put the **GenericTooltip** script on any GameObject you want to have a tooltip. Then fill in the details or write a script to automate the texts. Tooltip title is not required.

**GenericTooltipPool** just needs to be in the project. Set default delay and fade times directly in the class or from elsewhere in your project's code.

I've provided a template **Tooltip** prefab, as I created it for my game Destination Ares. If you make your own from scratch, be sure that it has an image and a text object. The prefab must be in your Resources folder and called "Tooltip".

###Workarounds

**AnimatorSupplements** lets you refer to Animator parameters in Inspector-based scripting (e.g., Button's `OnClick()` section). Put it on the GameObject with the Animator you want to influence.

**OnSelectPointerClear** alternates between keyboard/ gamepad and mouse UI hovers, so you don't have the double highlight glitch. It's a little attention to detail that will make the perfectionist in you weep for joy. Put it on all your UI Selectables that you want to have this behavior.

~ ~ ~

Happy developing! :)