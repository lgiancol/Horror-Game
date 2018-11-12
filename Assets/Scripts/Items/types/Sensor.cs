using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {
	private bool isActivated = false;

	public void activate() {
		if(!this.isActivated) {
			this.isActivated = true;
			Debug.Log("Sensor active");
		}
	}

	public void deactivate() {
		if(this.isActivated) {
			this.isActivated = false;
			Debug.Log("Sensor is no longer active");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
