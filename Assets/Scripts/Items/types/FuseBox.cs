using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : InteractableItem {
	public Transform fuseSlot;

	public override void onInteract() {
		// Item activeItem = player.inventory.getItem(player.inventory.activeIndex);
		
		// if(activeItem != null && activeItem.itemName == "Fuse") {
		// 	GameObject fuse = Instantiate(activeItem.itemDropPrefab, fuseSlot, false);
		// 	fuse.GetComponent<InteractableItem>().isActive = false;

		// 	player.removeActiveItem();
		// }
	}
}
