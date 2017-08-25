using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColorProfile {

	/**Use whichever channel(s) make sense for your project.
	 */
	public enum Chroma
	{
		BW,
		Red,
		Orange,
		Yellow,
		Green,
		Blue,
		Purple,
		Brown,
		Neutral,
		Alt0,
		Alt1,
		Alt2,
		Alt3,
		Alt4,
		Alt5,
		Alt6,
		Alt7,
		Alt8,
		Alt9
	}

    [SerializeField]
    public Color color;

    [SerializeField]
    [Tooltip("Use whichever channel(s) make sense for your project.")]
	public Chroma channel;

    /**0 is base color. Lower numbers are darker, higher numbers are lighter (Can go negative).
	 */
    [SerializeField]
    public int value;


	/*
	 * Custom Operators
	 */

	public static bool operator >(ColorProfile a, ColorProfile b)
	{
		return a.value > b.value;
	}

	public static bool operator <(ColorProfile a, ColorProfile b)
	{
		return a.value < b.value;
	}

	public static bool operator >=(ColorProfile a, ColorProfile b)
	{
		return a.value >= b.value;
	}

	public static bool operator <=(ColorProfile a, ColorProfile b)
	{
		return a.value <= b.value;
	}

	public static bool operator ==(ColorProfile a, ColorProfile b)
	{
        if(System.Object.ReferenceEquals(a, b)) {
            return true;
        }

        // If one is null, but not both, return false.
        if(((object)a == null) || ((object)b == null)) {
            return false;
        }

        return a.value == b.value && a.channel == b.channel;
	}

	public static bool operator !=(ColorProfile a, ColorProfile b)
	{
        return !(a == b);
	}

	public override bool Equals(System.Object obj)
	{
		if (obj == null)
			return false;

		ColorProfile ColorProfile = obj as ColorProfile;
		if ((System.Object)ColorProfile == null)
			return false;

		return ColorProfile.value == value;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode() ^ value;
	}
}
