using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class NPCController : UnitController
{
	private TextMeshProUGUI _interactionHint;
	private SpriteRenderer _mainSprite;

	private string _playerTag = Defines.Tags.Player.ToString();

	public void Bind()
	{
		TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
		foreach (TextMeshProUGUI text in texts)
		{
			if(text.name == "InteractionHint")
				_interactionHint = text;
		}
		_mainSprite = GetComponentInChildren<SpriteRenderer>();
	}
	public void Init()
	{
		_interactionHint.gameObject.SetActive(false);
	}

	public void OnInteract()
	{
		Debug.Log("npc");
		UI_Dialogue dialogue = Managers.UI.OpenPopUp("NPCDialogue") as UI_Dialogue;
		NPC data = this.gameObject.GetComponent<NPC>();
		dialogue.Init(data.Name, "Test");

	}

	private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
	{
		if (collision.CompareTag(_playerTag))
		{
			_interactionHint.gameObject.SetActive(true);
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag(_playerTag))
		{
			_mainSprite.flipX = (other.transform.position - this.transform.position).x < 0;
		}
	}

	private void OnTriggerExit2D(UnityEngine.Collider2D collision)
	{
		if (collision.CompareTag(_playerTag))
			_interactionHint.gameObject.SetActive(false);
	}
}