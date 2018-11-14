using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public int maxReflections = 1;
	private int numReflections = 0;
	public float maxStepDistance = 1000f;
	private LineRenderer laser;
	public Sensor sensor;

	// Use this for initialization
	void Start () {
		laser = GetComponentInChildren<LineRenderer>();
		laser.positionCount = 0; // Make sure there are enough verticies to keep up with the number of lines we want
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
		// laser.positionCount = 0;
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
			// We hit something so no matter what we need this variable so we can add another point
			fromPos = hit.point;

			// If we are hitting the player or we are not hitting a mirror, add one more point and return
			if(hit.collider.GetComponent<Player>() || !hit.collider.GetComponent<Mirror>()) {
				addPoint(fromPos);

				// There might be another point that was in before but shouldn't be in now
				//  (Like if the player walks in front of the laser at the beginning but it
				//  was reflecting off many things before that happened)
				laser.positionCount = numReflections;

				// After we add the final point, we need to check if the point we added to was the sensor
				// If it was, we want to activate the sensor
				if(hit.collider.GetComponent<Sensor>()) {
					sensor.activate();
				} else {
					sensor.deactivate();
				}

				return;
			}
			direction = Vector3.Reflect(direction, hit.normal);
		} else {
			fromPos += direction * maxStepDistance; // Add a new point to the laser (straight line)
		}

		// Actually add the new point
		addPoint(fromPos);

		drawLine(fromPos, direction, reflectionsRemaining - 1);
	}

	private void addPoint(Vector3 position) {
		// If we are trying to add a point that doesn't already exist, we need to add a new point first
		if(numReflections >= laser.positionCount) laser.positionCount++;

		// If the current number of points is less than the maximum number of reflections, add another reflection
		if(laser.positionCount < maxReflections) {
			laser.SetPosition(numReflections, position);
			numReflections++;
		}
	}
}
