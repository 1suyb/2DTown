using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameScene : UI_Scene
{
	[SerializeField] private Button _changeNameButton;
	[SerializeField] private Button _changeCharacterButton;
	[SerializeField] private Button _displayAttendanceButton;

	public override void Init()
	{
		_changeCharacterButton.onClick.AddListener(ChangeCharacter);
		_changeNameButton.onClick.AddListener(changeName);
		_displayAttendanceButton.onClick.AddListener(OpenAttendanceList);

	}

	private void OpenAttendanceList()
	{
		
	}

	private void changeName()
	{
		Managers.UI.OpenPopUp("UserNameSetter");
	}

	private void ChangeCharacter()
	{
		Managers.UI.OpenPopUp("CharacterSelecter");
	}
}
