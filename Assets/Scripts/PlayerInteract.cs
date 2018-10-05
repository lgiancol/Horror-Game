using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
	public Camera cam;
	public float radius = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("e")) {
			Ray ray = new Ray(cam.transform.position, cam.transform.forward);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, radius)) {
				Interactable item = hit.collider.GetComponent<Interactable>();

				if(item != null) {
					item.onInteract();
				} else {
					Debug.Log("Hit something that isn't interactive");
				}
			} else {
				Debug.Log("Nothing in range");
			}
		}
	}
}
