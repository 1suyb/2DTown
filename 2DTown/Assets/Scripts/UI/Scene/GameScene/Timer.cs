using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : UI_Scene
{
	[SerializeField] private TextMeshProUGUI _text;

	private void Update()
	{
		_text.text = System.DateTime.Now.ToString("HH:mm:ss");
	}
}
