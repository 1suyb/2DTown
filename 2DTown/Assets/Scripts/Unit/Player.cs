﻿using UnityEngine;
using TMPro;

public class Player : Unit
{
	private PlayerInputController _playerInputController;

	public override void Bind()
	{
		base.Bind();
		_playerInputController = this.gameObject.GetOrAddComponent<PlayerInputController>();
	}
	public override void Init()
	{
		base.Init();
	}

	public override void SetName(string name)
	{
		base.SetName(name);
		UpdateNameUI();
	}

	public override void SetUnitType(Defines.Gender gender, Defines.UnitSpecies species)
	{
		base.SetUnitType(gender, species);
		UpdateUnit();
	}

	protected void UpdateNameUI()
	{
		_nameUI.text = Name;
	}

	protected void UpdateUnit()
	{
		if (_mainSpriteObject != null)
			Destroy(_mainSpriteObject);
		Debug.Log(UnitTypeString);
		_mainSpriteObject = Managers.Resource.Instantiate($"Units/Humanoid/{UnitTypeString}",this.transform);
		_mainSpriteObject.transform.localPosition = Vector3.zero;
		_lookAction.Bind(_mainSpriteObject.GetComponent<SpriteRenderer>());
		_humanoidAnimationController.Bind(_mainSpriteObject.GetComponent<Animator>());
	}
}