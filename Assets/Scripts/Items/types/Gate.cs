using UnityEngine;

public class Gate : MonoBehaviour {
    // The number of fuses that are needed to unlock the gate
    public uint fusesNeeded = 1;

    // The number of fuses so far connected to the gate
    private uint fuseCount = 0;

    // The animation that we will play when the gate gets unlocked
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void connectFuse() {
        fuseCount++;
        if (fuseCount >= fusesNeeded) {
            // Play the unlocking animation
            animator.SetTrigger("Interact");
        }
    }
}
