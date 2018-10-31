using UnityEngine;

public class LockedDoor : Door {
    Inventory inventory;
    bool locked = true;

    protected override void Start() {
        base.Start();

        // Make it usable but uninteractable to start
        isActive = true;
        canInteract = false;

        // Add a callback method for the inventory
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += checkForKey;
    }

    public void checkForKey() {
        // Don't do anything if it's unlocked
        if (!locked) {
            return;
        }

        // We need to reset if this everytime because a key may have been used on a different door
        canInteract = false;
        // Look through all of the items and try to find a key
		for(int i = 0; i < inventory.items.Count; i++) {
			if(inventory.items[i].itemName == "Key") {
				canInteract = true;
				return;
			}
		}
    }

    public override void onInteract() {
        if (locked) {
            // Unlock the door if the player uses a key
            onItemUndetected();
            Item activeItem = inventory.getActiveItem();
            
            if(activeItem != null && activeItem.itemName == "Key") {
                // Set the locked status before we remove the item so our callback will see it
                locked = false;
                interactText = "Press 'E' to open";

                inventory.remove(activeItem);
                // Still open the door here for ease of use
                base.onInteract();
            }
        } else {
            // Work like a normal door once it's unlocked
            base.onInteract();
        }
    }
}
