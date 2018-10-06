using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	public void updateInventory(PlayerInventory inv) {
		int childCount = inv.maxItems;

		for(int i = 0; i < childCount; i++) {
			Transform child = this.transform.GetChild(i);

			child.GetComponentInChildren<RawImage>().texture = inv.getItem(i).itemIcon;
		}
	}
}
