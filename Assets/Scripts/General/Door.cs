using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	[SerializeField] private Animator DoorAnim;
	[SerializeField] private Timer Playtime;
	[SerializeField] private AudioSource EndSample;
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
			GetComponents<AudioSource>()[1].Play();
			return;
		} else {
			Playtime.stopTimer();
			DoorAnim.Play("OpenDoor");
			EndSample.Play();
			GetComponents<AudioSource>()[0].Play();
		}
	}

}
