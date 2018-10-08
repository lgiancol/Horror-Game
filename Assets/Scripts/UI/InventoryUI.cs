using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
	private Inventory inventory;
	public Transform slotsParent;
	public InventorySlot[] slots;

	// Use this for initialization
	void Start () {
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += this.updateInventoryUI;

		slots = slotsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void updateInventoryUI() {
		Debug.Log("Updating the inventory UI");

		for(int i = 0; i < slots.Length; i++) {
			if(i < inventory.items.Count) {
				slots[i].setItem(inventory.items[i]);
			} else {
				slots[i].clearItem();
			}
		}
	}
}
