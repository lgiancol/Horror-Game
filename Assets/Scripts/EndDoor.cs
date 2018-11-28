using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class EndDoor : Door {
	public bool isCorrect = false;
	public AudioSource endAudio;
	private bool hasPlayed = false;
	private bool done = false;
	public Fade fade;

	new void Start() {
		endAudio = GetComponent<AudioSource>();
	}

	void Update() {
		// Once it has played, if it stops playing, fade to black
		if(hasPlayed && !done) {
			if(!endAudio.isPlaying) {
				Debug.Log("Fade to black");
				done = true;
				fade.fadeOut();
			}
		}
	}

	public override void onInteract() {
			endAudio.Play(0);
			fade.isCorrect = isCorrect;

			hasPlayed = true;
    }
}
