using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Camera cam;
	public float radius = 2.0f;
	public Inventory inventory;
	// public GUI gui;

	// Use this for initialization
	void Start () {
		inventory = GetComponent<Inventory>();
		// gui.inventoryManager.updateInventory(inventory);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("e")) {
			Ray ray = new Ray(cam.transform.position, cam.transform.forward);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, radius)) {
				InteractableItem item = hit.collider.GetComponent<InteractableItem>();

				if(item != null && item.isActive) {
					item.onInteract();
				}
			}
		} else if(Input.GetKeyDown("1")) {
			// inventory.setActiveIndex(0);
		} else if(Input.GetKeyDown("2")) {
			// inventory.setActiveIndex(1);
		} else if(Input.GetKeyDown("3")) {
			// inventory.setActiveIndex(2);
		} else if(Input.GetKeyDown("4")) {
			// inventory.setActiveIndex(3);
		} else if(Input.GetKeyDown("5")) {
			// inventory.setActiveIndex(4);
		}
	}

	public void addInventoryItem(Item toAdd) {
		// inventory.addItem(toAdd);
		// gui.inventoryManager.updateInventory(inventory);
	}

	public void removeActiveItem() {
		// inventory.removeActiveItem();
		// gui.inventoryManager.updateInventory(inventory);
	}
}
