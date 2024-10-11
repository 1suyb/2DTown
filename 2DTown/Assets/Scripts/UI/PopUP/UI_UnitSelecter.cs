using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UnitSelecter : UI_Popup 
{
	[SerializeField] private Button _female;
	[SerializeField] private Button _male;

	[SerializeField] private Transform _layout;
	[SerializeField] private Button _startButton;
	
	public event Action<Defines.UnitSpecies> CharacterSelect;
	public Defines.UnitSpecies SelectedCharacterType { get; set; } = Defines.UnitSpecies.Unknown;

	private List<UI_UnitButton> characterButtons;

	public Defines.Gender SelectedGender { get; private set; }

	public override void Init()
	{
		_female.onClick.AddListener(SetGenderFemale);
		_male.onClick.AddListener(SetGenderMale);
		_startButton.onClick.AddListener(SetCharacterType);
		CreateCharacterButtons();
	}

	public void CreateCharacterButtons()
	{
		int charactersCount = (int)Defines.UnitSpecies.End;
		characterButtons =
			Managers.UI.CreateSubItems<UI_UnitButton>("CharacterButton", charactersCount, _layout);
		for (int i = 0; i < charactersCount; i++)
		{
			characterButtons[i].CharacterSelecter = this;
			characterButtons[i].gameObject.SetActive(false);
		}
	}

	private void SetGenderMale()
	{
		SelectedGender = Defines.Gender.male;
		UpdateCharacterButtons();
	}

	private void SetGenderFemale()
	{
		SelectedGender = Defines.Gender.Female;
		UpdateCharacterButtons();
	}

	public void UpdateCharacterButtons()
	{
		for (int i = 0; i < characterButtons.Count; i++)
		{
			characterButtons[i].Init(i);
			characterButtons[i].gameObject.SetActive(true);
		}
	}


	public void ClickedButton(Defines.UnitSpecies type)
	{
		CharacterSelect?.Invoke(type);
	}

	public void SetCharacterType()
	{
		if(SelectedCharacterType == Defines.UnitSpecies.Unknown)
		{
			return;
		}
		Managers.GameManager.Player.SetUnitType(SelectedGender, SelectedCharacterType);
		CallResponse();
		Close();
	}
	public override void Close()
	{
		base.Close();
		foreach(UI_UnitButton button in characterButtons)
		{
			button.Close();
		}
	}

}