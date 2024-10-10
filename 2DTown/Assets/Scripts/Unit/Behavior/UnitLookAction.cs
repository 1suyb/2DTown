using UnityEngine;

public class UnitLookAction : MonoBehaviour
{
	private UnitController _controller;
	private SpriteRenderer _spriteRenderer;


	private void Awake()
	{
		Bind();
	}
	private void Start()
	{
		Init();
	}

	public void Bind()
	{
		_controller = gameObject.GetOrAddComponent<UnitController>();
		_spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
	}
	public void Init()
	{
		_controller.OnLookEvent += Looking;
	}


	public void Looking(Vector2 direction)
	{
		float rotZ = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
		_spriteRenderer.flipX = Mathf.Abs(rotZ) > 90;
	}
}
