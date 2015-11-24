using UnityEngine;
using System.Collections;

public class Waitress : MonoBehaviour {
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
		//Debug.Log (findGameObjectAtClickedPosition ());
		if (findGameObjectAtClickedPosition ()) {
			GameObject go = findGameObjectAtClickedPosition ();
//			animator.SetBool("1_h", !string.IsNullOrEmpty(one_h));
//			animator.SetBool("2_h", !string.IsNullOrEmpty(two_h));
			if (!clicked) {
			} else {
				//				Debug.Log (!string.IsNullOrEmpty(one_h));
				clicked = false;
				Debug.Log ("clicked");

				if (go && atPosition && go.GetComponent<drinkObject>() ) {
					if (string.IsNullOrEmpty(one_h)) {
						//Debug.Log ("test");
						one_h = go.GetComponent<drinkObject> ().name;
						//create go_1h
						//go_1h = temp_plate;
						go.GetComponent<drinkObject> ().numberOfDrinks -= 1;
						go_1h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right/2 + Vector3.down *1/2, transform.rotation) as GameObject;
						go_1h.transform.SetParent (gameObject.transform);
						//go_1h.gameObject.layer = 5;
						Debug.Log (one_h);
						
					} else if (string.IsNullOrEmpty(two_h)) {
						//Debug.Log ("HELLO?????????????");
						two_h = go.GetComponent<drinkObject> ().name;
						//create go_2h
						//go_2h = temp_plate;
						go.GetComponent<drinkObject> ().numberOfDrinks -= 1;
						go_2h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2/3 + Vector3.down *1/2, transform.rotation) as GameObject;
						//go_2h.gameObject.layer = 5;
						go_2h.transform.SetParent (gameObject.transform);
						
					}
				}

				if (go && atPosition && go.GetComponent<Furnace>() ) {
					if (one_h == "firewood") {
						one_h = "";
						go.GetComponent<Furnace>().hasFirewood = true;
						Destroy (go_1h);
					}
					else if (two_h == "firewood") {
						two_h = "";
						go.GetComponent<Furnace>().hasFirewood = true;
						Destroy (go_2h);
					}
				}

				else if (go && atPosition && go.GetComponent<dropOffPoint> ()) {
					if (string.IsNullOrEmpty(one_h)) {
						//update dropoffpoint food name
						if (!string.IsNullOrEmpty(go.GetComponent<dropOffPoint> ().food_name)) {
							one_h = go.GetComponent<dropOffPoint> ().food_name;
							go_1h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right/2 + Vector3.down *1/2, transform.rotation) as GameObject;
							go_1h.transform.SetParent (gameObject.transform);
							go.transform.GetChild(0).tag = "empty_plate";
							GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().plates = null;
							GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().food_plates = null;
							GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().Setup_Tile();
							//add sprite of food
							//delete 1h
							go.GetComponentInChildren<SpriteRenderer>().sprite = go.GetComponentInChildren<go_emptyDish>().emptyDish.GetComponent<SpriteRenderer>().sprite;
						}
					} else if (string.IsNullOrEmpty(two_h)) {
						//update dropoffpoint food name
						if (!string.IsNullOrEmpty (go.GetComponent<dropOffPoint> ().food_name)) {
							two_h = go.GetComponent<dropOffPoint> ().food_name;
							go_2h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2/3 + Vector3.down *1/2, transform.rotation) as GameObject;
							go_2h.transform.SetParent (gameObject.transform);
							go.transform.GetChild(0).tag = "empty_plate";
							GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().plates = null;
							GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().food_plates = null;
							GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().Setup_Tile();
							//add sprite of food
							//delete 1h
							go.GetComponentInChildren<SpriteRenderer>().sprite = go.GetComponentInChildren<go_emptyDish>().emptyDish.GetComponent<SpriteRenderer>().sprite;

						}
					}
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


				//When 1H = empty and 2H has food.
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
