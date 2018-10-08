using UnityEngine;

public class ItemDetector {
	private int radius = 2;
	private InteractableItem detectedItem;

	public InteractableItem checkItemDetected(Camera cam) {
		Ray ray = new Ray(cam.transform.position, cam.transform.forward);
		RaycastHit hit;
		InteractableItem toReturn = null;

		if(Physics.Raycast(ray, out hit, radius)) {
			toReturn = hit.collider.GetComponent<InteractableItem>();
		}

		return toReturn;
	}
}
