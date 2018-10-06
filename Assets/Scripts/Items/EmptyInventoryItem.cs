using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyInventoryItem : InventoryItem {
	public EmptyInventoryItem() {
		itemName = "Empty"; // Name in the inventory slot
		itemIcon = null; // Icon in the inventory slot
		// itemDropPrefab = null; // Item that will appear when dropped
	}
}
