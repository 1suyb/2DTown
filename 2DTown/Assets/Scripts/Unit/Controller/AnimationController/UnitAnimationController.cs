using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class UnitAnimationController : MonoBehaviour
{
	protected UnitController _controller;
	protected Animator _animator;

	

	private void Awake()
	{
		Bind();
	}

	public void Bind()
	{
		_controller = gameObject.GetOrAddComponent<UnitController>();
		_animator = gameObject.GetComponentInChildren<Animator>();
	}
	
}
