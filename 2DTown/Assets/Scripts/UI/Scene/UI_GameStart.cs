using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_GameStart : UI_Scene
{
	[SerializeField] private TextMeshProUGUI _warringMessage;

	[SerializeField] private TextMeshProUGUI _characterName;
	[SerializeField] private Button _characterNameButton;

	[SerializeField] private Image _characterSprite;
	[SerializeField] private Button _characterSpriteButton;

	[SerializeField] private Button _startButton;

	private Player _player;



	public override void Init()
	{
		_player = Managers.GameManager.Player;

		_characterNameButton.onClick.AddListener(OpenNameSetter);
		_characterSpriteButton.onClick.AddListener(OpenCharacterSelsecter);
		_startButton.onClick.AddListener(GameStart);
	}

	private void OpenCharacterSelsecter()
	{
		UI_Popup characterSelecter = Managers.UI.OpenPopUp("UserCharacterSelecter");
		characterSelecter.ResponseEvent += SetSprite;
	}

	private void SetSprite()
	{
		_characterSprite.sprite = Managers.Resource.Load<Sprite>($"Sprites/{_player.UnitTypeString}");
	}

	private void OpenNameSetter()
	{
		UI_Popup nameSelecter = Managers.UI.OpenPopUp("UserNameSetter");
		nameSelecter.ResponseEvent += SetNameText;
	}

	public void SetNameText()
	{
		_characterName.text = _player.Name;
	}

	public void GameStart()
	{
		if (!_player.HasRightName)
		{
			_warringMessage.text = "캐릭터 이름을 설정해주세요";
			return; 
		}
		if (!_player.HasRightUnitType)
		{
			_warringMessage.text = "캐릭터를 설정해주세요";
			return;
		}
		Managers.Scene.LoadScene(Defines.Scene.GameScene);
	}
}