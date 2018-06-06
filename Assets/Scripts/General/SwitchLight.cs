using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour {

	[SerializeField] private SpriteRenderer Wallpainting;
	[SerializeField] private GameObject Lamp;
	[SerializeField] private Animator TurnLightswitch;
	private Component[] LampLights;
	private GameObject Player;
	private bool LightOn;

	private void Start() {
		TurnLightswitch = GetComponentInChildren<Animator>();
		Wallpainting.GetComponent<SpriteRenderer>().enabled = false;
		Player = GameObject.Find("Player");
		LampLights = Lamp.GetComponentsInChildren<Light>();
		LightOn = true;
	}

	private void Update() {
		
	}

	// The player is looking at the lightswitch
	public void isOnFocus() {
		Player.GetComponent<Player>().setOnFocus(this.gameObject);
	}

	// The player is not looking at the lightswitch
	public void isOffFocus() {
		Player.GetComponent<Player>().setOffFocus();
	}

	// Is called from Player.cs to activate the lightswitch
	public void activate() {
		if (LightOn == true) {
			TurnLightswitch.Play("LightSwitchOff");
			foreach (Component item in LampLights) {
				item.GetComponent<Light>().enabled = false;
			}
			Wallpainting.GetComponent<SpriteRenderer>().enabled = true;
			LightOn = false;
			Player.GetComponent<Player>().getProgressTracker().setStatusDone("TurnLightOff");
		} else {
			TurnLightswitch.Play("LightSwitchOn");
			foreach (Component item in LampLights) {
				item.GetComponent<Light>().enabled = true;
			}
			Wallpainting.GetComponent<SpriteRenderer>().enabled = false;
			LightOn = true;
		}
	}

}
