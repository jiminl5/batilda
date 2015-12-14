using UnityEngine;
using System.Collections;

public class drinkObject : MonoBehaviour {
	public int numberOfDrinks;
	public string name;

	public int maxDrinks;

	private bool waitingOnDrink = false;
	private int timeToMakeDrink = 5;

	//public Color c;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		checkDrinks ();
	}
	

	void checkDrinks() {
		if (!waitingOnDrink && numberOfDrinks < maxDrinks) {
			//this.GetComponent<SpriteRenderer> ().color = Color.red;
			Invoke("addDrink", timeToMakeDrink);
			waitingOnDrink = true;
		}
	}

	void addDrink() {
		numberOfDrinks += 1;
		waitingOnDrink = false;
		//this.GetComponent<SpriteRenderer> ().color = Color.white;
	}

}
