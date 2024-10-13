using UnityEngine;

public class SpawnManager
{
	private string _npcsObjectName = "@NPCs";
	private GameObject _npcs;
	public GameObject NPCSpawn(string id)
	{
		if(_npcs == null)
		{
			CreateNPCParent();
		}
		GameObject npc = Managers.Resource.Instantiate("NPCBase",_npcs.transform);

		NPCData data = Managers.Data.NPCDB[id];
		GameObject spriteObject = Managers.Resource.Instantiate(data.SpritePrefabPath, npc.transform);
		spriteObject.transform.localPosition = Vector3.zero;
		npc.transform.position = data.position;

		NPC npcComponent = npc.GetOrAddComponent<NPC>();
		npcComponent.SetName(data.Name);
		npcComponent.Bind(); npcComponent.Init();

		return npc;
	}
	public void CreateNPCParent()
	{
		
		_npcs =GameObject.Find(_npcsObjectName);
		if(_npcs == null)
			_npcs = new GameObject(_npcsObjectName);
		_npcs.transform.position = Vector3.zero;
	}
}