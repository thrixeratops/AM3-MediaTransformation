using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float PassedTime;
	private int Seconds;
	private int Minutes;
	private int Hours;

	void Start() {
		PassedTime = 0f;
	}

	void Update() {
		PassedTime += Time.deltaTime;
		Seconds = (int)PassedTime % 60;
		Minutes = (int)PassedTime / 60;
		Hours = Minutes / 60;
		GetComponentInChildren<Text>().text = Hours + ":" + Minutes + ":" + Seconds;
	}
}
