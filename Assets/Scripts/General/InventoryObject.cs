using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour {

	private GameObject Player;
	private bool isInInventory;

	private void Start() {
		Player = GameObject.Find("Player");
		isInInventory = false;
	}

	private void Update() {
		
	}

	// The player is looking at the object
	public void isOnFocus() {
		Player.GetComponent<Player>().setOnFocus(this.gameObject);
	}

	// The player is not looking at the object
	public void isOffFocus() {
		Player.GetComponent<Player>().setOffFocus();
	}

	public void activate() {
		if (isInInventory == true) {
			Player.GetComponent<Player>().removeFromInventory(this.gameObject);
			isInInventory = false;
		} else {
			Player.GetComponent<Player>().addToInventory(this.gameObject);
			isInInventory = true;
		}
	}

}
