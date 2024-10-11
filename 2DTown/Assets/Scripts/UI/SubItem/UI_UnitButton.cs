using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class UI_UnitButton : UI_SubItem
{
	[SerializeField] private Button _button;
	[SerializeField] private Image _characterImage;
	[SerializeField] private Image _backgroundColor;
	[SerializeField] private TextMeshProUGUI _text;

	private UI_UnitSelecter _unitSelecter;
	public UI_UnitSelecter CharacterSelecter {
		get { return _unitSelecter; }
		set
		{
			if (_unitSelecter == null) { _unitSelecter = value; }
		}
	}

	private Defines.UnitSpecies _characterType;

	public override void Init(int number)
	{
		_characterType = (Defines.UnitSpecies)number;
		_button.onClick.AddListener(ClickedThisButton);
		_text.text = _characterType.ToString();
		_unitSelecter.CharacterSelect += ChangeColor;

		Player player = Managers.GameManager.Player;
		_characterImage.sprite = 
			Managers.Resource.Load<Sprite>(
				$"Sprites/{_characterType.ToString()}_{Utils.GenderToString(CharacterSelecter.SelectedGender)}");
	}

	public void ClickedThisButton()
	{
		_unitSelecter.ClickedButton(_characterType);
		_unitSelecter.SelectedCharacterType = _characterType;
	}

	public void ChangeColor(Defines.UnitSpecies type)
	{
		if(type == _characterType)
			_backgroundColor.color = Color.yellow;
		else
			_backgroundColor.color = Color.white;
	}
	public void Close()
	{
		_backgroundColor.color = Color.white;
	}
}
