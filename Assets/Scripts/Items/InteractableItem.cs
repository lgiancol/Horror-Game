using UnityEngine;

public class InteractableItem : MonoBehaviour {
	public bool isActive = true;
	public string interactText;
	public bool canInteract = true;

	public virtual void onInteract() {

	}
}
