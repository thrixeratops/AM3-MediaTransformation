using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	[SerializeField] private ProgressTracker Tracker; // Keeps track of all the things the player has done
	[SerializeField] private Canvas Hud;
	[SerializeField] private float DelayTime; // Time that will pass until an event will be triggered
	private Image RadialProgress; // Image that respresents the FocusTimer on screen
	private GameObject ActiveObject; // The interactive object that the player is looking at
	private GameObject LastTeleporter; // The teleporter that was last used (, also functions as spawn point)
	private List<GameObject> Inventory; // Inventory that can hold GameObjects
	private bool Focus; // Enables the FocusTimer 
	private float FocusTimer; // Timer that will trigger event after it passed the DelayTime

	private void Start() {
		RadialProgress = Hud.GetComponentInChildren<Image>();
		RadialProgress.fillAmount = 0f;
		//LastTeleporter = GameObject.Find("TP1"); // Assuming that TP1 is our Teleporter
		Inventory = new List<GameObject>();
		FocusTimer = 0f;
		Focus = false;
	}

	private void Update() {
		if (Focus == true) {
			FocusTimer += Time.deltaTime;
			RadialProgress.fillAmount = FocusTimer / DelayTime; // Update the timer in HUD
			if (FocusTimer >= DelayTime) { // If time has passed

				// Based on the component of the ActiveObject it has to be handled differently
				if (ActiveObject.GetComponent<Teleporter>() != null) {
					if (LastTeleporter != null) { // At the start there is no LastTeleporter
						LastTeleporter.GetComponent<Teleporter>().showTeleporter();
					}
					LastTeleporter = ActiveObject;
					ActiveObject.GetComponent<Teleporter>().activate();

				} else if (ActiveObject.GetComponent<SwitchLight>() != null) {
					ActiveObject.GetComponent<SwitchLight>().activate();
				
				} else if (ActiveObject.GetComponent<OpenDrawer>() != null) {
					ActiveObject.GetComponent<OpenDrawer>().activate();
				
				} else if (ActiveObject.GetComponent<InventoryObject>() != null) {
					ActiveObject.GetComponent<InventoryObject>().activate();
				}

				Focus = false; // Prevents the the continuos triggering of events by forcing the player to "re-look" at the object
				RadialProgress.fillAmount = 0f;
			}
		}
	}

	// Is called from an object that is looked at to start the FocusTimer
	public void setOnFocus(GameObject SelectedObject) {
		Focus = true;
		ActiveObject = SelectedObject;
	}

	// Is called from an object that is looked at to stop the FocusTimer
	public void setOffFocus() {
		Focus = false;
		resetTimer();
	}

	// Makes the ProgressTracker avaible to other objects to set tasks as complete, etc.
	public ProgressTracker getProgressTracker() {
		return Tracker;
	}

	// Reset timer and update HUD
	private void resetTimer() {
		FocusTimer = 0f;
		RadialProgress.fillAmount = 0f;
	}

	public void addToInventory(GameObject Item) {
		Inventory.Add(Item);
		Item.GetComponent<MeshRenderer>().enabled = false;
		// Show Item in HUD
	}

	public void removeFromInventory(GameObject Item) {
		Inventory.Remove(Item);
		Item.GetComponent<MeshRenderer>().enabled = true;
	}

}
