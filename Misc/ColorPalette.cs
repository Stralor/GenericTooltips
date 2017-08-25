using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorPalette : MonoBehaviour
{

	/**Singleton-like reference to the ColorPalette component.
	 */
	public static ColorPalette cp;

	public List<ColorProfile> colorList = new List<ColorProfile> ();

	/**Searches 'distance' values for a matching color. If 'searchDown', will use 'colorValue' as the starting maximum value, else will use 'colorValue' as the starting minimum value.
	 * Use that to search for nearest light or dark value, respectively.
	 * Returns white if any color not found in chroma channel
	 */
	public static Color GetColor(ColorProfile.Chroma channel, int colorValue, int distance = 10, bool searchDown = true)
	{
		//Result
		ColorProfile color = null;

		//Only relevant colors
		var channelColors = cp.colorList.FindAll (obj => obj != null && obj.channel == channel);

		//Find
		for (int i = 0; i < distance; i++)
		{
			//The value we want from the ColorProfile
			int valueToMatch = searchDown ? colorValue - i : colorValue + i;

			//Try to match
			color = channelColors.Find (obj => obj.value == valueToMatch);

			//Match?
			if (color != null)
				break;
		}

		//Return result
		if (color != null)
			return color.color;
		else
			return Color.white;
	}

	public static string ColorToHex(Color32 color)
	{
		string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		return hex;
	}

	public static string ColorText(Color32 color, string text)
	{
		return "<color=#" + ColorToHex(color) + ">" + text + "</color>";
	}

	void Awake()
	{
		//Set the CP
		if (cp == null)
		{
			cp = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (cp != this)
		{
			Destroy(gameObject);
		}
	}

}
