using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : InteractableItem {
	private bool isMoving = false;
	private float distance;

	public override void onInteract() {
		isMoving = !isMoving; // Invert what we are doing with the mirror

		// If we started moving the mirror
		if(isMoving) {
			this.setActionText("Press 'e' to stop moving mirror");
			// distance = Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
			this.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
		} else {
			// We stopped moving the mirror
			this.setActionText("Press 'e' to move mirror");
			this.gameObject.transform.SetParent(null);
		}
    }
	
	// Update is called once per frame
	void Update () {
		// if(isMoving) {
		// 	Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		// 	this.transform.position = playerTransform.position + (playerTransform.forward * distance);
		// 	this.transform.rotation = playerTransform.rotation + this.transform.rotation;
		// }
	}
}
