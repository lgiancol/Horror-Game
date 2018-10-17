using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : InteractableItem {
	public Item item;

	public override void onInteract() {
		this.pickupItem();
		this.onItemUndetected();
		Destroy(this.gameObject);
	}

	private void pickupItem() {
		if(Inventory.instance.add(this.item)) {
			Destroy(this.gameObject);
		}
	}
}
