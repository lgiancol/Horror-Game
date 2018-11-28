using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {
	public Text endGameText;
	public bool isCorrect = false;

	public void fadeOut() {
		Debug.Log("isCorrect: " + isCorrect);
		StartCoroutine(doFade());
	}

	IEnumerator doFade() {
		Image black = GetComponent<Image>();
		Color col = new Color(0, 0, 0, 0);

		while(black.color.a < 1) {
			col = new Color(0, 0, 0, col.a + (Time.deltaTime / 2));
			black.color = col;

			yield return null;
		}

		if(isCorrect) {
			endGameText.text = "Winner";
		} else {
			endGameText.text = "Game Over LOSER";
		}

		yield return new WaitForSeconds(5);

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene("Main Menu");

		yield return null;
	}
}
