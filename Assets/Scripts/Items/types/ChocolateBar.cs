﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateBar : InteractableItem {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void onInteract() {
		Debug.Log("You are picking up a chocolate bar");
	}
}