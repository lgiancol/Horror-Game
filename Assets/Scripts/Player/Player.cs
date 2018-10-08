using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Camera cam;
	public ActionPanelUI actionPanelUI;

	private ItemDetector itemDetector;
	private InteractableItem activeItem; // The item that you are looking at

	void Start() {
		itemDetector = new ItemDetector();
	}
	
	// Update is called once per frame
	void Update () {
		this.activeItem = itemDetector.checkItemDetected(cam);

		// If we are looking at an item we can pickup
		if(activeItem != null) {
			// If we haven't already set a message and the item we are looking at is active set the text
			if(activeItem.canInteract && actionPanelUI.messageSet == false && activeItem.isActive) {
				actionPanelUI.setActionText(activeItem.interactText);
			}
		} else {
			// If we aren't looking at an item we can pickup and the message is already set
			if(actionPanelUI.messageSet) {
				actionPanelUI.resetActionText();
			}
		}

		if(Input.GetKeyDown("e")) {
			// Ray ray = new Ray(cam.transform.position, cam.transform.forward);
			// RaycastHit hit;

			// if(Physics.Raycast(ray, out hit, radius)) {
			// 	InteractableItem item = hit.collider.GetComponent<InteractableItem>();

			if(activeItem != null && activeItem.isActive) {
				activeItem.onInteract();
			}
			// }
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
