using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
	public event Action<Vector2> OnMoveEvent;
	public event Action<Vector2> OnLookEvent;
	public event Action OnInteractEvent;

	public void CallMove(Vector2 vec2)
	{
		OnMoveEvent?.Invoke(vec2);
	}
	public void CallLook(Vector2 vec2)
	{
		OnLookEvent?.Invoke(vec2);
	}
	public void CallInteract()
	{
		OnInteractEvent?.Invoke();
	}
}
