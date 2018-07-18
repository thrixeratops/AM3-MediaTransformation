using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	[SerializeField] private ProgressTracker Tracker; // Keeps track of all the things the player has done
	[SerializeField] private Canvas Hud;
	[SerializeField] private float DelayTime; // Time that will pass until an event will be triggered
	[SerializeField] private GameObject[] InventoryIcons;
	[SerializeField] private Camera PlayerCamera;
	public Transform ObjectHit;
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

		// Better method to get the focused object
		/* 
		RaycastHit hit;
		Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)) {
			ObjectHit = hit.transform;
		}
		*/

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

				} else if (ActiveObject.GetComponent<NumPad>() != null) {
					ActiveObject.GetComponent<NumPad>().activate();
				
				} else if (ActiveObject.GetComponent<Door>() != null) {
					ActiveObject.GetComponent<Door>().activate();
				
				} else if (ActiveObject.GetComponent<Laptop>() != null) {
					ActiveObject.GetComponent<Laptop>().activate();
				
				} else if (ActiveObject.GetComponent<NumPadSelector>() != null) {
					ActiveObject.GetComponent<NumPadSelector>().activate();
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

	public void addToInventory(GameObject Item, int IconNum) {
		Inventory.Add(Item);
		Item.GetComponent<MeshRenderer>().enabled = false;
		Item.GetComponent<Collider>().enabled = false;
		InventoryIcons[IconNum].GetComponent<SpriteRenderer>().enabled = true;
	}

	public void removeFromInventory(GameObject Item, int IconNum) {
		Inventory.Remove(Item);
		Item.GetComponent<MeshRenderer>().enabled = true;
		Item.GetComponent<Collider>().enabled = true;
		InventoryIcons[IconNum].GetComponent<SpriteRenderer>().enabled = false;
	}

}
