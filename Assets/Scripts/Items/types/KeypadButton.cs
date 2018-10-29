using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : InteractableItem {
	public string buttonVal = "0";
	public Keypad keypad;

	void Start() {
	}

	public override void onInteract() {
		keypad.updateGuess(this.buttonVal);
	}
}
