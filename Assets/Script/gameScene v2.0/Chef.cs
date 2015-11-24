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
	public bool atPosition = true;
	public static bool clicked = false;

	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		atPosition = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("mtX: " + mtX + " mtY: " + mtY + " atPosition = " + atPosition);
		if (findGameObjectAtClickedPosition ()) {
			GameObject go = findGameObjectAtClickedPosition ();
			//Debug.Log (go);
			animator.SetBool("1_h", !string.IsNullOrEmpty(one_h));
			animator.SetBool("2_h", !string.IsNullOrEmpty(two_h));
			if (!clicked) {
			} else {
//				Debug.Log (!string.IsNullOrEmpty(one_h));
				clicked = false;
				Debug.Log ("clicked");
				if (go && atPosition && go.GetComponent<cookingObject> ()) {
					//Debug.Log(gameObject);
					Debug.Log ("hello");
					Debug.Log(go.GetComponent<cookingObject> ().canCook (one_h));
					if (go.GetComponent<cookingObject> ().canCook (one_h) && 
							go.GetComponent<cookingObject> ().food_ready == false) {
						Debug.Log ("cooking...");
						go.GetComponent<cookingObject> ().cookReady = true;
						go.GetComponent<cookingObject> ().chef_1h = one_h;
						Destroy (go_1h);
						//MoveableTile.ResetMidTiles();
						one_h = "";
					}
					else if (go.GetComponent<cookingObject> ().canCook (two_h) && 
					    go.GetComponent<cookingObject> ().food_ready == false) {
						Debug.Log ("cooking...");
						go.GetComponent<cookingObject> ().cookReady = true;
						go.GetComponent<cookingObject> ().chef_1h = two_h;
						Destroy (go_2h);
						two_h = "";
					}

					else if (go.GetComponent<cookingObject> ().food_ready && (string.IsNullOrEmpty(one_h) || string.IsNullOrEmpty(two_h)) ) {

						if (string.IsNullOrEmpty(one_h)) {
							one_h = go.GetComponent<cookingObject> ().current_recipie.name;

							go_1h = Instantiate (go.GetComponent<cookingObject>().current_recipie.go, transform.position + Vector3.right/2 + Vector3.down *1/2, transform.rotation) as GameObject;
							go_1h.transform.SetParent (gameObject.transform);

							Debug.Log ("picking up food...");
							Debug.Log (go.GetComponent<cookingObject> ().food_cooking_name);
							go.GetComponent<cookingObject> ().food_ready = false;
						}

						else if (string.IsNullOrEmpty(two_h)) {
							two_h = go.GetComponent<cookingObject> ().current_recipie.name;
							
							go_2h = Instantiate (go.GetComponent<cookingObject>().current_recipie.go, transform.position + Vector3.left * 2/3 + Vector3.down *1/2, transform.rotation) as GameObject;
							go_2h.transform.SetParent (gameObject.transform);
							
							Debug.Log ("picking up food...");
							Debug.Log (go.GetComponent<cookingObject> ().food_cooking_name);
							go.GetComponent<cookingObject> ().food_ready = false;
						}
					}
						

					//Debug.Log (other.gameObject.GetComponent<cookingObject> ().canCook (one_h, two_h));
				} else if (go && atPosition && go.GetComponent<ingredientObject> ()) {
					Debug.Log ("this is two_h: " + string.IsNullOrEmpty(two_h));
					if (string.IsNullOrEmpty(one_h)) {
						//Debug.Log ("test");
						one_h = go.GetComponent<ingredientObject> ().name;
						//create go_1h
						//go_1h = temp_plate;
						go_1h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right/2 + Vector3.down *1/2, transform.rotation) as GameObject;
						go_1h.transform.SetParent (gameObject.transform);
						//go_1h.gameObject.layer = 5;
						Debug.Log (one_h);

					} else if (string.IsNullOrEmpty(two_h)) {
						//Debug.Log ("HELLO?????????????");
						two_h = go.GetComponent<ingredientObject> ().name;
						//create go_2h
						//go_2h = temp_plate;

						go_2h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2/3 + Vector3.down *1/2, transform.rotation) as GameObject;
						//go_2h.gameObject.layer = 5;
						go_2h.transform.SetParent (gameObject.transform);
				
					}
				} 

				else if (go && atPosition && go.GetComponent<doughObject> ()) {
					if (one_h == "wheat" && go.GetComponent<doughObject>().numberofWheat < go.GetComponent<doughObject>().maxWheat) {
						go.GetComponent<doughObject>().numberofWheat += 1;
						one_h = "";
						Destroy (go_1h);
					}
					else if (two_h == "wheat" && go.GetComponent<doughObject>().numberofWheat < go.GetComponent<doughObject>().maxWheat) {
						go.GetComponent<doughObject>().numberofWheat += 1;
						two_h = "";
						Destroy (go_2h);
					}
				} 

				else if (go && atPosition && go.GetComponent<doughPickUp> ()) {
					if (go.GetComponent<doughPickUp>().numberofDough > 0) {
						if (string.IsNullOrEmpty(one_h)) {
							one_h = "dough";
							go_1h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right/2 + Vector3.down *1/2, transform.rotation) as GameObject;
							go_1h.transform.SetParent (gameObject.transform);
							go.GetComponentInParent<doughObject> ().numberOfDough -= 1;
							go.GetComponent<doughPickUp> ().numberofDough -= 1;
						}
						else if (string.IsNullOrEmpty(two_h)) {
							go_2h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2/3 + Vector3.down *1/2, transform.rotation) as GameObject;
							go_2h.transform.SetParent (gameObject.transform);
							go.GetComponentInParent<doughObject> ().numberOfDough -= 1;
							go.GetComponent<doughPickUp> ().numberofDough -= 1;
						}
					}

				}

				else if (go && atPosition && go.GetComponent<dropOffPoint> ()) {
					Debug.Log ("HELLO!");
					Debug.Log (hand_with_Food());
					if (hand_with_Food () == "one_h") {

						//update dropoffpoint food name
						if (string.IsNullOrEmpty (go.GetComponent<dropOffPoint> ().food_name)) {
							go.GetComponent<dropOffPoint> ().food_name = one_h;
							go.GetComponent<nameAndPosition>().go = go_1h;
							go.GetComponentInChildren<SpriteRenderer>().sprite = go_1h.GetComponent<SpriteRenderer>().sprite;
							go.transform.GetChild(0).tag = "not_empty_plate";
							GameObject.FindGameObjectWithTag("tile_blk").GetComponent<MoveableTile>().ResetMidTiles();
							//add sprite of food
							//delete 1h
							one_h = "";
							Destroy (go_1h);
						}
					} else if (hand_with_Food () == "two_h") {
						//update dropoffpoint food name
						if (string.IsNullOrEmpty (go.GetComponent<dropOffPoint> ().food_name)) {
							go.GetComponent<dropOffPoint> ().food_name = two_h;
							go.GetComponent<nameAndPosition>().go = go_2h;
							go.GetComponentInChildren<SpriteRenderer>().sprite = go_2h.GetComponent<SpriteRenderer>().sprite;
							go.transform.GetChild(0).tag = "not_empty_plate";
							GameObject.FindGameObjectWithTag("tile_blk").GetComponent<MoveableTile>().ResetMidTiles();
							//add sprite of food
							//delete 1h
							two_h = "";
							Destroy (go_2h);
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
							Destroy (go_1h);
							one_h = "";
						}
					} else if (hand_with_Food () == "two_h") {
						//update dropoffpoint food name
						if (string.IsNullOrEmpty (go.GetComponent<Customer> ().food_given)) {
							go.GetComponent<Customer> ().food_given = two_h;
							//add sprite of food
							//delete 2h
							Destroy (go_2h);
							two_h = "";
						}
					}
				} else if (go && atPosition) {

					if (!string.IsNullOrEmpty (two_h)) {
						two_h = "";
						Destroy (go_2h);
					}
					else if (!string.IsNullOrEmpty (one_h)) {
						one_h = "";
						Destroy (go_1h);
					} 
				}else {
					//Debug.Log("didn't work!");
					//Debug.Log(gameObject.tag);
					clicked = true;
				}

				if (!string.IsNullOrEmpty(two_h) && string.IsNullOrEmpty(one_h)) {
					one_h = two_h;
					go_1h = Instantiate (go_2h, transform.position + Vector3.right/2 + Vector3.down *1/2, transform.rotation) as GameObject;
					go_1h.transform.SetParent (gameObject.transform);
					//------------------
					Destroy (go_2h);
					two_h = "";
				}

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
		if (!string.IsNullOrEmpty(one_h) && one_h.Contains("food")) {
			return "one_h";
		} else if (!string.IsNullOrEmpty(two_h) && two_h.Contains ("food")) {
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
