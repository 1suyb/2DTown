using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;

public class InitScene : BaseScene
{
	private void Start()
	{
		Managers.UI.OpenSceneUI("StartScene");
	}
}
