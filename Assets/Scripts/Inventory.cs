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

	public void Awake() {
		if(instance != null) {
			Debug.LogWarning("There is already another inventory");
			return;
		}

		instance = this;
	}

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

	public void remove(Item toRemove) {
		items.Remove(toRemove);

		if(onItemChangedCallback != null) {
			onItemChangedCallback.Invoke();
		}
	}

	public Item getActiveItem() {
		Debug.Log("Count: " + this.items.Count);
		Debug.Log("Active Item: " + this.activeItem);
		if(this.items.Count > 0 && this.items.Count >= this.activeItem) {
			return this.items[this.activeItem];
		}

		return null;
	}

	public void setActiveItem(int newActive) {
		this.activeItem = newActive;
	}
}
