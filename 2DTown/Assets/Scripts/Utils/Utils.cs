using System;
using System.Text.RegularExpressions;
using UnityEngine;

public static class Utils
{
	public static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
	{
		T compoent;
		if(gameObject.TryGetComponent<T>(out compoent))
		{
			return compoent;
		}
		return gameObject.AddComponent<T>();
	}
	public static bool IsContainsSpecialCharacters(string str)
	{
		string pattern = @"[^a-zA-Z0-9가-힣]";
		return Regex.IsMatch(str, pattern);
	}
	public static bool IsAvailableName(string str)
	{
		return !IsContainsSpecialCharacters(str) && (str.Length>0);
	}
	public static string GenderToString(Defines.Gender gender) 
	{ 
		return gender == Defines.Gender.Female ? "f" : "m";
	}
}