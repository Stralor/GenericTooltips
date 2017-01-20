using UnityEngine;
using System.Collections;

public static class Utility
{

	public static T GetRandomEnum<T>()
	{
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
		return V;
	}

}
