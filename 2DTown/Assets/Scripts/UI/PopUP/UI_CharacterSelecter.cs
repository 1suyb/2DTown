using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterSelecter : UI_Popup 
{
	[SerializeField] private Button _female;
	[SerializeField] private Button _male;

	[SerializeField] private Transform _layout;
	[SerializeField] private Button StartButton;
	
	public event Action<Defines.CharacterType> CharacterSelect;
	public Defines.CharacterType SelectedCharacterType { get; set; } = Defines.CharacterType.Unknown;

	private List<UI_CharacterButton> characterButtons;

	public override void Init()
	{
		_female.onClick.AddListener(SetGenderFemale);
		_male.onClick.AddListener(SetGenderMale);
		CreateCharacterButtons();
	}

	public void CreateCharacterButtons()
	{
		int charactersCount = (int)Defines.CharacterType.End;
		characterButtons =
			Managers.UI.CreateSubItems<UI_CharacterButton>("CharacterButton", charactersCount, _layout);
		for (int i = 0; i < charactersCount; i++)
		{
			characterButtons[i].CharacterSelecter = this;
			characterButtons[i].gameObject.SetActive(false);
		}
		StartButton.onClick.AddListener(SetCharacterType);
	}

	public void UpdateCharacterButtons()
	{
		for (int i = 0; i < characterButtons.Count; i++) 
		{
			characterButtons[i].Init(i);
			characterButtons[i].gameObject.SetActive(true);
		}
	}

	private void SetGenderMale()
	{
		Managers.GameManager.Player.SetGender(Defines.Gender.male);
		UpdateCharacterButtons();
	}

	private void SetGenderFemale()
	{
		Managers.GameManager.Player.SetGender(Defines.Gender.Female);
		UpdateCharacterButtons();
	}

	public void ClickedButton(Defines.CharacterType type)
	{
		CharacterSelect?.Invoke(type);
	}

	public void SetCharacterType()
	{
		if(SelectedCharacterType == Defines.CharacterType.Unknown)
		{
			return;
		}
		Managers.GameManager.Player.SetCharacterType(SelectedCharacterType);
		CallResponse();
		Close();
	}
	
}