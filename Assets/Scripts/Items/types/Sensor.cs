using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {
	private bool isActivated = false;
	public GameObject activatesGo;

	public void activate() {
		if(!this.isActivated) {
			this.isActivated = true;
			Debug.Log("Sensor active");
			activatesGo.GetComponent<Animator>().SetTrigger("Interact");
		}
	}

	public void deactivate() {
		if(this.isActivated) {
			this.isActivated = false;
			Debug.Log("Sensor is no longer active");
			activatesGo.GetComponent<Animator>().SetTrigger("Interact");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
