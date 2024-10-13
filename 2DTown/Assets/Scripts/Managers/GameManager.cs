using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
	private Player _player;
	public List<Unit> Attendee { get; private set; } = new List<Unit>();

	public Player Player
	{
		get
		{
			if (_player == null)
			{
				CreatePlayer();
			}
			return _player;
		}
	}

	public void CreatePlayer()
	{
		GameObject player = Managers.Resource.Instantiate("PlayerCharacter");
		_player = player.GetOrAddComponent<Player>();
		GameObject.DontDestroyOnLoad(player);
		player.SetActive(false);
		Attendance(_player);
	}

	public void Attendance(Unit unit)
	{
		Attendee.Add(unit);
	}

}
