using UnityEngine;
using System.Collections;

public class Chef : MonoBehaviour {
	public string one_h;
	public string two_h;
	public GameObject temp_plate;
	//public GameObject Player;
	GameObject go_1h;
	GameObject go_2h;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "cookingObject") {
			//Debug.Log(gameObject.tag);
			if (other.gameObject.GetComponent<cookingObject> ().canCook (one_h, two_h)) {
				other.gameObject.GetComponent<cookingObject> ().chef_1h = one_h;
				other.gameObject.GetComponent<cookingObject> ().chef_2h = two_h;
				Destroy (go_1h);
				Destroy (go_2h);
				one_h = "";
				two_h = "";
			}
		} else if (other.gameObject.tag == "ingredientObject") {
			Debug.Log(other.gameObject.tag);
			if (one_h == "") {
				Debug.Log("test");
				one_h = other.gameObject.GetComponent<ingredientObject> ().ingredient;
				//create go_1h
				//go_1h = temp_plate;
				go_1h = Instantiate (temp_plate, new Vector3 (0, 2, 0), transform.rotation) as GameObject;
				go_1h.transform.SetParent (gameObject.transform);
			} else if (two_h == "") {
				two_h = other.gameObject.GetComponent<ingredientObject> ().ingredient;
				//create go_2h
				//go_2h = temp_plate;
				go_2h = Instantiate (temp_plate, new Vector3 (1, 2, 0), transform.rotation) as GameObject;
				go_2h.transform.SetParent (gameObject.transform);
				
			}
		} 
		else {
			//Debug.Log("hello test");
			//Debug.Log(gameObject.tag);

		}

	}
}
