using UnityEngine;
using System.Collections;

public class Door : InteractableItem {
    protected Animator animator;
    
    protected virtual void Start () {
        animator = GetComponent<Animator>();
    }

    public override void onInteract() {
        animator.SetTrigger("Interact");
    }
}
