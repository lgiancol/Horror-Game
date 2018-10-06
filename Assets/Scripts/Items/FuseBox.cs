using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : Interactable {
	public Transform fuseSlot;

	public override void onInteract(Player player) {
		InventoryItem activeItem = player.inventory.getItem(player.inventory.activeIndex);
		
		if(activeItem != null && activeItem.itemName == "Fuse") {
			GameObject fuse = Instantiate(activeItem.itemDropPrefab, fuseSlot, false);
			fuse.GetComponent<Interactable>().isActive = false;

			player.removeActiveItem();
		}
	}
}
