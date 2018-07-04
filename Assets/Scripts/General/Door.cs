using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	[SerializeField] Animator DoorAnim;
	private GameObject Player;

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
		if (Player.GetComponent<Player>().getProgressTracker().getStatusBool("GetKey") == false) {
			return;
		} else {
			DoorAnim.Play("OpenDoor");
			GetComponent<AudioSource>().Play();
		}
	}

}
