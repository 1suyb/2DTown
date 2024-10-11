using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.U2D;

public class Unit : MonoBehaviour
{
	protected GameObject _mainSpriteObject;
	protected TextMeshProUGUI _nameUI;

	protected UnitLookAction _lookAction;
	protected UnitMoveAction _moveAction;
	protected HumanoidAnimationController _humanoidAnimationController;

	protected Defines.Gender _gender;
	protected Defines.UnitSpecies _species;



	public string Name { get; private set; } = "";
	public string UnitTypeString { get { return $"{_species}_{UnitGenderString}"; } }
	public string UnitGenderString { get { return Utils.GenderToString(_gender); } }

	public bool HasRightUnitType { get { return _species != Defines.UnitSpecies.Unknown; } }
	public bool HasRightName { get { return Utils.IsAvailableName(Name); } }

	protected virtual void Awake()
	{
		Bind();
	}
	
	protected virtual void Start()
	{
		Init();
	}

	public virtual void Bind()
	{
		SpriteRenderer mainSpriteRender = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		if(mainSpriteRender != null)
		{
			_mainSpriteObject = mainSpriteRender.gameObject;
		}
		_nameUI = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();

		_lookAction = this.gameObject.GetOrAddComponent<UnitLookAction>();
		_moveAction = this.gameObject.GetComponent<UnitMoveAction>();
		_humanoidAnimationController = this.gameObject.GetComponent<HumanoidAnimationController>();
	}
	public virtual void Init()
	{
		_lookAction.Bind(); _lookAction.Init();
		_moveAction.Bind(); _moveAction.Init();
		_humanoidAnimationController.Bind();
	}

	public virtual void SetName(string name)
	{
		Name = name;
	}
	public virtual void SetUnitType(Defines.Gender gender, Defines.UnitSpecies species)
	{
		_gender = gender;
		_species = species;
	}



}

