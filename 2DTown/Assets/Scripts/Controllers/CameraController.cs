using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform PlayerTransform { get; private set; }
	[SerializeField] private Vector3 delta = new Vector3(0, 0, -10);

	public void SetPlayer(Player player)
	{
		PlayerTransform = player.transform;
	}
	private void LateUpdate()
	{
		this.transform.position = PlayerTransform.position + delta;
	}
}
