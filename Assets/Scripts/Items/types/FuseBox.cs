using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : InteractableItem {
	public Transform fuseSlot;
	public Gate gate;
	private Inventory inventory;

	// The fuse that will be connected
	GameObject fuse;
	// Also save the item that will be removed from and added to the inventory
	Item fuseItem;
	// Keep track of the old interact text
	string oldInteractText;

	void Start() {
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += checkHasFuse;
		this.canInteract = false;
	}

	private void checkHasFuse() {
		Debug.Log(fuse);
		// If there is a fuse in the box, then we can still remove it
		if (fuse != null) {
			canInteract = true;
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
		
		if (fuse == null) {
			// Check for a fuse to use if it isn't connected yet
			if(activeItem != null && activeItem.itemName == "Fuse") {
				fuse = Instantiate(activeItem.itemDropPrefab, fuseSlot, false);
				fuse.GetComponent<InteractableItem>().isActive = false;

				inventory.remove(activeItem);
				fuseItem = activeItem;

				oldInteractText = interactText;
				interactText = "Press 'E' to remove the fuse";

				// Grab the Gate script object from the gate and increment the fuses
				gate.connectFuse();
			}
		} else {
			// Take the fuse out of the box and back into the player's inventory
			Destroy(fuse);
			fuse = null;

			// Add the fuse back to our inventory
			inventory.add(fuseItem);
			fuseItem = null;

			interactText = oldInteractText;
			oldInteractText = null;

			gate.disconnectFuse();
		}
	}
}
