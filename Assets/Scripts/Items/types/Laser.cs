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
		laser = GetComponentInChildren<LineRenderer>();
		laser.positionCount = maxReflections + 1; // Make sure there are enough verticies to keep up with the number of lines we want
	}
	
	// Update is called once per frame
	void Update () {
		// As of right now, the reflections are being updated every frame which seems a little dumb
		// What we are going to want to do is create all the reflections in the Start method and then
		// we can check when something intersects with the reflection and if it is a mirror, then we 
		// will update it so we aren't rerendering all the lines every update

		redrawLaser();
	}

	private void redrawLaser() {
		// Reset the first node since we might be moving it
		numReflections = 0;
		addPoint(this.transform.position);

		// Draw the rest of the nodes based on this position
		drawLine(this.transform.position, this.transform.forward, maxReflections);
	}

	private void drawLine(Vector3 fromPos, Vector3 direction, int reflectionsRemaining) {
		if(reflectionsRemaining == 0) {
			return;
		}

		Ray ray = new Ray(fromPos, direction);
		RaycastHit hit;

		// If we hit something, find the position of where we hit, and get the direction so we can properly figure out the next line
		if(Physics.Raycast(ray, out hit, maxStepDistance)) {
			fromPos = hit.point; // This point is calculated using the direction that was given originally
			direction = Vector3.Reflect(direction, hit.normal);
		} else {
			fromPos += direction * maxStepDistance;
		}

		// Actually add the new point
		addPoint(fromPos);

		drawLine(fromPos, direction, reflectionsRemaining - 1);
	}

	private void addPoint(Vector3 position) {
		laser.SetPosition(numReflections, position);
		numReflections++;
	}
}
