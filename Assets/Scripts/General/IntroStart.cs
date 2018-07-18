using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStart : MonoBehaviour {

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
		SceneManager.LoadScene("VR_Scene", LoadSceneMode.Single);
	}

}
