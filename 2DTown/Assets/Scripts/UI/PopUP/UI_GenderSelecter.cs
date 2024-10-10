using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GenderSelecter : UI_Popup
{
	[SerializeField] private Button _female;
	[SerializeField] private Button _male;
	[SerializeField] private TextMeshProUGUI _text;


	public override void Init()
	{
		base.Init();

	}

	private void SetGenderMale()
	{
		Managers.GameManager.Player.SetGender(Defines.Gender.male);
		OpenCharacterSelect();
	}

	private void SetGenderFemale()
	{
		Managers.GameManager.Player.SetGender(Defines.Gender.Female);
		OpenCharacterSelect();
	}

	private void OpenCharacterSelect()
	{
		Close();
		Managers.UI.OpenPopUp("UserCharacterSelecter");
	}
}
