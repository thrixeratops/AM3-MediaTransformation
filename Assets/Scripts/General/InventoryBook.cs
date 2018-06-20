using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBook : InventoryObject {

	[SerializeField] private Animator ShowPostIt;

	public override void activate() {
		if (isInInventory == true) {
			Player.GetComponent<Player>().removeFromInventory(this.gameObject, InvIconNum);
			isInInventory = false;
			Player.GetComponent<Player>().getProgressTracker().setStatusDone("PlaceBook");
			GetComponent<Collider>().enabled = false; // To prevent that the player can pick up the book after it has been placed in the correct position
			ShowPostIt.Play("PostItOut");
		} else {
			Player.GetComponent<Player>().addToInventory(this.gameObject, InvIconNum);
			isInInventory = true;
			Player.GetComponent<Player>().getProgressTracker().setStatusDone("PickUpBook");
			transform.position = new Vector3(-2.595f, 1.326f, -1.1402f);
			transform.localEulerAngles = new Vector3(-90f, 180f, 90f);
			GetComponent<Collider>().enabled = true;
		}
	}
}
