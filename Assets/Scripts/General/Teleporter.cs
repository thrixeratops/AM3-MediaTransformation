using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	private Color onFocusColor; // Color when looked at
	private Color offFocusColor; // Default color / Color when not looked at
	private Transform Indicator;
	private GameObject Player;

	private void Start() {
		onFocusColor = new Color(0f, 0.7f, 0f, 0.6f);
		offFocusColor = new Color(1f, 1f, 1f, 0.4f);
		Indicator = transform.parent.Find("TpLocationIndicator");
		Indicator.GetComponent<SpriteRenderer>().color = offFocusColor;
		Player = GameObject.Find("Player");
	}

	private void Update() {

	}

	// The player is looking at the teleporter
	public void isOnFocus() {
		Player.GetComponent<Player>().setOnFocus(this.gameObject);
		Indicator.GetComponent<SpriteRenderer>().color = onFocusColor;
	}

	// The player is not looking at the teleporter
	public void isOffFocus() {
		Player.GetComponent<Player>().setOffFocus();
		Indicator.GetComponent<SpriteRenderer>().color = offFocusColor;
	}

	// Is called from Player.cs to teleport the player and disable the teleporter
	public void activate() {
		Player.transform.position = transform.parent.position;
		GetComponent<MeshCollider>().enabled = false;
		Indicator.GetComponent<SpriteRenderer>().enabled = false;
	}

	// Is called from Player.cs to re-enable the teleporter
	public void showTeleporter() {
		GetComponent<MeshCollider>().enabled = true;
		Indicator.GetComponent<SpriteRenderer>().enabled = true;
	}
}
