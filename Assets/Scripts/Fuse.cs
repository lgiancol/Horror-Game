using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : Interactable {
	public override void onInteract(Player player) {
		Debug.Log("Pickup the fuse and add to " + player.name);
		player.addInventoryItem("Fuse");
	}
}
