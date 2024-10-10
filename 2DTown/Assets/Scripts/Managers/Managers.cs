using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
	private const string _gameObjectName = "@Managers";
	private static Managers _instacne;
	public static Managers Instacne {  get { Init(); return _instacne; } }

	private GameManager _gameManager = new GameManager();

	public static GameManager GameManager { get { return Instacne._gameManager; } }

	#region Managers 
	private SceneManagerW _scene = new SceneManagerW();
	private UIManager _ui = new UIManager();
	private ResourceManager _resource = new ResourceManager();
	#endregion

	#region Managers Property
	public static SceneManagerW Scene { get { return Instacne._scene; } }
	public static UIManager UI { get { return Instacne._ui; } }
	public static ResourceManager Resource { get { return Instacne._resource; } }
	#endregion

	private static void Init()
	{
		if (_instacne == null)
		{
			GameObject gm = GameObject.Find(_gameObjectName);
			if(gm == null)
			{
				gm = new GameObject(_gameObjectName);
				GameObject.DontDestroyOnLoad(gm);
			}
				
			_instacne = gm.GetOrAddComponent<Managers>();

			_instacne._ui.Init();
		}
		
	}
}
