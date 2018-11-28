using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceClue : InteractableItem {

    //public AudioClip audioCode;
    public AudioSource sourceCode;

    public void Start()
    {
        sourceCode = GetComponent<AudioSource>();
    }

    public override void onInteract()
	{
        sourceCode.Play();
	}
}
