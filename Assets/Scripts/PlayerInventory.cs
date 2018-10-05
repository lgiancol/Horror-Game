using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory {

	private List<InventoryItem> items;
	private int itemCount = 0;
	public int activeIndex = 0;

	public PlayerInventory() {
		items = new List<InventoryItem>();
	}

	public InventoryItem getItem(int index) {
		return items[index];
	}

	public int getItemCount() {
		return itemCount;
	}

	public void addItem(InventoryItem toAdd) {
		items.Add(toAdd);
		itemCount++;
	}

	public void setActiveIndex(int index) {
		activeIndex = index;

		Debug.Log("Active inventory index: " + activeIndex);
	}

	public void print() {
		foreach(InventoryItem item in items) {
			Debug.Log("Item: " + item.itemName);
		}
	}
	
}
