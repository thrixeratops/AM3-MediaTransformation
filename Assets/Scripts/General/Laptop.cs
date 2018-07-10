using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour {

	[SerializeField] private Animator LaptopAnim;
	private GameObject Player;
	private bool isOpen;

	void Start() {
		Player = GameObject.Find("Player");
		isOpen = false;
	}

	void Update() {

	}

	// The player is looking at the drawer
	public void isOnFocus() {
		Player.GetComponent<Player>().setOnFocus(this.gameObject);
	}

	// The player is not looking at the drawer
	public void isOffFocus() {
		Player.GetComponent<Player>().setOffFocus();
	}

	// Is called from Player.cs to open and close the drawer
	public void activate() {
		if (isOpen == false) {
			LaptopAnim.Play("OpenLaptop");
			GetComponentInChildren<UnityEngine.Video.VideoPlayer>().Play();
			isOpen = true;
			//GetComponent<Collider>().enabled = false;

		} else {
			LaptopAnim.Play("CloseLaptop");
			GetComponentInChildren<UnityEngine.Video.VideoPlayer>().Stop();
			isOpen = false;
		}
	}

}
