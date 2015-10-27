using UnityEngine;
using System.Collections;

public class Recipie : MonoBehaviour {
	public string name;
	public int timeToMake;
	//public int numberOfIngredients = 2;
	public string ingredient1 = "";
	public string ingredient2 = "";

	public ArrayList ingredients = new ArrayList();
	// Use this for initialization
	void Awake () {
		ingredients.Add (ingredient1);
		ingredients.Add (ingredient2);
		//name += " food";
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
