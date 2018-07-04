using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour {

	[SerializeField] private int CorrectNumber;
	[SerializeField] private GameObject NumSelector;
	private GameObject Player;
	private Component Casket;
	private Text TextField;
	private int DisplayedNumber;
	private Component[] NumCollider;
	private bool ShowNumSelector;

	void Start() {
		Player = GameObject.Find("Player");
		Casket = GetComponentInParent<Casket>();
		TextField = GetComponentInChildren<Text>();
		DisplayedNumber = 0;
		TextField.text = DisplayedNumber.ToString();
		NumCollider = NumSelector.GetComponentsInChildren<Collider>();
		ShowNumSelector = false;

		NumSelector.GetComponent<Canvas>().enabled = false;
		foreach (Component item in NumCollider) {
			item.GetComponent<Collider>().enabled = false;
		}
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
		if (ShowNumSelector == true) {
			NumSelector.GetComponent<Canvas>().enabled = false;
			foreach (Component item in NumCollider) {
				item.GetComponent<Collider>().enabled = false;
			}
			ShowNumSelector = false;
		} else {
			NumSelector.GetComponent<Canvas>().enabled = true;
			foreach (Component item in NumCollider) {
				item.GetComponent<Collider>().enabled = true;
			}
			ShowNumSelector = true;
		}

		/* START
		if (DisplayedNumber < 9) {
			DisplayedNumber++;
		} else {
			DisplayedNumber = 0;
		}
		TextField.text = DisplayedNumber.ToString();
		Casket.GetComponent<Casket>().checkNumCode();
		END */
	}

	public bool isCorrect() {
		if (DisplayedNumber == CorrectNumber) {
			return true;
		} else {
			return false;
		}
	}
}
