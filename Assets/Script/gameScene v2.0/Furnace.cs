using UnityEngine;
using System.Collections;

public class Furnace : MonoBehaviour {
	public bool isOn = false;
	public bool hasFirewood = false;

	private float maxTime = 30;
	private float currentTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn) {
			currentTime -= Time.deltaTime;
		}
		checkForFirewood ();
	}

	void turnOff() {
		this.GetComponent<SpriteRenderer> ().color = Color.white;
		isOn = false;
	}

	void turnOn() {
		this.GetComponent<SpriteRenderer> ().color = Color.yellow;
		isOn = true;
	}

	void checkForFirewood() {
		if (hasFirewood) {
			turnOn ();
			currentTime = maxTime;
			hasFirewood = false;
		} else if (currentTime <= 0) {
			turnOff ();
		}
	}
}
