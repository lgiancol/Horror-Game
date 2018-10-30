using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : InteractableItem {
	public Transform fuseSlot;
	public Gate gate;
	private Inventory inventory;

	void Start() {
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += checkHasFuse;
		this.canInteract = false;
	}

	private void checkHasFuse() {
		// Don't check anything if this fuse box has already been used
		if (!isActive) {
			return;
		}
		this.canInteract = false;
		for(int i = 0; i < inventory.items.Count; i++) {
			if(inventory.items[i].itemName == "Fuse") {
				this.canInteract = true;
				return;
			}
		}
	}

	public override void onInteract() {
		this.onItemUndetected();
		Item activeItem = inventory.getActiveItem();
		
		if(activeItem != null && activeItem.itemName == "Fuse") {
			GameObject fuse = Instantiate(activeItem.itemDropPrefab, fuseSlot, false);
			fuse.GetComponent<InteractableItem>().isActive = false;

			inventory.remove(activeItem);

			this.isActive = false;

			// Grab the Gate script object from the gate and increment the fuses
			gate.connectFuse();
		}
	}
}
