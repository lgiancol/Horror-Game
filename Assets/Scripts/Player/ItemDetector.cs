using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour {
	public int radius = 2;
	public InteractableItem detectedItem;
	public Camera cam;

	void Update() {
		detectItem();
	}

	public void detectItem() {
		Ray ray = new Ray(cam.transform.position, cam.transform.forward);
		RaycastHit hit;
		// I don't like this... I am resetting the detectedItem every time... I want to update it when it changes instead
		// detectedItem = null;

		if(Physics.Raycast(ray, out hit, radius)) {
			InteractableItem temp = hit.collider.GetComponent<InteractableItem>();

			// Call detectedItem.onFocus() or whatever so that updates the UI instead of the player class
			if(temp != null) {
				this.setItemDetected(temp);
			} else {
				this.setItemUndetected();
			}
		} else {
			this.setItemUndetected();
		}
	}

	private void setItemDetected(InteractableItem newItem) {
		if(newItem != detectedItem && newItem.canInteract) {
			this.setItemUndetected();
			detectedItem = newItem;
			detectedItem.onItemDetected();
		}
	}

	private void setItemUndetected() {
		if(detectedItem != null) {
			detectedItem.onItemUndetected();
			detectedItem = null;
		}
	}

	public InteractableItem getDetectedItem() {
		return this.detectedItem;
	}
}
