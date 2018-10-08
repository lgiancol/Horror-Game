using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Camera cam;
	public float radius = 2.0f;
	
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
