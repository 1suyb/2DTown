using UnityEngine;

public class GameScene : BaseScene
{
	private void Awake()
	{
		Player player = Managers.GameManager.Player;
		player.gameObject.SetActive(true);
		player.Bind(); player.Init();

		GameObject camera = Managers.Resource.Instantiate("GameCamera");
		camera.GetOrAddComponent<CameraController>().SetPlayer(player);

		Managers.UI.OpenSceneUI("GameScene");
		Managers.UI.OpenSceneUI("Timer");

		foreach(string id in Managers.Data.NPCDB.Keys)
		{
			GameObject npc = Managers.Spawner.NPCSpawn(id);
			Managers.GameManager.Attendance(npc.GetComponent<NPC>());
		}

	}
}