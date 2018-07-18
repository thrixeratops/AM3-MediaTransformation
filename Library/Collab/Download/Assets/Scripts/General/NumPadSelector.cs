using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPadSelector : MonoBehaviour {

	private GameObject Player;
	[SerializeField] private GameObject NumDisplay;
	[SerializeField] private int PadNumber;

	void Start() {
		Player = GameObject.Find("Player");
	}

	void Update() {
		
	}

	// The player is looking at the NumPadField
	public void isOnFocus() {
		Player.GetComponent<Player>().setOnFocus(this.gameObject);
	}

	// The player is not looking at the NumPadField
	public void isOffFocus() {
		Player.GetComponent<Player>().setOffFocus();
	}

	public void activate() {
		NumDisplay.GetComponent<NumPad>().displayNumber(PadNumber);
	}

}
