using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryKey : InventoryObject {

	public override void activate() {
		if (isInInventory == true) {
			Player.GetComponent<Player>().removeFromInventory(this.gameObject, InvIconNum);
			isInInventory = false;
		} else {
			Player.GetComponent<Player>().addToInventory(this.gameObject, InvIconNum);
			isInInventory = true;
			Player.GetComponent<Player>().getProgressTracker().setStatusDone("GetKey");
		}
	}

}
