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
	}
}