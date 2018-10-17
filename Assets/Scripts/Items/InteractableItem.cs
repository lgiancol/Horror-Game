using UnityEngine;

public class InteractableItem : MonoBehaviour {
	public bool isActive = true;
	public string interactText;
	public bool canInteract = true;
	public ActionPanelUI actionPanel;

	public virtual void onInteract() {

	}

	public virtual void onItemDetected() {
		actionPanel.setActionText(this.interactText);
	}

	public virtual void onItemUndetected() {
		actionPanel.resetActionText();
	}
}
