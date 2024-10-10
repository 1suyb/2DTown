using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
	public event Action ResponseEvent;
	protected virtual void Start()
	{
		Init();	
	}
	public virtual void Init()
	{

	}
	public virtual void CallResponse()
	{
		ResponseEvent?.Invoke();
	}

	public virtual void Close()
	{
		Managers.UI.ClosePopUp();
	}
}
