using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour {
	public string codeAnswer = "9654";
	public string codeGuess = "";
	public bool isCorrect = false;
	public Fuse fuse1;
	public Fuse fuse2;
	public Text codeInput;

	public void updateGuess(string newVal) {
		codeGuess += newVal;
		codeInput.text = codeGuess;
		checkGuess();
	}

	private void checkGuess() {
		if(codeGuess.Length == codeAnswer.Length) {
			if(codeGuess == codeAnswer) {
				isCorrect = true;
				fuse1.gameObject.SetActive(true);
				fuse1.canInteract = true;
				fuse2.gameObject.SetActive(true);
				fuse2.canInteract = true;
				codeInput.color = Color.green;
			} else {
				resetCodeGuess();
			}
		}
	}

	private void resetCodeGuess() {
		this.codeGuess = "";
		codeInput.text = "";
	}
}
