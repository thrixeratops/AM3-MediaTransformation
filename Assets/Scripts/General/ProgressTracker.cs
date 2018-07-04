using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour {

	[SerializeField] private string[] StatusList; // Complete list of (names of) things that the player is able to achieve
	[SerializeField] private bool[] Solved; // In references to StatusList[], list of things that the player has achieved
	private int LastStatus; // Latest thing that the player has achieved

	private void Start() {
		Solved = new bool[StatusList.Length];
		LastStatus = 0;
		Solved[0] = true;

		/* //OBSOLETE
		*if (StatusList.Length != Solved.Length) {
		*	Debug.LogError("StatusList.Length is unequal to Solved.Length " + StatusList.Length + " != " + Solved.Length + ". They need to have the same length!");
		*}
		*/
	}

	private void Update() {
		
	}

	// Mark a status as done by number
	public void setStatusDone(int status) {
		if (0 <= status && status < Solved.Length) {
			Solved[status] = true;
		} else {
			Debug.LogWarning("The int '" + status + "' does not exist in StatusList[]. No status was marked as done.");
		}
	}

	// Mark a status as done by string (preferred)
	public void setStatusDone(string statusName) {
		for (int i=0; i<StatusList.Length; i++) {
			if (StatusList[i] == statusName) {
				Solved[i] = true;
				return;
			}
		}
		Debug.LogWarning("The string '" + statusName + "' does not exist in StatusList[]. No status was marked as done.");
	}

	// Returns latest status that was achieved 
	public int getLastStatus() {
		return LastStatus;
	}

	// Returns status name by number
	public string getStatusName(int status) {
		return StatusList[status];
	}

	// Returns the value of a status by int, useful to check, whether the player should be that far or not
	public bool getStatusBool(int status) {
		return Solved[status];
	}

	// Returns the value of a status by string, useful to check, whether the player should be that far or not
	public bool getStatusBool(string statusName) {
		for (int i=0; i<StatusList.Length; i++) {
			if (StatusList[i] == statusName) {
				return Solved[i];
			}
		}
		Debug.LogWarning("The string '" + statusName + "' does not exist in StatusList[].");
		return false;
	}

}
