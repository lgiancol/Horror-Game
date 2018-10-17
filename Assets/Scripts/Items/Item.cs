using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject {
	public string itemName = "Item Name"; // Name in the inventory slot
	public Texture2D itemIcon = null; // Icon in the inventory slot
	public GameObject itemDropPrefab = null; // Item that will appear when dropped

}
