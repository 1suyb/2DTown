using UnityEngine;

public class GameScene : BaseScene
{
	private void Awake()
	{
		GameObject camera = Managers.Resource.Instantiate("GameCamera");
		camera.GetOrAddComponent<CameraController>().SetPlayer(Managers.GameManager.Player);
		Managers.GameManager.Player.Init();

		Managers.UI.OpenSceneUI("GameScene");
		Managers.UI.OpenSceneUI("Timer");
	}
}