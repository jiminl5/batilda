using UnityEngine;
using System.Collections;

public class cookingObject : MonoBehaviour {
	public string name;
	public string food_cooking_name;

	public Recipie recipie1;
	public Recipie recipie2;

	public bool start_cooking = false;
	public bool food_ready = false;
	public bool cookReady = false;

	public string chef_1h;
	public string chef_2h;

	private Recipie current_recipie;
	//private float Timer;
	// Use this for initialization
	void Start () {
		recipie1 = Instantiate (recipie1);
		recipie2 = Instantiate (recipie2);
	}
	
	// Update is called once per frame
	void Update () {
		if (cookReady) {
			cooking (chef_1h, chef_2h);
			cookReady = false;
		}
	}

	IEnumerator ExecuteAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
	}
	
	void cooking (string i1, string i2) {
		//checks a list of recipies and sees what you can cook. 
		//if there is something,  remove the ingredients from the cook, 
		//and saves the name of the food thats cooking. save the 
		//current time, and then wait how long it takes to make the food.
			if (canCook(i1, i2))
			{
				current_recipie = checkRecipies (i1, i2);
				food_cooking_name = current_recipie.name;
				Debug.Log (current_recipie.timeToMake);
				ExecuteAfterDelay(current_recipie.timeToMake); //wait for food to be done...
				Debug.Log ("food done!");
				//food is done! animation here.
				food_ready = true;

			}
			else
			{
				//can't cook anything!
			}



	}

	public bool canCook(string i1, string i2) {
		//Debug.Log (i1);
		//Debug.Log (recipie1.ingredients.Contains (i1));
		//Debug.Log (i2);
		//Debug.Log (recipie1.ingredients.Contains (i2));
		//Debug.Log (recipie1.ingredients.Count );
		if (i1 == "" && i2 == "") {
			return false;
		}
		if (recipie1.ingredients.Contains (i1) && recipie1.ingredients.Contains (i2)) {
			return true;
		} 
		else if (recipie2.ingredients.Contains (i1) && recipie2.ingredients.Contains (i2)) {
			return true;
		} 
		else
			return false;
	}

	Recipie checkRecipies(string i1, string i2) {
		if (recipie1.ingredients.Contains (i1) && recipie1.ingredients.Contains (i2)) {
			return recipie1;
		} 
		else
			return recipie2;
	}

}
