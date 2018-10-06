using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : Interactable {
	public override void onInteract(Player player) {
		player.addInventoryItem(this.inventoryItem);
		Destroy(this.gameObject);
	}
}
