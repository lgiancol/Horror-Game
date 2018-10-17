using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour{
	private Inventory inventory;
	public InventorySlot[] slots;

	// Use this for initialization
	void Start () {
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += this.updateInventoryUI;

		slots = this.transform.GetComponentsInChildren<InventorySlot>();
	}

	// This is the method that is called whenever the inventory is updated
	private void updateInventoryUI() {

		for(int i = 0; i < slots.Length; i++) {
			if(i < inventory.items.Count) {
				slots[i].setItem(inventory.items[i]);
			} else {
				slots[i].clearItem();
			}
		}
	}
}
