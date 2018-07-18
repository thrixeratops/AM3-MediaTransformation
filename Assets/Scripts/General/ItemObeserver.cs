using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObeserver : MonoBehaviour {

	private GameObject Player;
	private Transform OriginalPosition;

	private void Start() {
		Player = GameObject.Find("Player");
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

	}

}
