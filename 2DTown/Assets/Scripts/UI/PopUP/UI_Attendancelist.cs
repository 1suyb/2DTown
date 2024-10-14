using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Attendancelist : UI_Popup
{
	[SerializeField] private Button _closeButton;
	[SerializeField] private Transform _layout;

	public override void Init()
	{
		base.Init();
		_closeButton.onClick.AddListener(Managers.UI.ClosePopUp);
		CreateList();
	}

	public void CreateList()
	{
		int attendeeCount = Managers.GameManager.Attendee.Count;
		List<UI_Attendee> buttons = Managers.UI.CreateSubItems<UI_Attendee>("Attendee", attendeeCount,_layout);
		for(int i = 0; i<attendeeCount; i++)
		{
			buttons[i].Init(i);
		}
	}


	public override void Close()
	{
		base.Close();
	}
}
