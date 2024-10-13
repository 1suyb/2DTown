using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dialogue : UI_Popup
{
	[SerializeField] private TextMeshProUGUI _npcNameUI;
	[SerializeField] private TextMeshProUGUI _dialogueUI;
	[SerializeField] private Button _close;

	private UnitController _unitController;

	public override void Init()
	{
		_close.onClick.AddListener(Close);
	}

	public void Init(string name, string dialogue)
	{
		_npcNameUI.text = name;
		_dialogueUI.text = dialogue;
	}
	
	public void SetDialogue(string dialogue )
	{
		_dialogueUI.text = dialogue;
	}
	public void SetNpcName(string name)
	{
		_npcNameUI.text = name;
	}

	public override void Close()
	{
		base.Close();
	}

}