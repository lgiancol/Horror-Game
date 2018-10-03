using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public int maxReflections = 1;
	private int numReflections = 0;
	public float maxStepDistance = 1000f;
	private LineRenderer laser;

	// Use this for initialization
	void Start () {
		laser = GetComponent<LineRenderer>();
		laser.SetPosition(numReflections, this.transform.position + (this.transform.forward * 0.15f));
		numReflections++;
	}
	
	// Update is called once per frame
	void Update () {
		numReflections = 0;
		laser.SetPosition(numReflections, this.transform.position + (this.transform.forward * 0.15f));
		numReflections++;
		drawLine(this.transform.position + (this.transform.forward * 0.15f), this.transform.forward, maxReflections);
	}

	private void drawLine(Vector3 position, Vector3 direction, int reflectionsRemaining) {
		if(reflectionsRemaining == 0) {
			return;
		}

		Ray ray = new Ray(position, direction);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, maxStepDistance)) {
			direction = Vector3.Reflect(direction, hit.normal);
			position = hit.point;
		} else {
			position += direction * maxStepDistance;
		}

		// Actually add the new line
		Debug.Log("Num: " + numReflections);
		Debug.Log("Position: " + position);
		laser.SetPosition(numReflections, position);
		numReflections++;

		drawLine(position, direction, reflectionsRemaining - 1);
	}
}
