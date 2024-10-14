using System;
using Unity.VisualScripting;

public class NPCInteractionAction : UnitInteractAction
{
	public override void OnInteract()
	{
		UI_Dialogue dialogue = Managers.UI.OpenPopUp("NPCDialogue") as UI_Dialogue;
		NPC data = this.gameObject.GetComponent<NPC>();
		dialogue.Init(data.Name, "Test");
	}
}
