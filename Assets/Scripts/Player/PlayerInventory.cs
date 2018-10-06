using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory {

	private InventoryItem[] items;
	public InventoryItem empty;
	private int itemCount = 0;
	public int activeIndex = 0;
	public int maxItems = 5;
	private bool isFull = false;

	public PlayerInventory() {
		items = new InventoryItem[maxItems];

		for(int i = 0; i < maxItems; i++) {
			addEmptyItem(i);
		}
	}

	public InventoryItem getItem(int index) {
		return items[index];
	}

	public int getItemCount() {
		return itemCount;
	}

	public void addEmptyItem(int index) {
		items[index] = (EmptyInventoryItem) ScriptableObject.CreateInstance("EmptyInventoryItem");
	}

	public bool addItem(InventoryItem toAdd) {
		if(isFull)
			return false;

		items[itemCount] = toAdd;
		itemCount++;

		// When we set up observable, this is where we would call update or whatever
		return true;
	}

	public void removeActiveItem() {
		items[activeIndex]  = (EmptyInventoryItem) ScriptableObject.CreateInstance("EmptyInventoryItem");
	}

	public void setActiveIndex(int index) {
		activeIndex = index;
	}

	public void print() {
		foreach(InventoryItem item in items) {
			if(item != null)
				Debug.Log("Item: " + item.itemName);
		}

		Debug.Log("");
	}
	
}
