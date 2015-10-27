using UnityEngine;
using System.Collections;

public class Chef : MonoBehaviour {
	public string one_h;
	public string two_h;
	public GameObject temp_plate;
	public string at_current_name;
	//public GameObject Player;
	GameObject go_1h;
	GameObject go_2h;

	public int mtX;
	public int mtY;
	public bool atPosition = false;
	public static bool clicked = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("mtX: " + mtX + " mtY: " + mtY + " atPosition = " + atPosition);
		if (findGameObjectAtClickedPosition ()) {
			GameObject go = findGameObjectAtClickedPosition ();
			if (!clicked) {
			} else {
				Debug.Log ("clicked");
				if (go && atPosition && go.GetComponent<cookingObject> ()) {
					//Debug.Log(gameObject);
					Debug.Log(go.GetComponent<cookingObject> ().canCook (one_h, two_h));
					if (go.GetComponent<cookingObject> ().canCook (one_h, two_h) && 
						go.GetComponent<cookingObject> ().food_ready == false) {
						Debug.Log ("cooking...");
						go.GetComponent<cookingObject> ().cookReady = true;
						go.GetComponent<cookingObject> ().chef_1h = one_h;
						go.GetComponent<cookingObject> ().chef_2h = two_h;
						Destroy (go_1h);
						Destroy (go_2h);
						one_h = "";
						two_h = "";
					} else if (go.GetComponent<cookingObject> ().food_ready && handsEmpty ()) {
						one_h = go.GetComponent<cookingObject> ().food_cooking_name;
						Debug.Log ("picking up food...");
						Debug.Log (go.GetComponent<cookingObject> ().food_cooking_name);
						go.GetComponent<cookingObject> ().food_ready = false;
					}
					//Debug.Log (other.gameObject.GetComponent<cookingObject> ().canCook (one_h, two_h));
				} else if (go && atPosition && go.GetComponent<ingredientObject> ()) {
					//Debug.Log("HELLO?");
					if (one_h == "") {
						//Debug.Log ("test");
						one_h = go.GetComponent<ingredientObject> ().name;
						//create go_1h
						//go_1h = temp_plate;
						go_1h = Instantiate (temp_plate, new Vector3 (0, 2, 0), transform.rotation) as GameObject;
						go_1h.transform.SetParent (gameObject.transform);
						Debug.Log (one_h);
					} else if (two_h == "") {
						two_h = go.GetComponent<ingredientObject> ().name;
						//create go_2h
						//go_2h = temp_plate;
						go_2h = Instantiate (temp_plate, new Vector3 (1, 2, 0), transform.rotation) as GameObject;
						go_2h.transform.SetParent (gameObject.transform);
				
					}
				} else if (go && atPosition && go.GetComponent<dropOffPoint> ()) {
					if (hand_with_Food () == "one_h") {
						//update dropoffpoint food name
						if (string.IsNullOrEmpty (go.GetComponent<dropOffPoint> ().food_name)) {
							go.GetComponent<dropOffPoint> ().food_name = one_h;
							//add sprite of food
							//delete 1h
							one_h = "";
						}
					} else if (hand_with_Food () == "two_h") {
						//update dropoffpoint food name
						if (string.IsNullOrEmpty (go.GetComponent<dropOffPoint> ().food_name)) {
							go.GetComponent<dropOffPoint> ().food_name = two_h;
							//add sprite of food
							//delete 1h
							two_h = "";
						}
					}
				} else if (go && atPosition && go.GetComponent<Customer> ()) {
					//Debug.Log ("HEllO");
					if (hand_with_Food () == "one_h") {
						//update dropoffpoint food name

						if (string.IsNullOrEmpty (go.GetComponent<Customer> ().food_given)) {
							go.GetComponent<Customer> ().food_given = one_h;
							//add sprite of food
							//delete 1h
							one_h = "";
						}
					} else if (hand_with_Food () == "two_h") {
						//update dropoffpoint food name
						if (string.IsNullOrEmpty (go.GetComponent<Customer> ().food_given)) {
							go.GetComponent<Customer> ().food_given = two_h;
							//add sprite of food
							//delete 1h
							two_h = "";
						}
					}
				} else if (go && atPosition) {
					if (!string.IsNullOrEmpty (one_h)) {
						one_h = "";
						Destroy (go_1h);
					} else if (!string.IsNullOrEmpty (two_h)) {
						two_h = "";
						Destroy (go_2h);
					}
				} else {
					//Debug.Log("didn't work!");
					//Debug.Log(gameObject.tag);
			
				}
				clicked = false;
			}
		}

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "cookingObject") {
			at_current_name = other.gameObject.GetComponent<cookingObject>().name;

		} 
		else if (other.gameObject.tag == "ingredientObject") {
		at_current_name = other.gameObject.GetComponent<ingredientObject>().name;
		}
		else if (other.gameObject.tag == "dropOffPoint") {
			at_current_name = other.gameObject.GetComponent<dropOffPoint>().name;

		}
		else if (other.gameObject.tag == "trash") {
			at_current_name = "trash";
		}
		else {
			at_current_name = "";

		}

	}

	bool handsEmpty() {
		if (string.IsNullOrEmpty(one_h) && string.IsNullOrEmpty(two_h))
			return true;
		else
			return false;
	}

	string hand_with_Food() {
		if (!string.IsNullOrEmpty(one_h)) {
			return "one_h";
		} else if (!string.IsNullOrEmpty(two_h)) {
			return "two_h";
		} return "";
//		if (one_h.Contains ("food")) {
//			return "one_h";
//		} else if (two_h.Contains ("food")) {
//			return "two_h";
//		}
//			return "";
	}


	GameObject findGameObjectAtClickedPosition() {
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("test")) {
			if (go.GetComponent<nameAndPosition> ().x == mtX
				&& go.GetComponent<nameAndPosition> ().y == mtY) {
				return go;
			}
		}
		return null;
	}
}
