using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public int slots = 5;
	public List<Item> items = new List<Item>();

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
}
