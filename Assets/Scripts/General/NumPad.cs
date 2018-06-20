using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour {

	[SerializeField] private int CorrectNumber;
	private GameObject Player;
	private Component Casket;
	private Text TextField;
	private int DisplayedNumber;

	void Start() {
		Player = GameObject.Find("Player");
		Casket = GetComponentInParent<Casket>();
		TextField = GetComponentInChildren<Text>();
		DisplayedNumber = 0;
		TextField.text = DisplayedNumber.ToString();
	}

	void Update() {
		
	}

	// The player is looking at the lightswitch
	public void isOnFocus() {
		Player.GetComponent<Player>().setOnFocus(this.gameObject);
	}

	// The player is not looking at the lightswitch
	public void isOffFocus() {
		Player.GetComponent<Player>().setOffFocus();
	}

	public void activate() {
		if (DisplayedNumber < 9) {
			DisplayedNumber++;
		} else {
			DisplayedNumber = 0;
		}
		TextField.text = DisplayedNumber.ToString();
		Casket.GetComponent<Casket>().checkNumCode();
	}

	public bool isCorrect() {
		if (DisplayedNumber == CorrectNumber) {
			return true;
		} else {
			return false;
		}
	}
}
