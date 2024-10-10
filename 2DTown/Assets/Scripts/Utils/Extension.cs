using UnityEngine;

public static class Extension
{
	public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
	{
		return Utils.GetOrAddComponent<T>(gameObject);
	}
}