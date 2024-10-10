using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class Player : MonoBehaviour
{
	private GameObject _characterMainSprite;
	private TextMeshProUGUI _characterName;



	private string _name;
	private Defines.Gender _gender;
	private Defines.CharacterType _characterType;


	public string Name { get { return _name; } }
	public Defines.CharacterType CharacterType { get { return _characterType; } }
	public Defines.Gender Gender { get { return _gender; } }



	public void Init()
	{
		_characterMainSprite = Managers.Resource.Instantiate(GetUnitpath(),this.transform);
		_characterName = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
		_characterName.text = _name;

		UnitLookAction look = this.gameObject.GetOrAddComponent<UnitLookAction>();
		look.Bind();look.Init();

		UnitMoveAction move = this.gameObject.GetComponent<UnitMoveAction>();
		move.Bind(); move.Init();

		HumanoidAnimationController animator = this.gameObject.GetComponent<HumanoidAnimationController>();
		animator.Bind();

		gameObject.SetActive(true);
	}
	public string GetSpritePath()
	{
		return $"Sprites/{_characterType.ToString()}_{GetGenderInitial()}";
	}
	private string GetUnitpath()
	{
		return $"Units/Humanoid/{_characterType.ToString()}_{GetGenderInitial()}";
	}

	public void SetName(string name)
	{
		_name = name;
		if (_characterName != null)
		{
			_characterName.text = name;
		}
	}
	public void SetGender(Defines.Gender gender)
	{
		_gender = gender;
	}
	public void SetCharacterType(Defines.CharacterType characterType)
	{
		_characterType = characterType;
		if(_characterMainSprite != null)
		{
			Destroy(_characterMainSprite);
			_characterMainSprite = Managers.Resource.Instantiate(GetUnitpath(), this.transform);
		}
	}
	public string GetGenderInitial()
	{
		return _gender == Defines.Gender.Female ? "f" : "m";
	}

}