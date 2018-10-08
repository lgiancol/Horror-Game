using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public RawImage icon;
	public Item item;
	
	public void setItem(Item toAdd) {
		this.item = toAdd;

		icon.texture = toAdd.itemIcon;
		icon.enabled = true;
	}

	public void clearItem() {
		this.item = null;

		icon.texture = null;
		icon.enabled = false;
	}
}
