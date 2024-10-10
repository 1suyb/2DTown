using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerW
{
	public BaseScene CurrentScene { get; private set; }
	public void LoadScene(Defines.Scene type)
	{
		SceneManager.LoadScene(GetSceneName(type));
	}
	public string GetSceneName(Defines.Scene type) 
	{ 
		return System.Enum.GetName(typeof(Defines.Scene), type);
	}
	public void SetCurrentScene(BaseScene scene)
	{
		CurrentScene = scene;
	}
}