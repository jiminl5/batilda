using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {
	bool hasFood = false;
	bool waitingOnFood = false;
	public string foodWaitingOn = "none";
	Recipie current_food;
	public string food_given;
	GameObject foodSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (hasFood);
		//Debug.Log (waitingOnFood);
		if (!hasFood) {
			if (!waitingOnFood) {
				StartCoroutine(ExecuteAfterDelay(Random.Range (0,5)));
				//current_food = randomRecipe();
				//foodWaitingOn = current_food.name;
				//Debug.Log ("waiting on: " + foodWaitingOn);
				waitingOnFood = true;
			} else if (food_given == foodWaitingOn) {
				waitingOnFood = false;
				foodWaitingOn = "none";
				food_given = "";
				//given correct food!
				Debug.Log ("yum!");
				Destroy (foodSprite);
			} else if (food_given != foodWaitingOn && !string.IsNullOrEmpty(food_given)) {
				Debug.Log ("this isn't my order!");
				food_given = "";
			}
		}
	}

	IEnumerator ExecuteAfterDelay(float delay)
	{
		Debug.Log (delay);
		yield return new WaitForSeconds(delay);
		current_food = randomRecipe();
		foodWaitingOn = current_food.name;
		Debug.Log ("waiting on: " + foodWaitingOn);
		foodSprite = Instantiate (current_food.go, transform.position + Vector3.up / 2, transform.rotation) as GameObject;
		waitingOnFood = true;
		//food_ready = true;
		//update sprite;
	}

	Recipie randomRecipe() {
		GameObject[] food_list = GameObject.FindGameObjectsWithTag ("food");
		Debug.Log (food_list [Random.Range (0, food_list.Length)].GetComponent<Recipie> ());
		return food_list[Random.Range(0, food_list.Length)].GetComponent<Recipie>();
	}
}
