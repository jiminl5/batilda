﻿using UnityEngine;
using System.Collections;


public class doughObject : MonoBehaviour {
	
	public int numberOfDough;
	public string name;
	public int numberofWheat;
	public int maxWheat;

	public int maxDough;
	private bool waitingOnDough = false;
	private int timeToMakeDough = 5;
	
	//public Color c;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		checkDough ();
		if (waitingOnDough) {
			this.GetComponent<Animator> ().SetBool ("on", true);
		} 
		else {
			this.GetComponent<Animator> ().SetBool ("on", false);
		}
	}
	
	
	void checkDough() {
		if (!waitingOnDough && numberOfDough < maxDough && numberofWheat > 0) {
			//this.GetComponent<SpriteRenderer> ().color = Color.red;
			this.GetComponent<stopWatchObject> ().startTime = timeToMakeDough;
			this.GetComponent<stopWatchObject> ().timeInSeconds = timeToMakeDough;
			this.GetComponent<stopWatchObject> ().not_cooking = false;
			Invoke("addDough", timeToMakeDough);
			waitingOnDough = true;
		}
	}
	
	void addDough() {
		numberOfDough += 1;
		this.gameObject.GetComponentInChildren<doughPickUp> ().numberofDough += 1;
		waitingOnDough = false;
		this.GetComponent<SpriteRenderer> ().color = Color.white;
		numberofWheat -= 1;	
	}
	
}

