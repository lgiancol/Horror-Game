using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public int slots = 5;
	public List<Item> items = new List<Item>();
	public int activeItem = 0;

	public delegate void onItemChanged();
	public onItemChanged onItemChangedCallback;

	public static Inventory instance;

	/* Awake is only called once during the lifetime of this script. This is so we can set an
		instance of this class so it can be used throughout the entire game */
	public void Awake() {
		if(instance != null) {
			Debug.LogWarning("There is already another inventory");
			return;
		}

		instance = this;
	}

	// Add something to the inventory if there is room
	public bool add(Item toAdd) {
		if(items.Count >= slots) {
			return false;
		}
		items.Add(toAdd);

		if(onItemChangedCallback != null) {
			onItemChangedCallback.Invoke();
		}

		return true;
	}

	// Remove someting from the inventory
	public void remove(Item toRemove) {
		items.Remove(toRemove);

		if(onItemChangedCallback != null) {
			onItemChangedCallback.Invoke();
		}
	}

	// Get the item in the inventory for the slot this is active
	public Item getActiveItem() {
		Debug.Log("Count: " + this.items.Count);
		Debug.Log("Active Item: " + this.activeItem);
		if(this.items.Count > 0 && this.items.Count >= this.activeItem) {
			return this.items[this.activeItem];
		}

		return null;
	}

	// Set which slot is active
	public void setActiveItem(int newActive) {
		this.activeItem = newActive;
	}
}
