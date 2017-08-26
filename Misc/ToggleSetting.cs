using UnityEngine;
using System.Collections;

//Note: this has a dependency on ColorPalette's red4 and blue4

public class ToggleSetting : MonoBehaviour
{
	public string settingToToggle;
	public string displayName;

	/**Toggle the PlayerPref. Also calls a method to change the button text.
	 */
	public void Toggle()
	{
		//Current value
		var value = PlayerPrefs.GetInt(settingToToggle);

		//Change
		if (value == 0)
			PlayerPrefs.SetInt(settingToToggle, 1);
		else
			PlayerPrefs.SetInt(settingToToggle, 0);

		//Text
		SetText();
	}

	/**Set the button text.
	 */
	void SetText()
	{
		//Current value
		var value = PlayerPrefs.GetInt(settingToToggle);

		//Explicit text
		if (value == 1)
			GetComponentInChildren<UnityEngine.UI.Text>().text = displayName + ": " + ColorPalette.ColorText(ColorPalette.GetColor(ColorProfile.Chroma.Blue, 10), "On");
		else
			GetComponentInChildren<UnityEngine.UI.Text>().text = displayName + ": " + ColorPalette.ColorText(ColorPalette.GetColor(ColorProfile.Chroma.Red, 10), "Off");

	}

	void Start()
	{
		//Make sure we're up to date
		SetText();
	}
}
