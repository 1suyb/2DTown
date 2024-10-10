using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class UI_CharacterButton : UI_SubItem
{
	[SerializeField] private Button _button;
	[SerializeField] private Image _characterImage;
	[SerializeField] private Image _backgroundColor;
	[SerializeField] private TextMeshProUGUI _text;

	private UI_CharacterSelecter _characterSelecter;
	public UI_CharacterSelecter CharacterSelecter {
		get { return _characterSelecter; }
		set
		{
			if (_characterSelecter == null) { _characterSelecter = value; }
		}
	}

	private Defines.CharacterType _characterType;

	public override void Init(int number)
	{
		Player player = Managers.GameManager.Player;
		_characterType = (Defines.CharacterType)number;
		_text.text = _characterType.ToString();
		_button.onClick.AddListener(ClickedThisButton);
		_characterImage.sprite = Managers.Resource.Load<Sprite>($"Sprites/{_characterType.ToString()}_{player.GetGenderInitial()}");
		_characterSelecter.CharacterSelect += ChangeColor;
	}

	public void ClickedThisButton()
	{
		_characterSelecter.ClickedButton(_characterType);
		_characterSelecter.SelectedCharacterType = _characterType;
	}

	public void ChangeColor(Defines.CharacterType type)
	{
		if(type == _characterType)
		{
			_backgroundColor.color = Color.yellow;
		}
		else
		{
			_backgroundColor.color = Color.white;
		}
	}
}
