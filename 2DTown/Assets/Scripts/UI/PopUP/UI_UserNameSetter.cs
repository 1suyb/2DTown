using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class UI_UserNameSetter : UI_Popup
{
	[SerializeField] private Button _okButton;
	[SerializeField] private TMP_InputField _inputField;
	[SerializeField] private TextMeshProUGUI _text;

	private string _defaultText { get; } = "이름을 입력하세요";
	private string _warrningText { get; } = "특수문자는 사용이 불가능 합니다.";

	private float _warrningTime = 1f;
	private bool _warrning = false;
	private float _timer = 0f;


	public override void Init()
	{
		_okButton.onClick.AddListener(SetUserName);
	}

	private void Update()
	{
		if (_warrning)
		{
			if (_timer < _warrningTime)
			{
				_timer += Time.deltaTime;
				_text.text = _warrningText;
			}
			else
			{
				_warrning = false;
				_text.text = _defaultText;
			}
		}
	}
	public void SetUserName()
	{
		string name = _inputField.text.Replace("\n","").Replace("\r","").Replace("\u200B", "");
		if (Utils.IsContainsSpecialCharacters(name)) 
		{
			UnAvailableNameWarrning();
			return;
		}
		Managers.GameManager.Player.SetName(name);
		CallResponse();
		Managers.UI.ClosePopUp();
	}

	public void AddListener(UnityAction action)
	{
		_okButton.onClick.AddListener(action);
	}

	private void UnAvailableNameWarrning()
	{
		_warrning = true;
		_timer = 0f;
	}
	public override void Close()
	{
		base.Close();
		_inputField.text = "";
	}
}