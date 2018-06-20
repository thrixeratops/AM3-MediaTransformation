using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casket : MonoBehaviour {

	[SerializeField] private Animator CasketAnim;
	[SerializeField] private GameObject DoorKey;
	[SerializeField] private GameObject Door;
	private GameObject Player;
	private Component[] NumPad;

	void Start() {
		Player = GameObject.Find("Player");
		NumPad = GetComponentsInChildren<NumPad>();
	}

	void Update() {
		
	}

	public void checkNumCode() {
		foreach (Component item in NumPad) {
			if (item.GetComponent<NumPad>().isCorrect() == false) {
				return;
			}
		}
		CasketAnim.Play("OpenCasket");
		DoorKey.GetComponent<Renderer>().enabled = true;
		DoorKey.GetComponent<Collider>().enabled = true;
	}

}
