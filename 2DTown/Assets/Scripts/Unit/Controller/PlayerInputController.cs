using UnityEngine.InputSystem;
using UnityEngine;
public class PlayerInputController : UnitController
{

	public void OnMove(InputValue value)
	{
		CallMove(value.Get<Vector2>());
	}
	public void OnLook(InputValue value)
	{
		Vector2 aim = value.Get<Vector2>();
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(aim);
		aim = (worldPos - (Vector2)this.transform.position).normalized;
		CallLook(aim);
	}
	public void OnInteract(InputValue value)
	{
		CallInteract();
	}
}
