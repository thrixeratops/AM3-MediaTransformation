using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float PassedTime;
	private string TimeString;
	private int Seconds;
	private int Minutes;
	private int Hours;
	private bool active;

	private void Start() {
		PassedTime = 0f;
		Seconds = Minutes = Hours = 0;
		TimeString = "";
		active = true;
	}

	private void Update() {
		if (active) {
			PassedTime += Time.deltaTime;
			Seconds = (int)PassedTime % 60;
			Minutes = (int)PassedTime / 60;
			Hours = Minutes / 60;

			TimeString = "";

			if (Hours < 10) { 
				TimeString += "0" + Hours.ToString();
			} else {
				TimeString += Hours.ToString();
			}
			TimeString += ":";
			if (Minutes < 10) { 
				TimeString += "0" + Minutes.ToString();
			} else {
				TimeString += Minutes.ToString();
			}
			TimeString += ":";
			if (Seconds < 10) { 
				TimeString += "0" + Seconds.ToString();
			} else {
				TimeString += Seconds.ToString();
			}
				
			GetComponentInChildren<Text>().text = TimeString;
		}
	}

	public void stopTimer() {
		active = false;
	}
}
