using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {
	public GameObject inventoryHolder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateInventory(PlayerInventory inv) {
		int childCount = inv.getItemCount();

		for(int i = 0; i < childCount; i++) {
			Transform child = inventoryHolder.transform.GetChild(i);

			child.GetComponentInChildren<RawImage>().texture = inv.getItem(i).itemIcon;
		}
	}
}
