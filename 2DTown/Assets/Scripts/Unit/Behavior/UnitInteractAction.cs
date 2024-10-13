using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitInteractAction : MonoBehaviour
{
	private UnitController _controller;

	public void Bind()
	{
		_controller = GetComponent<UnitController>();
	}
	public void Init()
	{
		_controller.OnInteractEvent += OnInteract;
	}

	public abstract void OnInteract();
}