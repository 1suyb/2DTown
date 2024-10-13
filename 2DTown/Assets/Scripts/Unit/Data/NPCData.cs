using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<key,value> 
{
	public Dictionary<key, value> Load();
}

[Serializable]
public class NPCData
{
	public string ID;
	public string Name;
	public string SpritePrefabPath;
	public Vector2 position;
}

[Serializable]
public class NPCDataLoader : ILoader<string,NPCData>
{
	public List<NPCData> list = new List<NPCData>();
	public Dictionary<string,NPCData> Load()
	{
		Dictionary<string,NPCData> data = new Dictionary<string,NPCData>();	
		foreach(NPCData npcData in list)
		{
			data.Add(npcData.ID, npcData);
		}
		return data;
	}
}

