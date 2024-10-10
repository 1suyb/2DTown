using UnityEngine;

public class HumanoidAnimationController : UnitAnimationController
{
	private int isRun = Animator.StringToHash("isRun");
	private int isHit = Animator.StringToHash("isHit");

	private float _runThreshold = 0.1f;
	private void Start()
	{
		_controller.OnMoveEvent += Move;
	}
	public void Move(Vector2 direction)
	{
		_animator.SetBool(isRun, direction.magnitude > _runThreshold);
	}
	public void Hit()
	{

	}
}
