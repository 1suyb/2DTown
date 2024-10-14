using UnityEngine;

public class PlayerInteractionAction : UnitInteractAction
{
	private NPC _nearNPC;
	private string _npcTag = Defines.Tags.NPC.ToString();

	public override void OnInteract()
	{
		if( _nearNPC != null)
			_nearNPC.gameObject.GetComponent<UnitController>().CallInteract();

		
	}

	private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
	{
		if (collision.CompareTag(_npcTag))
		{
			_nearNPC = collision.GetComponent<NPC>();
		}
	}
	private void OnTriggerExit2D(UnityEngine.Collider2D collision)
	{
		if (collision.CompareTag(_npcTag))
		{
			_nearNPC = null;
			Managers.UI.ClosePopUp();
		}
	}

}
