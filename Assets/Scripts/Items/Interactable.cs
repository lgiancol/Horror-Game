using UnityEngine;

public class Interactable : MonoBehaviour {
	public InventoryItem inventoryItem;
	public bool isActive = true;

	public virtual void onInteract(Player player) {

	}
}
