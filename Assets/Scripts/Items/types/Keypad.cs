using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour {
	public string codeAnswer = "9654";
	public string codeGuess = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateGuess(string newVal) {
		codeGuess += newVal;
		checkGuess();
	}

	private void checkGuess() {
		if(codeGuess.Length == codeAnswer.Length) {
			if(codeGuess == codeAnswer) {
				Debug.Log("Figured it out");
			} else {
				resetCodeGuess();
			}
		}
	}

	private void resetCodeGuess() {
		this.codeGuess = "";
	}
}
