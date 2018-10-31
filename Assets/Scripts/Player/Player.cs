using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Camera cam;
	public ActionPanelUI actionPanelUI;

	private ItemDetector itemDetector;

	private bool cursorLocked = false;

	void Start() {
		itemDetector = GetComponent<ItemDetector>();
		Cursor.visible = cursorLocked;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		// Will return an item that is within range, or will return null
		// this.activeItem = itemDetector.checkItemDetected(cam);

		// If we are looking at an item we can pickup
		// if(itemDetector.getDetectedItem() != null) {
		// 	// If we haven't already set a message and the item we are looking at is active set the text
		// 	if(itemDetector.getDetectedItem().canInteract && actionPanelUI.messageSet == false && itemDetector.getDetectedItem().isActive) {
		// 		// actionPanelUI.setActionText(itemDetector.getDetectedItem().interactText);
		// 	}
		// } else {
		// 	// If we aren't looking at an item we can pickup and the message is already set
		// 	if(actionPanelUI.messageSet) {
		// 		// actionPanelUI.resetActionText();
		// 	}
		// }

		if(Input.GetMouseButtonDown(0)) {
			Ray ray = new Ray(cam.transform.position, cam.transform.forward);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 2.0f)) {
				ST_PuzzleTile temp = hit.collider.GetComponent<ST_PuzzleTile>();

				// Call detectedItem.onFocus() or whatever so that updates the UI instead of the player class
				if(temp != null) {
					// get the puzzle display and return the new target location from this tile. 
					temp.LaunchPositionCoroutine(GameObject.Find("Slide Puzzle").GetComponent<ST_PuzzleDisplay>().GetTargetLocation(temp));
				}
			}
		}

		if(Input.GetKeyDown("e")) {
			// Ray ray = new Ray(cam.transform.position, cam.transform.forward);
			// RaycastHit hit;

			// if(Physics.Raycast(ray, out hit, radius)) {
			// 	InteractableItem item = hit.collider.GetComponent<InteractableItem>();

			if(itemDetector.getDetectedItem() != null && itemDetector.getDetectedItem().isActive) {
				itemDetector.getDetectedItem().onInteract();
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
