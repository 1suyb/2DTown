using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class UnitMoveAction : MonoBehaviour
{
	private Vector2 _direction;

	private UnitController _controller;
	private Rigidbody2D _body;
	
	// ToDo : Character stat의 속도값으로 변경
	[SerializeField] private float speed = 5;

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
		_body = GetComponent<Rigidbody2D>();
	}
	public void Init()
	{
		_controller.OnMoveEvent += SetMoveDirection;
	}

	private void FixedUpdate()
	{
		if(_direction.magnitude > 0.1f)
		{
			_body.velocity = _direction * speed;
		}
		else
		{
			_body.velocity = Vector2.zero;
		}
	}

	public void SetMoveDirection(Vector2 direction)
	{
		_direction = direction;
	}

}
