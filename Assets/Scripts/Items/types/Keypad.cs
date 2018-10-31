using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour {
	public string codeAnswer = "9654";
	public string codeGuess = "";
	public bool isCorrect = false;
	public Fuse fuse;

	public void updateGuess(string newVal) {
		codeGuess += newVal;
		checkGuess();
	}

	private void checkGuess() {
		if(codeGuess.Length == codeAnswer.Length) {
			if(codeGuess == codeAnswer) {
				isCorrect = true;
				fuse.canInteract = true;
			} else {
				resetCodeGuess();
			}
		}
	}

	private void resetCodeGuess() {
		this.codeGuess = "";
	}
}
