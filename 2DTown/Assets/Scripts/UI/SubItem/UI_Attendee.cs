using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_Attendee : UI_SubItem
{
	[SerializeField] private Button _button;
	[SerializeField] private TextMeshProUGUI _text;

	private Unit _unit;

	public override void Init(int num)
	{
		_unit = Managers.GameManager.Attendee[num];
		_text.text = _unit.Name;
		_button.onClick.AddListener(Teleport);
;	}

	public void Teleport()
	{
		if(_unit == Managers.GameManager.Player) { return; }
		Managers.GameManager.Player.transform.position = _unit.transform.position+new Vector3(0.5f,0.5f,0);
	}


}
