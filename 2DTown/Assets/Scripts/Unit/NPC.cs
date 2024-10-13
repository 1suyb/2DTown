
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class NPC : Unit
{
	private NPCController _npcController;
	private NPCInteractionAction _interactionAction;

	private Vector2 _position;

	public override void Bind()
	{
		_npcController = this.gameObject.GetOrAddComponent<NPCController>();
		_interactionAction = this.gameObject.GetOrAddComponent<NPCInteractionAction>();
		base.Bind();
		TextMeshProUGUI[] texts = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
		foreach (TextMeshProUGUI text in texts)
		{
			if(text.name == "CharacterName")
				_nameUI = text;
		}
	}
	public override void Init()
	{
		base.Init();
		_npcController.Bind(); _npcController.Init();
		this.gameObject.tag = Defines.Tags.NPC.ToString();
		_nameUI.text = Name;
	}

	public void Interact()
	{
		_npcController.OnInteract();
	}

}
