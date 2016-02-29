using UnityEngine;
using System.Collections;

public class cookingObject : MonoBehaviour {
	//public string name;
	public string food_cooking_name;

	public Recipie recipie1;
	public Recipie recipie2;

	public AudioSource source;
	public AudioClip bubblingSFX;
	public AudioClip grillSizzleSFX;

	public bool start_cooking = false;
	public bool food_ready = false;
	public bool cookReady = false;
	public bool needsFurnace;
	public bool isCooking;

	public string chef_1h;
	public string chef_2h;

	public Color c;

	public float start_time;
	public float finish_time;
	public float time_to_cook;
	public bool timeSaved = false;
	
	private GameObject foodSprite;
    public GameObject cookingSpriteIdle;
    private GameObject _cookingSpriteIdle;
    public GameObject cookingSprite;
    private GameObject _cookingSprite;
	//public int x;
	//public int y;
	public Recipie current_recipie;
    recipeRepository rr;
    //private ArrayList tempingredients;
    //private float Timer;
    // Use this for initialization
    void Awake ()
    {
        this.gameObject.AddComponent<recipeRepository>();
        recipeRepository rr = GetComponent<recipeRepository>();
        rr.cookingObjectName = this.name.Split(' ')[0];
    }


	void Start () {
        Debug.Log(GetComponent<recipeRepository>().cookingObjectName);
        foreach (Recipie a in GetComponent<recipeRepository>().recipes)
        {
            Debug.Log(a.name);
        }
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
                //isCooking = true;
				start_time = Time.time;
                cooking (chef_1h);
                
			}
			if (!furnaceOn && timeSaved) 
			{
				timeSaved = false;
				time_to_cook -= Time.time; //time to cook - currnet time = new time to cook.
			}
			if (isCooking && furnaceOn && !timeSaved) 
			{
				//furnace is off, save time to cook.
				timeSaved = true;
				time_to_cook += Time.time; //add Time.time, to get new end time when furnace starts up again.
				start_time = Time.time;
				Debug.Log ("TIME TO COOK: " + time_to_cook);
				Debug.Log ("TIME: " + Time.time);
			}
			else if (isCooking && furnaceOn) {
				//timeSaved = false;
				if (Time.time >= time_to_cook) {
					cookFood (); //food is finished
				} else {
					//do nothing, wait for food to cook.
				}
			} 

		} else {
			if (!isCooking && !food_ready) {
                //isCooking = true;
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
			current_recipie = findRecipe (i1);
			food_cooking_name = current_recipie.name;
			if(food_cooking_name == "fish stew" || food_cooking_name == "onion soup"){
				source.PlayOneShot(bubblingSFX, .8f);
			}
            // 0 - grills, 1 - ovens, 2 - cuttingboard, 3 - rolling and so on
			if(food_cooking_name == "grilled fish" || food_cooking_name == "grilledMeat"){
				if (this.name == "grill 1"){
					GameObject.Find("Main Camera").GetComponent<timerObject>().genTimerAtUpper(2, 4, current_recipie.timeToMake, 0);
				}
				if (this.name == "grill 2"){
                    GameObject.Find("Main Camera").GetComponent<timerObject>().genTimerAtUpper(3, 4, current_recipie.timeToMake, 0);
				}
				if (this.name == "grill 3"){
                    GameObject.Find("Main Camera").GetComponent<timerObject>().genTimerAtLower(2, 2.9f, current_recipie.timeToMake, 0);
				}
				if (this.name == "grill 4"){
                    GameObject.Find("Main Camera").GetComponent<timerObject>().genTimerAtLower(3, 2.9f, current_recipie.timeToMake, 0);
				}
				source.PlayOneShot(grillSizzleSFX, .6f);
			}
			if( food_cooking_name == "bread"){
			
				if(this.name == "oven 4"){
                    GameObject.Find("Main Camera").GetComponent<timerObject>().genTimerAtUpper(1, 7, current_recipie.timeToMake, 1);
				}
				if(this.name == "oven 3"){
                    GameObject.Find("Main Camera").GetComponent<timerObject>().genTimerAtUpper(2, 7, current_recipie.timeToMake, 1);
				}
				if(this.name == "oven 2"){
                    GameObject.Find("Main Camera").GetComponent<timerObject>().genTimerAtLower(1, 5.9f, current_recipie.timeToMake, 1);
				}
				if(this.name == "oven 1"){
                    GameObject.Find("Main Camera").GetComponent<timerObject>().genTimerAtLower(2, 5.9f, current_recipie.timeToMake, 1);
				}
			}
            //Debug.Log (current_recipie.timeToMake);
            Destroy(_cookingSpriteIdle);
            _cookingSprite = Instantiate(cookingSprite, transform.position, transform.rotation) as GameObject;
            chef_1h = "";
            isCooking = true;
			time_to_cook = current_recipie.timeToMake + Time.time;
			start_time = Time.time;
			timeSaved = true;
            //Invoke("cookFood", current_recipie.timeToMake); //wait for food to be done...
			//Debug.Log ("food done!");
			//food is done! animation here.
			//food_ready = true;

		}
		else
		{
			//can't cook anything!
		}



	}


    public bool canCook(string ingredient)
    {
        foreach (Recipie recipe in GetComponent<recipeRepository>().recipes)
        {
            if (recipe.ingredient == ingredient)
            {
                return true;
            }
        }
        return false;
    }


    Recipie findRecipe(string ingredient)
    {
        foreach (Recipie recipe in GetComponent<recipeRepository>().recipes)
        {
            if (recipe.GetComponent<Recipie>().ingredient == ingredient)
            {
                return recipe.GetComponent<Recipie>();
            }
        }
        return null;
    }


}
