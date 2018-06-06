using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour {

	private GameObject Player;
	private Animator OpenDrawerAnimator;
	[SerializeField] private string OpenAnimationStateName;
	[SerializeField] private string CloseAnimationStateName;
	private bool isOpen;

	private void Start() {
		Player = GameObject.Find("Player");
		OpenDrawerAnimator = GetComponent<Animator>();
		isOpen = false;
	}

	private void Update() {
		
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
			OpenDrawerAnimator.Play(OpenAnimationStateName);
			isOpen = true;
		} else {
			OpenDrawerAnimator.Play(CloseAnimationStateName);
			isOpen = false;
		}
	}

}
