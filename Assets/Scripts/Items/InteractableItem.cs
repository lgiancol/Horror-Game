using UnityEngine;

public class InteractableItem : MonoBehaviour {
	public bool isActive = true;
	public string interactText;

	public virtual void onInteract() {

	}
}
