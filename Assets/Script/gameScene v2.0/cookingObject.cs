using UnityEngine;
using System.Collections;

public class cookingObject : MonoBehaviour {
	//public string name;
	public string food_cooking_name;

	public Recipie recipie1;
	public Recipie recipie2;

	public bool start_cooking = false;
	public bool food_ready = false;
	public bool cookReady = false;
	public bool needsFurnace;
	public bool isCooking;

	public string chef_1h;
	public string chef_2h;

	public Color c;

	private GameObject foodSprite;
    public GameObject cookingSpriteIdle;
    private GameObject _cookingSpriteIdle;
    public GameObject cookingSprite;
    private GameObject _cookingSprite;
	//public int x;
	//public int y;

	public Recipie current_recipie;
	//private ArrayList tempingredients;
	//private float Timer;
	// Use this for initialization
	void Start () {
		if (recipie1)
		recipie1 = Instantiate (recipie1);
		if (recipie2)
		recipie2 = Instantiate (recipie2);
		//if (needsFurnace) {

	}
	
	// Update is called once per frame
	void Update () {
		if (needsFurnace) {
			bool furnaceOn = GameObject.Find ("furnace").GetComponent<Furnace> ().isOn;
            this.GetComponent<Animator>().SetBool("furnaceOn", furnaceOn);
            if (!string.IsNullOrEmpty(chef_1h) && !_cookingSpriteIdle && !isCooking)
            {
                _cookingSpriteIdle = Instantiate(cookingSpriteIdle, transform.position, transform.rotation) as GameObject;
            }
            if (!isCooking && !food_ready && furnaceOn) {
                isCooking = true;
                cooking (chef_1h);
                
			}
		} else {
			if (!isCooking && !food_ready) {
                isCooking = true;
                cooking (chef_1h);
			}
			//this.GetComponent<SpriteRenderer> ().color = c;

		}
		if (!food_ready && foodSprite) {
			Destroy (foodSprite);
		}
	}

	void cookFood()
	{
		//this.GetComponent<SpriteRenderer> ().color = Color.red;
		this.GetComponent<Animator> ().SetBool ("on", true);
		//this.GetComponent<stopWatchObject> ().startTime = delay;
		//this.GetComponent<stopWatchObject> ().not_cooking = false;
		//this.GetComponent<SpriteRenderer> ().color = c;
		Debug.Log ("food done!");
		Debug.Log ("food name = " + food_cooking_name);
		this.GetComponent<Animator> ().SetBool ("on", false);
        isCooking = false;
        food_ready = true;
        //update sprite;
        foodSprite = Instantiate(current_recipie.finishedDish, transform.position, transform.rotation) as GameObject;
        Destroy(_cookingSprite);
    }
	
	void cooking (string i1) {
		//checks a list of recipies and sees what you can cook. 
		//if there is something,  remove the ingredients from the cook, 
		//and saves the name of the food thats cooking. save the 
		//current time, and then wait how long it takes to make the food.
		if (canCook(i1))
		{
			current_recipie = checkRecipies (i1);
			food_cooking_name = current_recipie.name;
            //Debug.Log (current_recipie.timeToMake);
            Destroy(_cookingSpriteIdle);
            _cookingSprite = Instantiate(cookingSprite, transform.position, transform.rotation) as GameObject;
            chef_1h = "";
            Invoke("cookFood", current_recipie.timeToMake); //wait for food to be done...
			//Debug.Log ("food done!");
			//food is done! animation here.
			//food_ready = true;

		}
		else
		{
			//can't cook anything!
		}



	}

	public bool canCook(string i1) {
		//Debug.Log (i1);
		//Debug.Log ("recipie 1 contains i1: " + recipie1.ingredient == i1);
        if (isCooking)
        {
            return false;
        }
		//Debug.Log (recipie1.ingredients.Count );
		if (i1 == "") {
			return false;
		}
		//ArrayList tempingredients = new ArrayList(recipie1.ingredients);
		//Debug.Log (recipie1.ingredients.Count);
		if (recipie1.ingredient == i1) {

			return true;
		} 
		if (recipie2.ingredient == i1) {
			
			return true;
		} 
			return false;

	}

	Recipie checkRecipies(string i1) {
		//Debug.Log ("this is i1; " + i1 );
		if (recipie1.ingredient == i1) {
			return recipie1;
		} 
		else
			return recipie2;


	}

}
