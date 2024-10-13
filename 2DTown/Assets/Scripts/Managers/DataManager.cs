using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManger
{
	public Dictionary<string, NPCData> NPCDB { get; private set; }

	public void Init()
	{
		NPCDB = LoadData<NPCDataLoader>("Data/NPCDATA").Load();

	}

	public T LoadData<T>(string path)
	{
		string textData = Managers.Resource.Load<TextAsset>(path).text;
		return JsonUtility.FromJson<T>(textData);
	}
}