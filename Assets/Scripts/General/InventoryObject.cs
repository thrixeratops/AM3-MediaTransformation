using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour {

	[SerializeField] protected int InvIconNum; // Refer to InventoryIcons[] in Player.cs (0 = Book, 1 = Key)
	protected GameObject Player;
	protected bool isInInventory;

	protected void Start() {
		Player = GameObject.Find("Player");
		isInInventory = false;
	}

	protected void Update() {
		
	}

	// The player is looking at the object
	public void isOnFocus() {
		Player.GetComponent<Player>().setOnFocus(this.gameObject);
	}

	// The player is not looking at the object
	public void isOffFocus() {
		Player.GetComponent<Player>().setOffFocus();
	}

	public virtual void activate() {
		if (isInInventory == true) {
			Player.GetComponent<Player>().removeFromInventory(this.gameObject, InvIconNum);
			isInInventory = false;
		} else {
			Player.GetComponent<Player>().addToInventory(this.gameObject, InvIconNum);
			isInInventory = true;
		}
	}

}
