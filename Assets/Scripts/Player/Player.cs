using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Camera cam;

	private ItemDetector itemDetector;

	void Start() {
		itemDetector = GetComponent<ItemDetector>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("e")) {

			if(itemDetector.getDetectedItem() != null && itemDetector.getDetectedItem().isActive) {
				itemDetector.getDetectedItem().onInteract();
			}
		} else if(Input.GetKeyDown("1")) {
			Inventory.instance.setActiveItem(0);
		} else if(Input.GetKeyDown("2")) {
			Inventory.instance.setActiveItem(1);
		} else if(Input.GetKeyDown("3")) {
			Inventory.instance.setActiveItem(2);
		} else if(Input.GetKeyDown("4")) {
			Inventory.instance.setActiveItem(3);
		} else if(Input.GetKeyDown("5")) {
			Inventory.instance.setActiveItem(4);
		}
	}
}
