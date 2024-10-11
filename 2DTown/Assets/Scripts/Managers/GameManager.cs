using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
	private Player _player;

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
	}


}
