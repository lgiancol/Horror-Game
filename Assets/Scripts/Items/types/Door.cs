using UnityEngine;
using System.Collections;

public class Door : InteractableItem {
    Animator animator;
    
    void Start () {
        animator = GetComponent<Animator>();
    }

    public override void onInteract() {
        animator.SetTrigger("Interact");
    }
}
