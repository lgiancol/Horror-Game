using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public RawImage icon;
	public Item item;
	
	// Set the item for the current inventory slot
	public void setItem(Item toAdd) {
		this.item = toAdd;

		icon.texture = toAdd.itemIcon;
		icon.enabled = true;
	}

	// Get rid of the item that is in the current slot
	public void clearItem() {
		this.item = null;

		icon.texture = null;
		icon.enabled = false;
	}
}
